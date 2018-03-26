using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


        string command;
        while ((command = Console.ReadLine()) != "Output")
        {
            FillRooms(doctors, departments, command);
        }

        while ((command = Console.ReadLine()) != "End")
        {
            PrintResult(doctors, departments, command);
        }
    }

    private static void PrintResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
    {
        string[] args = command.Split();

        if (args.Length == 1)
        {
            Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
        }
        else if (args.Length == 2 && int.TryParse(args[1], out int room))
        {
            Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
        }
    }

    private static void FillRooms(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
    {
        string[] tokens = command.Split();
        var departament = tokens[0];
        var firstName = tokens[1];
        var secondName = tokens[2];
        var pacient = tokens[3];
        var fullName = firstName + secondName;

        if (!doctors.ContainsKey(firstName + secondName))
        {
            doctors[fullName] = new List<string>();
        }
        if (!departments.ContainsKey(departament))
        {
            departments[departament] = new List<List<string>>();
            for (int rooms = 0; rooms < 20; rooms++)
            {
                departments[departament].Add(new List<string>());
            }
        }

        bool IsPlace = departments[departament].SelectMany(x => x).Count() < 60;
        if (IsPlace)
        {
            int room = 0;
            doctors[fullName].Add(pacient);
            for (int rooms = 0; rooms < departments[departament].Count; rooms++)
            {
                if (departments[departament][rooms].Count < 3)
                {
                    room = rooms;
                    break;
                }
            }
            departments[departament][room].Add(pacient);
        }
    }
}

