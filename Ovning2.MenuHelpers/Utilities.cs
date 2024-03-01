// Utility class for requesting and interpreting user input.

namespace Ovning2.MenuHelpers;

public static class Utilities
{
    public static string AskForString(string prompt)
    {
        string? readResult;
        string answer;

        // Ask the user for a string to input. Repeat if empty.
        Console.Write(prompt);
        do
        {
            readResult = Console.ReadLine();

            // Empty input
            if (string.IsNullOrWhiteSpace(readResult))
            {
                Console.Write("Cannot use an empty value. Try again: ");
                continue;
            }

            // Valid input
            answer = readResult;
            break;
        } while (true);

        return answer;
    }

    public static uint AskForUInt(string prompt)
    {
        string? readResult;
        uint answer;

        // Ask the user for a uint. Repeat if invalid.
        Console.Write(prompt);
        do
        {
            readResult = Console.ReadLine();

            // Empty input
            if (string.IsNullOrWhiteSpace(readResult))
            {
                Console.Write("Cannot use an empty value. Try again: ");
                continue;
            }

            // Input not interpretable as a uint
            if (!uint.TryParse(readResult, out answer))
            {
                Console.Write($"Could not parse '{readResult}' as a value. Try again: ");
                continue;
            }

            // Valid input
            break;
        } while (true);

        return answer;
    }

    public static MenuOption AskForOption(string prompt)
    {
        string? readResult;
        MenuOption option;

        // Ask the user for one of the menu options. Repeat until valid.
        Console.Write(prompt);
        do
        {
            readResult = Console.ReadLine();

            // Empty input
            if (string.IsNullOrWhiteSpace(readResult))
            {
                Console.Write("Cannot use an empty value. Try again: ");
                continue;
            }

            // Result not a recognized MenuOptions value
            if (!Enum.TryParse(readResult, out option))
            {
                Console.Write($"The choice '{readResult}' is not a valid option. Try again: ");
                continue;
            }

            // Valid MenuOptions value
            break;
        } while (true);

        return option;
    }
}
