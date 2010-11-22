partial class Gui
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
        this.mainTabControl = new System.Windows.Forms.TabControl();
        this.connectTabPage = new System.Windows.Forms.TabPage();
        this.connectButton = new System.Windows.Forms.Button();
        this.updateLabel = new System.Windows.Forms.Label();
        this.isNotConnectedLabel = new System.Windows.Forms.Label();
        this.isConnectedLabel = new System.Windows.Forms.Label();
        this.watchesTab = new System.Windows.Forms.TabPage();
        this.label8 = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.unpairButton = new System.Windows.Forms.Button();
        this.pairedStudentsListBox = new System.Windows.Forms.ListBox();
        this.pairButton = new System.Windows.Forms.Button();
        this.availableWatchesListBox = new System.Windows.Forms.ListBox();
        this.availableStudentsListBox = new System.Windows.Forms.ListBox();
        this.addNewStudentTab = new System.Windows.Forms.TabPage();
        this.addedStudentsListBox = new System.Windows.Forms.ListBox();
        this.addStudentButton = new System.Windows.Forms.Button();
        this.label4 = new System.Windows.Forms.Label();
        this.behaviorTextBox = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.teacherTextBox = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.lastNameTextBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.firstNameTextBox = new System.Windows.Forms.TextBox();
        this.deleteStudentTab = new System.Windows.Forms.TabPage();
        this.deleteButton = new System.Windows.Forms.Button();
        this.deleteStudentsListBox = new System.Windows.Forms.ListBox();
        this.exportToExcelTab = new System.Windows.Forms.TabPage();
        this.exportExcelButton = new System.Windows.Forms.Button();
        this.exportStudentsListBox = new System.Windows.Forms.ListBox();
        this.mainTabControl.SuspendLayout();
        this.connectTabPage.SuspendLayout();
        this.watchesTab.SuspendLayout();
        this.addNewStudentTab.SuspendLayout();
        this.deleteStudentTab.SuspendLayout();
        this.exportToExcelTab.SuspendLayout();
        this.SuspendLayout();
        // 
        // mainTabControl
        // 
        this.mainTabControl.Controls.Add(this.connectTabPage);
        this.mainTabControl.Controls.Add(this.watchesTab);
        this.mainTabControl.Controls.Add(this.addNewStudentTab);
        this.mainTabControl.Controls.Add(this.deleteStudentTab);
        this.mainTabControl.Controls.Add(this.exportToExcelTab);
        this.mainTabControl.Location = new System.Drawing.Point(12, 12);
        this.mainTabControl.Name = "mainTabControl";
        this.mainTabControl.SelectedIndex = 0;
        this.mainTabControl.Size = new System.Drawing.Size(412, 298);
        this.mainTabControl.TabIndex = 0;
        // 
        // connectTabPage
        // 
        this.connectTabPage.Controls.Add(this.connectButton);
        this.connectTabPage.Controls.Add(this.updateLabel);
        this.connectTabPage.Controls.Add(this.isNotConnectedLabel);
        this.connectTabPage.Controls.Add(this.isConnectedLabel);
        this.connectTabPage.ForeColor = System.Drawing.Color.Green;
        this.connectTabPage.Location = new System.Drawing.Point(4, 22);
        this.connectTabPage.Name = "connectTabPage";
        this.connectTabPage.Padding = new System.Windows.Forms.Padding(3);
        this.connectTabPage.Size = new System.Drawing.Size(404, 272);
        this.connectTabPage.TabIndex = 0;
        this.connectTabPage.Text = "connect";
        this.connectTabPage.UseVisualStyleBackColor = true;
        // 
        // connectButton
        // 
        this.connectButton.ForeColor = System.Drawing.Color.Black;
        this.connectButton.Location = new System.Drawing.Point(160, 116);
        this.connectButton.Name = "connectButton";
        this.connectButton.Size = new System.Drawing.Size(75, 23);
        this.connectButton.TabIndex = 3;
        this.connectButton.Text = "connect";
        this.connectButton.UseVisualStyleBackColor = true;
        this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
        // 
        // updateLabel
        // 
        this.updateLabel.AutoSize = true;
        this.updateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
        this.updateLabel.Location = new System.Drawing.Point(8, 53);
        this.updateLabel.Name = "updateLabel";
        this.updateLabel.Size = new System.Drawing.Size(0, 13);
        this.updateLabel.TabIndex = 2;
        // 
        // isNotConnectedLabel
        // 
        this.isNotConnectedLabel.AutoSize = true;
        this.isNotConnectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.isNotConnectedLabel.ForeColor = System.Drawing.Color.Red;
        this.isNotConnectedLabel.Location = new System.Drawing.Point(18, 14);
        this.isNotConnectedLabel.Name = "isNotConnectedLabel";
        this.isNotConnectedLabel.Size = new System.Drawing.Size(360, 25);
        this.isNotConnectedLabel.TabIndex = 1;
        this.isNotConnectedLabel.Text = "The access point is NOT connected.";
        // 
        // isConnectedLabel
        // 
        this.isConnectedLabel.AutoSize = true;
        this.isConnectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.isConnectedLabel.Location = new System.Drawing.Point(18, 14);
        this.isConnectedLabel.Name = "isConnectedLabel";
        this.isConnectedLabel.Size = new System.Drawing.Size(310, 25);
        this.isConnectedLabel.TabIndex = 0;
        this.isConnectedLabel.Text = "The access point is connected.";
        // 
        // watchesTab
        // 
        this.watchesTab.Controls.Add(this.label8);
        this.watchesTab.Controls.Add(this.label7);
        this.watchesTab.Controls.Add(this.label6);
        this.watchesTab.Controls.Add(this.label5);
        this.watchesTab.Controls.Add(this.unpairButton);
        this.watchesTab.Controls.Add(this.pairedStudentsListBox);
        this.watchesTab.Controls.Add(this.pairButton);
        this.watchesTab.Controls.Add(this.availableWatchesListBox);
        this.watchesTab.Controls.Add(this.availableStudentsListBox);
        this.watchesTab.Location = new System.Drawing.Point(4, 22);
        this.watchesTab.Name = "watchesTab";
        this.watchesTab.Padding = new System.Windows.Forms.Padding(3);
        this.watchesTab.Size = new System.Drawing.Size(404, 272);
        this.watchesTab.TabIndex = 4;
        this.watchesTab.Text = "watches";
        this.watchesTab.UseVisualStyleBackColor = true;
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(6, 16);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(387, 13);
        this.label8.TabIndex = 8;
        this.label8.Text = "Directions: To add a watch to available watches, press any button on the watch.";
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(120, 160);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(144, 13);
        this.label7.TabIndex = 7;
        this.label7.Text = "students paired with watches";
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(31, 38);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(92, 13);
        this.label6.TabIndex = 6;
        this.label6.Text = "available students";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(271, 38);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(92, 13);
        this.label5.TabIndex = 5;
        this.label5.Text = "available watches";
        // 
        // unpairButton
        // 
        this.unpairButton.Location = new System.Drawing.Point(154, 238);
        this.unpairButton.Name = "unpairButton";
        this.unpairButton.Size = new System.Drawing.Size(75, 23);
        this.unpairButton.TabIndex = 4;
        this.unpairButton.Text = "unpair";
        this.unpairButton.UseVisualStyleBackColor = true;
        this.unpairButton.Click += new System.EventHandler(this.unpairButton_Click);
        // 
        // pairedStudentsListBox
        // 
        this.pairedStudentsListBox.FormattingEnabled = true;
        this.pairedStudentsListBox.Location = new System.Drawing.Point(134, 176);
        this.pairedStudentsListBox.Name = "pairedStudentsListBox";
        this.pairedStudentsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        this.pairedStudentsListBox.Size = new System.Drawing.Size(120, 56);
        this.pairedStudentsListBox.TabIndex = 3;
        // 
        // pairButton
        // 
        this.pairButton.Location = new System.Drawing.Point(154, 78);
        this.pairButton.Name = "pairButton";
        this.pairButton.Size = new System.Drawing.Size(75, 23);
        this.pairButton.TabIndex = 2;
        this.pairButton.Text = "pair";
        this.pairButton.UseVisualStyleBackColor = true;
        this.pairButton.Click += new System.EventHandler(this.pairButton_Click);
        // 
        // availableWatchesListBox
        // 
        this.availableWatchesListBox.FormattingEnabled = true;
        this.availableWatchesListBox.Location = new System.Drawing.Point(255, 54);
        this.availableWatchesListBox.Name = "availableWatchesListBox";
        this.availableWatchesListBox.Size = new System.Drawing.Size(120, 95);
        this.availableWatchesListBox.TabIndex = 1;
        // 
        // availableStudentsListBox
        // 
        this.availableStudentsListBox.FormattingEnabled = true;
        this.availableStudentsListBox.Location = new System.Drawing.Point(16, 54);
        this.availableStudentsListBox.Name = "availableStudentsListBox";
        this.availableStudentsListBox.Size = new System.Drawing.Size(120, 95);
        this.availableStudentsListBox.TabIndex = 0;
        // 
        // addNewStudentTab
        // 
        this.addNewStudentTab.Controls.Add(this.addedStudentsListBox);
        this.addNewStudentTab.Controls.Add(this.addStudentButton);
        this.addNewStudentTab.Controls.Add(this.label4);
        this.addNewStudentTab.Controls.Add(this.behaviorTextBox);
        this.addNewStudentTab.Controls.Add(this.label3);
        this.addNewStudentTab.Controls.Add(this.teacherTextBox);
        this.addNewStudentTab.Controls.Add(this.label2);
        this.addNewStudentTab.Controls.Add(this.lastNameTextBox);
        this.addNewStudentTab.Controls.Add(this.label1);
        this.addNewStudentTab.Controls.Add(this.firstNameTextBox);
        this.addNewStudentTab.Location = new System.Drawing.Point(4, 22);
        this.addNewStudentTab.Name = "addNewStudentTab";
        this.addNewStudentTab.Padding = new System.Windows.Forms.Padding(3);
        this.addNewStudentTab.Size = new System.Drawing.Size(404, 272);
        this.addNewStudentTab.TabIndex = 1;
        this.addNewStudentTab.Text = "add new student";
        this.addNewStudentTab.UseVisualStyleBackColor = true;
        // 
        // addedStudentsListBox
        // 
        this.addedStudentsListBox.FormattingEnabled = true;
        this.addedStudentsListBox.Location = new System.Drawing.Point(231, 38);
        this.addedStudentsListBox.Name = "addedStudentsListBox";
        this.addedStudentsListBox.Size = new System.Drawing.Size(137, 134);
        this.addedStudentsListBox.TabIndex = 9;
        // 
        // addStudentButton
        // 
        this.addStudentButton.Location = new System.Drawing.Point(96, 188);
        this.addStudentButton.Name = "addStudentButton";
        this.addStudentButton.Size = new System.Drawing.Size(75, 23);
        this.addStudentButton.TabIndex = 8;
        this.addStudentButton.Text = "add";
        this.addStudentButton.UseVisualStyleBackColor = true;
        this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(29, 152);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(51, 13);
        this.label4.TabIndex = 7;
        this.label4.Text = "behavior:";
        // 
        // behaviorTextBox
        // 
        this.behaviorTextBox.Location = new System.Drawing.Point(87, 149);
        this.behaviorTextBox.Name = "behaviorTextBox";
        this.behaviorTextBox.Size = new System.Drawing.Size(100, 20);
        this.behaviorTextBox.TabIndex = 6;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(29, 114);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 5;
        this.label3.Text = "teacher:";
        // 
        // teacherTextBox
        // 
        this.teacherTextBox.Location = new System.Drawing.Point(87, 111);
        this.teacherTextBox.Name = "teacherTextBox";
        this.teacherTextBox.Size = new System.Drawing.Size(100, 20);
        this.teacherTextBox.TabIndex = 4;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(29, 77);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(55, 13);
        this.label2.TabIndex = 3;
        this.label2.Text = "last name:";
        // 
        // lastNameTextBox
        // 
        this.lastNameTextBox.Location = new System.Drawing.Point(87, 74);
        this.lastNameTextBox.Name = "lastNameTextBox";
        this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
        this.lastNameTextBox.TabIndex = 2;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(29, 41);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(55, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "first name:";
        // 
        // firstNameTextBox
        // 
        this.firstNameTextBox.Location = new System.Drawing.Point(87, 38);
        this.firstNameTextBox.Name = "firstNameTextBox";
        this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
        this.firstNameTextBox.TabIndex = 0;
        // 
        // deleteStudentTab
        // 
        this.deleteStudentTab.Controls.Add(this.deleteButton);
        this.deleteStudentTab.Controls.Add(this.deleteStudentsListBox);
        this.deleteStudentTab.Location = new System.Drawing.Point(4, 22);
        this.deleteStudentTab.Name = "deleteStudentTab";
        this.deleteStudentTab.Padding = new System.Windows.Forms.Padding(3);
        this.deleteStudentTab.Size = new System.Drawing.Size(404, 272);
        this.deleteStudentTab.TabIndex = 3;
        this.deleteStudentTab.Text = "delete student";
        this.deleteStudentTab.UseVisualStyleBackColor = true;
        // 
        // deleteButton
        // 
        this.deleteButton.Location = new System.Drawing.Point(148, 192);
        this.deleteButton.Name = "deleteButton";
        this.deleteButton.Size = new System.Drawing.Size(75, 23);
        this.deleteButton.TabIndex = 1;
        this.deleteButton.Text = "delete";
        this.deleteButton.UseVisualStyleBackColor = true;
        this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
        // 
        // deleteStudentsListBox
        // 
        this.deleteStudentsListBox.FormattingEnabled = true;
        this.deleteStudentsListBox.Location = new System.Drawing.Point(127, 30);
        this.deleteStudentsListBox.Name = "deleteStudentsListBox";
        this.deleteStudentsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        this.deleteStudentsListBox.Size = new System.Drawing.Size(120, 147);
        this.deleteStudentsListBox.TabIndex = 0;
        // 
        // exportToExcelTab
        // 
        this.exportToExcelTab.Controls.Add(this.exportExcelButton);
        this.exportToExcelTab.Controls.Add(this.exportStudentsListBox);
        this.exportToExcelTab.Location = new System.Drawing.Point(4, 22);
        this.exportToExcelTab.Name = "exportToExcelTab";
        this.exportToExcelTab.Size = new System.Drawing.Size(404, 272);
        this.exportToExcelTab.TabIndex = 2;
        this.exportToExcelTab.Text = "export to excel";
        this.exportToExcelTab.UseVisualStyleBackColor = true;
        // 
        // exportExcelButton
        // 
        this.exportExcelButton.Location = new System.Drawing.Point(195, 98);
        this.exportExcelButton.Name = "exportExcelButton";
        this.exportExcelButton.Size = new System.Drawing.Size(108, 23);
        this.exportExcelButton.TabIndex = 1;
        this.exportExcelButton.Text = "Export to Excel";
        this.exportExcelButton.UseVisualStyleBackColor = true;
        this.exportExcelButton.Click += new System.EventHandler(this.exportExcelButton_Click);
        // 
        // exportStudentsListBox
        // 
        this.exportStudentsListBox.FormattingEnabled = true;
        this.exportStudentsListBox.Location = new System.Drawing.Point(20, 20);
        this.exportStudentsListBox.Name = "exportStudentsListBox";
        this.exportStudentsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        this.exportStudentsListBox.Size = new System.Drawing.Size(116, 186);
        this.exportStudentsListBox.TabIndex = 0;
        // 
        // Gui
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(436, 322);
        this.Controls.Add(this.mainTabControl);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.Name = "Gui";
        this.Text = "Metamorphosis";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Gui_FormClosed);
        this.Load += new System.EventHandler(this.Gui_Load);
        this.mainTabControl.ResumeLayout(false);
        this.connectTabPage.ResumeLayout(false);
        this.connectTabPage.PerformLayout();
        this.watchesTab.ResumeLayout(false);
        this.watchesTab.PerformLayout();
        this.addNewStudentTab.ResumeLayout(false);
        this.addNewStudentTab.PerformLayout();
        this.deleteStudentTab.ResumeLayout(false);
        this.exportToExcelTab.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl mainTabControl;
    private System.Windows.Forms.TabPage connectTabPage;
    private System.Windows.Forms.TabPage addNewStudentTab;
    private System.Windows.Forms.Button addStudentButton;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox behaviorTextBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox teacherTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox lastNameTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox firstNameTextBox;
    private System.Windows.Forms.TabPage exportToExcelTab;
    private System.Windows.Forms.Label isNotConnectedLabel;
    private System.Windows.Forms.Label isConnectedLabel;
    private System.Windows.Forms.TabPage deleteStudentTab;
    private System.Windows.Forms.Button deleteButton;
    private System.Windows.Forms.ListBox deleteStudentsListBox;
    private System.Windows.Forms.Label updateLabel;
    private System.Windows.Forms.Button connectButton;
    private System.Windows.Forms.TabPage watchesTab;
    private System.Windows.Forms.Button unpairButton;
    private System.Windows.Forms.ListBox pairedStudentsListBox;
    private System.Windows.Forms.Button pairButton;
    private System.Windows.Forms.ListBox availableWatchesListBox;
    private System.Windows.Forms.ListBox availableStudentsListBox;
    private System.Windows.Forms.ListBox addedStudentsListBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ListBox exportStudentsListBox;
    private System.Windows.Forms.Button exportExcelButton;
    private System.Windows.Forms.Label label8;

}