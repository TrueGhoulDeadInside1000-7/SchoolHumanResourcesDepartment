using SchoolHumanResourcesDepartment.Model;
using SchoolHumanResourcesDepartment.View.Windows;
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

namespace SchoolHumanResourcesDepartment.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        SchoolHumanResourcesDepartmentNormEntities1 db = new SchoolHumanResourcesDepartmentNormEntities1();

        public EmployeesPage()
        {
            InitializeComponent();
            LoadEmployees();
        }

        void LoadEmployees()
        {
            ApplySort();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = SearchBox.Text.ToLower();

            EmployeesList.ItemsSource = db.Employees
                .Where(emp => emp.FirstName.ToLower().Contains(search)
                           || emp.LastName.ToLower().Contains(search))
                .ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow window = new AddEmployeeWindow();
            window.ShowDialog();

            LoadEmployees();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var employee = EmployeesList.SelectedItem as Employees;

            if (employee == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            LoadEmployees();
        }
        void ApplySort()
        {
            var employees = db.Employees.ToList();

            if (SortBox.SelectedIndex == 1)
                employees = employees.OrderBy(e => e.FirstName).ToList();

            if (SortBox.SelectedIndex == 2)
                employees = employees.OrderBy(e => e.LastName).ToList();

            if (SortBox.SelectedIndex == 3)
                employees = employees.OrderBy(e => e.HireDate).ToList();

            EmployeesList.ItemsSource = employees;
        }
        private void Sort_Changed(object sender, SelectionChangedEventArgs e)
        {
            ApplySort();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var employee = EmployeesList.SelectedItem as Employees;

            if (employee == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }

            AddEmployeeWindow window = new AddEmployeeWindow(employee);
            window.ShowDialog();

            LoadEmployees();
        }
    }
}