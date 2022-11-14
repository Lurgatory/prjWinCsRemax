using System;
using System.Collections.Generic;
using System.Text;

namespace prjWinCsRemaxBusinessLayer
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