public class Oven : Appliance
{
    public int MaxTemperature { get; }
    private const double DailyEnergyConsumption = 2.5;  // TODO: Placeholder rate, adjusted based on real data later
    public Oven(string brand, string room, int maxTemperature) : base(brand, room)
    {
        MaxTemperature = maxTemperature;
    }
    public sealed override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"Oven {Brand} starts preheating.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"Oven {Brand} turns off the heat.");
    }
    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;
    public override string GetInfo() => $"{base.GetInfo()} — oven, max temperature {MaxTemperature}°C";
}