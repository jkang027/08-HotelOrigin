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
using HotelOrigin.Core.Repository;

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
            dataGridRoom.ItemsSource = RoomRepository.GetAll();
            dataGridReservations.ItemsSource = ReservationRepository.GetAll();
        }

        //On Window Closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CustomerRepository.SaveToDisk();
            RoomRepository.SaveToDisk();
            ReservationRepository.SaveToDisk();
        }

        //DataGrid Currently Selected
        public static Customer currentlySelectedCustomer = null;
        public static Room currentlySelectedRoom = null;
        public static Reservation currentlySelectedReservation = null;

        //DataGrid Selection changed
        public void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentlySelectedCustomer = (Customer)dataGrid.SelectedItem;
            currentlySelectedRoom = (Room)dataGridRoom.SelectedItem;
            currentlySelectedReservation = (Reservation)dataGridReservations.SelectedItem;
        }

        //Customer Management ###################################################################################################
        
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

        //DataGrid Event Double Click to Edit/Update Customer Information
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                UpdateCustomerInfo updateCustomer = new UpdateCustomerInfo();
                updateCustomer.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was no selected customer to edit.");
            }
        }

        //Room Management #######################################################################################################

        //Button Add New Room
        private void button_ClickAddNewRoom(object sender, RoutedEventArgs e)
        {
            AddNewRoom newRoom = new AddNewRoom();
            newRoom.ShowDialog();
        }
        
        //Button Delete Existing Room
        private void button_ClickDeleteExistingRoom(object sender, RoutedEventArgs e)
        {
            try
            {
                ConfirmDeletionRoom deleteRoom = new ConfirmDeletionRoom();
                deleteRoom.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show("You did not select a room to delete.");
            }
        }

        //DataGrid Event Double Click to Edit/Update Room Information
        private void dataGridRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                UpdateExistingRoom updateRoom = new UpdateExistingRoom();
                updateRoom.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was no selected room to edit.");
            }
        }

        //Reservation Management ###################################################################################################

        //Button Add New Reservation
        private void buttonAddNewReservation_Click(object sender, RoutedEventArgs e)
        {
            AddNewReservation newReservation = new AddNewReservation();
            newReservation.ShowDialog();
        }

        private void buttonCancelReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConfirmCancelReservation cancelReservation = new ConfirmCancelReservation();
                cancelReservation.ShowDialog();
            }
            catch
            {
                MessageBox.Show("There was no selected reservation to cancel.");
            }
        }
    }
}