namespace Starship_Minii.Models;

public class BaseShip
{
    // --- Properties ---

    public double Speed { get; set; }

    public double Weight { get; set; }


    // --- Constructors ---

    public BaseShip(double speed, double weight)
    {
        Speed = speed;
        Weight = weight;
    }

    public BaseShip()
    {
    }


    // --- Virtual Method ---

    public virtual void Fly()
    {
        Console.WriteLine($"The ship is flying with {Speed} km/h.");
    }


    // --- ToString ---

    public override string ToString()
    {
        return $"Speed: {Speed}, Weight: {Weight}";
    }
}