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

// Reflektionsfrågor efter Del 1
/*

Frågor:
1. Varför behövde du kontrollera vilken typ varje objekt hade?
2. Vad händer om du lägger till en ny klass CoffeeMachine?
3. Vilka metoder måste du ändra om du lägger till CoffeeMachine?
4. Vad är problemet med att listan är List<object>?
5. Vad händer om du råkar glömma en apparattyp i ReportAllEnergy()

Svar:
1. Det finns ingen gemensam bas- eller gränssnittstyp som alla enheter ärver från, så vi måste kontrollera typen för att veta vilka metoder vi kan anropa på varje objekt.
2. Om vi lägger till en ny klass CoffeeMachine, måste vi också uppdatera både RunMorningRoutine och ReportAllEnergy för att hantera den nya typen
3. Vi måste ändra både RunMorningRoutine och ReportAllEnergy för att lägga till kontroll och hantering av CoffeeMachine-objekt.
4. Problemet med att använda List<object> är att vi förlorar typinformationen, vilket gör det svårt att arbeta med objekten utan att göra typkontroller och kastningar,
5. Om man glömmer en apparattyp i ReportAllEnergy, kommer den typen inte att logga sin energiförbrukningm.



*/

