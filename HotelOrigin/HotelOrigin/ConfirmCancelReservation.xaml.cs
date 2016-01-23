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
    /// Interaction logic for ConfirmCancelReservation.xaml
    /// </summary>
    public partial class ConfirmCancelReservation : Window
    {
        public ConfirmCancelReservation()
        {
            InitializeComponent();
            textBlock.Text = "Are you sure you want to cancel this reservation? ID# " + MainWindow.currentlySelectedReservation.Id;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReservationRepository.Delete(MainWindow.currentlySelectedReservation);
                ConfirmCancelReservation1.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was no selected reservation.");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConfirmCancelReservation1.Close();
        }
    }
}
