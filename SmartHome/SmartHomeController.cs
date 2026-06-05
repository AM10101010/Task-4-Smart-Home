public class SmartHomeController
{
    private List<Appliance> _devices = new List<Appliance>();
    public void AddDevice(Appliance device)
    {
        _devices.Add(device);
    }
    public void TurnOnAll()
    {
        foreach (Appliance device in _devices)
        {
            Console.WriteLine($"Turning on {device.GetInfo()}...");
            device.TurnOn();
        }

    }
    public void TurnOffAll()
    {
        foreach (Appliance device in _devices)
        {
            Console.WriteLine($"Turning off {device.GetInfo()}...");
            device.TurnOff();
        }
    }
    public void PrintStatusReport()
    {
        foreach (Appliance device in _devices)
        {
            Console.WriteLine($"{device.GetInfo()} is {(device.IsOn ? "ON" : "OFF")}");
        }
    }
    public double GetTotalDailyEnergyUsage()
    {
        double totalEnergyUsage = 0;
        foreach (Appliance device in _devices)
        {
            totalEnergyUsage += device.GetDailyEnergyUsage();
        }
        return totalEnergyUsage;
    }
    public void ScheduleAllSchedulableDevices(DateTime time)
    {
        foreach (Appliance device in _devices)
        {
            // 1. Kontrollera om device implementerar ISchedulable.
            if (device is ISchedulable schedulable) { schedulable.Schedule(time); }
        }
    }
}