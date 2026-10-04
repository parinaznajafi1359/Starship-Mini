namespace Starship_Minii.Models;

public class BaseShip
{
    // --- Properties ---

    public double Speed { get; set; }

    public double Weight { get; set; }


    // --- Ctor ---

    public BaseShip()
    {
    }


    // --- Virtual Method ---

    public virtual void Fly()
    {
        Console.WriteLine("The ship is flying.");
    }
}