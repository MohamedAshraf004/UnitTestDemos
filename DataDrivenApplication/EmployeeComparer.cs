using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataDrivenApplication
{
    public class EmployeeComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Employee e1 = x as Employee;
            Employee e2 = y as Employee;
            if (e1==null || e2==null)
            {
                return -1;
            }
            else
            {
                return e1.Name.CompareTo(e2.Name);
            }
            
        }
    }
}
