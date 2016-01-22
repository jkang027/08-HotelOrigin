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
    /// Interaction logic for ConfirmDeleteCustomer.xaml
    /// </summary>
    public partial class ConfirmDeleteCustomer : Window
    {
        public ConfirmDeleteCustomer()
        {
            InitializeComponent();
            textBlock.Text = ("Are you sure you want to delete the customer: \n" + MainWindow.currentlySelectedCustomer.LastName + ", " + MainWindow.currentlySelectedCustomer.FirstName + "\nCustomer ID# " + MainWindow.currentlySelectedCustomer.Id + "?");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerRepository.Delete(MainWindow.currentlySelectedCustomer.Id);
                ConfirmDeletionWindow.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was no selected customer.");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDeletionWindow.Close();
        }
    }
}