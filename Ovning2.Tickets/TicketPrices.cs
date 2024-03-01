// Helper class for holding ticket prices

namespace Ovning2.Tickets;

// Available ticket categories
public enum CategoryName
{
    Youth,
    Senior,
    Standard
}

internal static class TicketPrices
{
    // Only contains a list of the ticket prices
    public static readonly Dictionary<CategoryName, uint> TicketCategories = new Dictionary<CategoryName, uint>()
    {
        { CategoryName.Youth   ,  80 },
        { CategoryName.Senior  ,  90 },
        { CategoryName.Standard, 120 }
    };
}
