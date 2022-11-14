using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsListHouse
    {
        private List<clsHouse> myList;

        public clsListHouse()
        {
            myList = new List<clsHouse>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsHouse hou in myList)
            {
                if (hou.HouseNumber == number)
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

        public bool Add(clsHouse hou)
        {
            if (Existed(hou.HouseNumber) == false)
            {
                myList.Add(hou);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsHouse Find(string number)
        {
            foreach (clsHouse hou in myList)
            {
                if (hou.HouseNumber == number)
                {
                    return hou;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsHouse houFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(houFound);
            }
            return true;
        }

        public clsHouse MoveTo(Int32 indx)
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
            foreach (clsHouse hou in myList)
            {
                info += hou + "\n";
            }
            return info;
        }
    }
}