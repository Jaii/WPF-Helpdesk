using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ = Helpdesk.Linq;

namespace Helpdesk.BL
{
    public class Statuses
    {
        private List<Status> oStatuses;

        public List<Status> pStatuses
        {
            get { return oStatuses; }
            set {oStatuses = value;}
        }

        public void GetStatuses()
        {
            try
            {
                LINQ.TicketsDataContext oDc = new LINQ.TicketsDataContext();
                var otblStatuses = from m in oDc.tblStatuses select m;

                foreach (LINQ.tblStatuses s in otblStatuses)
                {
                    Status oStatus = new Status();
                    oStatus.statusID = s.statusID;
                    oStatus.statusDescription = s.statusDescription;
                    oStatus.statusName = s.statusName;

                    if (oStatuses == null)
                    {
                        oStatuses = new List<Status>();
                    }

                    oStatuses.Add(oStatus);
                }

                oDc = null;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }   
        }
    }

    public class Status
    {
        public Guid statusID { get; set; }
        public string statusName { get; set; }
        public string statusDescription { get; set; }
    }
}
