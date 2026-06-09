public class RobotVacuum : Appliance, ISchedulable
{

    public int BatteryLevel { get; }
    private const double DailyEnergyConsumption = 0.4;
    public DateTime NextRun { get; set; }
    public void Schedule(DateTime time)
    {
        NextRun = time;
        Console.WriteLine($"Robot vacuum {Brand} is scheduled to run at {NextRun}.");
    }

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