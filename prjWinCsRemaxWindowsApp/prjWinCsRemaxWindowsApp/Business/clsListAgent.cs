using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsListAgent
    {
        private List<clsAgent> myList;

        public clsListAgent()
        {
            myList = new List<clsAgent>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsAgent agt in myList)
            {
                if (agt.EmpNnumber == number)
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

        public bool Add(clsAgent agt)
        {
            if (Existed(agt.EmpNnumber) == false)
            {
                myList.Add(agt);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsAgent Find(string number)
        {
            foreach (clsAgent agt in myList)
            {
                if (agt.EmpNnumber == number)
                {
                    return agt;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsAgent agtFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(agtFound);
            }
            return true;
        }

        public clsAgent MoveTo(Int32 indx)
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
            foreach (clsAgent agt in myList)
            {
                info += agt + "\n";
            }
            return info;
        }
    }
}