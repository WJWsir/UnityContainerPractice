using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace UnityContainerPractice
{
    class RegisterResolve
    {
        private static IUnityContainer container = new UnityContainer();

        public static void one()
        {
            Driver driver = new Driver(new BMW());
            driver.RunCar();
        }

        // Using UnityContainer to register and resolve
        public static void two()
        {
            container.RegisterType<ICar, BMW>();// RegisterType: Map ICar with BMW 
            Driver driver = container.Resolve<Driver>();// Resolves dependencies and returns the Driver object 
            driver.RunCar();
        }

        public static void three()
        {
            container.RegisterType<ICar, BMW>();

            // driver1 and driver2 both have references to separate BMW objects.
            Driver driver1 = container.Resolve<Driver>();
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>();
            driver2.RunCar();
        }

        // Multiple Registration
        public static void four()
        {
            container.RegisterType<ICar, BMW>();
            container.RegisterType<ICar, Audi>();

            // Unity will inject Audi every time because it has been registered last.
            Driver driver = container.Resolve<Driver>();
            driver.RunCar();
        }

        // Register Named Type
        public static void five()
        {
            container.RegisterType<ICar, BMW>();
            // we have given the name "LuxuryCar" to the ICar-Audi mapping.
            container.RegisterType<ICar, Audi>("LuxuryCar");

            ICar bmw = container.Resolve<ICar>();  // returns the BMW object
            // the Resolve() method will return an object of Audi if we specify the mapping name.
            ICar audi = container.Resolve<ICar>("LuxuryCar"); // returns the Audi object

            // Registers Driver type
            container.RegisterType<Driver>("LuxuryCarDriver",// registered the Driver class with the name "LuxuryCarDriver"
                            new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));// specifies a construction injection for the Driver class, which passes an object of Audi

            Driver driver1 = container.Resolve<Driver>();// injects BMW
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects Audi
            driver2.RunCar();
        }

        // Register Instance
        public static void six()
        {
            ICar audi = new Audi();
            // register an existing instance using the RegisterInstance() method
            container.RegisterInstance<ICar>(audi);

            // It will not create a new instance for the registered type and we will use the same instance every time.
            Driver driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>();
            driver2.RunCar();
        }
    }
}
