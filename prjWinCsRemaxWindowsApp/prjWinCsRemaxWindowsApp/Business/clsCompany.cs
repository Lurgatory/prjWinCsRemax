using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsCompany
    {
        private string vNumber;
        private string vCompanyName;
        private clsListSeller vSellers;

        public clsCompany(string number, string companyName, clsListSeller sellers)
        {
            this.vNumber = number;
            this.vCompanyName = companyName;
            this.vSellers = sellers;
        }

        public string Number { get => vNumber; set => vNumber = value; }
        public string CompanyName { get => vCompanyName; set => vCompanyName = value; }
        public clsListSeller Sellers { get => vSellers; set => vSellers = value; }
    }
}