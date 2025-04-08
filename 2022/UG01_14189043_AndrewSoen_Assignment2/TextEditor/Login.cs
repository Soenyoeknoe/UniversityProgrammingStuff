using System;

namespace TextEditor
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        //method to called when the user clicked on "new user" Button
        private void regBtn_Click(object sender, EventArgs e)
        {
            NewUser registerForm = new NewUser();
            registerForm.Show();
            this.Hide();
        }
        //collections of user credentials
        List<string> daUsername = new List<string>();
        List<string> daPassword = new List<string>();
        List<string> daType = new List<string>();
        //method when the formload it will check the database in text file and split the string into credentials data of user
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader lgnData = new StreamReader("login.txt");
            string line = "";
            while((line = lgnData.ReadLine()) != null)
            {
                string[] components = line.Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
                daUsername.Add(components[0]);
                daPassword.Add(components[1]);  
                daType.Add(components[2]);
            }
            lgnData.Close();
        }
        //method to let user to log in and validate user into the text editor
        private void lgnBtn_Click(object sender, EventArgs e)
        {
            //check if the database created
            if (File.Exists("login.txt"))
            {
                bool validation = false;
                Editor editor = new Editor();
                //check if it match the database
                if (daUsername.Contains(lgnUsername.Text) && daPassword.Contains(lgnPassword.Text) && Array.IndexOf(daUsername.ToArray(),lgnUsername.Text) == Array.IndexOf(daPassword.ToArray(),lgnPassword.Text))
                {
                    validation = true;
                }
                else
                {
                    validation = false;
                }
                //check if the validation was valid
                if (validation == true)
                {
                    editor.Show();
                    this.Hide();
                    Editor.instance.currentUser.Text = lgnUsername.Text;//store the data of username to be shown on the text editor
                    //store the data of user type to be use on editor if the user is edit it will access all the feature if view it only allow to open file
                    string userline = File.ReadLines("login.txt").Skip(Array.IndexOf(daUsername.ToArray(), lgnUsername.Text)).Take(1).First();
                    string[] gettingUserTypes = userline.Split(",");
                    Editor.instance.userTypes = gettingUserTypes[2];
                }
                else
                {
                    //pop up screen will shown that the credentials is invalid 
                    MessageBox.Show("The credentials is incorrect! please try again", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //user need to retype username and password
                    lgnUsername.Clear();
                    lgnPassword.Clear();
                    lgnUsername.Focus();
                }

            }
            else
            {
                //pop up screen will shown that the data is not exist
                MessageBox.Show("The data is not exist! please create new user", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //user need to retype username and password
                lgnUsername.Clear();
                lgnPassword.Clear();
                lgnUsername.Focus();
            }
        }
        //method for "Exit" button to close the window and stop run the program
        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //method for when the window for is closing it would stop the program instead only hide/close the window
        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}