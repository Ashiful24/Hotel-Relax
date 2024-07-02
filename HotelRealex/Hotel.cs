using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelRealex
{
    internal class Hotel
    {
        public List<Room> rooms = new List<Room>();
        public List<User> users = new List<User>();
        public List<Booking> bookings = new List<Booking>();



        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            rooms.Remove(room);
        }

        public void AvailbaleRoom()
        {
            foreach (Room room in rooms)
            {
                if (room.IsAvailable == true)
                {
                    room.RoomDetails();
                }
            }
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
            Console.WriteLine("User Registred successfully");
        }

        public User LoginUser(String UserName, String Password)
        {

            foreach (var user in users)
            {
                if (user.UserName == UserName && user.Password == Password)
                {

                    Console.WriteLine("Log in Sucessfull");
                    return user;
                }
            }
            Console.WriteLine("Login Failed");
            return null;
        }

        public void MakeBooking(Booking booking)
        {
            var room = rooms.Find(r=> r.RoomId == booking.RoomId);

            if (room != null && room.IsAvailable)
            {
                room.IsAvailable = false;
                bookings.Add(booking);
                Console.WriteLine("Bookin made Sucessful");
            }
            else
            {
                Console.WriteLine("Room is not available");
            }
           
        }

        public void BookingDetais(int userId)
        {
            var userBokkings = bookings.FindAll(r=> r.UserId == userId);

            foreach (var user in userBokkings)
            {
                Console.WriteLine("Booking Id:"+user.BookingId);
                Console.WriteLine("Room Id: "+user.RoomId);
                Console.WriteLine("Check In: "+user.CheckInDate);
                Console.WriteLine("Check Out: "+user.CheckOutDate);
                Console.WriteLine("Ammount: "+user.TotalAmount);
            }

        }

        public void Makepayment(Payment payment, User user)
        {
            Console.WriteLine($"Payment sucessfull" );
        }



    }
}
