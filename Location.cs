using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationLibrary
{
    public class Location
    {
        float latitude;
        float longitude;

        public Location()
        {
            latitude = 0;
            longitude = 0;
        }

        public Location(float latitudeValue, float longitudeValue)
        {
            latitude = latitudeValue;
            longitude = longitudeValue;
        }

        public float Latitude
        {
            get { return latitude; }
            set
            {
                if (value >= -90 && value <= 90)
                    latitude = value;
            }
        }

        public float Longitude
        {
            get { return longitude; }
            set
            {
                if (value >= -180 && value <= 180)
                    longitude = value;
            }
        }

        public void setLocation(float latitudeValue, float longitudeValue)
        {
            latitude = latitudeValue;
            longitude = longitudeValue;
        }

        public override string ToString()
        {
            return $"Latitude: {latitude}; Longitude: {longitude}";
        }
    }
}

