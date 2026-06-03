public class Washer
{
    public string Brand { get; set; }
    public int Temperature { get; set; }

    private const double KWhPerDegree = 1.2;  // TODO: Placeholder rate, adjusted based on real data later

    public void StartWash()
    {
        Console.WriteLine($"{Brand} Starts washing.");
    }
    public void StopWash()
    {
        Console.WriteLine($"{Brand} Stops washing.");
    }
    public void PrintWashEnergy(int temp)
    {
        Console.WriteLine($"LG washer uses {KWhPerDegree} kwh per wash.");
    }
}