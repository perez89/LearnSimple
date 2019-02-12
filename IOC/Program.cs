using IOC.Unity_Container.Interfaces;
using IOC.Unity_Container.Models;
using IOC.UnityContainera.Models;
using Microsoft.Practices.Unity;
using System;


namespace IOC
{
    /// <summary>
    /// Tutotial website https://www.tutorialsteacher.com/ioc
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Constructor Injection
            //RegistrationConcreteObject();
            //RegistrationSingleInjection();
            //RegisterNamedType();
            //MultipleRegistration();
            //RegisterInstance();
            //RegisterMultipleParameters();
            //RegisterMultipleConstructors();
            //RegisterPrimitiveTypeParameter();

            #endregion

            #region Property Injection
            //PropertyInjection();
            //PropertyInjectionNamedMapping();
            //PropertyInjectionRuntimeConfiguration();
            #endregion

            #region Method Injection
            //MethodInjection();
            //MethodInjectionRuntimeConfiguration();
            #endregion

            #region Overrides
            //Constructor
            //ParameterOverride();
            //OverrideMultipleParameters();

            //Property
            //PropertyOverride();

            //DependencyOverride();

            #endregion

            #region Lifetime Manager
            
            //TransientLifetimeManager();
            //ContainerControlledLifetimeManager();
            HierarchicalLifetimeManager();
            #endregion


            Console.ReadLine();
        }

        #region Constructor Injection

        static void RegistrationConcreteObject() {
            //first approach without IOC
          Driver driver = new Driver(new BMW());

          driver.RunCar();  
       }


        static void RegistrationSingleInjection() {    

            var container = new UnityContainer();

            container.RegisterType<ICar, BMW>();
            

            //Resolves dependencies and returns Driver object 
            Driver driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            Driver driver2 = container.Resolve<Driver>();
            driver2.RunCar();           
        }

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

        static void RegisterMultipleParameters()
        {
            var container = new UnityContainer();

            container.RegisterType<ICar, Audi>();
            container.RegisterType<ICarKey, AudiKey>();

            var driver = container.Resolve<DriverK>();
            driver.RunCar();
        }

        static void RegisterMultipleConstructors()
        {
            var container = new UnityContainer();

            //container.RegisterType<DriverMC>(new InjectionConstructor(new BMW()));
            //or 
            container.RegisterType<ICar, Ford>();
            container.RegisterType<DriverMC>(new InjectionConstructor(container.Resolve<ICar>()));

            var driver = container.Resolve<DriverMC>();
            driver.RunCar();
        }

        static void RegisterPrimitiveTypeParameter()
        {
            var container = new UnityContainer();
            container.RegisterType<ICar, Ford>();
            //container.RegisterType<DriverP>(new InjectionConstructor(new object[] { container.Resolve<ICar>(), "Steve" }));
            container.RegisterType<DriverP>(new InjectionConstructor(new object[] { new Audi(), "Steve" }));

            var driver = container.Resolve<DriverP>(); // Injects Audi and Steve
            driver.RunCar();
        }

        #endregion

        #region Property Injection
        /// <summary>
        /// [Dependency] Attribute
        /// For the property injection, we first tell the unity container which property to inject. So, we need to decorate 
        /// the dependent properties with the [Dependency] attribute as shown in the following Driver class.
        /// </summary>
        static void PropertyInjection() {
            var container = new UnityContainer();
            container.RegisterType<IAirplane, Airbus>();

            var pilot = container.Resolve<Pilot>();
            pilot.RunAirplane();
        }

        /// <summary>
        /// We can specify a name in the [Dependency("name")] attribute, which can then be used to set property value.
        /// </summary>
        static void PropertyInjectionNamedMapping()
        {
            var container = new UnityContainer();
            container.RegisterType<IAirplane, Airbus>();
            container.RegisterType<IAirplane, Boeing>("LuxuryAirplane");

            var pilot = container.Resolve<PilotL>();
            pilot.RunAirplane();

            var pilot2 = container.Resolve<Pilot>();
            pilot2.RunAirplane();
        }

        static void PropertyInjectionRuntimeConfiguration() {
            var container = new UnityContainer();

            container.RegisterType<IAirplane, Airbus>();
            IAirplane Airbus = container.Resolve<IAirplane>();  // return BMW object
            container.RegisterType<Pilot>(new InjectionProperty("Airplane", Airbus));

            var pilot1 = container.Resolve<Pilot>();
            pilot1.RunAirplane();

            //or 
            //run-time configuration
            container.RegisterType<Pilot>(new InjectionProperty("Airplane", new Embraer()));

            var pilot2 = container.Resolve<Pilot>();
            pilot2.RunAirplane();
        }
        #endregion

        #region Method Injection

        /// <summary>
        /// For the method injection, we need to tell the unity container which method should be used for dependency injection. 
        /// So, we need to decorate a method with the [InjectionMethod] attribute
        /// </summary>
        static void MethodInjection() {
            var container = new UnityContainer();
            container.RegisterType<IShip, Airboat>();

            var sailor = container.Resolve<Sailor>();
            sailor.Sail();
        }

        static void MethodInjectionRuntimeConfiguration()
        {
            var container = new UnityContainer();

            //run-time configuration
            container.RegisterType<Sailor>(new InjectionMethod("UseShip", new Airboat()));

            var sailor = container.Resolve<Sailor>();
            sailor.Sail();
            //to specify multiple parameters values
            container.RegisterType<Sailor>(new InjectionMethod("UseShipTurbo", new object[] { new Airboat(), true }));

            var sailor2 = container.Resolve<Sailor>();
            sailor2.Sail();
        }
        #endregion


        /// <summary>
        ///There are three important classes which inherit ResolverOverride:
        ///ParameterOverride: Used to override constructor parameters.
        ///PropertyOverride: Used to override the value of specified property.
        ///DependencyOverride: Used to override the type of dependency and its value.
        /// </summary>

        #region Overrides

        static void ParameterOverride() {
            var container = new UnityContainer()
                .RegisterType<ICar, BMW>();

            var driver1 = container.Resolve<Driver>(); // Injects registered ICar type
            driver1.RunCar();

            // Override registered ICar type 
            var driver2 = container.Resolve<Driver>(new ParameterOverride("car", new Ford()));
            driver2.RunCar();
        }

        static void OverrideMultipleParameters()
        {
            var container = new UnityContainer()
                  .RegisterType<ICar, BMW>();

            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();

            var driver2 = container.Resolve<Driver>(new ResolverOverride[] {
                    new ParameterOverride("car1", new Ford()),
                    new ParameterOverride("car2", new BMW()),
                    new ParameterOverride("car3", new Audi())
            });

            driver2.RunCar();
        }

        static void PropertyOverride() {
            var container = new UnityContainer();

            //Configure default value of Car property
            container.RegisterType<Pilot>(new InjectionProperty("Airplane", new Boeing()));

            var pilot = container.Resolve<Pilot>();
            pilot.RunAirplane();

            //Override default value of Car property
            var pilot2 = container.Resolve<Pilot>(
                new PropertyOverride("Airplane", new Embraer()));

            pilot2.RunAirplane();
        }

        static void DependencyOverride()
        {
            var container = new UnityContainer()
                .RegisterType<ICar, BMW>();

            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();

            //Override dependency
            var driver2 = container.Resolve<Driver>(new DependencyOverride<ICar>(new Audi()));
            driver2.RunCar();
        }

        #endregion


        #region Lifetime Manager
        /// <summary>
        /// TransientLifetimeManager is the default lifetime manager. It creates a new object of requested type every time you 
        /// call Resolve() or ResolveAll() method.
        /// </summary>
        static void TransientLifetimeManager() {
            var container = new UnityContainer()
                   .RegisterType<ICar, BMW>();

            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();

            var driver2 = container.Resolve<Driver>();
            driver2.RunCar();


            /* The following example will display same output as above example because 
                 TransientLifetimeManager is the default manager if not specified.
             It is the same than the following:*/
            /*var container = new UnityContainer()
                   .RegisterType<ICar, BMW>(new TransientLifetimeManager());

            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();

            var driver2 = container.Resolve<Driver>();
            driver2.RunCar();*/
        }

        /// <summary>
        /// Use ContainerControlledLifetimeManager when you want to create a singleton instance.
        /// </summary>
        static void ContainerControlledLifetimeManager()
        {
            var container = new UnityContainer()
                    .RegisterType<ICar, BMW>(new ContainerControlledLifetimeManager());

            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();

            var driver2 = container.Resolve<Driver>();
            driver2.RunCar();
        }

        /// <summary>
        /// The HierarchicalLifetimeManager is the same as ContainerControlledLifetimeManager except that if 
        /// you create a child container then it will create its own singleton instance of registered type and 
        /// will not share instance with parent container.
        /// </summary>
        static void HierarchicalLifetimeManager()
        {
            var container = new UnityContainer()
                    .RegisterType<ICar, BMW>(new HierarchicalLifetimeManager());

            var childContainer = container.CreateChildContainer();

            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();

            var driver2 = container.Resolve<Driver>();
            driver2.RunCar();

            var driver3 = childContainer.Resolve<Driver>();
            driver3.RunCar();

            var driver4 = childContainer.Resolve<Driver>();
            driver4.RunCar();
        }

        #endregion




    }
}
