// Utility class for requesting and interpreting user input.

namespace Ovning2.MenuHelpers;

/* Define the type of a try-parsing function.
 * A try-parse style function takes an input, fills in a result,
 * and returns a bool based on whether parsing was successful.
 * This kind of try-parse function is used in all the AskFor* methods.
 */
public delegate bool TryParse<T>(string input, out T result);

public static class Utilities
{
    /* Core looping logic of all AskFor* methods.
     * Uses an initial prompt to ask a user for an input.
     * The input is passed to a try-parse style function.
     * If that function fails, the errorFormatter is used to relay
     * that back to the user before asking them to try again.
     */
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

            // Apply the try-parse function
            bool success = tryParse(readResult, out result);
            if (!success)
            {
                Console.WriteLine(string.Format(errorFormatter, readResult));
                continue;
            }

            // If we make it here, valid result was obtained
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
        string errorFormatter = "Could not parse '{0}' as an integer. Try again:";
        return AskForBase<uint>(prompt, tryParse, errorFormatter);
    }

    public static MenuOption AskForOption(string prompt)
    {
        static bool tryParse(string readResult, out MenuOption option)
        {
            /* Previously, only Enum.TryParse was used
             * Unfortunately, for string inputs that evaluate to
             * integers of the correct type, it does not catch whether
             * the value is out of bounds. For that we need Enum.IsDefined as well.
             */
            bool success = Enum.TryParse(readResult, out option);
            if (!success) return success;
            success &= Enum.IsDefined<MenuOption>(option);
            return success;
        }
        string errorFormatter = "The choice '{0}' is not a valid menu option. Try again:";
        return AskForBase<MenuOption>(prompt, tryParse, errorFormatter);
    }

    public static bool AskForYesNo(string prompt)
    {
        static bool tryParse(string readResult, out bool result)
        {
            bool success = false;
            string answerString = readResult.Trim().ToLower();
            // This is really "Ask for a word that starts with y or n"
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
            else result = default;

            return success;
        }
        string errorFormatter = "Could not parse '{0}' as [y]es or [n]o. Try again:";
        return AskForBase<bool>(prompt, tryParse, errorFormatter);
    }

    // Ignore the following separators when parsing lists
    private static readonly char[] separators = [' ', ',', ';', '-'];

    public static uint[] AskForUInts(string prompt, uint length)
    {
        bool tryParse(string readResult, out uint[] values)
        {
            values = new uint[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = default;
            }

            /* To handle a variety of separators and spacing,
             * combine the `TrimEntries` and `RemoveEmptyEntries` flags
             */
            StringSplitOptions options =
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            string[] numStrings = readResult.Split(
                separator: separators, options: options);
            if (length != numStrings.Length) return false;

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
