using System;
using System.Collections.Generic;
using System.Text;

namespace prjWinCsRemaxBusinessLayer
{
    public class clsListCompany
    {
        private List<clsCompany> myList;

        public clsListCompany()
        {
            myList = new List<clsCompany>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsCompany comp in myList)
            {
                if (comp.Number == number)
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

        public bool Add(clsCompany comp)
        {
            if (Existed(comp.Number) == false)
            {
                myList.Add(comp);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsCompany Find(string number)
        {
            foreach (clsCompany comp in myList)
            {
                if (comp.Number == number)
                {
                    return comp;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsCompany compFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(compFound);
            }
            return true;
        }

        public clsCompany MoveTo(Int32 indx)
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
            foreach (clsCompany comp in myList)
            {
                info += comp + "\n";
            }
            return info;
        }
    }
}