using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DriverLibrary;
using LocationLibrary;
using VehicleLibrary;
using PassengerLibrary;
using AdminLibrary;
using RideLibrary;

namespace MyRide
{
    internal class Program
    {
        public static Admin admin = new Admin();
        public static Ride ride = new Ride();
        static void Main(string[] args)
        {
            string answer;
            do
            { 
                mainMenu();
                Console.Write("\nDo you want to continue? (Y/N): ");
                answer = Console.ReadLine();
            }
            while (answer == "Y" || answer == "y");
        }

        public static void mainMenu()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.WriteLine("                            WELCOME TO MYRIDE");
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.WriteLine("\n1. Book a Ride");
            Console.WriteLine("2. Enter as Driver");
            Console.WriteLine("3. Enter as Admin");

            Console.Write("\nPress 1 to 3 to select an option: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int option = int.Parse(Console.ReadLine());
            Console.ResetColor();
            
            if (option == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nBook a Ride:");
                Console.ResetColor();

                ride.bookRide(admin.DriversList);
            }
            else if (option == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nEnter as Driver:");
                Console.ResetColor();

                Driver driverFound = searchDriverByID();

                if (driverFound != null)
                {
                    Console.WriteLine($"\nHello {driverFound.Name}!");
                    Console.Write("\nEnter your current Location: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string[] curr_loc = Console.ReadLine().Split(',');
                    Console.ResetColor();

                    driverFound.Curr_location.Latitude = float.Parse(curr_loc[0]);
                    driverFound.Curr_location.Longitude = float.Parse(curr_loc[1]);

                    driverMenu(driverFound);
                }
                else
                {
                    Console.WriteLine("\nERROR! Driver is not registered.");
                }
            }
            else if(option == 3) 
            {
                adminMenu();
            }
            else 
            {
                Console.WriteLine("\nInvalid Input...");
            }
        }

        public static void driverMenu(Driver driverFound)
        {
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.WriteLine("\n1. Change availability");
            Console.WriteLine("2. Change Location");
            Console.WriteLine("3. Exit as Driver");
            Console.WriteLine("\n-------------------------------------------------------------------------");

            Console.Write("\nPress 1 to 3 to select an option: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int driverOption = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (driverOption == 1)
            {
                driverFound.updateAvailability();
                driverMenu(driverFound);
            }
            else if (driverOption == 2)
            {
                driverFound.updateLocation();
                driverMenu(driverFound);
            }
            else if (driverOption == 3)
            {
                mainMenu();
            }
            else
            {
                Console.WriteLine("\nInvalid Input...");
            }
        }
             

        public static void adminMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nEnter as Admin:");
            Console.ResetColor();

            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.WriteLine("\n1. Add Driver");
            Console.WriteLine("2. Remove Driver");
            Console.WriteLine("3. Update Driver");
            Console.WriteLine("4. Search Driver");
            Console.WriteLine("5. Exit as Admin");
            Console.WriteLine("\n-------------------------------------------------------------------------");

            Console.Write("\nPress 1 to 5 to select an option: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int adminOption = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (adminOption == 1) 
            {
                admin.addDriver();
                adminMenu();
            }
            else if (adminOption == 2)
            {
                admin.removeDriver();
                adminMenu();
            }
            else if (adminOption == 3)
            {
                admin.updateDriver();
                adminMenu();
            }
            else if (adminOption == 4)
            {
                admin.searchDriver();
                adminMenu();
            }
            else if (adminOption == 5)
            {
                mainMenu();
            }
            else
            {
                Console.WriteLine("\nInvalid Input...");
            }
        }

        public static Driver searchDriverByID()
        {
            Console.Write("\nEnter ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string id = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();

            foreach (Driver driver in admin.DriversList)
            {
                if (driver.Name == name && driver.DriverID == int.Parse(id))
                {
                    return driver;
                }
            }
            return null;
        }
    }
}
