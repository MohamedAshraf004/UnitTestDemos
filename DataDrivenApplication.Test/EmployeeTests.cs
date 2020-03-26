using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDrivenApplication.Test
{
    [TestClass]
    public class EmployeeTests
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DataSource("System.Data.SqlClient",
            "server=(localdb)\\MSSQLLocalDB;database=TestDB;Trusted_Connection=true",
            "Employees", DataAccessMethod.Sequential)]
        //[DataSource("UnitTestDataSource")]
        [Priority(2)]
        public void DataDrivemEmployeeTest()
        {
            Employee employee = new Employee();
            employee.Name = TestContext.DataRow["Name"].ToString();
            employee.Email = TestContext.DataRow["Email"].ToString();
            Assert.IsNotNull(employee.Email);
            Assert.IsNotNull(employee.Name);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "Employees.xml",
            "Employee", DataAccessMethod.Sequential)]
        [Priority(1)]
        [Timeout(2000)]
        public void DataDrivemEployeeTest_XmlFile()
        {
            Employee employee = new Employee();
            employee.Name = TestContext.DataRow["Name"].ToString();
            employee.Email = TestContext.DataRow["Email"].ToString();
            Assert.IsNotNull(employee.Email);
            Assert.IsNotNull(employee.Name);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "Employees.csv",
            "Employees.csv", DataAccessMethod.Sequential)]
        public void DataDrivemEployeeTest_CsvFile()
        {
            Employee employee = new Employee();
            employee.Name = TestContext.DataRow["Name"].ToString();
            employee.Email = TestContext.DataRow["Email"].ToString();
            Assert.IsNotNull(employee.Email);
            Assert.IsNotNull(employee.Name);
        }
        [TestMethod]
        public void AssertClass()
        {
            int expected = 25;
            double actual = Math.Pow(5, 2);
            //Assert.AreEqual(expected, actual, "the power is 25");
            //Assert.AreNotEqual(expected, actual, "the power is 25");
            Employee e1 = new Employee { Name = "Mohamed", Email = "Mohamed_123@gmail.com" };
            Employee e2 = new Employee { Name = "Mohamed", Email = "Mohamed_123@gmail.com" };
            //Assert.AreEqual(e1, e2);
            //Assert.AreEqual(e1.Email, e2.Email);
            Assert.IsTrue(AssertObjectEquality(e1, e2));
            //Assert.AreSame(e1, e2);
            //Assert.AreNotSame(e1, e2);
            //Assert.Fail("Failed cannot execute");
            //Assert.IsTrue(true);
            //Assert.IsFalse(false);
            //Assert.IsNull(null);
            ////Assert.IsNotNull(e1);
            //Assert.IsInstanceOfType(e2, typeof(Employee));
            //Assert.IsNotInstanceOfType(e2, typeof(Employee));

        }
        private static bool AssertObjectEquality(Employee e1, Employee e2)
        {
            return e1.Email == e2.Email && e1.Name == e2.Name;
        }
        [TestMethod]
        public void CollectionAssertClass_AreEqual()
        {
            //List<string> str1 = new List<string> { "Mohamed", "Ashraf" ,"Ahmed"};
            //List<string> str2 = new List<string> { "Mohamed","Ashraf", "Ahmed" };// order is must

            //CollectionAssert.AreEqual(str1, str2);
            List<Employee> emps1 = new List<Employee>
            {
             new Employee { Name = "Mohamed",Email="Mohamed_123@gmail.com" },
             new Employee { Name = "Mohamed", Email = "Mohamed_123@gmail.com" }
            };
            List<Employee> emps2 = new List<Employee>
            {
             new Employee { Name = "Mohamed",Email="Mohamed_123@gmail.com" },
             new Employee { Name = "Mohamed", Email = "Mohamed_123@gmail.com" }
            };
            //CollectionAssert.AreEqual(emps1, emps2);//will not equal as it equal referances
            CollectionAssert.AreEqual(emps1, emps2, new EmployeeComparer());//will  equal as I implement IComparer to EmployeeComparer        }
            CollectionAssert.AreEqual(emps1.Select(e => new { e.Name, e.Email }).ToList(),
                                     emps2.Select(e => new { e.Name, e.Email }).ToList());
        }
        [TestMethod]
        public void CollectionAssertClass_AreEquivalent()
        {
            List<Employee> emps1 = new List<Employee>();
            emps1.Add(new Employee() { Name = "Mohamed" });
            emps1.Add(new Employee() { Name = "Ahmed" });
            List<Employee> emps2 = new List<Employee>();
            
            emps2.Add(new Employee() { Name = "Mohamed" });
            emps2.Add(new Employee (){ Name = "Ahmed" });
            CollectionAssert.AreNotEquivalent(emps1, emps2,"Are Equal");

        }
        [TestMethod]
        public void CollectionAssertClass_Contains()
        {
            List<Customer> cus1 = new List<Customer>() { new Customer() { Name = "Mohamed" } };
            //emps1.Add(new Employee() { Name = "Mohamed",Email="mohamed@gmail.com" });
            cus1.Add(new Customer() { Name = "Ahmed" });
            List<Employee> emps2 = new List<Employee>();
            emps2.Add(new Employee() { Name = "Mohamed" });
            emps2.Add(new Employee() { Name = "Ahmed" });
            CollectionAssert.Contains(cus1, new Customer() { Name = "Mohamed"});

        }
        [TestMethod]
        public void CollectionAssertClass_Subset()
        {
            List<Customer> super = new List<Customer>() { new Customer() { Name = "Mohamed" } };
            super.Add(new Customer() { Name = "Ahmed" });
            super.Add(new Customer() { Name = "Ashraf" });
            List<Customer> sub = new List<Customer>();
            sub.Add(new Customer() { Name = "Mohamed" });
            sub.Add(new Customer() { Name = "Ahmed" });
            CollectionAssert.IsNotSubsetOf(sub, super);
        }
        [TestMethod]
        public void CollectionAssertClass_AllItemsAreUnique()
        {
            List<Customer> super = new List<Customer>() { new Customer() { Name = "Mohamed" } };
            super.Add(new Customer() { Name = "Ahmed" });
            super.Add(new Customer() { Name = "Ashraf" });
            CollectionAssert.AllItemsAreUnique(super);
        }
        [TestMethod]
        public void CollectionAssertClass_AllItemsAreNotNull()
        {
            List<Customer> super = new List<Customer>() { new Customer() { Name = "Mohamed" } };
            super.Add(new Customer() { Name = "Ahmed" });
            super.Add(new Customer() { Name = "Ashraf" });
            CollectionAssert.AllItemsAreNotNull(super);
        }
        [TestMethod]
        public void CollectionAssertClass_AllItemsAreInstanceOfType()
        {
            List<Customer> super = new List<Customer>() { new Customer() { Name = "Mohamed" } };
            super.Add(new Customer() { Name = "Ahmed" });
            super.Add(new Customer() { Name = "Ashraf" });
            super.Add(new DrivedCustomer() { Name = "Ashraf" });// drived from customer and will true
            CollectionAssert.AllItemsAreInstancesOfType(super, typeof(Customer));// true
            //CollectionAssert.AllItemsAreInstancesOfType(super,typeof(DrivedCustomer)); // drived from customer and will false as this is child
        }
        [TestMethod]
        public void StringAssertClass()
        {
            //StringAssert.StartsWith("Mohamed Ashraf", "mohamed");//case insensitive
            //StringAssert.EndsWith("Mohamed Ashraf", "ashraf");//case insensitive
            //StringAssert.Contains("Mohamed Ashraf Mohamed", "Ashraf");//case insensitive
            Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

            //StringAssert.Matches("MohamedAshraf1811@outlook.com", regex);//match pattern
            StringAssert.DoesNotMatch("MohamedAshraf1811outlook.com", regex);//does not match pattern

        }
    }
}
