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

namespace Foop202FinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdventureLiteEntities db = new AdventureLiteEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEx1_Click_1(object sender, RoutedEventArgs e)
        {
            var q = db.Customers.OrderBy(c => c.CompanyName).Select(c => c.CompanyName);

            lbxCustomersQ1.ItemsSource = q.ToList();
        }
    }
}
