using IOC.Unity_Container.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Unity_Container.Models
{
    public class Airboat : IShip
    {
        private int _miles = 0;

        public int Sail()
        {
            return ++_miles;
        }
    }

    public class Gondola : IShip
    {
        private int _miles = 0;

        public int Sail()
        {
            return ++_miles;
        }
    }

    public class Corvette : IShip
    {
        private int _miles = 0;

        public int Sail()
        {
            return ++_miles;
        }

    }
    public class Sailor
    {
        private IShip _ship ;

        public bool _turbo
        {
            get; set;
        }

        public Sailor()
        {
        }
        /// <summary>
        /// For the method injection, we need to tell the unity container which method should be used for dependency injection. 
        /// So, we need to decorate a method with the [InjectionMethod] attribute.
        /// </summary>
        /// <param name="ship"></param>
        //[InjectionMethod]
        public void UseShip(IShip ship)
        {
            _ship = ship;
        }

        public void UseShipTurbo(IShip ship, bool turbo)
        {
            _ship = ship;
            _turbo = turbo;
        }

        public void Sail()
        {
            Console.WriteLine("Sailing {0} - {1} mile, turbo ON= {2} ", _ship.GetType().Name, _ship.Sail(), _turbo.ToString());
        }
    }
}
