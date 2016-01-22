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
using HotelOrigin.Core;
using HotelOrigin.Core.Domain.Repository;
using HotelOrigin.Core.Domain;

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = CustomerRepository.GetAll();
        }
        
        //On Window Closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CustomerRepository.SaveToDisk();
        }

        //DataGrid Currently Selected
        public static Customer currentlySelectedCustomer = null;

        //DataGrid Selection changed
        public void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentlySelectedCustomer = (Customer)dataGrid.SelectedItem;
        }

        //DataGrid Event Double Click to Edit/Update Customer Information
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UpdateCustomerInfo updateCustomer = new UpdateCustomerInfo();
            updateCustomer.ShowDialog();
        }

        //Button Add New Customer
        private void button_ClickAddNewCustomer(object sender, RoutedEventArgs e)
        {
            AddNewCustomerWindow newCustomer = new AddNewCustomerWindow();
            newCustomer.ShowDialog();
        }

        //Button Delete Existing Customer
        private void buttonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConfirmDeleteCustomer deleteCustomer = new ConfirmDeleteCustomer();
                deleteCustomer.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show("You did not select a customer to delete.");
            }
        }
    }
}