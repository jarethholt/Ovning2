// Helper class for holding ticket prices

namespace Ovning2.Tickets;

// Available ticket categories
public enum CategoryName
{
    Youth,
    Senior,
    Standard
}

// Struct to hold description of a ticket category
readonly struct TicketCategory
{
    public readonly CategoryName categoryName;
    public readonly uint price;

    public TicketCategory(CategoryName categoryName, uint price)
    {
        this.categoryName = categoryName;
        this.price = price;
    }
}

internal static class TicketPrices
{
    // Only contains a list of the ticket prices
    public static readonly TicketCategory[] TicketCategories =
    [
        new(CategoryName.Youth, 80),
        new(CategoryName.Senior, 90),
        new(CategoryName.Standard, 120)
    ];
}
