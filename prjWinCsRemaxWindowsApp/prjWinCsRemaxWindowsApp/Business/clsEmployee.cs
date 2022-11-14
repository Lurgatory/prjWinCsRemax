using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsEmployee
    {
        private string vEmpNnumber;
        private string vName;
        private DateTime vBirthdate;
        private string vPassword;
        private string vPosition;

        public clsEmployee(string empNnumber, string name, int Day, int Month, int Year, string password, string position)
        {
            this.vEmpNnumber = empNnumber;
            this.vName = name;
            this.vBirthdate = new DateTime(Year, Month, Day);
            this.vPassword = password;
            this.vPosition = position;
        }

        public clsEmployee(string empNnumber, string name, DateTime birthdate, string password, string position)
        {
            this.vEmpNnumber = empNnumber;
            this.vName = name;
            this.vBirthdate = birthdate;
            this.vPassword = password;
            this.vPosition = position;
        }

        public clsEmployee()
        {
            vEmpNnumber = vName = vPassword = vPosition = "Not Defined";
            vBirthdate = DateTime.Now;
        }

        public string EmpNnumber { get => vEmpNnumber; set => vEmpNnumber = value; }
        public string Name { get => vName; set => vName = value; }
        public DateTime Birthdate { get => vBirthdate; set => vBirthdate = value; }
        public string Password { get => vPassword; set => vPassword = value; }
        public int Age { get => (DateTime.Today.Year - Birthdate.Year); }
        public string Position { get => vPosition; set => vPosition = value; }
    }
}