using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOrigin.Core.Domain
{
    public class Room : INotifyPropertyChanged
    {
        public static int IdCounter = 0;

        public Room()
        {
            IdCounter++;
        }
        
        public int Id { get; set; }

        private int roomNumber;
        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                if (value != roomNumber)
                {
                    roomNumber = value;
                    OnPropertyChanged("RoomNumber");
                }
            }
        }

        private int numberOfBeds;
        public int NumberOfBeds
        {
            get
            {
                return numberOfBeds;
            }
            set
            {
                if (value != numberOfBeds)
                {
                    numberOfBeds = value;
                    OnPropertyChanged("NumberOfBeds");
                }
            }
        }

        private bool hasTv;
        public bool HasTv
        {
            get
            {
                return hasTv;
            }
            set
            {
                if (value != hasTv)
                {
                    hasTv = value;
                    OnPropertyChanged("HasTv");
                }
            }
        }

        private bool smokingAllowed;
        public bool SmokingAllowed
        {
            get
            {
                return smokingAllowed;
            }
            set
            {
                if (value != smokingAllowed)
                {
                    smokingAllowed = value;
                    OnPropertyChanged("SmokingAllowed");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, e);
        }
    }
}
