using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using DriverLibrary;
using LocationLibrary;
using PassengerLibrary;
using AdminLibrary;

namespace RideLibrary
{
    public class Ride
    {
        Location start_location;
        Location end_location;
        double price;
        Driver driver;
        Passenger passenger;

        public Ride()
        {
            start_location = new Location();
            end_location = new Location();
            price = 0;
            driver = new Driver();
            passenger = new Passenger();
        }

        public Location Start_location 
        { 
            get { return start_location; }
            set { start_location = value; }
        }

        public Location End_location
        {
            get { return end_location; }
            set { end_location = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Driver Driver
        { 
            get { return driver; }
            set { driver = value; }
        }

        public Passenger Passenger
        {
            get { return passenger; }
            set { passenger = value; }
        }

        public void assignPassenger()
        {
            Console.Write("\nEnter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            passenger.Name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter PhoneNo: ");
            Console.ForegroundColor = ConsoleColor.Green;
            passenger.PhoneNo = Console.ReadLine();
            Console.ResetColor();
        }

        public void getLocations()
        {
            Console.Write("\nEnter Start Location: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string[] startLoc = Console.ReadLine().Split(',');
            float startLat = float.Parse(startLoc[0]);
            float startLong = float.Parse(startLoc[1]);
            start_location = new Location(startLat, startLong);
            Console.ResetColor();

            Console.Write("\nEnter End Location: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string[] endLoc = Console.ReadLine().Split(',');
            float endLat = float.Parse(endLoc[0]);
            float endLong = float.Parse(endLoc[1]);
            end_location = new Location(endLat, endLong);
            Console.ResetColor();
        }

        public double calculatePrice()
        {
            int fuel_price = 272;
            double distance = Math.Sqrt(Math.Pow(end_location.Latitude - start_location.Latitude, 2) 
                              + Math.Pow(end_location.Longitude - start_location.Longitude, 2));

            Console.Write("\nEnter Ride Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string rideType = Console.ReadLine();
            Console.ResetColor();

            if (rideType == "Car" || rideType == "car")
            {
                price = ((distance * fuel_price) / 15.0) + (20/100.0);
            }
            else if (rideType == "Bike" || rideType == "bike")
            {
                price = ((distance * fuel_price) / 50.0) + (5 / 100.0);
            }
            else if (rideType == "Rickshaw" || rideType == "rickshaw")
            {
                price = ((distance * fuel_price) / 35.0) + (10 / 100.0);
            }

            return price;
        }

        public void giveRating()
        {
            Console.Write("\nGive rating out of 5: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int rating = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (rating >= 1 && rating <= 5)
            {
                driver.Ratings.Add(rating);
            }
            else
            {
                Console.WriteLine("\nInvalid Input...Please give rating from 1-5.");
            }
        }

        public bool assignDriver(List<Driver> drivers_list)
        {
            Driver assignedDriver = null;
            double distance = double.MaxValue;

            foreach(Driver drivers in drivers_list)
            {
                if (drivers.Availability == true)
                {
                    double driverDistance = Math.Sqrt(Math.Pow(drivers.Curr_location.Latitude - start_location.Latitude, 2)
                              + Math.Pow(drivers.Curr_location.Longitude - start_location.Longitude, 2));
                    if (driverDistance <= distance) 
                    { 
                        distance = driverDistance;
                        assignedDriver = drivers;
                    }
                }
            }

            if (assignedDriver != null) 
            {
                driver = assignedDriver;
                driver.Availability = false;
                return true;
            }
            else
            {
                Console.WriteLine("\nNo driver available at this time...Try again after some time.");
                return false;
            }
        }

        public void bookRide(List<Driver> drivers)
        {
            assignPassenger();
            getLocations();
            double ridePrice = calculatePrice();
            Console.WriteLine("\n------------------THANK YOU-------------------");
            Console.WriteLine($"\nPrice for this ride is : {ridePrice}");
            Console.Write("\nEnter 'Y' if you want to Book the ride, enter 'N' if you want to cancel operation: ");
            char response = char.Parse(Console.ReadLine());
            if (response == 'Y' ||  response == 'y')
            {
                Console.WriteLine("\nHappy Travel...!");
                bool driverStatus = assignDriver(drivers);
                if (driverStatus) 
                {
                    giveRating();
                }
            }
            else
            {
                Console.WriteLine("\nYour Ride is Cancelled.");
            }
            
        }

    }
}

