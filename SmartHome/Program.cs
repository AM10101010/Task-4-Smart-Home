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
    smartHomeController.AddDevice(new PizzaOven("Ooni", "Garden", maxTemperature: 450));
    smartHomeController.ScheduleAllSchedulableDevices(DateTime.Now.AddHours(2));


    smartHomeController.PrintStatusReport();
    Console.WriteLine();
    smartHomeController.TurnOnAll();
    Console.WriteLine("\nStatus report:");
    smartHomeController.PrintStatusReport();
    double total = smartHomeController.GetTotalDailyEnergyUsage();
    Console.WriteLine($"Total daily energy usage: {total} kWh");
    Console.WriteLine("\nTurning off all devices...");
    smartHomeController.TurnOffAll();

    //Del 11: Labb med new + (additional comments row 171-190) <=
    
    //Test:
    SmartLamp lamp1 = new SmartLamp("IKEA", "Hallway", 80);
    Appliance lamp2 = lamp1;
    lamp1.TurnOn(); // SmartLamp's TurnOn() körs
    lamp2.TurnOn(); // Appliance's TurnOn() körs, inte SmartLamp's

    /*
     With "new" (current code) — output differs because the variable's type decides:
     Smart lamp IKEA in Hallway turns on with brightness 80%.   // lamp1 (SmartLamp)
     IKEA in Hallway is now ON.                                 // lamp2 (Appliance)
    
     If "new" were changed to "override" — output is the same on both lines,
     because the object's real type (SmartLamp) decides:
     Smart lamp IKEA in Hallway turns on with brightness 80%.
     Smart lamp IKEA in Hallway turns on with brightness 80%.

    1. Blir utskriften samma?
       Nej. Trots att lamp1 och lamp2 är samma objekt blir utskriften olika,
       eftersom variablerna har olika deklarerade typer.

    2. Vilken metod körs när variabeln har typen SmartLamp?
       SmartLamps egen TurnOn()

    3. Vilken metod körs när variabeln har typen Appliance?
       Basklassens (Appliance) TurnOn(), trots att objektet faktiskt är en SmartLamp.

    4. Varför är detta farligt eller förvirrande?
       Samma objekt gör olika saker beroende på vilken typ variabeln har.
       Det kan ge buggar som är svåra att hitta.

    5. Vad händer om du byter "new" till "override"?
       Då kör båda raderna SmartLamps TurnOn(), för då bestämmer objektets
       riktiga typ vilken metod som körs. */

    List<ISchedulable> schedulables = smartHomeController.GetSchedulableDevices();
    foreach (ISchedulable device in schedulables)
    {
      Console.WriteLine($"Scheduling {device.GetType().Name} to run at {DateTime.Now.AddHours(1)}...");
      device.Schedule(DateTime.Now.AddHours(1));
    }

    // Del 14: Extra utmaning - sök efter apparat
    smartHomeController.TurnOnDeviceByBrand("LG");
  }
}

/*

---- Frågor efter Del 1 ----

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

---- Frågor efter Del 2 ----

Fråga:
När jag lade till CoffeeMachine behövde jag ändra...

Svar:
Behövde lägga till kod på följande ställen:
   1. Skapa CoffeeMachine-objektet i Main.
   2. Lägga till objektet i listan devices.
   3. Lägga till en ny "else if (device is CoffeeMachine)"-gren i RunMorningRoutine.
   4. Lägga till en ny "else if (device is CoffeeMachine)"-gren i ReportAllEnergy.


---- Frågor efter Del 5 ----

1. Varför fungerar device.TurnOn() trots att device har typen Appliance?
2. Vilken metod körs om objektet egentligen är en RobotVacuum?
3. Vad blev bättre jämfört med List<object>

Svar:
1. Eftersom TurnOn() är en virtuell metod i bas-klassen Appliance, kommer
när vi anropar device.TurnOn(), att den körs polymorft. Det betyder att den version av TurnOn() 
som hör till den faktiska typen av objektet (t.ex. RobotVacuum) kommer att köras, även om variabeln device har typen Appliance.
2. Om objektet är en RobotVacuum, kommer RobotVacuum-klassens override av TurnOn() att köras.
3. Jämfört med List<object> behöver vi inte längre göra typkontroller och kastningar, vilket gör koden mer robust och lättare att underhålla.


---- Frågor efter Del 9 ----

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


---- Frågor efter Del 10 ----

Test A: Ta bort virtual
 -  Appliance.TurnOn()' because it is not marked virtual, abstract, or override
 -  För att kunna override TurnOn() i Refrigerator måste den vara markerad som virtual i bas-klassen Appliance. 
    Utan virtual kan inte TurnOn() polymorft anropas, och kompilatorn tillåter inte override i Refrigerator.

Test B: Ta bort override
- warning CS0114: 'Washer.TurnOn()' hides inherited member 'Appliance.TurnOn()'. 
  To make the current member override that implementation, add the override keyword. 
  Otherwise add the new keyword.
- Koden kompilerar, men utan override döljs Washers metod: via en Appliance-
  referens körs basklassens TurnOn() istället, så Washers version triggas inte.


 ---- Frågor efter Del 11 ----

 1. Blir utskriften samma?
    Nej. lamp1 och lamp2 är samma objekt, men utskriften blir olika.
    Med "new" bestämmer variabelns typ vilken metod som körs.

 2. Vilken metod körs när variabeln har typen SmartLamp?
    SmartLamps egen TurnOn() (den med "new").
    -> "Smart lamp IKEA in Hallway turns on with brightness 80%."

 3. Vilken metod körs när variabeln har typen Appliance?
    Appliance sin TurnOn(), även om objektet egentligen är en SmartLamp.
    -> "IKEA in Hallway is now ON."

 4. Varför är detta farligt eller förvirrande?
    Samma objekt gör olika saker beroende på variabelns typ.
    Man tror att metoden byts ut, men "new" bara gömmer den gamla.
    Det kan ge buggar som är svåra att hitta.

 5. Vad händer om du byter "new" till "override"?
    Då körs SmartLamps TurnOn() på båda raderna, för då bestämmer
    objektets riktiga typ. Utskriften blir lika på båda raderna.


 ---- Frågor efter Del 12 ----

 1. Vad säger kompilatorn?
    Fel CS0239: PizzaOven får inte override:a TurnOn(), för metoden är
    sealed i Oven.

 2. Varför får PizzaOven inte override:a TurnOn()?
    För att Oven har markerat TurnOn() med "sealed". Det stänger metoden
    så att ingen klass under Oven kan skriva om den igen.

 3. När kan det vara rimligt att använda sealed override?
    När en metod är "färdig" och man vill vara säker på att ingen subklass
    ändrar den, t.ex. för att skydda viktig logik.

 4. Vad kan PizzaOven fortfarande göra i stället?
    Den kan override:a andra metoder som inte är sealed, t.ex. GetInfo(),
    TurnOff() eller GetDailyEnergyUsage(). Bara TurnOn() är låst. Den ärver
    Ovens TurnOn() som den är och kan lägga till egna metoder/properties.

 ---- Fråga efter Del 13 ----

    Varför kan listan vara List<ISchedulable> även om objekten är olika klasser?
    För att alla objekten implementerar ISchedulable. Listan bryr sig inte om
    den exakta klassen, bara om att de uppfyller kontraktet. Därför har varje
    element garanterat NextRun och Schedule().
*/