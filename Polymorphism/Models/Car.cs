using Polymorphism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    class Car : IVehicle
    {
        public void AppStore()
        {
            Console.WriteLine("AppStore");
        }

        public void OS()
        {
            Console.WriteLine("OS");
        }
    }
}
