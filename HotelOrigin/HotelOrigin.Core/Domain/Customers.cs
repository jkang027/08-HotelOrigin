using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOrigin.Core.Domain
{
    public class Customer : INotifyPropertyChanged
    {
        public static int IdCounter = 0;

        public Customer()
        {
            IdCounter++;
        }

        public int Id { get; set; }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if(value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                if (value != emailAddress)
                {
                    emailAddress = value;
                    OnPropertyChanged("EmailAddress");
                }
            }
        }

        private string telephoneNumber;
        public string TelephoneNumber
        {
            get
            {
                return telephoneNumber;
            }
            set
            {
                if (value != telephoneNumber)
                {
                    telephoneNumber = value;
                    OnPropertyChanged("TelephoneNumber");
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