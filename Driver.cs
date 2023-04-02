using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using LocationLibrary;
using VehicleLibrary;

namespace DriverLibrary
{
    public class Driver
    {
        static int IdCounter = -1;
        int driverID;
        string name;
        int age;
        string gender;
        string address;
        string phoneNo;
        Location curr_location;
        Vehicle driVehicle;
        List<int> ratings;
        bool availability;

        public Driver() 
        {
            driverID = ++IdCounter;
            name = string.Empty;
            age = 0;
            gender = string.Empty;
            address = string.Empty;
            phoneNo = string.Empty;
            curr_location = new Location();
            driVehicle = new Vehicle();
            ratings = new List<int>();
            availability = false;
        }

        public Driver(string driverName, int driverAge, string driverGender, string driverAddress, string driverPhoneNo, Location driverCurr_location, Vehicle driverVehicle, int driverRating, bool availabilityStatus)
        {
            name = driverName;
            age = driverAge;
            gender = driverGender;
            address = driverAddress;
            phoneNo = driverPhoneNo;
            curr_location = driverCurr_location;
            driVehicle = driverVehicle;
            ratings.Add(driverRating);
            availability = availabilityStatus;
        }

        private bool containsOnlyDigits(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public int DriverID
        {
            get { return driverID; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        { 
            get { return gender; } 
            set { gender = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNo
        { 
            get { return phoneNo; } 
            set 
            {
                if (containsOnlyDigits(phoneNo))
                    phoneNo = value;
                else
                    Console.WriteLine("Invalid phone number format. Phone number must contain only digits.");
            }
        }

        public Location Curr_location
        {
            get { return curr_location; }
            set { curr_location = value; }
        }

        public Vehicle DriVehicle
        {
            get { return  driVehicle; }
            set { driVehicle = value; }
        }

        public List<int> Ratings
        {  
            get { return ratings; } 
            set { ratings = value; }
        }

        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }
        public void updateAvailability()
        {
            Console.Write("\nAre you available? (Y/N): ");
            Console.ForegroundColor = ConsoleColor.Green;
            char status = Convert.ToChar(Console.ReadLine());
            Console.ResetColor();
            if (status == 'Y' || status == 'y')
            {
                availability = true;
                Console.WriteLine("\nAvailability status updated!!");
            }
            else if (status == 'N' || status == 'n')
            {
                availability = false;
                Console.WriteLine("\nAvailability status updated!!");
            }
            else
                Console.WriteLine("\nInvalid Input. Please enter Y or N!!");
        }

        public double getRating()
        {
            if (ratings.Count == 0)
                return 0;
            else
                return ratings.Average();
        }

        public void updateLocation()
        {
            Console.WriteLine("\n----Enter your updated Location----");

            Console.Write("\nEnter Latitude: ");
            Console.ForegroundColor = ConsoleColor.Green;
            float latitude = Convert.ToSingle(Console.ReadLine());
            Console.ResetColor();

            Console.Write("\nEnter Longitude: ");
            Console.ForegroundColor = ConsoleColor.Green;
            float longitude = Convert.ToSingle(Console.ReadLine());
            Console.ResetColor();

            curr_location.setLocation(latitude, longitude);
        }

        

    }
}
