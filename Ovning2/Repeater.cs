// Class that repeats a given word 10 times.

namespace Ovning2;

internal class Repeater(uint numRepeats = 10)
{
    public uint NumRepeats { get; set; } = numRepeats;

    public void Repeat(string word)
    {
        for (int i = 0; i < NumRepeats; i++)
        {
            Console.Write($"{word} ");
        }
        Console.WriteLine();
    }
}
