using IOC.Unity_Container.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IOC.Unity_Container.Models
{
    class DriverP
    {
        private ICar _car;
        private string _name = string.Empty;

        public DriverP(ICar car, string driverName)
        {
            _car = car;
            _name = driverName;
        }

        public void RunCar()
        {
            Console.WriteLine("{0} is running {1} - {2} mile ",
                            _name, _car.GetType().Name, _car.Run());
        }
    }
}
