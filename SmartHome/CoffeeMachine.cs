public class CoffeeMachine : Appliance
{
    public int CupsPerBrew { get; }

    private const double DailyEnergyConsumption = 0.3;  // TODO: Placeholder rate, adjusted based on real data later

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
}