// Classes that support the main menu in Ovning2.

using System.Text;

namespace Ovning2.MenuHelpers;

public enum MenuOptions : uint
{
    Quit
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
        string[] names = Enum.GetNames(typeof(MenuOptions));
        var values = Enum.GetValues(typeof(MenuOptions));
        int numOptions = names.Length;
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < numOptions; i++)
        {
            stringBuilder.AppendLine($"{values.GetValue(i)}: {names[i]}");
        }
        Console.WriteLine(stringBuilder.ToString());
        Console.WriteLine();
    }
}