// Driver of the main application menu

namespace Ovning2;

internal class Program
{
    // Create classes that will run their respective actions
    static readonly Repeater repeater = new();
    static readonly NthWordFinder wordFinder = new();
    static readonly TicketPrices ticketPrices = new();

    static void Main(string[] args)
    {
        bool again = true;
        do
        {
            MenuHelper.DisplayMenu();
            MenuOption option = Utilities.AskForOption(
                "Your choice (use either the number or name of the subprogram):");

            // Each action can be looped except for Quit
            Action? action = null;
            string againPrompt = "";

            switch(option)
            {
                case MenuOption.Quit:
                    again = false;
                    break;
                case MenuOption.SingleTicket:
                    action = ticketPrices.SingleTicketApp;
                    againPrompt = "Would you like to find another ticket price (y/n)?";
                    break;
                case MenuOption.GroupTicket:
                    action = ticketPrices.GroupTicketApp;
                    againPrompt =
                        "Would you like to calculate the price for another group (y/n)?";
                    break;
                case MenuOption.RepeatWord:
                    action = repeater.RepeatApp;
                    againPrompt = "Would you like to repeat another word (y/n)?";
                    break;
                case MenuOption.FindWord:
                    action = wordFinder.FindWordApp;
                    againPrompt = "Would you like to do another sentence (y/n)?";
                    break;
            }

            if (again)
            {
                Utilities.KeepLooping(action!, againPrompt);
            }
        } while (again);
    }
}
