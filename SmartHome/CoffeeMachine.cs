public class CoffeeMachine
{
    public string Brand { get; set; }
    public int CupsPerBrew { get; set; }

    private const double KWhPerCup = 0.1;  // TODO: Placeholder rate, adjusted based on real data later

    public void StartBrewing()
    {
        Console.WriteLine("Starta kaffebryggning");
    }
    public void StopBrewing()
    {
        Console.WriteLine("Stoppa kaffebryggning");
    }
    public void PrintBrewingEnergy(int cups)
    {
        double total = KWhPerCup * cups;
        Console.WriteLine($"Kaffemaskin {Brand} använder {total} kWh för att brygga {cups} koppar.");
    }
}