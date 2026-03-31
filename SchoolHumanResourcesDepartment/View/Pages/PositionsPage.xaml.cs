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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolHumanResourcesDepartment.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PositionsPage.xaml
    /// </summary>
    public partial class PositionsPage : Page
    {
        SchoolHumanResourcesDepartmentNormEntities1 db = new SchoolHumanResourcesDepartmentNormEntities1();

        public PositionsPage()
        {
            InitializeComponent();

            PositionsList.ItemsSource = db.Positions.ToList();
        }
    }
}