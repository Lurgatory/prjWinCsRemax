using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsClient
    {
        private string vCltNnumber;
        private string vName;
        private DateTime vBirthdate;
        private string vPassword;
        private string vIdentity;

        public clsClient(string cltNnumber, string name, int Day, int Month, int Year, string password, int age, string identity)
        {
            this.vCltNnumber = cltNnumber;
            this.vName = name;
            this.vBirthdate = new DateTime(Year, Month, Day);
            this.vPassword = password;
            this.vIdentity = identity;
        }

        public clsClient(string cltNnumber, string name, DateTime birthdate, string password, int age, string identity)
        {
            this.vCltNnumber = cltNnumber;
            this.vName = name;
            this.vBirthdate = birthdate;
            this.vPassword = password;
            this.vIdentity = identity;
        }
        public clsClient()
        {
            vCltNnumber = vName = vPassword = vIdentity = "Not Defined";
            vBirthdate = DateTime.Now;
        }

        public string CltNnumber { get => vCltNnumber; set => vCltNnumber = value; }
        public string Name { get => vName; set => vName = value; }
        public DateTime Birthdate { get => vBirthdate; set => vBirthdate = value; }
        public string Password { get => vPassword; set => vPassword = value; }
        public int Age { get => (DateTime.Today.Year - Birthdate.Year); }
        public string Identity { get => vIdentity; set => vIdentity = value; }
    }
}