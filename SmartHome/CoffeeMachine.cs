public class CoffeeMachine : Appliance
{
    public int CupsPerBrew { get; set; }

    private const double DailyEnergyConsumption = 0.3;  // TODO: Placeholder rate, adjusted based on real data later

    public CoffeeMachine(string brand, string room, int cupsPerBrew) : base(brand, room)
    {
        CupsPerBrew = cupsPerBrew;
    }
    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"Coffee machine {Brand} is now on.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"Coffee machine {Brand} is now off.");
    }
    public override double GetDailyEnergyUsage() => DailyEnergyConsumption;
    public override string GetInfo() => $"{base.GetInfo()} — coffee machine, brews {CupsPerBrew} cups per brew";    
}