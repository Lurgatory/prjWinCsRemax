using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsAgent : clsEmployee
    {
        private clsListBuyer vBuyers;
        private clsListSeller vSellers;
        private clsListHouse vHouses;

        public clsAgent(clsListBuyer buyers, clsListSeller sellers, clsListHouse houses)
        {
            this.vBuyers = buyers;
            this.vSellers = sellers;
            this.vHouses = houses;
        }

        public clsListBuyer Buyers { get => vBuyers; set => vBuyers = value; }
        public clsListSeller Sellers { get => vSellers; set => vSellers = value; }
        public clsListHouse Houses { get => vHouses; set => vHouses = value; }
    }
}