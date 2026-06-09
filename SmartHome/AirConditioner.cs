public class AirConditioner : Appliance, ISchedulable
{
    public int TargetTemperature { get; }
    public DateTime NextRun { get; set; }

    private const double DailyEnergyConsumption = 5.0;  // TODO: Placeholder rate, adjusted based on real data later

    public AirConditioner(string brand, string room, int targetTemperature) : base(brand, room)
    {
        TargetTemperature = targetTemperature;
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"Air conditioner {Brand} starts cooling the room to {TargetTemperature}°C.");
    }

    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"Air conditioner {Brand} powers down.");
    }

    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;

    public override string GetInfo() => $"{base.GetInfo()} — air conditioner, target {TargetTemperature}°C";

    public void Schedule(DateTime time)
    {
        NextRun = time;
        Console.WriteLine($"Air conditioner {Brand} scheduled to run at {time}.");
    }
}
