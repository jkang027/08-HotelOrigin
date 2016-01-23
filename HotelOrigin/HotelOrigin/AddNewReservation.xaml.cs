using HotelOrigin.Core.Domain.Repository;
using HotelOrigin.Core.Repository;
using HotelOrigin.Core.Domain;
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
    /// Interaction logic for AddNewReservation.xaml
    /// </summary>
    public partial class AddNewReservation : Window
    {
        public AddNewReservation()
        {
            InitializeComponent();
            comboBoxCustomer.ItemsSource = CustomerRepository.GetAll();
            comboBoxRoom.ItemsSource = RoomRepository.GetAll();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            AddNewReservationWindow.Close();
        }

        Customer selectedCustomer = null;
        Room selectedRoom = null;

        private void comboBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)comboBoxCustomer.SelectedItem;
        }
        private void comboBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRoom = (Room)comboBoxRoom.SelectedItem;
        }

        private void buttonCancel_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime checkInDate = DateTime.Parse(textBoxCheckInDate.Text);
                DateTime checkOutDate = DateTime.Parse(textBoxCheckOutDate.Text);

                ReservationRepository.Create(selectedCustomer, selectedRoom, checkInDate, checkOutDate);
                AddNewReservationWindow.Close();
            }
            catch
            {
                MessageBox.Show("Please input check in/out date(s) in the following format. (Ex XX/XX/XXXX)");
            }
        }
    }
}
