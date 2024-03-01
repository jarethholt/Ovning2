// Class that helps decide the price of a single ticket.
namespace Ovning2.Tickets;

public static class SinglePriceDecider
{
    public static uint DecidePrice(uint age)
    {
        CategoryName categoryName;
        if (age < 20)
        {
            categoryName = CategoryName.Youth;
        }
        else if (age > 64)
        {
            categoryName = CategoryName.Senior;
        }
        else
        {
            categoryName = CategoryName.Standard;
        }
        return TicketPrices.TicketCategories[categoryName];
    }
}
