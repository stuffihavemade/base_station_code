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
        this.mainTabControl = new System.Windows.Forms.TabControl();
        this.connectTabPage = new System.Windows.Forms.TabPage();
        this.isNotConnectedLabel = new System.Windows.Forms.Label();
        this.isConnectedLabel = new System.Windows.Forms.Label();
        this.addNewStudentTab = new System.Windows.Forms.TabPage();
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
        this.updateLabel = new System.Windows.Forms.Label();
        this.mainTabControl.SuspendLayout();
        this.connectTabPage.SuspendLayout();
        this.addNewStudentTab.SuspendLayout();
        this.deleteStudentTab.SuspendLayout();
        this.SuspendLayout();
        // 
        // mainTabControl
        // 
        this.mainTabControl.Controls.Add(this.connectTabPage);
        this.mainTabControl.Controls.Add(this.addNewStudentTab);
        this.mainTabControl.Controls.Add(this.deleteStudentTab);
        this.mainTabControl.Controls.Add(this.exportToExcelTab);
        this.mainTabControl.Location = new System.Drawing.Point(12, 12);
        this.mainTabControl.Name = "mainTabControl";
        this.mainTabControl.SelectedIndex = 0;
        this.mainTabControl.Size = new System.Drawing.Size(377, 249);
        this.mainTabControl.TabIndex = 0;
        // 
        // connectTabPage
        // 
        this.connectTabPage.Controls.Add(this.updateLabel);
        this.connectTabPage.Controls.Add(this.isNotConnectedLabel);
        this.connectTabPage.Controls.Add(this.isConnectedLabel);
        this.connectTabPage.ForeColor = System.Drawing.Color.Green;
        this.connectTabPage.Location = new System.Drawing.Point(4, 22);
        this.connectTabPage.Name = "connectTabPage";
        this.connectTabPage.Padding = new System.Windows.Forms.Padding(3);
        this.connectTabPage.Size = new System.Drawing.Size(369, 223);
        this.connectTabPage.TabIndex = 0;
        this.connectTabPage.Text = "connect";
        this.connectTabPage.UseVisualStyleBackColor = true;
        // 
        // isNotConnectedLabel
        // 
        this.isNotConnectedLabel.AutoSize = true;
        this.isNotConnectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.isNotConnectedLabel.ForeColor = System.Drawing.Color.Red;
        this.isNotConnectedLabel.Location = new System.Drawing.Point(6, 13);
        this.isNotConnectedLabel.Name = "isNotConnectedLabel";
        this.isNotConnectedLabel.Size = new System.Drawing.Size(360, 25);
        this.isNotConnectedLabel.TabIndex = 1;
        this.isNotConnectedLabel.Text = "The access point is NOT connected.";
        // 
        // isConnectedLabel
        // 
        this.isConnectedLabel.AutoSize = true;
        this.isConnectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.isConnectedLabel.Location = new System.Drawing.Point(6, 13);
        this.isConnectedLabel.Name = "isConnectedLabel";
        this.isConnectedLabel.Size = new System.Drawing.Size(310, 25);
        this.isConnectedLabel.TabIndex = 0;
        this.isConnectedLabel.Text = "The access point is connected.";
        // 
        // addNewStudentTab
        // 
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
        this.addNewStudentTab.Size = new System.Drawing.Size(369, 223);
        this.addNewStudentTab.TabIndex = 1;
        this.addNewStudentTab.Text = "add new student";
        this.addNewStudentTab.UseVisualStyleBackColor = true;
        // 
        // addStudentButton
        // 
        this.addStudentButton.Location = new System.Drawing.Point(87, 173);
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
        this.label4.Location = new System.Drawing.Point(29, 135);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(51, 13);
        this.label4.TabIndex = 7;
        this.label4.Text = "behavior:";
        // 
        // behaviorTextBox
        // 
        this.behaviorTextBox.Location = new System.Drawing.Point(87, 132);
        this.behaviorTextBox.Name = "behaviorTextBox";
        this.behaviorTextBox.Size = new System.Drawing.Size(100, 20);
        this.behaviorTextBox.TabIndex = 6;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(29, 97);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 5;
        this.label3.Text = "teacher:";
        // 
        // teacherTextBox
        // 
        this.teacherTextBox.Location = new System.Drawing.Point(87, 94);
        this.teacherTextBox.Name = "teacherTextBox";
        this.teacherTextBox.Size = new System.Drawing.Size(100, 20);
        this.teacherTextBox.TabIndex = 4;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(29, 60);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(55, 13);
        this.label2.TabIndex = 3;
        this.label2.Text = "last name:";
        // 
        // lastNameTextBox
        // 
        this.lastNameTextBox.Location = new System.Drawing.Point(87, 57);
        this.lastNameTextBox.Name = "lastNameTextBox";
        this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
        this.lastNameTextBox.TabIndex = 2;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(29, 24);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(55, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "first name:";
        // 
        // firstNameTextBox
        // 
        this.firstNameTextBox.Location = new System.Drawing.Point(87, 21);
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
        this.deleteStudentTab.Size = new System.Drawing.Size(369, 223);
        this.deleteStudentTab.TabIndex = 3;
        this.deleteStudentTab.Text = "delete student";
        this.deleteStudentTab.UseVisualStyleBackColor = true;
        // 
        // deleteButton
        // 
        this.deleteButton.Location = new System.Drawing.Point(47, 179);
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
        this.deleteStudentsListBox.Location = new System.Drawing.Point(26, 17);
        this.deleteStudentsListBox.Name = "deleteStudentsListBox";
        this.deleteStudentsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        this.deleteStudentsListBox.Size = new System.Drawing.Size(120, 147);
        this.deleteStudentsListBox.TabIndex = 0;
        // 
        // exportToExcelTab
        // 
        this.exportToExcelTab.Location = new System.Drawing.Point(4, 22);
        this.exportToExcelTab.Name = "exportToExcelTab";
        this.exportToExcelTab.Size = new System.Drawing.Size(369, 223);
        this.exportToExcelTab.TabIndex = 2;
        this.exportToExcelTab.Text = "export to excel";
        this.exportToExcelTab.UseVisualStyleBackColor = true;
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
        // Gui
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(406, 273);
        this.Controls.Add(this.mainTabControl);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "Gui";
        this.Text = "Metamorphosis";
        this.Load += new System.EventHandler(this.Gui_Load);
        this.mainTabControl.ResumeLayout(false);
        this.connectTabPage.ResumeLayout(false);
        this.connectTabPage.PerformLayout();
        this.addNewStudentTab.ResumeLayout(false);
        this.addNewStudentTab.PerformLayout();
        this.deleteStudentTab.ResumeLayout(false);
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

}