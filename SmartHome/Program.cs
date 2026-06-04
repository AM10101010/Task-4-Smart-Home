using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {

        List<Appliance> devices = new List<Appliance>
        {
            new Washer("LG", "Laundry", capacityKg: 8),
            new Refrigerator("Samsung", "Kitchen", temperature: 4),
            new Oven("Electrolux", "Kitchen", maxTemperature: 250),
            new RobotVacuum("Xiaomi", "Living room", batteryLevel: 100),
            new CoffeeMachine("Nespresso", "Kitchen", cupsPerBrew: 2)
        };
     
        RunMorningRoutine(devices);
        Console.WriteLine("");
        ReportAllEnergy(devices);
        Console.WriteLine("");

    }

    private static void ReportAllEnergy(List<Appliance> devices)
    {
        // No type checks, no casts — polymorphism dispatches to the right override.
        foreach (Appliance device in devices)
        {
            Console.WriteLine($"{device.GetInfo()} uses {device.GetDailyEnergyUsage()} kWh/day.");
        }
    }

    static void RunMorningRoutine(List<Appliance> devices)
    {
        foreach (Appliance device in devices)
        {
            device.TurnOn();
            device.TurnOff();
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



Del 2: Lägg till en ny apparat och känn problemet
Fråga:
// När jag lade till CoffeeMachine behövde jag ändra...

Svar:
//Behövde lägga till kod på följande ställen:
//   1. Skapa CoffeeMachine-objektet i Main.
//   2. Lägga till objektet i listan devices.
//   3. Lägga till en ny "else if (device is CoffeeMachine)"-gren i RunMorningRoutine.
//   4. Lägga till en ny "else if (device is CoffeeMachine)"-gren i ReportAllEnergy.

*/