using SchoolHumanResourcesDepartment.Model;
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

namespace SchoolHumanResourcesDepartment.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        SchoolHumanResourcesDepartmentNormEntities1 db = new SchoolHumanResourcesDepartmentNormEntities1();

        Employees currentEmployee;

        public AddEmployeeWindow(Employees employee = null)
        {
            InitializeComponent();

            LoadData();

            currentEmployee = employee;

            if (currentEmployee != null)
            {
                FirstNameBox.Text = currentEmployee.FirstName;
                LastNameBox.Text = currentEmployee.LastName;
                PhoneBox.Text = currentEmployee.Phone;
                HireDatePicker.SelectedDate = currentEmployee.HireDate;

                DepartmentBox.SelectedValue = currentEmployee.DepartmentId;
                PositionBox.SelectedValue = currentEmployee.PositionId;
            }
        }

        void LoadData()
        {
            DepartmentBox.ItemsSource = db.Departments.ToList();
            PositionBox.ItemsSource = db.Positions.ToList();

            DepartmentBox.DisplayMemberPath = "Name";
            DepartmentBox.SelectedValuePath = "Id";

            PositionBox.DisplayMemberPath = "Name";
            PositionBox.SelectedValuePath = "Id";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (currentEmployee == null)
            {
                Employees employee = new Employees();

                employee.FirstName = FirstNameBox.Text;
                employee.LastName = LastNameBox.Text;
                employee.Phone = PhoneBox.Text;
                employee.HireDate = HireDatePicker.SelectedDate;
                employee.DepartmentId = (int)DepartmentBox.SelectedValue;
                employee.PositionId = (int)PositionBox.SelectedValue;

                db.Employees.Add(employee);
            }
            else
            {
                var emp = db.Employees.Find(currentEmployee.Id);

                emp.FirstName = FirstNameBox.Text;
                emp.LastName = LastNameBox.Text;
                emp.Phone = PhoneBox.Text;
                emp.HireDate = HireDatePicker.SelectedDate;
                emp.DepartmentId = (int)DepartmentBox.SelectedValue;
                emp.PositionId = (int)PositionBox.SelectedValue;
            }

            db.SaveChanges();
            this.Close();
        }
    }
}