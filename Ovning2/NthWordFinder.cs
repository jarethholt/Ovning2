// Class the finds the nth word in a sentence.

using System.Text.RegularExpressions;

namespace Ovning2;

internal class NthWordFinder(uint wordNumber = 3)
{
    public uint WordNumber
    {
        get { return wordNumber; }
        set
        {
            // Cannot accept 0 as a wordNumber
            // Supposed to be the number, not the index
            if (value == 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(value),
                    message: "Cannot extract word number 0 from a sentence; use a value > 0");

            wordNumber = value;
        }
    }

    // Add the ordinal to the WordNumber (1 -> 1st, 3 -> 3rd, etc.)
    // Taken from: https://stackoverflow.com/a/20175
    private string WordNumberOrdinal
    {
        get
        {
            switch (WordNumber % 100)
            {
                case 11:
                case 12:
                case 13:
                    return WordNumber.ToString() + "th";
            }

            return (WordNumber % 10) switch
            {
                1 => WordNumber.ToString() + "st",
                2 => WordNumber.ToString() + "nd",
                3 => WordNumber.ToString() + "rd",
                _ => WordNumber.ToString() + "th",
            };
        }
    }

    public string FindWord(string sentence)
    {
        // Remove punctuation using the punctuation character class
        string noPunctuation = Regex.Replace(sentence, "\\p{P}", " ");
        string[] words = noPunctuation.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < WordNumber)
            throw new ArgumentException(
                $"Cannot find word number {WordNumber} in a sentence with {words.Length} words");

        return words[WordNumber - 1];  // Convert number to index
    }

    // Primary subprogram for main menu
    public void FindWordApp()
    {
        Console.Clear();
        Console.WriteLine("In this subprogram, you provide a sentence.");
        Console.WriteLine("We will then find the 3rd word in the sentence.");
        Console.WriteLine();
        string[] words = Utilities.AskForSentence("What is your sentence?", WordNumber);
        Console.WriteLine();
        Console.WriteLine(string.Format(
            "The {0} word in the sentence is: '{1}'",
            WordNumberOrdinal, words[WordNumber - 1]));
    }
}
