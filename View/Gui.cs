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
    private List<Student> students;
    private IRepository repository;
    private IAccessPoint accessPoint;
    private WatchPool watchPool;

    public Gui(IRepository repository, IAccessPoint accessPoint) {
        this.repository = repository;
        this.accessPoint = accessPoint;
        watchPool = new WatchPool();
        InitializeComponent();
    }

    private void Gui_Load(object sender, EventArgs e) {
        students = repository.All().ToList();
        deleteStudentsListBox.DataSource = students;
        accessPoint.OnPacketRecieved += new Action<uint>(accessPoint_OnPacketRecieved);
        accessPoint.OnLostConnection += () => {
            accessPoint.Close();
            new View.CouldNotConnectError(accessPoint).ShowDialog();
        };
        try {
            accessPoint.Open();
        }
        catch {
            new View.CouldNotConnectError(accessPoint).ShowDialog();
        }
    }

    private void accessPoint_OnPacketRecieved(uint packet) {
        if (watchPool.HasWatchWithIdentifier(packet)) {
            var watch = watchPool.WithIdentifier(packet);
            try {
                var behavior = new Behavior();
                watch.Student.Behaviors.Add(behavior);
                repository.Commit();
            }
            catch {
                repository.Rollback();
                UnknownFailureMessageBox();
            }
        }
        else {
        }
        updateLabel.Invoke(new Action(() => updateLabel.Text = DateTime.Now.ToString()));
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
            repository.Add(student);
            repository.Commit();
            students = repository.All().ToList();
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
                MessageBoxIcon.Error
            );
        }
        catch {
            repository.Rollback();
            UnknownFailureMessageBox();
        }
    }


    private void deleteButton_Click(object sender, EventArgs e) {
        IList<Student> selected = deleteStudentsListBox.SelectedItems.Cast<Student>().ToList();
        try {
            foreach (var s in selected)
                repository.Delete(s);
            repository.Commit();
            MessageBox.Show("Students succesfully deleted.",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
        catch {
            repository.Rollback();
            UnknownFailureMessageBox();
        }

    }
    #endregion

    private static void UnknownFailureMessageBox() {
        MessageBox.Show(
            "An unknown error occured. Try closing Metamorphosis and reopening.",
            "Failure",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }
}