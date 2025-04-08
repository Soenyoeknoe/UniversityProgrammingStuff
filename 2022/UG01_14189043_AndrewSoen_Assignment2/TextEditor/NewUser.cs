using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void Username_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        // method for the user to cancel in creating account and return to login screen
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            login loginScrn = new login();
            loginScrn.Show();
            this.Hide();
        }
        //method for user to create new user 
        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the password entered is the same as password re enter to autenticate the password
            if (pwdReEnter.Text == thePassword.Text)
            {
                //check if the credential input was valid 
                if (!theUsename.Text.Contains(",") && !thePassword.Text.Contains(",") && !theFname.Text.Contains(",") && !theLname.Text.Contains(","))
                {
                    //check if the login.txt exist
                    if (!File.Exists("login.txt"))
                    {
                        //create a file called login.txt and store the credentials into text file
                        using (StreamWriter lgnDataCreator = File.CreateText("login.txt"))
                        {
                            lgnDataCreator.WriteLine(theUsename.Text + "," + thePassword.Text + "," + theType.Text + "," + theFname.Text + "," + theLname.Text + "," + theDOB.Text);
                        }
                        login loginScrn = new login();
                        loginScrn.Show();
                        this.Hide();
                    }
                    else
                    {
                        //append file called login.txt and store the credentials into text file
                        using (StreamWriter lgnDataCreator = File.AppendText("login.txt"))
                        {
                            lgnDataCreator.WriteLine(theUsename.Text + "," + thePassword.Text + "," + theType.Text + "," + theFname.Text + "," + theLname.Text + "," + theDOB.Text);
                        }
                        login loginScrn = new login();
                        loginScrn.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //it will show a pop-up that the user is invalid to be created
                    MessageBox.Show("The credentials is not valid, please try again","Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //user will need to retype user details
                    theUsename.Clear();
                    thePassword.Clear();
                    pwdReEnter.Clear();
                    theFname.Clear();
                    theLname.Clear();
                    pwdReEnter.Focus();
                }
            }
            else
            {
                //pop up will show up that the passwor reentry is incorrect
                MessageBox.Show("The password is incorrect! please try again", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //user will need to retype the password re-entry
                pwdReEnter.Clear();
                pwdReEnter.Focus();
            }
        }
        //method for when the window for is closing it would stop the program instead only hide/close the window
        private void NewUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
