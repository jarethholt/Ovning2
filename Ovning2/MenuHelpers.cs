// Classes that support the main menu in Ovning2.

using System.Text;

namespace Ovning2.MenuHelpers;

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
    public static readonly Dictionary<MenuOption, string> Descriptions = new()
    {
        { MenuOption.Quit,         "Quit this program" },
        { MenuOption.SingleTicket, "Find the price of a single movie ticket" },
        { MenuOption.GroupTicket,  "Calculate the total price of tickets for a group" },
        { MenuOption.RepeatWord,   "Repeat a given word 10 times" },
        { MenuOption.FindWord,     "Find the third word in a sentence" }
    };

    private static readonly int MaxOptionLength =
        Enum.GetValues(typeof(MenuOption)).Cast<MenuOption>()
        .Select(option => option.ToString().Length).Max();

    public static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to my console app!");
        Console.WriteLine();
        Console.WriteLine("Choose one of the options below.");

        // Construct the options from the MenuOptions
        StringBuilder stringBuilder = new();
        string format = string.Format(
            "{0}0{1} : {0}1,-{2}{1} : {0}2{1}",
            "{", "}", MaxOptionLength);

        foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
        {
            stringBuilder.AppendLine(string.Format(
                format, (uint)option, option, Descriptions[option]));
        }
        Console.WriteLine(stringBuilder.ToString());
        Console.WriteLine();
    }
}