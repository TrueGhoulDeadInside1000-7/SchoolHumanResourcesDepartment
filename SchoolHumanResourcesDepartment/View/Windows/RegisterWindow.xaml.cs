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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        SchoolHumanResourcesDepartmentNormEntities1 db = new SchoolHumanResourcesDepartmentNormEntities1();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            if (login == "" || password == "")
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            var existingUser = db.Admins.FirstOrDefault(a => a.Login == login);

            if (existingUser != null)
            {
                MessageBox.Show("Пользователь уже существует");
                return;
            }

            Admins newAdmin = new Admins()
            {
                Login = login,
                Password = password,
            };

            db.Admins.Add(newAdmin);
            db.SaveChanges();

            MessageBox.Show("Регистрация успешна");

            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}