using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresComplects = new List<Tire[]>();
            string recievTires;
            while((recievTires = Console.ReadLine()) != "No more tires")
            {
                string [] recievedTire = recievTires.Split();
                Tire tire1 = new Tire(int.Parse(recievedTire[0]), double.Parse(recievedTire[1]));
                Tire tire2 = new Tire(int.Parse(recievedTire[2]), double.Parse(recievedTire[3]));
                Tire tire3 = new Tire(int.Parse(recievedTire[4]), double.Parse(recievedTire[5]));
                Tire tire4 = new Tire(int.Parse(recievedTire[6]), double.Parse(recievedTire[7]));
                Tire[] complect = new Tire[] { tire1, tire2, tire3, tire4 };
                tiresComplects.Add(complect);
            }
            List<Engine> engines = new List<Engine>();
            string recievEngines;
            while((recievEngines = Console.ReadLine()) != "Engines done")
            {
                string [] recievEngine = recievEngines.Split();
                engines.Add(new Engine(int.Parse(recievEngine[0]), double.Parse(recievEngine[1])));
            }
            List<Car> cars = new List<Car>();
            string recievCars;
            while((recievCars = Console.ReadLine()) != "Show special")
            {
                string [] recievCar = recievCars.Split();
                int engineIndex = int.Parse(recievCar[5]);
                int tireIndex = int.Parse(recievCar[6]);
                Car car = new Car(recievCar[0], recievCar[1], int.Parse(recievCar[2]), double.Parse(recievCar[3]), double.Parse(recievCar[4]), engines[engineIndex], tiresComplects[tireIndex]);
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                double sumPressure = 0;
                foreach (var tire in car.Tires)
                {
                    sumPressure += tire.Pressure;
                }
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && sumPressure>=9 && sumPressure <= 10)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
