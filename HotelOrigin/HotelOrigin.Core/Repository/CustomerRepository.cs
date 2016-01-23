using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelOrigin;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;

namespace HotelOrigin.Core.Domain.Repository
{
    public class CustomerRepository
    {
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        //Create
        public static Customer Create(string lastName, string firstName, string telephone, string emailAddress)
        {
            Customer newCustomer = new Customer();

            newCustomer.Id = Customer.CustomersIdCounter;
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            newCustomer.TelephoneNumber = telephone;
            newCustomer.EmailAddress = emailAddress;
            customers.Add(newCustomer);

            return newCustomer;
        }

        //Read
        public static Customer GetById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public static ObservableCollection<Customer> GetAll()
        {
            return customers;
        }

        //Update
        public static void Update(Customer customer, string lastName, string firstName, string telephone, string emailAddress)
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
        public static void Delete(Customer customer)
        {
            customers.Remove(customer);
        }

        //Save to Disk
        public static void SaveToDisk()
        {
            string json = JsonConvert.SerializeObject(customers);

            File.WriteAllText("customers.json", json);
        }

        //Load from Disk
        public static void LoadFromDisk()
        {
            if(File.Exists("customers.json"))
            {
                string json = File.ReadAllText("customers.json");

                customers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(json);
            }
        }
    }
}
