public class PizzaOven : Oven
{
    public PizzaOven(string brand, string room, int maxTemperature)
        : base(brand, room, maxTemperature)
    {
    }
    public override string GetInfo()
        => $"{base.GetInfo()} — pizza oven, runs extra hot";

    //public override void TurnOn() //When sealed is used, it prevents any further overriding of this method in derived classes.
    // CS0239: 'PizzaOven.TurnOn()' : cannot override inherited member'Oven.TurnOn()' because it is sealed
    //{
    //    Console.WriteLine("Pizza oven starts at extra high temperature.");
    //}
}