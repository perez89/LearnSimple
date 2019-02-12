using IOC.Unity_Container.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Unity_Container.Models
{
    /// <summary>
    /// If a class includes multiple constructors then use [InjectionConstructor] attribute 
    /// to indicate which constructor to use for construction injection.
    /// </summary>
    public class DriverMC
    {
        private ICar _car;

        [InjectionConstructor]
        public DriverMC(ICar car)
        {
            _car = car;
        }

        public DriverMC(string name)
        {
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }
}
