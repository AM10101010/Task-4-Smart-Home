public class RobotVacuum
{
    public string Brand { get; set; }
    public int BatteryLevel { get; set; }
    private const double KWhPerBatteryLevel = 0.4; // TODO: Placeholder rate, adjusted based on real data later

    public void StartCleaning()
    {
        Console.WriteLine($"Robot vacuum {Brand} is cleaning with battery level {BatteryLevel}%.");
    }
    public void StopCleaning()
    {
        Console.WriteLine($"Robot vacuum {Brand} has stopped cleaning.");
    }
    public void PrintCleaningEnergy(int energy)
    {
        Console.WriteLine($"Xiaomi robot vacuum uses {KWhPerBatteryLevel} kWh per cleaning session.");
    }
}