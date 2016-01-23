using HotelOrigin.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace HotelOrigin.Core.Repository
{
    public class ReservationRepository
    {
        private static ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();

        //Create
        public static Reservation Create(object customer, object room, DateTime checkInDate, DateTime checkOutDate)
        {
            Reservation newReservation = new Reservation();

            newReservation.Id = Reservation.ReservationsIdCounter;
            newReservation.Customer = customer;
            newReservation.Room = room;
            newReservation.CheckInDate = checkInDate;
            newReservation.CheckOutDate = checkOutDate;
            reservations.Add(newReservation);

            return newReservation;
        }

        //Read
        public static Reservation GetById(int id)
        {
            return reservations.FirstOrDefault(c => c.Id == id);
        }

        public static ObservableCollection<Reservation> GetAll()
        {
            return reservations;
        }

        //Update
        public static void Update(Reservation reservation, object customer, object room, DateTime checkInDate, DateTime checkOutDate)
        {
            reservation.Customer = customer;
            reservation.Room = room;
            reservation.CheckInDate = checkInDate;
            reservation.CheckOutDate = checkOutDate;
        }

        //Delete
        public static void Delete(int id)
        {
            var reservation = GetById(id);
            reservations.Remove(reservation);
        }
        public static void Delete(Reservation reservation)
        {
            reservations.Remove(reservation);
        }

        //Save to Disk
        public static void SaveToDisk()
        {
            string json = JsonConvert.SerializeObject(reservations);

            File.WriteAllText("reservations.json", json);
        }

        //Load from Disk
        public static void LoadFromDisk()
        {
            if (File.Exists("reservations.json"))
            {
                string json = File.ReadAllText("reservations.json");

                reservations = JsonConvert.DeserializeObject<ObservableCollection<Reservation>>(json);
            }
        }
    }
}
