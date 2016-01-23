using HotelOrigin.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace HotelOrigin.Core.Repository
{
    public class RoomRepository
    {
        private static ObservableCollection<Room> rooms = new ObservableCollection<Room>();

        //Create
        public static Room Create(int roomNumber, int numberOfBeds, bool hasTv, bool smokingAllowed)
        {
            Room newRoom = new Room();

            newRoom.Id = Room.RoomsIdCounter;

            newRoom.RoomNumber = roomNumber;
            newRoom.NumberOfBeds = numberOfBeds;
            newRoom.HasTv = hasTv;
            newRoom.SmokingAllowed = smokingAllowed;
            rooms.Add(newRoom);

            return newRoom;
        }

        //Read
        public static Room GetById(int id)
        {
            return rooms.FirstOrDefault(c => c.Id == id);
        }

        public static ObservableCollection<Room> GetAll()
        {
            return rooms;
        }

        //Update
        public static void Update(Room room, int roomNumber, int numberOfBeds, bool hasTv, bool smokingAllowed)
        {
            room.RoomNumber = roomNumber;
            room.NumberOfBeds = numberOfBeds;
            room.HasTv = hasTv;
            room.SmokingAllowed = smokingAllowed;
        }

        //Delete
        public static void Delete(int id)
        {
            var room = GetById(id);
            rooms.Remove(room);
        }
        public static void Delete(Room room)
        {
            rooms.Remove(room);
        }

        //Save to Disk
        public static void SaveToDisk()
        {
            string json = JsonConvert.SerializeObject(rooms);

            File.WriteAllText("rooms.json", json);
        }

        //Load from Disk
        public static void LoadFromDisk()
        {
            if (File.Exists("rooms.json"))
            {
                string json = File.ReadAllText("rooms.json");

                rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(json);
            }
        }
    }
}
