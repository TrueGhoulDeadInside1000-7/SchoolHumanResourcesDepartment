using SchoolHumanResourcesDepartment.Model;
using SchoolHumanResourcesDepartment.View.Pages;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new EmployeesPage());
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeesPage());
        }

        private void Departments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DepartmentsPage());
        }
        private void Positions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PositionsPage());
        }
    }
}