using HotelOrigin.Core.Domain.Repository;
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

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for UpdateCustomerInfo.xaml
    /// </summary>
    public partial class UpdateCustomerInfo : Window
    {
        public UpdateCustomerInfo()
        {
            InitializeComponent();
            textBoxFirstName.Text = MainWindow.currentlySelectedCustomer.FirstName;
            textBoxLastName.Text = MainWindow.currentlySelectedCustomer.LastName;
            textBoxEmail.Text = MainWindow.currentlySelectedCustomer.EmailAddress;
            textBoxPhoneNumber.Text = MainWindow.currentlySelectedCustomer.TelephoneNumber;
        }

        //Click Button Update
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            CustomerRepository.Update(MainWindow.currentlySelectedCustomer, textBoxLastName.Text, textBoxFirstName.Text, textBoxPhoneNumber.Text, textBoxEmail.Text);

            UpdateCustomerInfo1.Close();
        }

        //Click Button Cancel
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            UpdateCustomerInfo1.Close();
        }
    }
}