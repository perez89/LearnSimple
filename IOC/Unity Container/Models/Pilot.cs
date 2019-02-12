using IOC.Unity_Container.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Unity_Container.Models
{
    public class Airbus : IAirplane
    {
        private int _miles = 0;

        public int Fly()
        {
            return ++_miles;
        }
    }

    public class Boeing : IAirplane
    {
        private int _miles = 0;

        public int Fly()
        {
            return ++_miles;
        }
    }

    public class Embraer : IAirplane
    {
        private int _miles = 0;

        public int Fly()
        {
            return ++_miles;
        }

    }
    public class Pilot
    {
        public Pilot()
        {
        }

        /// <summary>
        /// [Dependency] Attribute
        /// For the property injection, we first tell the unity container which property to inject. So, we need to decorate 
        /// the dependent properties with the [Dependency] attribute as shown in the following Driver class.
        /// [Dependency] -> can be removed if RuntimeConfiguration is used 
        /// </summary>
        [Dependency]
        public IAirplane Airplane { get; set; }

        public void RunAirplane()
        {
            Console.WriteLine("Flight {0} - {1} mile ",
                                this.Airplane.GetType().Name, this.Airplane.Fly());
        }
    }
}
