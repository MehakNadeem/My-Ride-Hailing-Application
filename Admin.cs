using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DriverLibrary;
using VehicleLibrary;

namespace AdminLibrary
{
    public class Admin
    {
        List<Driver> driversList;

        public Admin()
        {
            driversList = new List<Driver>();
        }

        public List<Driver> DriversList
        {
            get { return driversList; }
        }

        public void addDriver()
        {
            Console.WriteLine("\n\t-------------Add Driver---------------");
            Driver driver = new Driver();

            Console.Write("\nEnter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            driver.Name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            driver.Age = int.Parse(Console.ReadLine());
            Console.ResetColor();

            Console.Write("\nEnter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            driver.Gender = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            driver.Address = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            driver.DriVehicle.Type = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            driver.DriVehicle.Model = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            driver.DriVehicle.License_plate = Console.ReadLine();
            Console.ResetColor();

            driversList.Add(driver);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nDriver with ID {driver.DriverID} added successfully!!");
            Console.ResetColor();
        }

        public void removeDriver()
        {
            Console.WriteLine("\n\t-------------Remove Driver---------------");
            Console.Write("\nEnter ID of driver to be removed: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int ID = int.Parse( Console.ReadLine() );
            Console.ResetColor();
            
            foreach( Driver driver in driversList ) 
            {
                if (driver.DriverID == ID)
                {
                    driversList.Remove(driver);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nDriver with {ID} removed successfully!!");
                    Console.ResetColor();
                    return;
                }
            }
            Console.WriteLine($"\nERROR!! No driver with ID {ID} exists.");
        }

        public void updateDriver()
        {
            Console.WriteLine("\n\t-------------Update Driver---------------");
            Console.Write("\nEnter Driver ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int ID = int.Parse(Console.ReadLine());
            Console.ResetColor();

            foreach (Driver driver in driversList)
            {
                if (driver.DriverID == ID)
                {
                    Console.WriteLine($"\n-------------Driver with ID {ID} exists-------------");

                    Console.Write("\nEnter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name))
                        driver.Name = name;
                    Console.ResetColor();

                    Console.Write("\nEnter Age: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string age = Console.ReadLine();
                    if (!string.IsNullOrEmpty(age))
                        driver.Age = int.Parse (age);
                    Console.ResetColor();

                    Console.Write("\nEnter Gender: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string gender = Console.ReadLine();
                    if (!string.IsNullOrEmpty(gender))
                        driver.Gender = gender;
                    Console.ResetColor();

                    Console.Write("\nEnter Address: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string address = Console.ReadLine();
                    if (!string.IsNullOrEmpty(address))
                        driver.Address = address;
                    Console.ResetColor();

                    Console.Write("\nEnter Vehicle Type: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehType = Console.ReadLine();
                    if (!string.IsNullOrEmpty(vehType))
                        driver.DriVehicle.Type = vehType;
                    Console.ResetColor();

                    Console.Write("\nEnter Vehicle Model: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehModel = Console.ReadLine();
                    if (!string.IsNullOrEmpty(vehModel))
                        driver.DriVehicle.Model = vehModel;
                    Console.ResetColor();

                    Console.Write("\nEnter Vehicle License Plate: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehLP = Console.ReadLine();
                    if (!string.IsNullOrEmpty(vehLP))
                        driver.DriVehicle.License_plate = vehLP;
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nDriver with ID {ID} updated successfully!!");
                    Console.ResetColor();

                    return;
                }
            }
            Console.WriteLine($"\nERROR!! No driver with ID {ID} exists.");
        }

        public void searchDriver()
        {
            Console.WriteLine("\n\t-------------Search Driver---------------");

            Console.Write("\nEnter Driver ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string driver_id = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string age = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string gender = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string address = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string vehType = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string vehModel = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\nEnter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string vehLP = Console.ReadLine();
            Console.ResetColor();

            List<Driver> searchedDrivers = new List<Driver>();

            foreach(Driver driver in driversList)
            {
                if((!string.IsNullOrEmpty(driver_id) && driver.DriverID == int.Parse(driver_id)) || 
                    (!string.IsNullOrEmpty(name) && driver.Name == name) ||
                    (!string.IsNullOrEmpty(age) && driver.Age == int.Parse(age)) ||
                    (!string.IsNullOrEmpty(gender) && driver.Gender == gender) ||
                    (!string.IsNullOrEmpty(address) && driver.Address == address) ||
                    (!string.IsNullOrEmpty(vehType) && driver.DriVehicle.Type == vehType) ||
                    (!string.IsNullOrEmpty(vehModel) && driver.DriVehicle.Model ==  vehModel) ||
                    (!string.IsNullOrEmpty(vehLP) && driver.DriVehicle.License_plate ==  vehLP))
                {
                    searchedDrivers.Add(driver);
                }
            }

            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", "Name", "Age", "Gender", "V.Type", "V.Model", "V.Lisence");
            Console.WriteLine("\n-------------------------------------------------------------------------");
            foreach (Driver driver in searchedDrivers) 
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", driver.Name, driver.Age, driver.Gender, driver.DriVehicle.Type, driver.DriVehicle.Model, driver.DriVehicle.License_plate);
                Console.WriteLine("\n-------------------------------------------------------------------------");
            }
        }

        
    }
}
