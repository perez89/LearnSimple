using IOC.Unity_Container.Interfaces;
using IOC.Unity_Container.Models;
using System;
using Unity;

namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            //or
            //var container = new UnityContainer();

            container.RegisterType<ICar, BMW>();

            Driver driver = new Driver(new BMW());

            driver.RunCar();

            Console.ReadLine();
        }
    }
}
