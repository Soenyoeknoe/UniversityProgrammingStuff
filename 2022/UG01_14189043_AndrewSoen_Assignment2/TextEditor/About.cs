using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //method to allow user to return back to editor page 
        private void button1_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.Show();
            this.Hide();
        }
        //method for when the window for is closing it would stop the program instead only hide/close the window
        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void About_Load(object sender, EventArgs e)
        {
            
        }
    }
}
