using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxWindowsApp
{
    public class clsListEmployee
    {
        private List<clsEmployee> myList;

        public clsListEmployee()
        {
            myList = new List<clsEmployee>();
        }

        private bool Existed(string number)
        {
            bool result = false;
            foreach (clsEmployee emp in myList)
            {
                if (emp.EmpNnumber == number)
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

        public bool Add(clsEmployee emp)
        {
            if (Existed(emp.EmpNnumber) == false)
            {
                myList.Add(emp);
                return true;
            }
            else
            {
                return false;
            }
        }

        public clsEmployee Find(string number)
        {
            foreach (clsEmployee emp in myList)
            {
                if (emp.EmpNnumber == number)
                {
                    return emp;
                }
            }
            return null;
        }

        public bool Delete(string number)
        {
            clsEmployee empFound = Find(number);
            if (Find(number) == null)
            {
                return false;
            }
            else
            {
                return myList.Remove(empFound);
            }
            return true;
        }

        public clsEmployee MoveTo(Int32 indx)
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
            foreach (clsEmployee emp in myList)
            {
                info += emp + "\n";
            }
            return info;
        }
    }
}