public class Oven
{
    public string Brand { get; set; }
    public int MaxTemperature { get; set; }
    private const double KWhPerDegree = 2.5;  // TODO: Placeholder rate, adjusted based on real data later
    public void StartCooking()
    {
        Console.WriteLine($"Starting cooking with {Brand} at max temperature {MaxTemperature} degrees.");
    }
    public void StopCooking()
    {
        Console.WriteLine($"Stopping cooking with {Brand}.");
    }
    public void PrintHeatingEnergy(int temp)
    {
        Console.WriteLine($"Oven {Brand} uses {KWhPerDegree} kWh per hour.");
    }
}