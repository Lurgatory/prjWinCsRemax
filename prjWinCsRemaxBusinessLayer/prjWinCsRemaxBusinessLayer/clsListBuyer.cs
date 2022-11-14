using System;
using System.Collections.Generic;
using System.Text;

namespace prjWinCsRemaxBusinessLayer
{
    public class clsListBuyer
    {
        private List<clsBuyer> myList;

        public clsListBuyer()
        {
            myList = new List<clsBuyer>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsBuyer byr in myList)
            {
                if (byr.CltNnumber == number)
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        public int Quantity
        {
            get
            {
                return myList.Count;
            }
        }

        public bool Add(clsBuyer byr)
        {
            if (Existed(byr.CltNnumber) == false)
            {
                myList.Add(byr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsBuyer Find(string number)
        {
            foreach (clsBuyer byr in myList)
            {
                if (byr.CltNnumber == number)
                {
                    return byr;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsBuyer byrFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(byrFound);
            }
            return true;
        }

        public clsBuyer MoveTo(Int32 indx)
        {
            if (indx >= 0 && indx < myList.Count)
            {
                return myList[indx];
            }
            else
            {
                return null;
            }
        }

        public string Display()
        {
            string info = "";
            foreach (clsBuyer byr in myList)
            {
                info += byr + "\n";
            }
            return info;
        }
    }
}