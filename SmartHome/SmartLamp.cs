public class SmartLamp : Appliance
{
    public int Brightness { get; set; }
    public SmartLamp(string brand, string room, int brightness)
    : base(brand, room)
    {
        Brightness = brightness;
    }
    public new void TurnOn()
    {
        Console.WriteLine($"Smart lamp {Brand} in {Room} turns on with brightness {Brightness}%.");
    }
}
