using System;
using System.Collections.Generic;
using System.Text;

namespace prjWinCsRemaxBusinessLayer
{
    public class clsHouse
    {
        private string vHouseNumber;
        private string vHouseType;
        private DateTime vHouseYear;
        private string vAddress;
        private int vHouseAge;

        public clsHouse(string houseNumber, string houseType, DateTime houseYear, string address, int houseAge)
        {
            this.vHouseNumber = houseNumber;
            this.vHouseType = houseType;
            this.vHouseYear = houseYear;
            this.vAddress = address;
            this.vHouseAge = houseAge;
        }

        public string HouseNumber { get => vHouseNumber; set => vHouseNumber = value; }
        public string HouseType { get => vHouseType; set => vHouseType = value; }
        public DateTime HouseYear { get => vHouseYear; set => vHouseYear = value; }
        public string Address { get => vAddress; set => vAddress = value; }
        public int HouseAge { get => vHouseAge; set => vHouseAge = value; }
    }
}