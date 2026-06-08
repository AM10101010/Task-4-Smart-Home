public class PizzaOven : Oven
{
    public PizzaOven(string brand, string room, int maxTemperature)
        : base(brand, room, maxTemperature)
    {
    }

    public new void TurnOn()   
    {
        Console.WriteLine("Pizza oven starts at extra high temperature.");
    }
}