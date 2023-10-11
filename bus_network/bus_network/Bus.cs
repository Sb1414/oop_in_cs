using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_network
{
    public class Bus
    {
        public string LicensePlate { get; set; }
        public string DriverName { get; set; }
        public Bus NextBus { get; set; }  // ссылка на следующий автобус в маршруте

        public Bus(string licensePlate, string driverName)
        {
            LicensePlate = licensePlate;
            DriverName = driverName;
            NextBus = this;  // изначально автобус ссылается сам на себя
        }
    }
}
