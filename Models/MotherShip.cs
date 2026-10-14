namespace Starship_Mini.Models;

// has-a relationship
// 1 Mothership has n Basehips
public class MotherShip
{
    private const int MAX_SHIPS = 10;
    
    // private List<BaseShip> _baseShips = new List<BaseShip>();
    // Invariants: [0, 10], no duplicates
    private List<BaseShip> _baseShips = [];

    public IReadOnlyList<BaseShip> BaseShips => _baseShips.AsReadOnly();

    // Dock
    public void Dock(BaseShip baseShip)
    {
        ArgumentNullException.ThrowIfNull(baseShip);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(BaseShips.Count, MAX_SHIPS);

        // For each element in the BaseShip List
        //  take the list element and call the equals to compare the list elem with the param
        if (BaseShips.Contains(baseShip))
            throw new ArgumentException("Baseship is already in the list");
        
        _baseShips.Add(baseShip);
    }
    
    // UnDock
    public void UnDock(BaseShip baseShip)
    {
        ArgumentNullException.ThrowIfNull(baseShip);

        // For each element in the BaseShip List
        //  take the list element and call the equals to compare the list elem with the param
        if (!BaseShips.Contains(baseShip))
            throw new ArgumentException("BaseShip is not in the list");
        
        _baseShips.Remove(baseShip);
    }
    
    
    // JavaScript: for (let baseship of baseships) {}
    // Java: for (var basehip : baseships) {}
    // C#: foreach (var basehip in basehips) {}
    
    // Imperative Version
    // Return the total number of crew members on all docked ships.
    public int SumCrewMembers_Imp()
    {
        int sum = 0;

        // type inferring
        // foreach (BaseShip baseship in BaseShips)
        // foreach (var foobar in new List<int>() { 1, 2, 3 } )
        foreach (var baseship in BaseShips )
        {
            sum += baseship.CrewMembers;
        }

        return sum;
    }
    
    // Declarative
    public int SumCrewMembers_Decl()
    {
        // Lambda: (spaceship) => int
        // int sum = BaseShips.Sum(baseship => baseship.CrewMembers);
        // return sum;
        
        return BaseShips.Sum((baseShip) => baseShip.CrewMembers);
    }
    
    // Return how many ships have more crew members than `limit`.
    public int NumberLargeCrew_Imp(int limit)
    {
        // BaseShip 1: 5 Crews // JA
        // BaseShip 2: 8 Crews // JA
        // BaseShip 3: 2 Crews // NEIN
        
        // NumberLargeCrew(4) -> Anzahl: 2

        int count = 0;
        
        foreach (var baseShip in BaseShips)
        {
            if (baseShip.CrewMembers > limit)
            {
                count++;
            }
        }

        return count;
    }

    public int NumberLargeCrew_Decl(int limit)
    {
        // predicate: (baseship) => bool
        return BaseShips.Count(baseShip => baseShip.CrewMembers > limit);
    }
    
    
    
    // Return all ships with more crew members than `limit`.
    public IReadOnlyList<BaseShip> LargeShips_Imp(int limit)
    {
        var largeShips = new List<BaseShip>();
        
        foreach (var baseShip in BaseShips)
        {
            if (baseShip.CrewMembers > limit)
            {
                largeShips.Add(baseShip);
            }
        }

        return largeShips;
    }
    
    // Return all ships with more crew members than `limit`.
    public IReadOnlyList<BaseShip> LargeShips_Decl(int limit)
    {
        // predicate: (baseship) => bool
        // List<BaseShip> largeShips = BaseShips
        //     .Where(baseShip => baseShip.CrewMembers > limit)
        //     .ToList();
        // return largeShips;

        // predicate: (baseship) => bool
        return BaseShips
            .Where(baseShip => baseShip.CrewMembers > limit)
            .ToList();
    }

    public int CountCaptainOnly()
    {
        return BaseShips.Count(ship => ship.HasShipOnlyCaptain);
    }

    public bool AnyShipFull()
    {
        return BaseShips.Any(ship => ship.IsShipFull);
    }
    public bool AllHaveMinCrew(int min)
    {
        return BaseShips.All(ship => ship.CrewMembers >= min);
    }

    public int SmallestCrew()
    {
        return BaseShips.Min(ship => ship.CrewMembers);
    }

    public int LargestCrew()
    {
        return BaseShips.Max(ship => ship.CrewMembers);
    }

    public DateOnly OldestBuildDate()
    {
        return BaseShips.Min(ship => ship.BuildAt);
    }

    public IReadOnlyList<string> ShipNames()
    {
        return BaseShips.Select(ship => ship.Name).ToList();
    }

    public IReadOnlyList<BaseShip> BuiltAfter(DateOnly date)
    {
        return BaseShips.Where(ship => ship.BuildAt > date).ToList();
    }

    public IReadOnlyList<BaseShip> SortedByName()
    {
        return BaseShips.OrderBy(ship => ship.Name).ToList();
    }

    public bool IsDocked(string name)
    {
        return BaseShips.Any(ship => ship.Name == name);
    }
    
    
    // Ex 6 - Imperative
    public int CountCaptainOnly_Imp()
    {
        int count = 0;

        foreach (var ship in BaseShips)
        {
            if (ship.HasShipOnlyCaptain)
            {
                count++;
            }
        }

        return count;
    }

    // Ex 7 - Imperative
    public bool AnyShipFull_Imp()
    {
        foreach (var ship in BaseShips)
        {
            if (ship.IsShipFull)
            {
                return true;
            }
        }

        return false;
    }

    // Ex 12 - Imperative
    public IReadOnlyList<string> ShipNames_Imp()
    {
        var names = new List<string>();

        foreach (var ship in BaseShips)
        {
            names.Add(ship.Name);
        }

        return names;
    }

}