using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Helpdesk.Linq;
using System.Collections.Generic;
using System.Data.Linq;
using Helpdesk.BL;

namespace Helpdesk.Test
{
    [TestClass]
    public class BLTest
    {
        [TestMethod]
        public void GetTicketsTest()
        {
             Tickets ticket = new Tickets();
             List<Ticket> tickets;

             ticket.GetTickets();
             tickets = ticket.pTickets;
        }
    }
}
