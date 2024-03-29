﻿// Helper class for holding ticket prices and categories

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

// Similarly, a base class absolutely isn't necessary but I did TicketPrices twice
public abstract class TicketPricesBase
{
    public abstract uint DecidePrice(uint age);
    public abstract uint DecideTotalPrice(uint[] ages);

    public void SingleTicketApp()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the ticket price info subprogram!");
        Console.WriteLine("We can tell you the price of a single ticket based on your age.");
        Console.WriteLine();
        uint age = Utilities.AskForUInt("Please enter your age: ");

        uint price = DecidePrice(age);

        Console.WriteLine();
        Console.WriteLine($"The price of a ticket for your age {age} is {price}kr.");
    }

    public void GroupTicketApp()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the group ticket price calculator!");
        Console.WriteLine(
            "This subprogram calculates the total price for a group based on their ages.");
        Console.WriteLine();
        uint length = Utilities.AskForUInt("How many are in your group? ");
        uint[] ages = Utilities.AskForUInts(
            "What are their ages? (Separate them using space, comma, or a combination)",
            length);

        uint totalPrice = DecideTotalPrice(ages);

        Console.WriteLine();
        Console.WriteLine(
            $"The total price for your group of {length} people is {totalPrice}kr.");
    }
}


// Original, straightforward implementation of TicketPrices
public class TicketPrices : TicketPricesBase
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

    public override uint DecidePrice(uint age)
    {
        CategoryName categoryName = age switch
        {
            <    5 => CategoryName.Child,
            <   20 => CategoryName.Youth,
            <=  64 => CategoryName.Standard,
            <= 100 => CategoryName.Senior,
            _      => CategoryName.Centenarian
        };
        return TicketCategories[categoryName];
    }

    public override uint DecideTotalPrice(uint[] ages)
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

public class TicketPrices_Advanced : TicketPricesBase
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

    public override uint DecidePrice(uint age)
    {
        // Decide the price using LINQ.First (for practicing with LINQ)
        KeyValuePair<CategoryName, CheckAndPrice> kvp = TicketCategories
            .First(kvp => kvp.Value.Checker(age));
        return kvp.Value.Price;
    }

    /* LINQ.Sum is not provided for uint, only signed integers.
     * This wrapper handles the resulting conversions.
    private int DecidePriceInt(uint age) => (int)DecidePrice(age);
    public override uint DecideTotalPrice(uint[] ages) =>
        (uint) ages.Sum(DecidePriceInt);
     */

    // Alternatively LINQ's Aggregate can be used
    public override uint DecideTotalPrice(uint[] ages) =>
        ages.Aggregate<uint, uint>(0, (uint curr, uint next) => curr + next);
}

