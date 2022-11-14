using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsHouse
    {
        private string vHouseNumber;
        private string vHouseName;
        private DateTime vHouseYear;
        private string vAddress;
        private int vHouseAge;

        public clsHouse(string houseNumber, string houseName, DateTime houseYear, string address, int houseAge)
        {
            this.vHouseNumber = houseNumber;
            this.vHouseName = houseName;
            this.vHouseYear = houseYear;
            this.vAddress = address;
            this.vHouseAge = houseAge;
        }

        public string HouseNumber { get => vHouseNumber; set => vHouseNumber = value; }
        public string HouseName { get => vHouseName; set => vHouseName = value; }
        public DateTime HouseYear { get => vHouseYear; set => vHouseYear = value; }
        public string Address { get => vAddress; set => vAddress = value; }
        public int HouseAge { get => vHouseAge; set => vHouseAge = value; }
    }
}