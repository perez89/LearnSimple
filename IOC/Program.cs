using IOC.Unity_Container.Interfaces;
using IOC.UnityContainera.Models;
using Microsoft.Practices.Unity;
using System;


namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConcreteObject();
            //SingleInjection();

            //RegisterNamedType();
            MultipleRegistration();
           // RegisterInstance();

            Console.ReadLine();


        }

        #region Concrete Object
       static void ConcreteObject() {
            //first approach without IOC
          Driver driver = new Driver(new BMW());

          driver.RunCar();  
        }


        #endregion

        #region Single Injection
        static void SingleInjection() {    

            var container = new UnityContainer();

            container.RegisterType<ICar, BMW>();
            

            //Resolves dependencies and returns Driver object 
            Driver driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            Driver driver2 = container.Resolve<Driver>();
            driver2.RunCar();
            
       
        }
        #endregion

        #region Multiple Registration 
        static void MultipleRegistration() {
              var container = new UnityContainer();
              container.RegisterType<ICar, BMW>();
              container.RegisterType<ICar, Audi>("LuxuryCar");


            ICar audi = container.Resolve<ICar>("LuxuryCar"); // return Audi object
                                                              // Register Driver type            
            //container.RegisterType<Driver>("LuxuryCarDriver", 
            //                  new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));

            container.RegisterType<Driver>("LuxuryCarDriver",
                         new InjectionConstructor(audi));

            Driver driver1 = container.Resolve<Driver>();// injects BMW
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects Audi
            driver2.RunCar();
        }
        #endregion


        #region Register Named Type
        static void RegisterNamedType()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICar, BMW>();
            container.RegisterType<ICar, Audi>("LuxuryCar");

            ICar bmw = container.Resolve<ICar>();  // return BMW object
            ICar audi = container.Resolve<ICar>("LuxuryCar"); // return Audi object

            Driver driver1 = container.Resolve<Driver>();// injects BMW
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects Audi
            driver2.RunCar();
        }
        #endregion

        #region Register Instance
        static void RegisterInstance() {
            var container = new UnityContainer();
            ICar audi = new Audi();
            container.RegisterInstance<ICar>(audi);

            Driver driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>();
            driver2.RunCar();
        }
        #endregion
    }
}
