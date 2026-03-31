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

        public AddEmployeeWindow()
        {
            InitializeComponent();

            LoadData();
        }

        void LoadData()
        {
            DepartmentBox.ItemsSource = db.Departments.ToList();
            PositionBox.ItemsSource = db.Positions.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Employees employee = new Employees();

            employee.FirstName = FirstNameBox.Text;
            employee.LastName = LastNameBox.Text;
            employee.Phone = PhoneBox.Text;
            employee.HireDate = HireDatePicker.SelectedDate;

            var department = DepartmentBox.SelectedItem as Departments;
            var position = PositionBox.SelectedItem as Positions;

            if (department != null)
                employee.DepartmentId = department.Id;

            if (position != null)
                employee.PositionId = position.Id;

            db.Employees.Add(employee);
            db.SaveChanges();

            this.Close();
        }
    }
}