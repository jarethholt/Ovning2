// Helper class for holding ticket prices

namespace Ovning2.Tickets;

// Available ticket categories
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
}
