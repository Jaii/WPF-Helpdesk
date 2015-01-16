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
using System.Windows.Shapes;
using Helpdesk.BL;

namespace Helpdesk
{
    /// <summary>
    /// Interaction logic for ViewTicketWindow.xaml
    /// </summary>
    public partial class ViewTicketWindow : Window
    {
        
        public Ticket ticket = new Ticket();

        public ViewTicketWindow()
        {
            InitializeComponent();
        }

        public ViewTicketWindow(Ticket t)
        {
            InitializeComponent();
            ticket = t;

            //get statuses
            Statuses s = new Statuses();
            List<Status> statuses = new List<Status>();
            s.GetStatuses();
            statuses = s.pStatuses;
            cboStatuses.ItemsSource = statuses;
            cboStatuses.DisplayMemberPath = "statusName";
            cboStatuses.Text = t.status;

            //fill in the ticket if there is one
            lblCustName.Content = t.custName;
            //show date on calendar
            if (t.LastContacted != "")
            {
                calLastContacted.DisplayDate = Convert.ToDateTime(t.LastContacted);
                calLastContacted.SelectedDate = Convert.ToDateTime(t.LastContacted);
            }
            
            //set other labels w/ ticket information
            txtNotes.Text = t.Notes;
            txtNotes.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            lblDateCreated.Content = t.DateCreated;
            lblDateCompleted.Content = t.DateCompleted;

            //get departments
            Departments d = new Departments();
            List<Department> departments = new List<Department>();
            d.GetDepartments();
            departments = d.pDepartments;
            cboDept.ItemsSource = departments;
            cboDept.DisplayMemberPath = "deptDescription";
            
            //get department for ticket
            cboDept.Text = d.GetNameFromID(t);

            //Get employee list and add to employees
            
            List<Employee> employees = new List<Employee>();
            Employees emp = new Employees();
            emp.GetEmployees();
            employees = emp.pEmployees;
            cboEmployee.ItemsSource = employees;
            cboEmployee.DisplayMemberPath = "empName";
            cboEmployee.Text = emp.GetNameFromSSN(t);

            //grab selected dept and get employees
            Department selDept = new Department();
            selDept = (Department)cboDept.SelectedItem;
            EmployeesByDept(selDept);
            cboAgent.DisplayMemberPath = "empName";
            cboAgent.Text = ticket.AssignedTo;
            
        }

        private void EmployeesByDept(Department dept)
        {
            Department selectedDept = dept;
            Employees emps = new Employees();
            List<Employee> empsForDept = new List<Employee>();
            emps.GetEmployees();
            empsForDept = emps.GetEmployeesForDept(selectedDept);
            cboAgent.ItemsSource = empsForDept;
            cboAgent.DisplayMemberPath = "empName";

        }

        private void UpdateCompletedDate(object sender, EventArgs e)
        {
            if (cboStatuses.Text == "Done")
            {
                lblDateCompleted.Content = DateTime.Now.ToShortDateString();
                ticket.DateCompleted = lblDateCompleted.Content.ToString();
            }
            else
            {
                lblDateCompleted.Content = "";
            }
            
        }

        private void DataWindow_Closing(object sender, EventArgs e)
        {
            Tickets tix = new Tickets();
            tix.GetTickets();
        }

        private void cboDept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department changedDept = (Department)cboDept.SelectedItem;
            EmployeesByDept(changedDept);
            ticket.deptId = changedDept.deptID;
        }

        private void btnSaveTicket_Click(object sender, RoutedEventArgs e)
        {
            //assign values to ticket
            ticket.AssignedTo = cboAgent.Text;
            ticket.LastContacted = calLastContacted.SelectedDate.ToString();
            ticket.Notes = txtNotes.Text;

            Tickets saveTicket = new Tickets();
            saveTicket.SaveTicket(ticket);
            lblSuccessMessage.Content = "Saved!";

            
        }

        private void cboEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee emp = (Employee)cboEmployee.SelectedItem;
            ticket.empSSN = emp.empSSN;
        }

        private void cboStatuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Status stat = (Status)cboStatuses.SelectedItem;
            ticket.statusID = stat.statusID;
        }

        
    }
}
