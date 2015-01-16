using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ = Helpdesk.Linq;

namespace Helpdesk.BL
{
    public class Departments
    {
        private List<Department> oDepartments;

        public List<Department> pDepartments
        {
            get { return oDepartments; }
            set { oDepartments = value; }
        }

        public string GetNameFromID(Ticket t)
        {
            string ticketDept = ""; 

            foreach (Department d in oDepartments)
            {

                if (d.deptID == t.deptId)
                {
                    ticketDept = d.deptDescription;
                
                }

            }

            return ticketDept;
        }

        public void GetDepartments()
        {
            try
            {
                LINQ.TicketsDataContext oDc = new LINQ.TicketsDataContext();
                var otblDepartments = from m in oDc.tblDepartments select m;

                foreach (LINQ.tblDepartment s in otblDepartments)
                {
                    Department oDepartment = new Department();
                    oDepartment.deptID = s.deptID;
                    oDepartment.deptDescription = s.deptDescription;


                    if (oDepartments == null)
                    {
                        oDepartments = new List<Department>();
                    }

                    oDepartments.Add(oDepartment);
                }

                oDc = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class Department
    {
        public Guid deptID { get; set; }
        public string deptDescription { get; set; }

    }
}
