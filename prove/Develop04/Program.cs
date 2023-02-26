using System;

class Program
{
    static void Main(string[] args)
    {
        // creation of the program main menu
        Menu mainMenu = new Menu("Mindfulness Program");
        mainMenu.AddMenuItem(1, "Breathing Activity");
        mainMenu.AddMenuItem(2, "Reflecting Activity");
        mainMenu.AddMenuItem(3, "Listing Activity");
        mainMenu.AddMenuItem(4, "Quit");

        // Creation of the program variable
        int option = 0;

        // Creation of the breathing activity
        var breathingStartingMessage = "Welcome to the Breathing Activity" + Environment.NewLine +
            Environment.NewLine +
            "This activity will help you relax by walking you through breathing in and out slowly in three phases:" + Environment.NewLine +
            "   - Breathing in quietly through the nose for 4 seconds" + Environment.NewLine +
            "   - Holding the breath for 7 seconds" + Environment.NewLine +
            "   - Exhaling forcefully through the mouth, pursing the lips, and making a “whoosh” sound for 8 seconds";
        var breathingEndingMessage = "Well done!!";
        List<string> breathingPrompts = null;
        var breatheIn = "Breathe in...";
        var holdBreath = "Hold your breath...";
        var breatheOut = "Breathe out...";
        int durationBreatheIn = 4;
        int durationHoldBreath = 7;
        int durationBreatheOut = 8;
        BreathingActivity breathingActivity  = new BreathingActivity
        (
            breathingStartingMessage,
            breathingEndingMessage,
            breathingPrompts,
            breatheIn,
            holdBreath,
            breatheOut,
            durationBreatheIn,
            durationHoldBreath,
            durationBreatheOut
        );

        // Creation of the reflecting activity
        var reflectingStartingMessage = "Welcome to the Reflecting Activity" + Environment.NewLine +
            Environment.NewLine +
            "This activity will help you reflect on times in your life when you have shown strength and resilience." + Environment.NewLine +
            "This will help you recognize the power you have and how you can use it in other aspects of your life by:" + Environment.NewLine +
            "   - Considering an experience in your life" + Environment.NewLine +
            "   - Pondering on a question related to the experience for 30 seconds";
        var reflectingEndingMessage = "Well done!!";
        List<string> reflectingPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        List<string> reflectingQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        int durationQuestion = 30;
        ReflectingActivity reflectingActivity  = new ReflectingActivity
        (
            reflectingStartingMessage,
            reflectingEndingMessage,
            reflectingPrompts,
            reflectingQuestions,
            durationQuestion
        );

        // Creation of the listing activity
        var listingStartingMessage = "Welcome to the Listing Activity" + Environment.NewLine +
            Environment.NewLine +
            "This activity will help you reflect on the good things in your life by:" + Environment.NewLine +
            "   - Considering an area of your life" + Environment.NewLine +
            "   - Listing as many items of this area during the allocated time";
        var listingEndingMessage = "Well done!!";
        List<string> listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        List<string> listingInputs = new List<string>();
        ListingActivity listingActivity  = new ListingActivity
        (
            listingStartingMessage,
            listingEndingMessage,
            listingPrompts,
            listingInputs
        );

        // all the needed variables are created




        do
        {
            Console.Clear();
            option = mainMenu.AskOption();

            switch (option)
            {
                case 1: // Breathing Activity

                    Console.Clear();
                    breathingActivity.DisplayStartingMessage(20);

                    Console.Clear();
                    int breathingTimes = breathingActivity.DetermineNumberTimes((durationBreatheIn + durationHoldBreath + durationBreatheOut), 5);
                    
                    Console.Clear();
                    breathingActivity.GetReady("Clear your mind and focus on your breathing.", 10);

                    for (int i = 0; i < breathingTimes; i++)
                    {
                        Console.Clear();
                        breathingActivity.DisplayBreatheIn(durationBreatheIn);  // exceeding requirements: I coded a progress bar for displaying the duration of the activity
                        Console.Clear();
                        breathingActivity.DisplayHoldBreath(durationHoldBreath);  // exceeding requirements: I coded a progress bar for displaying the duration of the activity
                        Console.Clear();
                        breathingActivity.DisplayBreatheOut(durationBreatheOut);  // exceeding requirements: I coded a progress bar for displaying the duration of the activity
                    }

                    Console.Clear();
                    breathingActivity.DisplayEndingMessage((breathingTimes * (durationBreatheIn + durationHoldBreath + durationBreatheOut)), "Breathing Activity");
                break;


                case 2: // Reflecting Activity

                    Console.Clear();
                    reflectingActivity.DisplayStartingMessage(20);

                    Console.Clear();
                    int reflectingTimes = reflectingActivity.DetermineNumberTimes(durationQuestion, 5);

                    Console.Clear();
                    reflectingActivity.DisplayRandomPrompt("Consider the following prompt:", true);

                    Console.Clear();
                    if (reflectingTimes <= 1)  // Exceeding requirements: I coded a management for not having more questions asked than available
                    {
                        reflectingActivity.GetReady("Now, ponder on the following question as it relates to this experience.", 10);
                    }
                    else
                    {
                        reflectingActivity.GetReady("Now, ponder on each of the following questions as they relate to this experience.", 10);
                    }

                    if (reflectingTimes > reflectingQuestions.Count())
                    {
                        reflectingTimes = reflectingQuestions.Count();
                    }
                    for (int i = 0; i < reflectingTimes; i++)
                    {
                        Console.Clear();
                        reflectingActivity.DisplayRandomQuestion(durationQuestion);  // exceeding requirements: I coded a progress bar for displaying the duration of the activity
                    }

                    Console.Clear();
                    reflectingActivity.DisplayEndingMessage((reflectingTimes * durationQuestion), "Reflecting Activity");
                break;


                case 3: // Listing Activity

                    Console.Clear();
                    listingActivity.DisplayStartingMessage(15);

                    Console.Clear();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    int listingDuration = int.Parse(Console.ReadLine());

                    Console.Clear();
                    listingActivity.DisplayRandomPrompt("Consider the following prompt:", false);

                    listingActivity.GetReady("Now, list as many responses you can to the previous prompt:", 10);

                    var startTime = DateTime.UtcNow;
                    while(DateTime.UtcNow - startTime < TimeSpan.FromSeconds(listingDuration))
                    {
                        listingActivity.WaitResponse();
                    }

                    Console.WriteLine();
                    listingActivity.DisplayNumberAnswers();

                    Console.Clear();
                    listingActivity.DisplayEndingMessage(listingDuration, "Listing Activity");
                break;
            }
        } while (option != 4);
    
    Console.Clear();
    Console.WriteLine("Goodbye!");
    }
}