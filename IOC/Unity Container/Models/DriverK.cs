using IOC.Unity_Container.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Unity_Container.Models
{
    public class BMWKey : ICarKey
    {

    }

    public class AudiKey : ICarKey
    {

    }

    public class FordKey : ICarKey
    {

    }

    public class DriverK
    {
        private ICar _car;
        private ICarKey _key;

        public DriverK(ICar car, ICarKey key)
        {
            _car = car;
            _key = key;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} with {1} - {2} mile ", _car.GetType().Name, _key.GetType().Name, _car.Run());
        }
    }
}
