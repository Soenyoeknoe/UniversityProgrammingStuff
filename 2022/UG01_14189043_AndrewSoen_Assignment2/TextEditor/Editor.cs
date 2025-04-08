using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditor
{
    public partial class Editor : Form
    {
        public static Editor instance; //create an instance in editor page to get the data of the enum of user type from other file
        public ToolStripLabel currentUser; //store the data in to the variable
        public string userTypes;//store the user type as string to diffrentiate user in disabling features (Save file, bold, italic, save as)
        
        public Editor()
        {
            InitializeComponent();
            instance = this;
            currentUser = toolStripLabel2;
        }
        
        public string filePath;//store the filepath data
        public RichTextBoxStreamType daFileType;//store the filetype data
        
        private void CurrentUserStripLabel1_Click(object sender, EventArgs e)
        {

        }
        //method to allow user to go to about page
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();
        }
        //method to allow user to return back to login screen and log out the user account
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }
        //method to allow user to go to help page 
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
            this.Hide();

        }
        //method to allow user to create a new file inside the rich text box
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if the textbox has omething in it
            if (textBoxData.Text != "")
            {
                //it clear the data of the text boxt if the user click on ok of the pop up window
                if(DialogResult.OK==MessageBox.Show("The content will be lost. Do you wish to continue?","Continue?",MessageBoxButtons.OKCancel))
                {
                    textBoxData.Clear();
                }
            }
        }
        //method to allow user to create a new file inside the rich text box
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //check if the textbox has omething in it
            if (textBoxData.Text != "")
            {
                //it clear the data of the text boxt if the user click on ok of the pop up window
                if (DialogResult.OK == MessageBox.Show("The content will be lost. Do you wish to continue?", "Continue?", MessageBoxButtons.OKCancel))
                {
                    textBoxData.Clear();
                }
            }
        }
        //method to allow user to open a .txt file or .rtf file inside the rich text box
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open the file using openfiledialog and filter the file with only .rtf and .txt format
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (.rtf)|*.rtf|Text Files (.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Open a file...";
            RichTextBoxStreamType fileType;
            fileType = RichTextBoxStreamType.RichText;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FilterIndex == 2)
                {
                    fileType = RichTextBoxStreamType.PlainText;
                    
                }
                daFileType = fileType;
                filePath = openFileDialog.FileName;
                textBoxData.LoadFile(openFileDialog.FileName, fileType);
                
            }
        }
        //method to allow user to open a .txt file or .rtf file inside the rich text box
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //open the file using openfiledialog and filter the file with only .rtf and .txt format
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (.rtf)|*.rtf|Text Files (.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Open a file...";
            RichTextBoxStreamType fileType;
            fileType = RichTextBoxStreamType.RichText;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(openFileDialog.FilterIndex == 2)
                {
                    fileType = RichTextBoxStreamType.PlainText;
                    
                }
                daFileType = fileType;
                filePath = openFileDialog.FileName;
                textBoxData.LoadFile(openFileDialog.FileName, fileType);
            }
        }
        //method to allow user to save a .txt file or .rtf file that was inside the rich text box
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                textBoxData.SaveFile(filePath, daFileType);
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to allow user to save a .txt file or .rtf file that was inside the rich text box
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                textBoxData.SaveFile(filePath, daFileType);
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        //method to allow user to save as a .txt file or .rtf file that was inside the rich text box
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                //save the file using savefiledialog and filter the file with only .rtf and .txt format
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                string filename = "";
                saveFileDialog.Filter = "Rich Text Format (.rtf)|*.rtf|Text Files (.txt)|*.txt";
                saveFileDialog.Title = "Save the file...";
                saveFileDialog.FilterIndex = 1;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog.FileName;
                }
                // check if the user save as rtf file or txt file and stor the file type as data to safe file
                RichTextBoxStreamType fileType;
                if (saveFileDialog.FilterIndex == 2)
                {
                    fileType = RichTextBoxStreamType.PlainText;
                }
                else
                {
                    fileType = RichTextBoxStreamType.RichText;
                }
                textBoxData.SaveFile(filename, fileType);
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to allow user to save as a .txt file or .rtf file that was inside the rich text box
        private void SaveAsToolStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                //save the file using savefiledialog and filter the file with only .rtf and .txt format
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                string filename = "";
                saveFileDialog.Filter = "Rich Text Format (.rtf)|*.rtf|Text Files (.txt)|*.txt";
                saveFileDialog.Title = "Save the file...";
                saveFileDialog.FilterIndex = 1;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog.FileName;
                }
                // check if the user save as rtf file or txt file and stor the file type as data to save file
                RichTextBoxStreamType fileType;
                if (saveFileDialog.FilterIndex == 2)
                {
                    fileType = RichTextBoxStreamType.PlainText;
                }
                else
                {
                    fileType = RichTextBoxStreamType.RichText;
                }
                textBoxData.SaveFile(filename, fileType);
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to allow user to make the text bold if the user type is edit
        private void boldTextStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                //make the text bold if the user type is edit
                Font SelectedText = textBoxData.SelectionFont;
                if (SelectedText != null)
                {
                    textBoxData.SelectionFont = new Font(textBoxData.SelectionFont.FontFamily, textBoxData.SelectionFont.Size, textBoxData.SelectionFont.Style ^ FontStyle.Bold);
                }
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to allow user to make the text italic if the user type is edit
        private void italTextStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                //make the text underline if the user type is edit
                Font SelectedText = textBoxData.SelectionFont;
                if (SelectedText != null)
                {
                    textBoxData.SelectionFont = new Font(textBoxData.SelectionFont.FontFamily, textBoxData.SelectionFont.Size, textBoxData.SelectionFont.Style ^ FontStyle.Italic);
                }
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to allow user to make the text underline if the user type is edit
        private void underTextStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                //make the text underline if the user type is edit
                Font SelectedText = textBoxData.SelectionFont;
                if (SelectedText != null)
                {
                    textBoxData.SelectionFont = new Font(textBoxData.SelectionFont.FontFamily, textBoxData.SelectionFont.Size, textBoxData.SelectionFont.Style ^ FontStyle.Underline);
                }
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //method to allow user to make the text highlighted be deleted
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                textBoxData.Cut();//make the text highlighted be deleted
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to allow user to make the text highlighted be copied
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                textBoxData.Copy();//make the text highlighted be copied
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to allow user to paste text that was copied
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                textBoxData.Paste();//paste text that was copied
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method to change theme to dark mode
        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxData.ForeColor = Color.White;
            textBoxData.BackColor = Color.Black;
            this.BackColor = Color.Gray;
        }
        //method to return to default mode from dark mode
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxData.ForeColor = Color.Black;
            textBoxData.BackColor = Color.White;
            this.BackColor = Color.White;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
        }
        //method to change the font size of text if the user type is edit
        private void toolStripComboBox1_SelectedIndexChanged(object sender,EventArgs e)
        {
            //check if user type is edit
            if (userTypes == "Edit")
            {
                //change the font size of the text in the rich text box
                Font SelectedText = textBoxData.SelectionFont;
                if (SelectedText != null)
                {
                    textBoxData.SelectionFont = new Font(textBoxData.Font.FontFamily, float.Parse(toolStripComboBox1.SelectedItem.ToString()));
                }
            }
            else
            {
                MessageBox.Show("This user can't access edit mode feature", "View Mode Type User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //method for when the window for is closing it would stop the program instead only hide/close the window
        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
