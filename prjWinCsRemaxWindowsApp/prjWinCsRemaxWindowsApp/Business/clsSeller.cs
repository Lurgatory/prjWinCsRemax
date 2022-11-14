using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsSeller : clsClient
    {
        private clsListHouse vHouses;

        public clsSeller(clsListHouse houses)
        {
            this.vHouses = houses;
        }

        public clsListHouse Houses { get => vHouses; set => vHouses = value; }
    }
}