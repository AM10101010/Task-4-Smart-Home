using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {

        Console.WriteLine("Morning routine:");
        SmartHomeController smartHomeController = new SmartHomeController();

        smartHomeController.AddDevice(new Washer("LG", "Laundry", capacityKg: 8));
        smartHomeController.AddDevice(new Refrigerator("Samsung", "Kitchen", temperature: 4));
        smartHomeController.AddDevice(new Oven("Electrolux", "Kitchen", maxTemperature: 250));
        smartHomeController.AddDevice(new RobotVacuum("Xiaomi", "Living room", batteryLevel: 100));
        smartHomeController.AddDevice(new CoffeeMachine("Nespresso", "Kitchen", cupsPerBrew: 2));
        smartHomeController.AddDevice(new AirConditioner("Daikin", "Bedroom", targetTemperature: 21));
        smartHomeController.ScheduleAllSchedulableDevices(DateTime.Now.AddHours(2));

        smartHomeController.PrintStatusReport();
        Console.WriteLine();
        smartHomeController.TurnOnAll();
        Console.WriteLine("\nStatus report:");
        smartHomeController.PrintStatusReport();
        double total = smartHomeController.GetTotalDailyEnergyUsage();
        Console.WriteLine("\nTurning off all devices...");
        smartHomeController.TurnOffAll();
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
1. Det finns ingen gemensam bas- eller gränssnittstyp som alla enheter ärver från, 
så vi måste kontrollera typen för att veta vilka metoder vi kan anropa på varje objekt.
2. Om vi lägger till en ny klass CoffeeMachine, måste vi också uppdatera både RunMorningRoutine och ReportAllEnergy för att hantera den nya typen
3. Vi måste ändra både RunMorningRoutine och ReportAllEnergy för att lägga till kontroll och hantering av CoffeeMachine-objekt.
4. Problemet med att använda List<object> är att vi förlorar typinformationen, 
vilket gör det svårt att arbeta med objekten utan att göra typkontroller och kastningar,
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

Frågor efter Del 5
1. Varför fungerar device.TurnOn() trots att device har typen Appliance?
2. Vilken metod körs om objektet egentligen är en RobotVacuum?
3. Vad blev bättre jämfört med List<object>

Svar:
1. Eftersom TurnOn() är en virtuell metod i bas-klassen Appliance, kommer
när vi anropar device.TurnOn(), att den körs polymorft. Det betyder att den version av TurnOn() 
som hör till den faktiska typen av objektet (t.ex. RobotVacuum) kommer att köras, även om variabeln device har typen Appliance.
2. Om objektet är en RobotVacuum, kommer RobotVacuum-klassens override av TurnOn() att köras.
3. Jämfört med List<object> behöver vi inte längre göra typkontroller och kastningar, vilket gör koden mer robust och lättare att underhålla.


Frågor efter Del 9

1. Varför kan vi inte anropa Schedule() direkt på en variabel av typen Appliance?
   - För att Appliance inte känner till någon Schedule()-metod. Kompilatorn tittar
     bara på den deklarerade typen, och eftersom alla apparater inte kan schemaläggas
     finns metoden inte i basklassen – bara i ISchedulable.

2. Varför fungerar det efter att vi castar till ISchedulable?
   - När vi castar säger vi till kompilatorn att objektet faktiskt följer ISchedulable.
     Då vet den att Schedule() finns, och anropet blir tillåtet.

3. Vad betyder det att RobotVacuum både är en Appliance och en ISchedulable?
   - Att den har två roller samtidigt: den är en apparat (ärver allt gemensamt från
     Appliance) och den kan dessutom schemaläggas. Vi kan alltså behandla den både
     som en vanlig Appliance och som ett schemaläggbart objekt.

4. Varför ska inte Schedule() ligga direkt i Appliance?
   - Då skulle alla apparater tvingas ha den, även de som inte kan schemaläggas, till
     exempel ugnen och kylen. Schemaläggning passar bättre som något man väljer att
     lägga till via ett interface.

5. Vad är skillnaden mellan arv och interface i det här exemplet?
   - Arv handlar om vad något är – alla apparater är en Appliance och delar samma
     grund. Ett interface handlar om vad något kan göra – bara vissa apparater kan
     schemaläggas. Arv ger gemensam kod, interface ger en gemensam förmåga utan att
     röra basklassen.

*/