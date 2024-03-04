// Class the finds the nth word in a sentence.

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

    public string FindWord(string sentence)
    {
        string[] words = sentence.Split(' ', options: StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < WordNumber)
            throw new ArgumentException(
                $"Cannot find word number {WordNumber} in a sentence with {words.Length} words");

        return words[WordNumber - 1];  // Convert number to index
    }
}
