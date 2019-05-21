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

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs eventArgs)
        {
            if (sender == null) return;
            if (eventArgs.ButtonState != MouseButtonState.Pressed) return; //only react on pressed

            var dataGrid = sender as DataGrid;
            if (dataGrid == null || dataGrid.SelectedItems == null) return;

            if (dataGrid.SelectedItems.Count == 1)
            {
                var customer = dataGrid.SelectedItem as Customer;
                if (customer != null)
                {
                    CustomerInfoWindow customerWindow = new CustomerInfoWindow(customer, db);
                    customerWindow.Owner = this;
                    customerWindow.ShowDialog();
                }
            }
        }

        private void ProductsTab_ContextMenuOpening(object sender, ContextMenuEventArgs e)//products tab is opened
        {
            decimal minValue = db.Products.Min(p => p.ListPrice);
            decimal maxValue = db.Products.Max(p => p.ListPrice);

            maxValueSlider.Minimum = (double)minValue;
            maxValueSlider.Maximum = (double)maxValue;

            double currentMaxValue = maxValueSlider.Value;
            currentMaxValueTxBlk.Text = currentMaxValue.ToString();
        }

        partial class Products{
            public void displayProductDetails()
            {
                string details = string.Format($"Product ID:{0}");
            }
        }

        private void maxValueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double currentMaxValue = maxValueSlider.Value;
            currentMaxValueTxBlk.Text = currentMaxValue.ToString();

            var q = db.Products.Where(p => (decimal)p.ListPrice < (decimal)currentMaxValue);

            q2Lbx.ItemsSource = q.ToList();
        }

        private void lbxCustomersQ1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
