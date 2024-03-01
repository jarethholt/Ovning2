// Classes that support the main menu in Ovning2.

using System.Text;

namespace Ovning2.MenuHelpers;

public enum MenuOption : uint
{
    Quit,
    // Single ticket price
    // Group ticket price
    Repeat = 3  // Repeat a word
}

public class MenuHelper
{
    public static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to my console app!");
        Console.WriteLine();
        Console.WriteLine("Choose one of the options below.");

        // Construct the options from the MenuOptions
        StringBuilder stringBuilder = new();

        foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
        {
            stringBuilder.AppendLine($"{(uint)option}: {option}");
        }
        Console.WriteLine(stringBuilder.ToString());
        Console.WriteLine();
    }
}