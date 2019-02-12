using IOC.Unity_Container.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Unity_Container.Models
{
    class PilotL
    {
        public PilotL()
        {
        }

        /// <summary>
        /// We can specify a name in the [Dependency("name")] attribute, which can then be used to set property value.
        /// </summary>
        [Dependency("LuxuryAirplane")]
        public IAirplane Airplane { get; set; }

  
        public void RunAirplane()
        {
            Console.WriteLine("Running {0} - {1} mile ",
                                this.Airplane.GetType().Name, this.Airplane.Fly());
        }
    }
}
