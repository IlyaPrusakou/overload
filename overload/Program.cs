using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overload
{
    public class Transport
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int MaxSpeed { get; set; }
        public float Distance { get; set; }
        public virtual void Move(float km)
        {
            Distance += km;
        }
    }
    public class Car : Transport
    {
        public float Engine { get; set; }

    }
    public class FuelCar : Car
    {
        public int Tank { get; set; }
        public float Fuel { get; set; }
        public float FuelUsage { get; set; }
        public FuelCar(float eng)
        {
            Engine = eng;
        }
        public override void Move(float km)
        {
            base.Move(km);
            Fuel -= km * FuelUsage / 100;
        }

        public static bool operator <(FuelCar f1, FuelCar f2) //overload operator
        {
            return f1.Engine < f2.Engine;
        }
        public static bool operator >(FuelCar f1, FuelCar f2) //overload operator
        {
            return f1.Engine > f2.Engine;
        }
        public static bool operator ==(FuelCar f1, FuelCar f2) //overload operator
        {
            return f1.Engine == f2.Engine;
        }
        public static bool operator !=(FuelCar f1, FuelCar f2) //overload operator
        {
            return f1.Engine != f2.Engine;
        }
        public override bool Equals(object obj) //overload equals
        {
            if (!(obj is FuelCar))
                return false;

            return this == (FuelCar)obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FuelCar car = new FuelCar(4);
            FuelCar car2 = new FuelCar(5);
            FuelCar car3 = new FuelCar(4);
            bool fequal = car == car3;
            bool f = car == car2;
            Console.WriteLine(f + " ==  ");
            Console.WriteLine(fequal + " ==  ");
            Console.WriteLine(car2.Equals(car) + " equals1  ");
            Console.WriteLine(car3.Equals(car) + " equals2  ");
            Console.ReadKey();
        }
    }
}
