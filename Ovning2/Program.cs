using Ovning2.MenuHelpers;

namespace Ovning2;

internal class Program
{
    static void Main(string[] args)
    {
        // Run the menu interface
        do
        {
            MenuHelper.DisplayMenu();
            MenuOption option = Utilities.AskForOption("Your choice: ");

            switch (option)
            {
                case MenuOption.Quit:
                    Environment.Exit(0);
                    break;
            }

        } while (true);
    }
}
