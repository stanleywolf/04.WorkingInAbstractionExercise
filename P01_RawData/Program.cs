using System;
using System.Collections.Generic;
using System.Linq;


class RawData
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            FillCars(cars);
        }

        PrintCar(cars);
    }

    private static void PrintCar(List<Car> cars)
    {
        string command = Console.ReadLine();
        if (command == "fragile")
        {
            foreach (var car in cars.Where(a => a.cargoType == "fragile").Where(b => b.tires.Where(c => c.Tire1Presure < 1).FirstOrDefault() != null))
            {
                Console.WriteLine(car.model);
            }
        }
        else
        {
            foreach (var car in cars.Where(c => c.cargoType == "flamable").Where(a => a.enginePower > 250))
            {
                Console.WriteLine(car.model);
            }


        }
    }

    private static void FillCars(List<Car> cars)
    {
        string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string model = parameters[0];
        int engineSpeed = int.Parse(parameters[1]);
        int enginePower = int.Parse(parameters[2]);
        int cargoWeight = int.Parse(parameters[3]);
        string cargoType = parameters[4];

        double tire1Pressure = double.Parse(parameters[5]);
        double tire2Pressure = double.Parse(parameters[7]);
        double tire3Pressure = double.Parse(parameters[9]);
        double tire4Pressure = double.Parse(parameters[11]);

        cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, new Tires[]
        {
                new Tires(tire1Pressure),
                new Tires(tire2Pressure),
                new Tires(tire3Pressure),
                new Tires(tire4Pressure)
        }));
    }
}

