// Class that repeats a given word 10 times.

namespace Ovning2;

internal class Repeater(uint numRepeats = 10)
{
    public uint NumRepeats { get; set; } = numRepeats;

    public void Repeat(string word)
    {
        /* This method has to take a word and then output:
         * 1. word, 2. word, 3. word, ...
         */
        for (int i = 1; i <= NumRepeats; i++)
        {
            if (i > 1) Console.Write(", ");
            Console.Write($"{i}. {word}");
        }
        Console.WriteLine();
    }

    public void RepeatApp()
    {
        Console.Clear();
        Console.WriteLine("In this subprogram, you provide a word.");
        Console.WriteLine($"That word will then be repeated {NumRepeats} times in the console.");
        Console.WriteLine();
        string word = Utilities.AskForString("What word should be repeated? ");
        Console.WriteLine();

        Repeat(word);
    }
}
