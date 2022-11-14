using System;
using System.Collections.Generic;
using System.Text;

namespace prjWinCsRemaxBusinessLayer
{
    public class clsListClient
    {
        private List<clsClient> myList;

        public clsListClient()
        {
            myList = new List<clsClient>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsClient clt in myList)
            {
                if (clt.CltNnumber == number)
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

        public bool Add(clsClient clt)
        {
            if (Existed(clt.CltNnumber) == false)
            {
                myList.Add(clt);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsClient Find(string number)
        {
            foreach (clsClient clt in myList)
            {
                if (clt.CltNnumber == number)
                {
                    return clt;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsClient cltFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(cltFound);
            }
            return true;
        }

        public clsClient MoveTo(Int32 indx)
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
            foreach (clsClient clt in myList)
            {
                info += clt + "\n";
            }
            return info;
        }
    }
}