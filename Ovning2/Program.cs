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
        do
        {
            MenuHelper.DisplayMenu();
            MenuOption option = Utilities.AskForOption("Your choice: ");

            switch (option)
            {
                case MenuOption.Quit:
                    Environment.Exit(0);
                    break;
                case MenuOption.SingleTicket:
                    GetSingleTicketPrice();
                    break;
                case MenuOption.RepeatWord:
                    RepeatWord();
                    break;
                case MenuOption.FindWord:
                    FindWord();
                    break;
            }

        } while (true);
    }

    // Methods to run individual menu options
    static void GetSingleTicketPrice()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the ticket price info subprogram!");
            Console.WriteLine("We can tell you the price of a single ticket based on your age.");
            Console.WriteLine();
            uint age = Utilities.AskForUInt("Please enter your age: ");

            uint price = SinglePriceDecider.DecidePrice(age);

            Console.WriteLine();
            Console.WriteLine($"The price of a ticket for your age {age} is {price}kr.");

            Console.WriteLine();
            bool again = Utilities.AskForYesNo("Would you like to find another ticket price (y/n)? ");
            if (!again)
            {
                break;
            }
        } while (true);

        Console.WriteLine();
        Console.Write("Press enter to go back to the main menu.");
        _ = Console.ReadLine();
    }

    static void RepeatWord()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("In this subprogram, you provide a word.");
            Console.WriteLine("That word will then be repeated 10 times in the console.");
            Console.WriteLine();
            string word = Utilities.AskForString("What word should be repeated? ");
            Console.WriteLine();

            repeater.Repeat(word);

            Console.WriteLine();
            bool again = Utilities.AskForYesNo("Would you like to repeat another word (y/n)? ");
            if (!again)
            {
                break;
            }
        } while (true);

        // End of sub-program; wait for user response
        Console.WriteLine();
        Console.Write("Press enter to go back to the main menu.");
        _ = Console.ReadLine();
    }

    static void FindWord()
    {
        do
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

            Console.WriteLine();
            bool again = Utilities.AskForYesNo("Would you like to do another sentence (y/n)? ");
            if (!again)
            {
                break;
            }
        } while (true);

        // End of sub-program; wait for user input
        Console.WriteLine();
        Console.Write("Press enter to go back to the main menu.");
        _ = Console.ReadLine();
    }
}
