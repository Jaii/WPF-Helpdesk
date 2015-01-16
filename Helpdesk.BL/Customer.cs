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
    public class Customers
    {
        private List<Customer> oCustomers;

        public List<Customer> pCustomers
        {
            get { return oCustomers; }
            set { oCustomers = value; }
        }

        public void GetCustomers()
        {
            try
            {
                LINQ.TicketsDataContext oDc = new LINQ.TicketsDataContext();
                var otblCustomers = from m in oDc.tblCustomers select m;

                foreach (LINQ.tblCustomer e in otblCustomers)
                {
                    Customer oCustomer = new Customer();
                    oCustomer.cID = e.custID;
                    oCustomer.custName = e.custName;

                    if (oCustomers == null)
                    {
                        oCustomers = new List<Customer>();
                    }

                    
                    oCustomers.Add(oCustomer);
                }

                oDc = null;
            }
            catch (Exception ex)
            {

                Logger.Error(ex);
                throw ex;
            }
        }

    }

    public class Customer
    {
        public Guid cID { get; set; }
        public String custName { get; set; }

        public void CreateCust(Customer newCust)
        {
            try
            {
                Customer newCustomer = newCust;

                LINQ.TicketsDataContext oDc = new LINQ.TicketsDataContext();
                Helpdesk.Linq.tblCustomer tblCust = new Helpdesk.Linq.tblCustomer();

                tblCust.custID = newCust.cID;
                tblCust.custName = newCust.custName;

                oDc.tblCustomers.InsertOnSubmit(tblCust);

                oDc.SubmitChanges();

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }


        }
    }
}
