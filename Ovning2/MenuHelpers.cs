// Classes that support the main menu in Ovning2.

using System.Text;

namespace Ovning2.MenuHelpers;

// Name all the menu options here to keep them consistent
public enum MenuOption : uint
{
    Quit,          // Quit the program
    SingleTicket,  // Single ticket price
    GroupTicket,   // Group ticket price
    RepeatWord,    // Repeat a word
    FindWord       // Find 3rd word in a sentence
}

public static class MenuHelper
{
    public static readonly Dictionary<MenuOption, string> MenuOptionDescriptions = new()
    {
        { MenuOption.Quit,         "Quit this program" },
        { MenuOption.SingleTicket, "Find the price of a single movie ticket" },
        { MenuOption.GroupTicket,  "Calculate the total price of tickets for a group" },
        { MenuOption.RepeatWord,   "Repeat a given word 10 times" },
        { MenuOption.FindWord,     "Find the third word in a sentence" }
    };

    /* Get the max length of the names of any menu options
     * Used for formatting the menu
     */
    private static readonly int MaxOptionLength =
        Enum.GetValues(typeof(MenuOption)).Cast<MenuOption>()
            .Select(option => option.ToString().Length).Max();

    public static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to my console app!");
        Console.WriteLine();
        Console.WriteLine("Choose one of the options below.");

        StringBuilder stringBuilder = new();
        /* Want to end up with format looking like "{0} : {1,-12} : {2}"
         * assuming MaxOptionLength = 12
         * This is then passed 0 = (uint) option, 1 = (string) option, 2 = description
         */
        string format = string.Format(
            "{0}0{1} : {0}1,-{2}{1} : {0}2{1}",
            "{", "}", MaxOptionLength);

        foreach (MenuOption option in Enum.GetValues<MenuOption>())
            stringBuilder.AppendLine(string.Format(
                format, (uint)option, option, MenuOptionDescriptions[option]));
        
        Console.WriteLine(stringBuilder.ToString());
        Console.WriteLine();
    }
}