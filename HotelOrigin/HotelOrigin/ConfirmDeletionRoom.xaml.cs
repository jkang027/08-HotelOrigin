using HotelOrigin.Core.Repository;
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
    /// Interaction logic for ConfirmDeletionRoom.xaml
    /// </summary>
    public partial class ConfirmDeletionRoom : Window
    {
        public ConfirmDeletionRoom()
        {
            InitializeComponent();
            textBlock.Text = ("Are you sure you want to delete the room: \nRoom Number: " + MainWindow.currentlySelectedRoom.RoomNumber + "? \nRoom ID Number: " + MainWindow.currentlySelectedRoom.Id);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomRepository.Delete(MainWindow.currentlySelectedRoom.Id);
                ConfirmRoomDeletion.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was no selected customer.");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConfirmRoomDeletion.Close();
        }
    }
}
