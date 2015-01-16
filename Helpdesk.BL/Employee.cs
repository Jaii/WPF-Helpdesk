using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ = Helpdesk.Linq;
using Helpdesk.Utilities;
using log4net;
using System.Reflection;

namespace Helpdesk.BL
{
    public class Employees
    {

        private List<Employee> oEmployees;
       
        public List<Employee> pEmployees
        {
            get { return oEmployees; }
            set { oEmployees = value; }
        }

        public void GetEmployees()
        {
            try
            {
                LINQ.TicketsDataContext oDc = new LINQ.TicketsDataContext();
                var otblEmployees = from m in oDc.tblEmployees select m;

                foreach (LINQ.tblEmployee e in otblEmployees)
                {
                    Employee oEmployee = new Employee();
                    oEmployee.empSSN = e.empSSN;
                    oEmployee.empName = e.empName;
                    oEmployee.empDept = e.empDept;

                    if (oEmployees == null)
                    {
                        oEmployees = new List<Employee>();
                    }

                    oEmployees.Add(oEmployee);
                }

                oDc = null;
            }
            catch (Exception ex)
            {
                
                Logger.Error(ex);
                throw ex;
            }
        }

        public string GetNameFromSSN(Ticket t)
        {
            string empName = "";
            try
            {
                foreach (Employee e in oEmployees)
                {

                    if (e.empSSN == t.empSSN)
                    {
                        empName = e.empName;
                    }

                }

                return empName;
            }
            catch (Exception ex)
            {

                Logger.Error(ex);
                throw ex;
                return null;
            }
        }

        public List<Employee> GetEmployeesForDept(Department dept)
        {
            List<Employee> empInDept = new List<Employee>();

            try
            {
                foreach (Employee e in oEmployees)
                {

                    if (new Guid(e.empDept) == dept.deptID)
                    {
                        empInDept.Add(e);
                    }

                }
            }
            catch (Exception ex)
            {


                Logger.Error(ex);
                throw ex;
            }

            return empInDept;
        }
    }

    public class Employee
    {
        public string empSSN { get; set; }
        public string empName { get; set; }
        public string empDept { get; set; }

    }
}
