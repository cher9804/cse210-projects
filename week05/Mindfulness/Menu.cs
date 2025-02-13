public class Menu
{
    public void Main()
    {
        // Console.WriteLine("Hello World! This is the Mindfulness Project.")
        int activityCounter = 0;
        Console.Write("What is your name?");
        string name = Console.ReadLine();

        do
        {

            Console.Clear();
            Console.WriteLine(
            $"""
            Welcome to the Activities program, {name}
            Menu Options:
                1. Start breathing activity
                2. Start reflecting avtivity
                3. Start listing activity
                4. Quit
            """);
            Console.Write("Select a choice from the menu: ");
            string userchoice = Console.ReadLine();

            if (userchoice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                activityCounter += 1;

            }
            else if (userchoice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                activityCounter += 1;

            }
            else if (userchoice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                activityCounter += 1;

            }
            else if (userchoice == "4")
            {
                Console.WriteLine($"You completed {activityCounter} activities");
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }



        } while (true);

    }
}