using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRealex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
           

            hotel.AddRoom(new Room(1, "Single", 1500, true));
            hotel.AddRoom(new Room(2, "Single", 1500, true));
            hotel.AddRoom(new Room(3, "Double", 2500, true));
            hotel.AddRoom(new Room(4, "Double", 2500, true));
            hotel.AddRoom(new Room(5, "Single Ac", 2500, true));
            hotel.AddRoom(new Room(6, "Double AC", 3500, true));
            hotel.AddRoom(new Room(7, "Family", 4500, true));

            while (true)
            {
                Console.WriteLine("Registration - 1");
                Console.WriteLine("Login - 2");
                Console.WriteLine("Exit - 3");
                Console.WriteLine("Choose an Option");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("User Name: ");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Phone number: ");
                    string phoneNumber = Console.ReadLine();

                    var user = new User()
                    {
                        UserName = userName,
                        Password = password,
                        Email = email,
                        PhoneNumber = phoneNumber

                    };

                    hotel.RegisterUser(user);
                    UserMenu(hotel, user);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter your User Name");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Enter your Password");
                    string password = Console.ReadLine();

                    var user = hotel.LoginUser(userName, password);

                    if (user != null)
                    {
                        UserMenu(hotel,user);
                    }
                }
                else if (option == 3)
                {
                    break;
                }
            }

        }

        public static void UserMenu(Hotel hotel, User user)
        {
            while (true) {
                Console.WriteLine("WellCome to Hotel Relax");
                Console.WriteLine("1. See Availble Rooms");
                Console.WriteLine("2. Book a Room");
                Console.WriteLine("3. View Booking History");
                Console.WriteLine("4. Payment");
                Console.WriteLine("5. logout");
                Console.WriteLine("Chosse an option: ");
                var option = Console.ReadLine();

                if (option == "1")
                {
                    hotel.AvailbaleRoom();
                }
                else if (option == "2")
                {
                    Console.WriteLine("Enter Room ID");
                    int roomId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Cheak in Date (YYYY-MM-DD)");
                    DateTime cheakIn = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Cheak Out date  (YYYY-MM-DD)");
                    DateTime cheackOut = DateTime.Parse(Console.ReadLine());

                    var booking = new Booking
                    {
                        BookingId = new Random().Next(1000),
                        UserId = user.UserId,
                        RoomId = roomId,
                        CheckInDate = cheakIn,
                        CheckOutDate = cheackOut,
                        TotalAmount = (cheackOut - cheakIn).Days* hotel.rooms.Find(r => r.RoomId == roomId).price,
                        BookingStatus = "Confirmed"
                    };

                    hotel.MakeBooking(booking);
                }
                else if (option == "3")
                {
                    hotel.BookingDetais(user.UserId);
                }
                else if (option == "4")
                {
                    var booking = hotel.bookings.Find(r=> r.UserId == user.UserId);
                    var payment = new Payment
                    {
                        PaymentId = new Random().Next(1000),
                        BookingId = booking.BookingId,
                        PaymentDate = DateTime.Now,
                        PaymentStatus = "Complete",
                        Amount = booking.TotalAmount,
                    };
                    hotel.Makepayment(payment,user);

                }
                else if (option == "5")
                {
                    break;
                }

            }
           
        }
    }
}
