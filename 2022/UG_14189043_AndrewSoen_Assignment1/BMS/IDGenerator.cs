using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    class IDGenerator
    {
        static int id = 100000;
        string storeId;

        public string generate()//method for generate password
        {
            string gid = "";
            storeId = gid + ++id;
            
            return storeId;

        }

    }
}

