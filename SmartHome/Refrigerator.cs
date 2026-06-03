public class Refrigerator
{
    public string Brand { get; set; }
    public int CapacityKg { get; set; }

    private const double KWhPerKg = 3.6;  // TODO: Placeholder rate, adjusted based on real data later

    public void StartCooling()
    {
       Console.WriteLine($"Refrigerator {Brand} starts cooling with capacity {CapacityKg} kg.");
    }
    public void StopCooling()
    {
        Console.WriteLine($"Refrigerator {Brand} stops cooling.");
    }
    public void PrintCoolingEnergy(int capacity)
    {
        Console.WriteLine($"Refrigerator {Brand} uses {KWhPerKg} kWh per day.");
    }
}