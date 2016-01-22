using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelOrigin;
using System.Collections.ObjectModel;

namespace HotelOrigin.Core.Domain.Repository
{
    public class CustomerRepository
    {
        private static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        //Create
        public static Customer Create()
        {
            Customer newCustomer = new Customer();

            customers.Add(newCustomer);

            return new Customer();
        }

        //Read
        public static Customer GetById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);

            /*
            Customer foundCustomer = null;
            
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers.ElementAt(i).Id == id)
                    foundCustomer = customers.ElementAt(i);
            }
        return foundCustomer;
        */

        }

        public static ObservableCollection<Customer> GetAll()
        {
            return customers;
        }

        //Update
        public static void Update(Customer customer, string firstName, string lastName, string telephone, string emailAddress)
        {
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.TelephoneNumber = telephone;
            customer.EmailAddress = emailAddress;
        }

        //Delete
        public static void Delete(int id)
        {
            var customer = GetById(id);
            customers.Remove(customer);
        }
    }
}
