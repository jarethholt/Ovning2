// Helper class for holding ticket prices and categories

namespace Ovning2;

// Available ticket categories
// enum isn't necessary but I wanted to try it out
public enum CategoryName
{
    Child,
    Youth,
    Standard,
    Senior,
    Centenarian
}

// Original, straightforward implementation of TicketPrices
public static class TicketPrices
{
    // Only contains the ticket prices
    public static readonly Dictionary<CategoryName, uint> TicketCategories = new()
    {
        { CategoryName.Child      ,   0 },
        { CategoryName.Youth      ,  80 },
        { CategoryName.Standard   , 120 },
        { CategoryName.Senior     ,  90 },
        { CategoryName.Centenarian,   0 }
    };

    public static uint DecidePrice(uint age)
    {
        CategoryName categoryName;
        if (age < 5)
            categoryName = CategoryName.Child;
        else if (age < 20)
            categoryName = CategoryName.Youth;
        else if (age > 100)
            categoryName = CategoryName.Centenarian;
        else if (age > 64)
            categoryName = CategoryName.Senior;
        else
            categoryName = CategoryName.Standard;
        return TicketCategories[categoryName];
    }

    public static uint DecideTotalPrice(uint[] ages)
    {
        uint total = 0;
        foreach (uint age in ages)
            total += DecidePrice(age);

        return total;
    }
}



/* This implementation was more for me to practice
 * defining and passing delegates and using some LINQ functionality
 */

// Type of function that determines whether someone fits an age category
public delegate bool AgeCheck(uint age);

// Type that combines an AgeCheck with the associated price
public class CheckAndPrice(AgeCheck checker, uint price)
{
    public AgeCheck Checker { get; init; } = checker;
    public uint Price { get; init; } = price;
}

public static class TicketPrices_Advanced
{
    /* This dictionary includes a category, an age-checking function,
     * and the associated price. A given age fits into the *first* category
     * for which the age-check passes. Thus the last entry should always be
     * Standard with an always-true function.
     */
    public static readonly Dictionary<CategoryName, CheckAndPrice> TicketCategories = new()
    {
        { CategoryName.Child      , new((uint age) => age <   5,   0) },
        { CategoryName.Youth      , new((uint age) => age <  20,  80) },
        { CategoryName.Centenarian, new((uint age) => age > 100,   0) },
        { CategoryName.Senior     , new((uint age) => age >  64,  90) },
        { CategoryName.Standard   , new((uint age) => true     , 120) }
    };

    public static uint DecidePrice(uint age)
    {
        // Decide the price using LINQ.First (for practicing with LINQ)
        KeyValuePair<CategoryName, CheckAndPrice> kvp = TicketCategories
            .First(kvp => kvp.Value.Checker(age));
        return kvp.Value.Price;
    }

    /* LINQ.Sum is not provided for uint, only signed integers.
     * This wrapper handles the resulting conversions.
     */
    private static int DecidePriceInt(uint age) => (int)DecidePrice(age);

    public static uint DecideTotalPrice(IEnumerable<uint> ages) =>
        (uint) ages.Sum(DecidePriceInt);
}

