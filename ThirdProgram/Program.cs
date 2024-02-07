namespace ThirdProgram
{
    class Program
    {
        static void Main()
        {
            // Bradford.Program.Prog();
            // ExampleObjectOriented.Example.Prog();
            Game.Program.Prog();
        }
    }
}

namespace Bradford
{
    class Program
    {
        internal static void Prog()
        {
            /*
            * Program to calculate Bradford factor.
            * Needs total instances of absence (i) & total days of absence (a)
            * Performs i^2 * a
            * Checks concern level
            */

            int totalInstances = getUserInt("Enter the total number of instances of absence: ");
            int totalDays = getUserInt("Enter the total number of days of absence: ");

            int bradfordFactor = totalInstances * totalInstances * totalDays;

            Console.WriteLine("The Bradford factor is {0}: {1}", bradfordFactor, getConcern(bradfordFactor));
        }

        static string getConcern(int bradford)
        {
            /*
            * Get concern level from Bradford factor.
            * Returns as string
            */

            if (bradford >= 900)
                return "Sufficient days for a manager to consider dismissal.";

            if (bradford >= 100)
                return "Sufficient days for a manager to start a disciplinary action (oral warning, written warning, formal monitoring etc.)";

            if (bradford >= 45)
                return "Sufficient days for a manager to show concern and advise on possible disciplinary of financial actions, should more absences occur during an identified period.";

            return "No concern.";
        }

        static int getUserInt(string prompt)
        {
            /*
            * Get string from user input (STDIN)
            * Try converting to int
            * If not an integer, advise & loop
            * Else, return
            */

            bool readyToBreak = false;
            int userInt;

            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine().Trim();

                readyToBreak = int.TryParse(userInput, out userInt);

                if (!readyToBreak)
                    Console.WriteLine("Please enter a valid integer.");
            } while (!readyToBreak);

            return userInt;
        }
    }
}

namespace ExampleObjectOriented
{
    class Example
    {
        internal static void Prog ()
        {
            Person me = new Person("Jack", "Greenacre", 19);
            me.Bradford.SetInstances(3);
            me.Bradford.SetDays(10);
            me.SayHello();
            me.SayBradford();
        }
    }
}

namespace Game
{
    class Program
    {
        internal static void Prog ()
        {
            bool userPrefPlayer = getUserPrefPlayer();
            bool userPref = getUserPref(userPrefPlayer);

            Nim game = new Nim(userPref, userPrefPlayer);
            game.Start();
        }

        static bool getUserPref(bool aiPlayer)
        {
            bool readyToBreak = false;
            int userInputInt;

            do
            {
                Console.Write("Please select an option: (1) Player{0} goes first, or (2) {1} goes first: ", (aiPlayer ? "" : " 1"), (aiPlayer ? "the AI" : "Player 2"));
                string userInputString = Console.ReadLine().Trim();

                readyToBreak = int.TryParse(userInputString, out userInputInt);

                if (userInputInt < 1 || userInputInt > 2)
                    readyToBreak = false;

                if (!readyToBreak)
                    Console.WriteLine("Please enter a valid option!");
            } while (!readyToBreak);

            return (userInputInt == 1 ? true : false);
        }

        static bool getUserPrefPlayer()
        {
            bool readyToBreak = false;
            int userInputInt;

            do
            {
                Console.Write("Please select an option: (1) AI player, or (2) human player: ");
                string userInputString = Console.ReadLine().Trim();

                readyToBreak = int.TryParse(userInputString, out userInputInt);

                if (userInputInt < 1 || userInputInt > 2)
                    readyToBreak = false;

                if (!readyToBreak)
                    Console.WriteLine("Please enter a valid option!");
            } while (!readyToBreak);

            return (userInputInt == 1 ? true : false);
        }
    }
}