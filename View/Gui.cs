using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DataAccessLayer;
using WatchCommunication;

public partial class Gui: Form
{
    private IRepository repository;
    private IAccessPoint accessPoint;
    private IWatchPool watchPool;
    private List<ListBox> studentListBoxes;

    public Gui(IRepository repository, IAccessPoint accessPoint, IWatchPool watchPool) {
        this.repository = repository;
        this.watchPool = watchPool;
        this.accessPoint = accessPoint;

        watchPool = new WatchPool();
        studentListBoxes = new List<ListBox>();
        InitializeComponent();
    }

    private void Gui_Load(object sender, EventArgs e) {
        studentListBoxes.Add(deleteStudentsListBox);
        studentListBoxes.Add(addedStudentsListBox);
        RefreshStudentListBoxes();

        RefreshAvailableStudentsListBox();
        RefreshAvailableWatchesListBox();

        accessPoint.OnPacketRecieved += new Action<uint>(accessPoint_OnPacketRecieved);
        accessPoint.OnLostConnection += new Action(accessPoint_OnLostConnection);

        connect();
    }

    private void connect() {
        try {
            accessPoint.Open();
        }
        catch {
            new CouldNotConnectError(accessPoint).ShowDialog();
        }
        refreshConnectionDependentComponents();
    }

    private void accessPoint_OnLostConnection() {
        accessPoint.Close();
        DisableThisForm();
        var dialog = new CouldNotConnectError(accessPoint);
        dialog.FormClosed += (x, y) => EnableThisForm();
        dialog.ShowDialog();
        refreshConnectionDependentComponents();
    }

    private void EnableThisForm() {
        this.Invoke(new Action(() => this.Enabled = true));
    }

    private void DisableThisForm() {
        this.Invoke(new Action(() => this.Enabled = false));
    }

    private void accessPoint_OnPacketRecieved(uint packet) {
        if (watchPool.HasWatchWithIdentifier(packet)) {
            var watch = watchPool.WatchWithIdentifier(packet);
            try {
                if (watch.IsPaired()) {
                    watch.RecordBehavior(new Behavior());
                    repository.Commit();
                }
            }
            catch {
                repository.Rollback();
                UnknownFailureMessageBox();
            }
        }
        else {
            watchPool.AddWatch(new Watch { PacketIdentifier = packet });
            RefreshAvailableWatchesListBox();
        }
        this.Invoke(new Action(() => { updateLabel.Text = DateTime.Now.ToString(); }));
    }

    #region refresh methods

    private void RefreshStudentListBoxes() {
        var students = repository.AllStudents().ToList();
        foreach (var s in studentListBoxes) {
            s.DataSource = students;
            s.Refresh();
        }
    }

    private void refreshConnectionDependentComponents() {
        Action connected = () => {
            isConnectedLabel.Visible = true;
            isNotConnectedLabel.Visible = false;
            connectButton.Visible = false;
        };
        Action notConnected = () => {
            isConnectedLabel.Visible = false;
            isNotConnectedLabel.Visible = true;
            connectButton.Visible = true;
        };

        if (accessPoint.IsConnected())
            this.Invoke(connected);
        else
            this.Invoke(notConnected);
    }

    private void RefreshAvailableWatchesListBox() {
        this.Invoke(new Action(() => {
            availableWatchesListBox.DataSource = watchPool.AvailableWatches();
            availableWatchesListBox.Refresh();
        }));
    }

    private void RefreshAvailableStudentsListBox() {
        this.Invoke(new Action(() => {
            availableStudentsListBox.DataSource = repository
                .AllStudents()
                .Except(watchPool.StudentsWithWatches())
                .ToList();
            availableStudentsListBox.Refresh();
        }));
    }

    private void RefreshPairedStudentsListBox() {
        this.Invoke(new Action(() => {
            pairedStudentsListBox.DataSource = watchPool.StudentsWithWatches();
            availableStudentsListBox.Refresh();
        }));
    }

    #endregion refresh methods

    private static void UnknownFailureMessageBox() {
        MessageBox.Show(
            "An unknown error occured. Try closing Metamorphosis and reopening.",
            "Failure",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }

    #region event handlers

    private void addStudentButton_Click(object sender, EventArgs e) {
        try {
            var student = new Student(
                firstNameTextBox.Text,
                lastNameTextBox.Text,
                teacherTextBox.Text,
                behaviorTextBox.Text,
                new List<Behavior>()
            );
            repository.AddStudent(student);
            repository.Commit();
            MessageBox.Show("Student succesfully added.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (ArgumentException ex) {
            repository.Rollback();
            MessageBox.Show(
                ex.Message,
                "Failure",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch {
            repository.Rollback();
            UnknownFailureMessageBox();
        }
        firstNameTextBox.Clear();
        lastNameTextBox.Clear();
        teacherTextBox.Clear();
        behaviorTextBox.Clear();
        RefreshStudentListBoxes();
        RefreshAvailableStudentsListBox();
    }


    private void deleteButton_Click(object sender, EventArgs e) {
        var result = MessageBox.Show(
                "Are you sure you want to delete the selected students?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
        if (result == DialogResult.Yes) {
            IList<Student> selected = deleteStudentsListBox.SelectedItems.Cast<Student>().ToList();
            try {
                repository.DeleteStudents(selected);
                repository.Commit();
                MessageBox.Show(
                "Students succesfully deleted.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch {
                repository.Rollback();
                UnknownFailureMessageBox();
            }
        }
        RefreshStudentListBoxes();
        RefreshAvailableStudentsListBox();
    }

    private void connectButton_Click(object sender, EventArgs e) {
        connect();
    }

    #endregion

    private void pairButton_Click(object sender, EventArgs e) {
        var selectedStudent = (Student)availableStudentsListBox.SelectedItem;
        var selectedWatch = (Watch)availableWatchesListBox.SelectedItem;
        if (selectedWatch != null && selectedStudent != null) {
            selectedWatch.PairWith(selectedStudent);
            RefreshAvailableWatchesListBox();
            RefreshAvailableStudentsListBox();
            RefreshPairedStudentsListBox();
        }

    }

    private void unpairButton_Click(object sender, EventArgs e) {
        var selectedStudent = (Student)pairedStudentsListBox.SelectedItem;
        if (selectedStudent != null) {
            watchPool.WatchPairedWith(selectedStudent).Unpair();
            RefreshAvailableWatchesListBox();
            RefreshAvailableStudentsListBox();
            RefreshPairedStudentsListBox();
        }
    }
}