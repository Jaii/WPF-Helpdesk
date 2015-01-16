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
    /// Interaction logic for NewTicket.xaml
    /// </summary>
    public partial class NewTicket : Window
    {
        private Ticket ticket = new Ticket();
        private Customers custs = new Customers();
        private Departments depts = new Departments();
        private Status selStatus = new Status();
        Employee selAgent = new Employee();
        public NewTicket()
        {

            InitializeComponent();

            //fill in what needs to be filled in
            custs.GetCustomers();
            cboCustomers.ItemsSource = custs.pCustomers;
            cboCustomers.DisplayMemberPath = "custName";

            depts.GetDepartments();
            cboDept.ItemsSource = depts.pDepartments;
            cboDept.DisplayMemberPath = "deptDescription";
            
            Statuses statuses = new Statuses();
            statuses.GetStatuses();
            cboStatuses.ItemsSource = statuses.pStatuses;
            cboStatuses.DisplayMemberPath = "statusName";

            Employees employees = new Employees();
            employees.GetEmployees();
            cboEmployee.ItemsSource = employees.pEmployees;
            cboEmployee.DisplayMemberPath ="empName";

            lblDateCreated.Content = DateTime.Now.ToShortDateString();


        }

        private void cboCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selectedCust = new Customer();
            selectedCust = (Customer)cboCustomers.SelectedItem;

        }

        private void checkForCust()
        {
            bool custExists = false;

            foreach (Customer c in custs.pCustomers)
            {
                if (cboCustomers.Text == c.custName)
                {
                    ticket.custId = c.cID;
                    ticket.custName = c.custName;
                    custExists = true;
                    break;
                }

            }

            if (custExists == false)
            {
                Customer newCust = new Customer();
                newCust.cID = Guid.NewGuid();
                newCust.custName = cboCustomers.Text;
                newCust.CreateCust(newCust);
                ticket.custId = newCust.cID;
                ticket.custName = newCust.custName;
            }

            
        }

        private void btnSaveTicket_Click(object sender, RoutedEventArgs e)
        {


            if (cboCustomers.Text == "")
            {
                MessageBox.Show("Pick a customer!");
            }

            else if(cboDept.SelectedItem == null)
            {
                MessageBox.Show("Pick a department!");
            }

            else if(cboEmployee.SelectedItem == null)
            {
                MessageBox.Show("Pick the employee who created this ticket!");
            }

            else if(cboStatuses.SelectedItem == null)
            {
                MessageBox.Show("Pick a status!");
            }


            else { 
                    try
                    {
                        checkForCust();
                        ticket.Id = Guid.NewGuid();
                        ticket.DateCompleted = lblDateCompleted.Content.ToString();
                        ticket.DateCreated = DateTime.Now.ToShortDateString();
                        Department dept = new Department();
                        dept = (Department)cboDept.SelectedItem;
                        ticket.deptId = dept.deptID;
                        Employee selCreatedEmp = (Employee)cboEmployee.SelectedItem;
                        ticket.empSSN = selCreatedEmp.empSSN;
                        ticket.LastContacted = calLastContacted.SelectedDate.ToString();
                        ticket.Notes = txtNotes.Text;
                        
                        selAgent = (Employee)cboAgent.SelectedItem;
                        ticket.AssignedTo = selAgent.empName;
                        
                        selStatus = (Status)cboStatuses.SelectedItem;
                        ticket.status = selStatus.statusName;
                        ticket.statusID = selStatus.statusID;
                        ticket.CreateTicket(ticket);
                        lblSuccessMessage.Content = "Saved";

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

            }

        }

        private void cboDept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees emps = new Employees();
            emps.GetEmployees();
            List<Employee> empList = emps.GetEmployeesForDept((Department)cboDept.SelectedItem);
            cboAgent.ItemsSource = empList;
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

        private void cboEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selAgent = (Employee)cboAgent.SelectedItem;
        }


    }
}
