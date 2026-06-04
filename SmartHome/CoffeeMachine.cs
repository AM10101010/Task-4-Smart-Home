public class CoffeeMachine
{
    public string Brand { get; set; }
    public int CupsPerBrew { get; set; }

    private const double KWhPerCup = 0.1;  // TODO: Placeholder rate, adjusted based on real data later

    public void StartBrewing()
    {
        Console.WriteLine($"Coffee machine {Brand} starts brewing {CupsPerBrew} cups.");
    }
    public void StopBrewing()
    {
        Console.WriteLine($"Coffee machine {Brand} has stopped brewing.");
    }
    public void PrintBrewingEnergy(int cups)
    {
        double total = KWhPerCup * cups;
        Console.WriteLine($"Coffee machine {Brand} uses {total} kWh to brew {cups} cups.");
    }
}