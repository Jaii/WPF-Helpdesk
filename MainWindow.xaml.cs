using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Helpdesk.BL;
using System.IO;

namespace Helpdesk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ticket selectedTicket = new Ticket();
       

        public MainWindow()
        {
            InitializeComponent();

            Tickets ticket = new Tickets();
            List<Ticket> tickets;

            ticket.GetTickets();
            tickets = ticket.pTickets;

            grdTickets.ItemsSource = tickets;
            grdTickets.SelectedIndex = 0;
            
        }


        private void btnOpenTicket_Click(object sender, RoutedEventArgs e)
        {
            if (grdTickets.SelectedItem == null)
            {
                lblWarning.Content = "Select a ticket!";
            }
            else
            {
                lblWarning.Content = "";
                selectedTicket = (Ticket)grdTickets.SelectedItem;
                ViewTicketWindow viewTicket = new ViewTicketWindow(selectedTicket);
                viewTicket.Show(); 
            }
            
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Tickets ticket = new Tickets();
            List<Ticket> tickets;

            ticket.GetTickets();
            tickets = ticket.pTickets;

            grdTickets.ItemsSource = tickets;
            trimColumns(sender, e);
        }

        private void btnNewTicket_Click(object sender, RoutedEventArgs e)
        {
            NewTicket newTicket = new NewTicket();
            newTicket.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            selectedTicket = (Ticket)grdTickets.SelectedItem;
            selectedTicket.DeleteTicket(selectedTicket);

            Tickets ticket = new Tickets();
            List<Ticket> tickets;

            ticket.GetTickets();
            tickets = ticket.pTickets;

            grdTickets.ItemsSource = tickets;
            grdTickets.SelectedIndex = 0;
            trimColumns(sender, e);
        }

        private void trimColumns(object sender, RoutedEventArgs e)
        {
            grdTickets.Columns[10].DisplayIndex = 0;
            grdTickets.Columns[0].Visibility = Visibility.Hidden;
            grdTickets.Columns[6].Visibility = Visibility.Hidden;
            grdTickets.Columns[7].Visibility = Visibility.Hidden;
            grdTickets.Columns[8].Visibility = Visibility.Hidden;
            grdTickets.Columns[9].Visibility = Visibility.Hidden;
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {

            //This was hooked up to a windows service to call a stored procedure, for fun
            //fire a stored procedure here of your own or delete
            //TODO: move this out of the UI, or delete if you don't want reporting
            /*
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            List<Ticket> tickets =  new List<Ticket>();
            var tix = service.GetAllInfo();

            foreach (var t in tix)
            {
                Ticket ticket = new Ticket();
                ticket.AssignedTo = t.AssignedTo;
                ticket.custId = t.custId;
                ticket.custName = t.custName;
                ticket.DateCompleted = t.DateCompleted;
                ticket.DateCreated = t.DateCreated;
                ticket.deptId = t.deptId;
                ticket.empSSN = t.empSSN;
                ticket.Id = t.Id;
                ticket.LastContacted = t.LastContacted;
                ticket.Notes = t.Notes;
                ticket.status = t.status;
                ticket.statusID = t.statusID;

                tickets.Add(ticket);

            }

            //Spit out file in bin\debug
           
            var csv = new StringBuilder();
            string file = "Report.csv";

            foreach (Ticket t in tickets)
            {
                var newline = string.Format(t.AssignedTo + "," + t.custId + "," + t.custName + "," + 
                                            t.DateCompleted +"," + "," + t.DateCreated + "," + t.deptId + "," + t.empSSN + "," + t.Id +
                                            "," + t.LastContacted + "," + t.Notes + "," + t.status + "," + t.statusID + Environment.NewLine);
                    csv.Append(newline);
                   
            }

            File.AppendAllText(file, csv.ToString());
            */
        }
             

    }
}
