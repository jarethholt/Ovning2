// Driver of the main application menu

namespace Ovning2;

internal class Program
{
    // Create classes that will run their respective actions
    static readonly Repeater repeater = new();
    static readonly NthWordFinder wordFinder = new();

    static void Main(string[] args)
    {
        bool again = true;
        do
        {
            MenuHelper.DisplayMenu();
            MenuOption option = Utilities.AskForOption(
                "Your choice (use either the number or name of the subprogram):");

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
                    againPrompt = "Would you like to find another ticket price (y/n)?";
                    break;
                case MenuOption.GroupTicket:
                    action = GetGroupTicketPrice;
                    againPrompt =
                        "Would you like to calculate the price for another group (y/n)?";
                    break;
                case MenuOption.RepeatWord:
                    action = RepeatWord;
                    againPrompt = "Would you like to repeat another word (y/n)?";
                    break;
                case MenuOption.FindWord:
                    action = FindWord;
                    againPrompt = "Would you like to do another sentence (y/n)?";
                    break;
            }

            if (again)
            {
                Utilities.KeepLooping(action!, againPrompt);
            }
        } while (again);
    }

    // Methods describing individual menu options
    // Because of KeepLooping, these only need to describe one iteration
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

    static void GetGroupTicketPrice()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the group ticket price calculator!");
        Console.WriteLine(
            "This subprogram calculates the total price for a group based on their ages.");
        Console.WriteLine();
        uint length = Utilities.AskForUInt("How many are in your group? ");
        uint[] ages = Utilities.AskForUInts(
            "What are their ages? (Separate them using space, comma, or a combination)",
            length);

        uint totalPrice = TicketPrices.DecideTotalPrice(ages);

        Console.WriteLine();
        Console.WriteLine(
            $"The total price for your group of {length} people is {totalPrice}kr.");
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
        string sentence = Utilities.AskForString("What is your sentence?");
        Console.WriteLine();

        /* Right now FindWord throws an exception if the sentence has < 3 words
         * but this is something easy for the user to enter. Maybe it's better
         * to handle this through another AskFor* function?
         */
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
