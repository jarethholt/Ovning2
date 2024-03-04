// Helper class for holding ticket prices and categories

namespace Ovning2.Tickets;

// Available ticket categories
// enum isn't necessary but I wanted to try it out
public enum CategoryName
{
    Youth,
    Senior,
    Standard
}

public static class TicketPrices
{
    // Only contains a list of the ticket prices
    public static readonly Dictionary<CategoryName, uint> TicketCategories = new()
    {
        { CategoryName.Youth   ,  80 },
        { CategoryName.Senior  ,  90 },
        { CategoryName.Standard, 120 }
    };

    public static uint DecidePrice(uint age)
    {
        CategoryName categoryName;
        if (age < 20)
            categoryName = CategoryName.Youth;
        else if (age > 64)
            categoryName = CategoryName.Senior;
        else
            categoryName = CategoryName.Standard;
        return TicketCategories[categoryName];
    }

    public static uint DecideTotalPrice(uint[] ages)
    {
        // Decide the total price from an array of ages
        // Uses a straightforward calculation method
        uint total = 0;
        foreach (uint age in ages)
        {
            total += DecidePrice(age);
        }
        return total;
    }
}


/* Similarly, this implementation was more for me to practice
 * defining and passing delegates and using some LINQ functionality
 */

// Type of function that determines whether someone fits an age category
public delegate bool AgeCheck(uint age);

// Type of tuple that combines an AgeCheck with the associated price
public class CheckAndPrice(AgeCheck checker, uint price)
{
    public AgeCheck Checker { get; init; } = checker;
    public uint Price { get; init; } = price;
}

public static class TicketPrices2
{
    public static readonly Dictionary<CategoryName, CheckAndPrice> TicketCategories = new()
    {
        { CategoryName.Youth   , new((uint age) => age < 20,  80) },
        { CategoryName.Senior  , new((uint age) => age > 64,  90) },
        { CategoryName.Standard, new((uint age) => true    , 120) }
    };

    public static uint DecidePrice(uint age)
    {
        KeyValuePair<CategoryName, CheckAndPrice> kvp = TicketCategories
            .First(kvp => kvp.Value.Checker(age));
        return kvp.Value.Price;
    }
}

