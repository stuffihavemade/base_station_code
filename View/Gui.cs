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
    private IWatchDataSaver watchDataSaver;
    private List<ListBox> studentListBoxes;

    public Gui(IRepository repository,
               IAccessPoint accessPoint, 
               IWatchPool watchPool,
               IWatchDataSaver watchDataSaver) {
        this.repository = repository;
        this.watchDataSaver = watchDataSaver;
        this.watchPool = watchPool;
        this.accessPoint = accessPoint;

        InitializeComponent();
    }

    private void Gui_Load(object sender, EventArgs e) {
        accessPoint.OnPacketRecieved += watchDataSaver.SavePacket;
        accessPoint.OnLostConnection += accessPoint_OnLostConnection;

        watchDataSaver.OnFailureToSave += UnknownFailureMessageBox;
        watchDataSaver.IfNoMatchingWatch += (p) => {
            watchPool.AddWatch(new Watch { PacketIdentifier = p });
            RefreshAvailableWatchesListBox();
        };

        studentListBoxes = new List<ListBox>();
        studentListBoxes.Add(deleteStudentsListBox);
        studentListBoxes.Add(addedStudentsListBox);
        studentListBoxes.Add(exportStudentsListBox);

        RefreshStudentListBoxes();
        RefreshAvailableStudentsListBox();
        RefreshExportStudentListBox();

        Connect();
    }

    private void Gui_FormClosed(object sender, FormClosedEventArgs e) {
        //This is necessary to prevent an exception if the user
        //pulls out the AP while closing the program.
        accessPoint.Close();
    }

    private void Connect() {
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

    private static void UnknownFailureMessageBox() {
        MessageBox.Show(
            "An unknown error occured. Try closing Metamorphosis and reopening.",
            "Failure",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
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

    private void RefreshExportStudentListBox()
    {
        this.Invoke(new Action(() =>
        {
            exportStudentsListBox.DataSource = repository
                .AllStudents()
                .Except(watchPool.StudentsWithWatches())
                .ToList();
            exportStudentsListBox.Refresh();
        }));
    }

    private void RefreshPairedStudentsListBox() {
        this.Invoke(new Action(() => {
            pairedStudentsListBox.DataSource = watchPool.StudentsWithWatches();
            availableStudentsListBox.Refresh();
        }));
    }

    #endregion refresh methods

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
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            teacherTextBox.Clear();
            behaviorTextBox.Clear();
            RefreshStudentListBoxes();
            RefreshAvailableStudentsListBox();
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

    }

    private void deleteButton_Click(object sender, EventArgs e) {
        var result = MessageBox.Show(
                "Are you sure you want to delete the selected students?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
        if (result == DialogResult.Yes) {
            var selected = deleteStudentsListBox.SelectedItems.Cast<Student>().ToList();
            try {
                repository.DeleteStudents(selected);
                repository.Commit();
                watchPool.UnpairWatchesWithStudents(selected);
                MessageBox.Show(
                "Students succesfully deleted.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                RefreshStudentListBoxes();
                RefreshAvailableStudentsListBox();
                RefreshPairedStudentsListBox();
                RefreshAvailableWatchesListBox();
            }
            catch {
                repository.Rollback();
                UnknownFailureMessageBox();
            }
        }
    }

    private void connectButton_Click(object sender, EventArgs e) {
        Connect();
    }

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
            watchPool.UnpairWatchWithStudent(selectedStudent);
            RefreshAvailableWatchesListBox();
            RefreshAvailableStudentsListBox();
            RefreshPairedStudentsListBox();
        }
    }

    #endregion

    private void exportExcelButton_Click(object sender, EventArgs e)
    {
        var selectedStudents = exportStudentsListBox.SelectedItems.Cast<Student>().ToList();
        if (selectedStudents != null)
        {
            foreach (var selectedStudent in selectedStudents)
            {
                if (selectedStudent != null)
                {
                    try
                    {
                        new GemBoxExcel.Excel(selectedStudent).Create();
                        MessageBox.Show(
                        "Excel spreadsheet created.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show(
                        "Could not create spreadsheet! Ensure that " + selectedStudent.FirstName +
                        "'s Excel file is not already open.",
                        "Failure",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}