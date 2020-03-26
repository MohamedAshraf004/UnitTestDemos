using System;
using System.Text.RegularExpressions;

namespace DataDrivenApplication
{
    public class Employee 
    {
        public string Name { get; set; }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    _email = value;
                }
                else
                {
                    throw new Exception("Invalid Email");
                }
            }
        }
        //public override bool Equals(object obj)
        //{
        //    Employee e2 = obj as Employee;
        //    if (e2 ==null)
        //    {
        //        return false;
        //    }

        //    return this.Email==e2.Email && this.Name==e2.Name;
        //}
        //public override int GetHashCode()
        //{
        //    return this.Name.GetHashCode()^this.Email.GetHashCode();
        //}
    }
    
}
