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

namespace Foop202FinalExam
{
    /// <summary>
    /// Interaction logic for CustomerInfoWindow.xaml
    /// </summary>
    public partial class CustomerInfoWindow : Window
    {
        Customer customer;
        AdventureLiteEntities db;

        public CustomerInfoWindow(Customer c, AdventureLiteEntities db)
        {
            this.customer = c;
            this.db = db;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Owner;
            lastModifiedLbl.Content = customer.ModifiedDate;
            PhoneTxtBx.Text = customer.Phone;
            EmailTxtBx.Text = customer.EmailAddress;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneTxtBx.Text != null)// if text box is not null 
            {
                customer.Phone = PhoneTxtBx.Text;
                customer.ModifiedDate = DateTime.Now;//update date if there was text in the text box
            }
            if (EmailTxtBx.Text != null)// if text box is not null 
            {
                customer.EmailAddress = EmailTxtBx.Text;
                customer.ModifiedDate = DateTime.Now;//update date if there was text in the text box
            }
            db.SaveChanges();//save channges to database
            this.Close();//close window
        }
    }
}
