using System;
using System.Collections.Generic;
using System.Text;

namespace prjWinCsRemaxBusinessLayer
{
    public class clsAdmin : clsEmployee
    {
        private clsListAgent vAgents;
        private clsListAdmin vAdmins;
        private clsListBuyer vBuyers;
        private clsListSeller vSellers;

        //public clsAdmin()
        //{
        //    EmpNnumber = Name = Password = Position = "Not Defined";
        //    Birthdate = DateTime.Now;
        //    vAgents = new clsListAgent();
        //    vAdmins = new clsListAdmin();
        //    vBuyers = new clsListBuyer();
        //    vSellers = new clsListSeller();
        //}

        public clsAdmin(clsListAgent agents, clsListAdmin admins, clsListBuyer buyers, clsListSeller sellers)
        {
            this.vAgents = agents;
            this.vAdmins = admins;
            this.vBuyers = buyers;
            this.vSellers = sellers;
        }

        public clsListAgent Agents { get => vAgents; set => vAgents = value; }
        public clsListAdmin Admins { get => vAdmins; set => vAdmins = value; }
        public clsListBuyer Buyers { get => vBuyers; set => vBuyers = value; }
        public clsListSeller Sellers { get => vSellers; set => vSellers = value; }
    }
}