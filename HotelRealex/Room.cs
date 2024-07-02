using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRealex
{
    internal class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; }           
        public decimal price { get; set; }
        public bool IsAvailable { get; set; }


        public Room(int RoomId, string RoomType, decimal price, bool IsAvailable) {
        
            this.RoomId = RoomId;
            this.RoomType = RoomType;
            this.price = price;
            this.IsAvailable = IsAvailable;       
        
        }

        public void RoomDetails()
        {
            Console.WriteLine("Room ID: "+ RoomId);
            Console.WriteLine("Room Type: " + RoomType);
            Console.WriteLine("Room Price: "+ price);
            Console.WriteLine();
        }



    }
}
