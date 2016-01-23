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
    /// Interaction logic for AddNewRoom.xaml
    /// </summary>
    public partial class AddNewRoom : Window
    {
        public AddNewRoom()
        {
            InitializeComponent();
        }

        bool checkBoxHasTv1 = false;
        bool checkBoxSmokingAllowed1 = false;

        //Button Click Cancel
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            AddNewRoom1.Close();
        }

        //Check Box Checked for TV
        private void checkBoxHasTv_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxHasTv1 = true;
        }

        //Check Box Checked for Smoking Allowed
        private void checkBoxSmokingAllowed_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxSmokingAllowed1 = true;
        }
    
        //Button Click Add Room
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int roomNumber = int.Parse(textBoxRoomNumber.Text);
                int numberOfBeds = int.Parse(textBoxNumberOfBeds.Text);

                RoomRepository.Create(roomNumber, numberOfBeds, checkBoxHasTv1, checkBoxSmokingAllowed1);

                AddNewRoom1.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was an invalid input. Please input only numbers for 'Room Number' and 'Number of Beds'.");
            }
        }
    }
}
