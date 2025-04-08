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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)// method to return back to editor page
        {
            Editor editor = new Editor();   
            editor.Show();
            this.Hide();
        }
        //method for when the window for is closing it would stop the program instead only hide/close the window
        private void Help_FormClosing(object sender, FormClosingEventArgs e) 
        {
            Environment.Exit(0);
        }

        private void search_Click(object sender, EventArgs e)
        {
            
        }

        private void saveLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
