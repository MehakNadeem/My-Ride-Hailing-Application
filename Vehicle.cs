using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public class Vehicle
    {
        string type;
        string model;
        string license_plate;

        public Vehicle()
        {
            type = string.Empty;
            model = string.Empty;
            license_plate = string.Empty;
        }

        public Vehicle(string typeVal, string modelVal, string licensePlateVal)
        {
            type = typeVal;
            model = modelVal;
            license_plate = licensePlateVal;
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (value == "Car" || value == "Bike" || value == "Rickshaw" ||
                    value == "car" || value == "bike" || value == "rickshaw")
                {
                    type = value;
                }
            }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string License_plate
        {
            get { return license_plate; }
            set { license_plate = value; }
        }

        public override string ToString()
        {
            return $"Vehicle\nType: {type}\t  Model: {model}\tLicense Plate: {license_plate}";
        }
    }
}
