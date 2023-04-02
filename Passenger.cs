using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerLibrary
{
    public class Passenger
    {
        string name;
        string phoneNo;

        public Passenger()
        {
            name = string.Empty;
            phoneNo = string.Empty;
        }

        public Passenger(string nameVal, string phoneNoVal)
        {
            name = nameVal;
            phoneNo = phoneNoVal;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
    }
}

