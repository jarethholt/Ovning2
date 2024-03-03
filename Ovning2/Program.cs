using Ovning2.MenuHelpers;
using Ovning2.Tickets;

namespace Ovning2;

internal class Program
{
    static readonly Repeater repeater = new();
    static readonly NthWordFinder wordFinder = new();

    static void Main(string[] args)
    {
        // Run the menu interface
        bool again = true;
        do
        {
            MenuHelper.DisplayMenu();
            MenuOption option = Utilities.AskForOption("Your choice: ");

            // Each action can be looped except for Quit
            Action? action = null;
            string againPrompt = "";

            switch(option)
            {
                case MenuOption.Quit:
                    again = false;
                    break;
                case MenuOption.SingleTicket:
                    action = GetSingleTicketPrice;
                    againPrompt = "Would you like to find another ticket price (y/n)? ";
                    break;
                case MenuOption.RepeatWord:
                    action = RepeatWord;
                    againPrompt = "Would you like to repeat another word (y/n)? ";
                    break;
                case MenuOption.FindWord:
                    action = FindWord;
                    againPrompt = "Would you like to do another sentence (y/n)? ";
                    break;
            }

            if (again)
            {
                KeepLooping(action!, againPrompt);
            }
        } while (again);
    }

    // Helper function: Loop an action until asked to stop
    static void KeepLooping(Action action, string againPrompt)
    {
        bool again;
        do
        {
            action();

            Console.WriteLine();
            again = Utilities.AskForYesNo(againPrompt);
        } while (again);

        Console.WriteLine();
        Console.Write("Press enter to go back to the main menu.");
        _ = Console.ReadLine();
    }

    // Methods describing individual menu options
    static void GetSingleTicketPrice()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the ticket price info subprogram!");
        Console.WriteLine("We can tell you the price of a single ticket based on your age.");
        Console.WriteLine();
        uint age = Utilities.AskForUInt("Please enter your age: ");

        uint price = TicketPrices.DecidePrice(age);

        Console.WriteLine();
        Console.WriteLine($"The price of a ticket for your age {age} is {price}kr.");
    }

    static void RepeatWord()
    {
        Console.Clear();
        Console.WriteLine("In this subprogram, you provide a word.");
        Console.WriteLine("That word will then be repeated 10 times in the console.");
        Console.WriteLine();
        string word = Utilities.AskForString("What word should be repeated? ");
        Console.WriteLine();

        repeater.Repeat(word);
    }

    static void FindWord()
    {
        Console.Clear();
        Console.WriteLine("In this subprogram, you provide a sentence.");
        Console.WriteLine("We will then find the 3rd word in the sentence.");
        Console.WriteLine();
        string sentence = Utilities.AskForString("What is your sentence?\n");
        Console.WriteLine();

        try
        {
            string word = wordFinder.FindWord(sentence);
            Console.WriteLine($"The 3rd word in the sentence is: '{word}'");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
