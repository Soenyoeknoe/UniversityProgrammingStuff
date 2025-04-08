using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class FileManager
    {
        //an enum to get the user type 
        enum theType
        {
            view,
            edit
        }
        //get method of user credentials
        public string username { get; set; }
        public string password { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string DOB { get; set; } 
        //constructor to get the user data 
        public FileManager(string username, string password, string fName, string lName, string dOB)
        {
            this.username = username;
            this.password = password;
            this.fName = fName;
            this.lName = lName;
            DOB = dOB;
        }

    }
}
