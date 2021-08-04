using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }

        public string dob { get; set; }

        
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string spouseName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string state { get; set; }
        public string pinCode { get; set; }
        public string country { get; set; }
        public string userType { get; set; }

    }
}
