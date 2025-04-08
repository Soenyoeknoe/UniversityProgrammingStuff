namespace TextEditor
{
    partial class NewUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.theUsename = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.thePassword = new System.Windows.Forms.TextBox();
            this.pwdReEnter = new System.Windows.Forms.TextBox();
            this.theFname = new System.Windows.Forms.TextBox();
            this.theLname = new System.Windows.Forms.TextBox();
            this.theDOB = new System.Windows.Forms.DateTimePicker();
            this.theType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // theUsename
            // 
            this.theUsename.Location = new System.Drawing.Point(163, 87);
            this.theUsename.Name = "theUsename";
            this.theUsename.Size = new System.Drawing.Size(355, 23);
            this.theUsename.TabIndex = 0;
            this.theUsename.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Username.Location = new System.Drawing.Point(22, 90);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(62, 15);
            this.Username.TabIndex = 1;
            this.Username.Text = "Username";
            this.Username.Click += new System.EventHandler(this.Username_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Re-Enter Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(22, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "First Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(23, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date of Birth";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(23, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "User-Type";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(471, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // thePassword
            // 
            this.thePassword.Location = new System.Drawing.Point(163, 123);
            this.thePassword.Name = "thePassword";
            this.thePassword.PasswordChar = '*';
            this.thePassword.Size = new System.Drawing.Size(355, 23);
            this.thePassword.TabIndex = 10;
            // 
            // pwdReEnter
            // 
            this.pwdReEnter.Location = new System.Drawing.Point(163, 162);
            this.pwdReEnter.Name = "pwdReEnter";
            this.pwdReEnter.PasswordChar = '*';
            this.pwdReEnter.Size = new System.Drawing.Size(355, 23);
            this.pwdReEnter.TabIndex = 11;
            // 
            // theFname
            // 
            this.theFname.Location = new System.Drawing.Point(163, 203);
            this.theFname.Name = "theFname";
            this.theFname.Size = new System.Drawing.Size(355, 23);
            this.theFname.TabIndex = 12;
            // 
            // theLname
            // 
            this.theLname.Location = new System.Drawing.Point(163, 246);
            this.theLname.Name = "theLname";
            this.theLname.Size = new System.Drawing.Size(355, 23);
            this.theLname.TabIndex = 13;
            // 
            // theDOB
            // 
            this.theDOB.CustomFormat = "dd-MM-yyyy";
            this.theDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.theDOB.Location = new System.Drawing.Point(163, 288);
            this.theDOB.Name = "theDOB";
            this.theDOB.Size = new System.Drawing.Size(355, 23);
            this.theDOB.TabIndex = 14;
            // 
            // theType
            // 
            this.theType.FormattingEnabled = true;
            this.theType.Items.AddRange(new object[] {
            "View",
            "Edit"});
            this.theType.Location = new System.Drawing.Point(163, 334);
            this.theType.Name = "theType";
            this.theType.Size = new System.Drawing.Size(355, 23);
            this.theType.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(188, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 29);
            this.label7.TabIndex = 16;
            this.label7.Text = "Register Account";
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 451);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.theType);
            this.Controls.Add(this.theDOB);
            this.Controls.Add(this.theLname);
            this.Controls.Add(this.theFname);
            this.Controls.Add(this.pwdReEnter);
            this.Controls.Add(this.thePassword);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.theUsename);
            this.Name = "NewUser";
            this.Text = "RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewUser_FormClosing);
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox theUsename;
        private Label Username;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
        private TextBox thePassword;
        private TextBox pwdReEnter;
        private TextBox theFname;
        private TextBox theLname;
        private DateTimePicker theDOB;
        private ComboBox theType;
        private Label label7;
    }
}