using System;
using Unity;

namespace UnityContainerPractice.ConstructorInjection
{
    class Driver
    {
        private ICar _car = null;
        private ICarKey _key = null;

        public Driver(ICar car, ICarKey key)
        {
            _car = car;
            _key = key;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} with {1} - {2} mile ", _car.GetType().Name, _key.GetType().Name, _car.Run());
        }
    }

    class DriverWithPrimitiveTypeParameter
    {
        private ICar _car = null;
        private string _name = string.Empty;

        public DriverWithPrimitiveTypeParameter(ICar car, string driverName)
        {
            _car = car;
            _name = driverName;
        }

        public void RunCar()
        {
            Console.WriteLine("{0} is running {1} - {2} mile ",
                            _name, _car.GetType().Name, _car.Run());
        }
    }

    class DriverWithMultipleConstructors
    {
        private ICar _car = null;

        [InjectionConstructor]//If a class includes multiple constructors, then
                              //use the [InjectionConstructor] attribute to indicate which constructor to use for construction injection.
        public DriverWithMultipleConstructors(ICar car)
        {
            _car = car;
        }

        public DriverWithMultipleConstructors(string name)
        {
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }

    class DriverWithMultipleConstructors2
    {
        private ICar _car = null;

        public DriverWithMultipleConstructors2(ICar car)
        {
            _car = car;
        }

        public DriverWithMultipleConstructors2(string name)
        {
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }
}
