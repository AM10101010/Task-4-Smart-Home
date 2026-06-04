public class Appliance
{
    public string Brand { get; }
    public string Room { get; }
    public bool IsOn { get; protected set; }
    public Appliance(string brand, string room)
    {
        Brand = brand;
        Room = room;
        IsOn = false;
    }
    public virtual string GetInfo()
    {
        return $"{Brand} in {Room}";
    }
    public virtual void TurnOn()
    {
        IsOn = true;
        Console.WriteLine($"{Brand} in {Room} is now ON.");
    }
    public virtual void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Brand} in {Room} is now OFF.");
    }
    public virtual double GetDailyEnergyUsage()
    {
        return 0;
    }
}