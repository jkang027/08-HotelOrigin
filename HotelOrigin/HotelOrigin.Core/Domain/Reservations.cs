using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOrigin.Core.Domain
{
    public class Reservation : INotifyPropertyChanged
    {
        public static int ReservationsIdCounter = 0;

        public Reservation()
        {
            ReservationsIdCounter++;
        }

        public int Id { get; set; }

        private object customer;
        public object Customer
        {
            get
            {
                return customer;
            }
            set
            {
                if (value != customer)
                {
                    customer = value;
                    OnPropertyChanged("Customers");
                }
            }
        }

        private object room;
        public object Room
        {
            get
            {
                return room;
            }
            set
            {
                if (value != room)
                {
                    room = value;
                    OnPropertyChanged("Rooms");
                }
            }
        }

        private DateTime checkInDate;
        public DateTime CheckInDate
        {
            get
            {
                return checkInDate;
            }
            set
            {
                if (value != checkInDate)
                {
                    checkInDate = value;
                    OnPropertyChanged("CheckInDate");
                }
            }
        }
        
        private DateTime checkOutDate;
        public DateTime CheckOutDate
        {
            get
            {
                return checkOutDate;
            }
            set
            {
                if (value != checkOutDate)
                {
                    checkOutDate = value;
                    OnPropertyChanged("CheckOutDate");
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
