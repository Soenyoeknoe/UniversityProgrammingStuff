namespace TextEditor
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.saveLink = new System.Windows.Forms.LinkLabel();
            this.copyLink = new System.Windows.Forms.LinkLabel();
            this.diffrenceLink = new System.Windows.Forms.LinkLabel();
            this.createLink = new System.Windows.Forms.LinkLabel();
            this.searchIcon1 = new System.Windows.Forms.PictureBox();
            this.searchIcon2 = new System.Windows.Forms.PictureBox();
            this.searchIcon3 = new System.Windows.Forms.PictureBox();
            this.searchIcon4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(66, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "We\'re here to help";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(66, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(623, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tell us your problem so we can get you the right help and support";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(66, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(505, 29);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = " Example: How to open a file";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "Return to Text Editor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(66, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Common Search";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(577, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.search_Click);
            // 
            // saveLink
            // 
            this.saveLink.AutoSize = true;
            this.saveLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.saveLink.Location = new System.Drawing.Point(80, 223);
            this.saveLink.Name = "saveLink";
            this.saveLink.Size = new System.Drawing.Size(113, 17);
            this.saveLink.TabIndex = 10;
            this.saveLink.TabStop = true;
            this.saveLink.Text = "How to save a file?";
            this.saveLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.saveLink_LinkClicked);
            // 
            // copyLink
            // 
            this.copyLink.AutoSize = true;
            this.copyLink.Location = new System.Drawing.Point(80, 252);
            this.copyLink.Name = "copyLink";
            this.copyLink.Size = new System.Drawing.Size(103, 15);
            this.copyLink.TabIndex = 11;
            this.copyLink.TabStop = true;
            this.copyLink.Text = "How to copy text?";
            // 
            // diffrenceLink
            // 
            this.diffrenceLink.AutoSize = true;
            this.diffrenceLink.Location = new System.Drawing.Point(80, 278);
            this.diffrenceLink.Name = "diffrenceLink";
            this.diffrenceLink.Size = new System.Drawing.Size(352, 15);
            this.diffrenceLink.TabIndex = 12;
            this.diffrenceLink.TabStop = true;
            this.diffrenceLink.Text = "What is the diffrence betweem edit-type user and view-type user?";
            // 
            // createLink
            // 
            this.createLink.AutoSize = true;
            this.createLink.Location = new System.Drawing.Point(80, 305);
            this.createLink.Name = "createLink";
            this.createLink.Size = new System.Drawing.Size(114, 15);
            this.createLink.TabIndex = 13;
            this.createLink.TabStop = true;
            this.createLink.Text = "Creating an account";
            // 
            // searchIcon1
            // 
            this.searchIcon1.Image = ((System.Drawing.Image)(resources.GetObject("searchIcon1.Image")));
            this.searchIcon1.Location = new System.Drawing.Point(49, 223);
            this.searchIcon1.Name = "searchIcon1";
            this.searchIcon1.Size = new System.Drawing.Size(25, 17);
            this.searchIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchIcon1.TabIndex = 14;
            this.searchIcon1.TabStop = false;
            // 
            // searchIcon2
            // 
            this.searchIcon2.Image = ((System.Drawing.Image)(resources.GetObject("searchIcon2.Image")));
            this.searchIcon2.Location = new System.Drawing.Point(49, 252);
            this.searchIcon2.Name = "searchIcon2";
            this.searchIcon2.Size = new System.Drawing.Size(25, 17);
            this.searchIcon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchIcon2.TabIndex = 15;
            this.searchIcon2.TabStop = false;
            // 
            // searchIcon3
            // 
            this.searchIcon3.Image = ((System.Drawing.Image)(resources.GetObject("searchIcon3.Image")));
            this.searchIcon3.Location = new System.Drawing.Point(49, 278);
            this.searchIcon3.Name = "searchIcon3";
            this.searchIcon3.Size = new System.Drawing.Size(25, 17);
            this.searchIcon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchIcon3.TabIndex = 16;
            this.searchIcon3.TabStop = false;
            // 
            // searchIcon4
            // 
            this.searchIcon4.Image = ((System.Drawing.Image)(resources.GetObject("searchIcon4.Image")));
            this.searchIcon4.Location = new System.Drawing.Point(49, 305);
            this.searchIcon4.Name = "searchIcon4";
            this.searchIcon4.Size = new System.Drawing.Size(25, 17);
            this.searchIcon4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchIcon4.TabIndex = 17;
            this.searchIcon4.TabStop = false;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchIcon4);
            this.Controls.Add(this.searchIcon3);
            this.Controls.Add(this.searchIcon2);
            this.Controls.Add(this.searchIcon1);
            this.Controls.Add(this.createLink);
            this.Controls.Add(this.diffrenceLink);
            this.Controls.Add(this.copyLink);
            this.Controls.Add(this.saveLink);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Help";
            this.Text = "Help";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Help_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Label label3;
        private Button button2;
        private LinkLabel saveLink;
        private LinkLabel copyLink;
        private LinkLabel diffrenceLink;
        private LinkLabel createLink;
        private PictureBox searchIcon1;
        private PictureBox searchIcon2;
        private PictureBox searchIcon3;
        private PictureBox searchIcon4;
    }
}