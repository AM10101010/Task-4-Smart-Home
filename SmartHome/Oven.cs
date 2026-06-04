public class Oven : Appliance
{
    public int MaxTemperature { get; set; }
    private const double DailyEnergyConsumption = 2.5;  // TODO: Placeholder rate, adjusted based on real data later
    public Oven(string brand, string room, int maxTemperature) : base(brand, room)
    {
        MaxTemperature = maxTemperature;
    }
    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"Oven {Brand} is now on.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"Oven {Brand} is now off.");
    }       
    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;
    public override string GetInfo() => $"{base.GetInfo()} — oven, max temperature {MaxTemperature}°C";
}