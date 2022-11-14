using System;
using System.Collections.Generic;
using System.Text;

namespace prjWinCsRemaxBusinessLayer
{
    public class clsListAdmin
    {
        private List<clsAdmin> myList;

        public clsListAdmin()
        {
            myList = new List<clsAdmin>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsAdmin adm in myList)
            {
                if (adm.EmpNnumber == number)
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

        public bool Add(clsAdmin adm)
        {
            if (Existed(adm.EmpNnumber) == false)
            {
                myList.Add(adm);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsAdmin Find(string number)
        {
            foreach (clsAdmin adm in myList)
            {
                if (adm.EmpNnumber == number)
                {
                    return adm;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsAdmin admFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(admFound);
            }
            return true;
        }

        public clsAdmin MoveTo(Int32 indx)
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
            foreach (clsAdmin adm in myList)
            {
                info += adm + "\n";
            }
            return info;
        }
    }
}