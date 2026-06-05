public class Washer : Appliance, ISchedulable
{
    public int CapacityKg { get; }
    private const double DailyEnergyConsumption = 1.2;  // TODO: Placeholder rate, adjusted based on real data later
    public DateTime NextRun { get; set; }
    public Washer(string brand, string room, int capacityKg) : base(brand, room)
    {
        CapacityKg = capacityKg;
    }
    public void Schedule(DateTime time)
    {
        NextRun = time;
        Console.WriteLine($"{Brand} is scheduled to run at {NextRun}.");
    }
    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} starts washing program.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} stops washing.");
    }
    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;

    public override string GetInfo() => $"{base.GetInfo()} — washer, {CapacityKg} kg drum";
}