using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsListSeller
    {
        private List<clsSeller> myList;

        public clsListSeller()
        {
            myList = new List<clsSeller>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsSeller slr in myList)
            {
                if (slr.CltNnumber == number)
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

        public bool Add(clsSeller slr)
        {
            if (Existed(slr.CltNnumber) == false)
            {
                myList.Add(slr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsSeller Find(string number)
        {
            foreach (clsSeller slr in myList)
            {
                if (slr.CltNnumber == number)
                {
                    return slr;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsSeller slrFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(slrFound);
            }
            return true;
        }

        public clsSeller MoveTo(Int32 indx)
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
            foreach (clsSeller slr in myList)
            {
                info += slr + "\n";
            }
            return info;
        }
    }
}