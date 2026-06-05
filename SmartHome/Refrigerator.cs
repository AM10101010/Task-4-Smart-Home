public class Refrigerator : Appliance
{
    public int Temperature { get; }

    private const double DailyEnergyConsumption = 3.6;  // TODO: Placeholder rate, adjusted based on real data later

    public Refrigerator(string brand, string room, int temperature) : base(brand, room)
    {
        Temperature = temperature;
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"Refrigerator {Brand} starts cooling to {Temperature}°C.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"Refrigerator {Brand} stops cooling.");
    }
    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;

    public override string GetInfo() => $"{base.GetInfo()} — refrigerator, set to {Temperature}°C";
}