// Utility class for requesting and interpreting user input.

namespace Ovning2.MenuHelpers;

// Define the type of a try-parsing function
public delegate bool TryParse<T>(string input, out T result);

public static class Utilities
{
    // This method forms the basis of all others
    public static T AskForBase<T>(string prompt, TryParse<T> tryParse, string errorFormatter)
    {
        string? readResult;
        T result;

        Console.WriteLine(prompt);
        do
        {
            readResult = Console.ReadLine();

            // Empty input
            if (string.IsNullOrWhiteSpace(readResult))
            {
                Console.WriteLine("Cannot use an empty value. Try again.");
                continue;
            }

            // Apply the parser
            bool success = tryParse(readResult, out result);
            if (!success)
            {
                Console.WriteLine(string.Format(errorFormatter, readResult));
                continue;
            }

            // Result is valid!
            break;
        } while (true);

        return result;
    }

    public static string AskForString(string prompt)
    {
        static bool tryParse(string readResult, out string result)
        {
            result = readResult;
            return true;
        }
        string errorFormatter = "";
        return AskForBase<string>(prompt, tryParse, errorFormatter);
    }

    public static uint AskForUInt(string prompt)
    {
        TryParse<uint> tryParse = uint.TryParse;
        string errorFormatter = "Could not parse '{0}' as an integer. Try again: ";
        return AskForBase<uint>(prompt, tryParse, errorFormatter);
    }

    public static MenuOption AskForOption(string prompt)
    {
        static bool tryParse(string readResult, out MenuOption option)
        {
            bool success = Enum.TryParse(readResult, out option);
            if (!success) return success;
            success &= Enum.IsDefined<MenuOption>(option);
            return success;
        }
        string errorFormatter = "The choice '{0}' is not a valid menu option. Try again: ";
        return AskForBase<MenuOption>(prompt, tryParse, errorFormatter);
    }

    public static bool AskForYesNo(string prompt)
    {
        static bool tryParse(string readResult, out bool result)
        {
            bool success = false;
            string answerString = readResult.Trim().ToLower();
            if (answerString.StartsWith('y'))
            {
                result = true;
                success = true;
            }
            else if (answerString.StartsWith('n'))
            {
                result = false;
                success = true;
            }
            else
            {
                result = default;
            }
            return success;
        }
        string errorFormatter = "Could not parse '{0}' as [y]es or [n]o. Try again: ";
        return AskForBase<bool>(prompt, tryParse, errorFormatter);
    }

    private static readonly char[] separator = [' ', ',', ';', '-'];

    public static uint[] AskForUInts(string prompt, uint length)
    {
        bool tryParse(string readResult, out uint[] values)
        {
            values = new uint[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = default;
            }

            string[] numStrings = readResult.Split(
                separator: separator,
                options: StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (length != numStrings.Length)
            {
                return false;
            }

            bool success = false;
            for (int i = 0; i < length; i++)
            {
                success = uint.TryParse(numStrings[i], out values[i]);
                if (!success) break;
            }
            return success;
        }
        string errorFormatter = "Could not parse all entries as integers. Try again: ";
        return AskForBase<uint[]>(prompt, tryParse, errorFormatter);
    }
}
