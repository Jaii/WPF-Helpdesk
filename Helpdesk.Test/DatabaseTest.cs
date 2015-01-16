using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Helpdesk.Linq;
using System.Collections.Generic;
using System.Data.Linq;

namespace Helpdesk.Test
{
    [TestClass]
    public class DatabaseTest
    {
        /*
        [TestMethod]
        public void CreateATicket()
        {
            //create a connection to the table, instantiate new instance
            TicketsDataContext oDc = new TicketsDataContext();
            tblTicket ticket = new tblTicket();

            //assign values to ticket
            ticket.custID = new Guid("644586eb-8967-4ba7-ab7d-174ebab44742");
            ticket.deptID = new Guid("556172f9-79f8-45bc-a376-373f649900e7");
            ticket.empSSN = "555-32-1234";
            ticket.statusID = new Guid("b8f886d7-dfb6-4ae7-8003-2d5a4c9af314");
            ticket.tixAssignedTo = "John from Hardware";
            ticket.tixDateCompleted = null;
            ticket.tixDateCreated = DateTime.Now.ToShortDateString();
            ticket.tixID = Guid.NewGuid();
            ticket.tixLastContacted = DateTime.Now.ToShortDateString();
            ticket.tixNotes = "This was a super easy request";

            oDc.tblTickets.InsertOnSubmit(ticket);
            oDc.SubmitChanges();
            oDc = null;
        }

        [TestMethod]
        public void GetTicketsByAgent()
        {
        }

        [TestMethod]
        public void Update()
        {
            
        }

        [TestMethod]
        public void DeleteTicket()
        {
            //get list of tickets
            TicketsDataContext oDc = new TicketsDataContext();
            List<tblTicket> tickets = oDc.tblTickets.ToList();

            //loop through list of tickets and find this ID
            foreach (tblTicket ticket in tickets)
            {
                if (ticket.tixID == new Guid("44ed434c-57db-4e41-941f-a55c0c4f34ad"))
                {
                    //Delete the tickets
                    oDc.tblTickets.DeleteOnSubmit(ticket);
                    oDc.SubmitChanges();
                    oDc = null;
                }
            }

        }

        */
    }
}
