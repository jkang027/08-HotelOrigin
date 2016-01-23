﻿using HotelOrigin.Core.Repository;
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
    /// Interaction logic for UpdateExistingRoom.xaml
    /// </summary>
    public partial class UpdateExistingRoom : Window
    {
        public UpdateExistingRoom()
        {
            InitializeComponent();
            string textBoxRoomNumberString = MainWindow.currentlySelectedRoom.RoomNumber.ToString();
            string textBoxNumberOfBedsString = MainWindow.currentlySelectedRoom.NumberOfBeds.ToString();

            if (MainWindow.currentlySelectedRoom.HasTv == true)
            {
                checkBoxHasTv.IsChecked = true;
                hasTv = true;
            }

            if (MainWindow.currentlySelectedRoom.SmokingAllowed == true)
            {
                checkBoxSmokingAllowed.IsChecked = true;
                smokingAllowed = true;
            }

            textBoxRoomNumber.Text = textBoxRoomNumberString;
            textBoxNumberOfBeds.Text = textBoxNumberOfBedsString;
        }

        bool hasTv = false;
        bool smokingAllowed = false;
        
        private void checkBoxHasTv_Checked(object sender, RoutedEventArgs e)
        {
            hasTv = true;
        }
        private void checkBoxHasTv_Unchecked(object sender, RoutedEventArgs e)
        {
            hasTv = false;
        }


        private void checkBoxSmokingAllowed_Checked(object sender, RoutedEventArgs e)
        {
            smokingAllowed = true;
        }
        private void checkBoxSmokingAllowed_Unchecked(object sender, RoutedEventArgs e)
        {
            smokingAllowed = false;
        }

        //Button Cancel Click
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            UpdateExistingRoom1.Close();
        }

        //Button Update Click
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int roomNumber = int.Parse(textBoxRoomNumber.Text);
            int numberOfBeds = int.Parse(textBoxNumberOfBeds.Text);

            RoomRepository.Update(MainWindow.currentlySelectedRoom, roomNumber, numberOfBeds, hasTv, smokingAllowed);

            UpdateExistingRoom1.Close();
        }

        
    }
}
