public class CoffeeMachine : Appliance, ISchedulable
{
    public int CupsPerBrew { get; }
    public DateTime NextRun { get; set; }

    private const double DailyEnergyConsumption = 0.3;
    public CoffeeMachine(string brand, string room, int cupsPerBrew) : base(brand, room)
    {
        CupsPerBrew = cupsPerBrew;
    }
    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"Coffee machine {Brand} starts brewing {CupsPerBrew} cups.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"Coffee machine {Brand} stops brewing.");
    }
    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;
    public override string GetInfo() => $"{base.GetInfo()} — coffee machine, brews {CupsPerBrew} cups per brew";

    public void Schedule(DateTime time)
    {
        NextRun = time;
        Console.WriteLine($"{Brand} is scheduled to run at {NextRun}.");
    }
}