using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace UnityContainerPractice.ConstructorInjection
{
    class Demo
    {
        private static IUnityContainer container = new UnityContainer();

        // by default, the Resolve() method performs constructor injection while resolving types.
        public static void one()
        {
            container.RegisterType<ICar, BMW>();

            // whenever Unity container needs to inject an object of type ICar, it will create and inject an object of the BMW class.
            var driver = container.Resolve<UnityContainerPractice.Driver>();
            driver.RunCar();
        }

        //  inject multiple parameters in the constructor
        public static void two()
        {
            container.RegisterType<ICar, Audi>();
            container.RegisterType<ICarKey, AudiKey>();

            var driver = container.Resolve<Driver>();
            driver.RunCar();
        }

        // injects primitive type parameters in the constructor
        public static void twoAgain()
        {
            container.RegisterType<DriverWithPrimitiveTypeParameter>(new InjectionConstructor(new object[] { new Audi(), "Steven Curry" }));

            var driver = container.Resolve<DriverWithPrimitiveTypeParameter>();// Injects Audi and Steve
            driver.RunCar();
        }

        // If a class includes multiple constructors, then
        // use the [InjectionConstructor] attribute to indicate which constructor to use for construction injection.
        public static void three()
        {
            container.RegisterType<ICar, Audi>();

            DriverWithMultipleConstructors driver = container.Resolve<DriverWithMultipleConstructors>();
            driver.RunCar();
        }

        public static void threeInstead()
        {
            container.RegisterType<DriverWithMultipleConstructors2>(new InjectionConstructor(new Ford()));

            //or 

            container.RegisterType<ICar, Ford>();
            container.RegisterType<DriverWithMultipleConstructors2>(new InjectionConstructor(container.Resolve<ICar>()));

            DriverWithMultipleConstructors2 driver = container.Resolve<DriverWithMultipleConstructors2>();
            driver.RunCar();
        }


    }
}
