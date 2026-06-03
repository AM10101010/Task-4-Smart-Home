using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<object> devices = new List<object>();
        // TODO:
        // Skapa minst fyra objekt:
        Washer washer = new Washer { Brand = "LG", Temperature = 30 };
        Refrigerator refrigerator = new Refrigerator { Brand = "Samsung", CapacityKg = 20 };
        Oven oven = new Oven { Brand = "Electrolux", MaxTemperature = 10 };
        RobotVacuum robotVacuum = new RobotVacuum { Brand = "Xiaomi", BatteryLevel = 10 };
        // Lägg till dem i listan devices.
        devices.Add(washer);
        devices.Add(refrigerator);
        devices.Add(oven);
        devices.Add(robotVacuum);

        RunMorningRoutine(devices);
        Console.WriteLine("");
        ReportAllEnergy(devices);
        Console.WriteLine("");

    }

    private static void ReportAllEnergy(List<object> devices)
    {
        foreach (object device in devices)
        {
            // TODO:
            // 1. Kontrollera vilken typ device är.
            if (device is Washer)
            {
                Washer washer = (Washer)device;
                washer.PrintWashEnergy(washer.Temperature);
            }
            else if (device is Refrigerator)
            {
                Refrigerator refrigerator = (Refrigerator)device;
                refrigerator.PrintCoolingEnergy(refrigerator.CapacityKg);
            }
            else if (device is Oven)
            {
                Oven oven = (Oven)device;
                oven.PrintHeatingEnergy(oven.MaxTemperature);
            }
            else if (device is RobotVacuum)
            {
                RobotVacuum robotVacuum = (RobotVacuum)device;
                robotVacuum.PrintCleaningEnergy(robotVacuum.BatteryLevel);
            }
        }
    }

    static void RunMorningRoutine(List<object> devices)
    {
        foreach (object device in devices)
        {
            // TODO:
            // 1. Kontrollera vilken typ device är.
            // 2. Casta till rätt typ.
            // 3. Anropa rätt startmetod.
            // 4. Anropa rätt stoppmetod.

            if (device is Washer)
            {
                Washer washer = (Washer)device;
                washer.StartWash();
                washer.StopWash();
            }
            else if (device is Refrigerator)
            {
                Refrigerator refrigerator = (Refrigerator)device;
                refrigerator.StartCooling();
                refrigerator.StopCooling();
            }
            else if (device is Oven)
            {
                Oven oven = (Oven)device;
                oven.StartCooking();
                oven.StopCooking();
            }
            else if (device is RobotVacuum)
            {
                RobotVacuum robotVacuum = (RobotVacuum)device;
                robotVacuum.StartCleaning();
                robotVacuum.StopCleaning();
            }
        }
    }
}