public class RobotVacuum : Appliance
{
    public int BatteryLevel { get; set; }
    private const double DailyEnergyConsumption = 0.4; // TODO: Placeholder rate, adjusted based on real data later

    public RobotVacuum(string brand, string room, int batteryLevel) : base(brand, room)
    {
        BatteryLevel = batteryLevel;
    }
    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"Robot vacuum {Brand} starts cleaning.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"Robot vacuum {Brand} has stopped cleaning.");
    }
    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;

    public override string GetInfo() => $"{base.GetInfo()} — robot vacuum, battery level {BatteryLevel}%";
}