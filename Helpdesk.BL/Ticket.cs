using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ = Helpdesk.Linq;
using log4net;
using Helpdesk.Utilities;



namespace Helpdesk.BL
{
    public class Tickets
    {
        private List<Ticket> oTickets;

        public List<Ticket> pTickets
        {
            get { return oTickets; }
            set { oTickets = value; }
        }

        public void GetTickets()
        {
            try
            {
                LINQ.TicketsDataContext oDc = new Linq.TicketsDataContext();
                var otblTickets =( from f in oDc.tblTickets 
                                  join c in oDc.tblCustomers on f.custID equals c.custID
                                  join s in oDc.tblStatuses on f.statusID equals s.statusID
                                  select f);

                foreach (LINQ.tblTicket t in otblTickets)
                {
                    Ticket oTicket = new Ticket();
                    oTicket.AssignedTo = t.tixAssignedTo;
                    oTicket.custId = t.custID;
                    oTicket.DateCompleted = t.tixDateCompleted;
                    oTicket.DateCreated = t.tixDateCreated;
                    oTicket.deptId = t.deptID;
                    oTicket.empSSN = t.empSSN;
                    oTicket.Id = t.tixID;
                    oTicket.LastContacted = t.tixLastContacted;
                    oTicket.Notes = t.tixNotes;
                    oTicket.statusID = (Guid)t.statusID;
                    oTicket.custName = t.tblCustomer.custName;
                    oTicket.status = t.tblStatuses.statusName; 

                    if (oTickets == null)
                    {
                        oTickets = new List<Ticket>();
                    }

                    oTickets.Add(oTicket);
                }

                oDc = null;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public void SaveTicket(Ticket ticket)
        {
            try
            {
                using (var oDc = new LINQ.TicketsDataContext())
                {
                   Helpdesk.Linq.tblTicket editTicket = (from f in oDc.tblTickets 
                                  join c in oDc.tblCustomers on f.custID equals c.custID
                                  join s in oDc.tblStatuses on f.statusID equals s.statusID
                                  where f.tixID == ticket.Id
                                  select f).SingleOrDefault();

                   editTicket.deptID = ticket.deptId;
                   editTicket.empSSN = ticket.empSSN;
                   editTicket.statusID = ticket.statusID;
                   editTicket.tixAssignedTo = ticket.AssignedTo;
                   editTicket.tixDateCompleted = ticket.DateCompleted;
                   editTicket.tixLastContacted = ticket.LastContacted;
                   editTicket.tixNotes = ticket.Notes;

                   oDc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
        }

      
        
    }


    public class Ticket
    {
        public Guid Id { get; set; }
        public string Notes { get; set; }
        public string DateCreated { get; set;}
        public string AssignedTo { get; set; }
        public string DateCompleted { get; set; }
        public string LastContacted {get; set;}
        public Guid custId { get; set; }
        public string empSSN { get; set; }
        public Guid deptId { get; set; }
        public Guid statusID { get; set; }
        public string custName { get; set; }
        public string status { get; set; }

        public void CreateTicket(Ticket newTicket)
        {
            try
            {
                LINQ.TicketsDataContext oDc = new LINQ.TicketsDataContext();
                Helpdesk.Linq.tblTicket newTick = new Helpdesk.Linq.tblTicket();
                newTick.custID = newTicket.custId;
                newTick.deptID = newTicket.deptId;
                newTick.empSSN = newTicket.empSSN;
                newTick.statusID = newTicket.statusID;
                newTick.tixAssignedTo = newTicket.AssignedTo;
                newTick.tixDateCompleted = newTicket.DateCompleted;
                newTick.tixDateCreated = newTicket.DateCreated;
                newTick.tixID = newTicket.Id;
                newTick.tixLastContacted = newTicket.LastContacted;
                newTick.tixNotes = newTicket.Notes;

                oDc.tblTickets.InsertOnSubmit(newTick);
                oDc.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void DeleteTicket(Ticket delTicket)
        {
            try
            {
                using (var oDc = new LINQ.TicketsDataContext())
                {
                   Helpdesk.Linq.tblTicket editTicket = (from f in oDc.tblTickets 
                                  join c in oDc.tblCustomers on f.custID equals c.custID
                                  join s in oDc.tblStatuses on f.statusID equals s.statusID
                                  where f.tixID == delTicket.Id
                                  select f).SingleOrDefault();

                   oDc.tblTickets.DeleteOnSubmit(editTicket);                   
                   oDc.SubmitChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
    
}
