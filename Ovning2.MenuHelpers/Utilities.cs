﻿// Utility class for requesting and interpreting user input.

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

    public static bool AskForYesNo(string prompt)
    {
        string? readResult;
        bool answer;

        // Ask the user a yes/no question
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

            string answerString = readResult.Trim().ToLower();
            if (answerString.StartsWith('y'))
            {
                answer = true;
                break;
            }
            else if (answerString.StartsWith('n'))
            {
                answer = false;
                break;
            }
            else
            {
                // Unparseable answer
                Console.Write($"Could not parse '{answerString}' as [y]es or [n]o. Try again: ");
                continue;
            }
        } while (true);

        return answer;
    }

    private static readonly char[] separator = [' ', ',', ';', '-'];

    public static uint[] AskForUInts(string prompt, uint length)
    {
        string? readResult;
        uint[] result = new uint[length];

        // Ask the user to provide several numbers
        // Fails if any of them is unparseable
        Console.WriteLine(prompt);
        do
        {
            readResult = Console.ReadLine();

            // Empty input
            if (String.IsNullOrWhiteSpace(readResult))
            {
                Console.Write("Cannot use an empty value. Try again: ");
                continue;
            }

            // Split the string into components
            string[] numStrings = readResult.Split(
                separator: separator,
                options: StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (length != numStrings.Length)
            {
                Console.Write(
                    $"Expected {length} values, got {numStrings.Length}. Try again: ");
                continue;
            }

            // Attempt to parse the components
            bool success = false;
            for (int i = 0; i < length; i++)
            {
                success = uint.TryParse(numStrings[i], out result[i]);
                if (!success)
                {
                    break;
                }
            }
            if (!success)
            {
                Console.Write("Could not parse all components as uint. Try again: ");
                continue;
            }

            // If we got this far, the parsing was successful!
            break;
        } while (true);

        return result;
    }
}
