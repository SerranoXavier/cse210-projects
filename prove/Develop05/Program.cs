using System;

class Program
{
    static void Main(string[] args)
    {
        // creation of menus (main menu and Create New Goal menu)
        Menu mainMenu = new Menu("Eternal Quest");
        mainMenu.AddMenuOption(1, "Create New Goals");
        mainMenu.AddMenuOption(2, "List Goals");
        mainMenu.AddMenuOption(3, "Save Goals");
        mainMenu.AddMenuOption(4, "Load Goals");
        mainMenu.AddMenuOption(5, "Record Event");
        mainMenu.AddMenuOption(6, "Quit");

        Menu newGoalMenu = new Menu("Create New Goal");
        newGoalMenu.AddMenuOption(1, "Simple Goal");
        newGoalMenu.AddMenuOption(2, "Eternal Goal");
        newGoalMenu.AddMenuOption(3, "Checklist Goal");
        newGoalMenu.AddMenuOption(4, "Back to Main Menu");

        // creation of global variables
        int optionMain = 0;
        int optionNewGoal = 0;
        Spinner spinner = new Spinner();
        Progress progress = new Progress();

        // start
        do
        {
            string prompt = "You have a total of " + progress.TotalPoints + " points." + "\n\n" + "What would you like to do?";
            optionMain = mainMenu.AskOption(prompt);

            switch(optionMain)
            {
                case 1: // Create New Goal
                {
                    do
                    {
                        optionNewGoal = newGoalMenu.AskOption();
                        switch (optionNewGoal)
                        {
                            case 1: // Create Simple Goal // Exceed requirements: I added a date of accomplishment to track when it was done // Exceed requirements: I added some guardrail to make sure that the number of points input is a number and greater than 0
                            {
                                progress.AddGoal("SimpleGoal");
                            }
                            break;

                            case 2: // Create Eternal Goal // Exceed requirements: I added the number of times it was accomplished // Exceed requirements: I added some guardrail to make sure that the number of points input is a number and greater than 0
                            {
                                progress.AddGoal("EternalGoal");
                            }
                            break;

                            case 3: // Create Checklist Goal // Exceed requirements: I added a date of accomplishment to track when it was done // Exceed requirements: I added some guardrail to make sure that the number of points input is a number and greater than 0
                                progress.AddGoal("ChecklistGoal");
                            break;
                        }
                    } while (optionNewGoal != 4);
                }
                break;


                case 2: // List Goals
                {
                    progress.DisplayGoals();
                    Console.WriteLine();
                    Console.Write("Press any key...");
                    Console.ReadLine();
                }
                break;


                case 3: // Save Goals
                {
                    Console.Clear();
                    Console.WriteLine("Save Goals");
                    Console.WriteLine();
                    progress.SaveProgress();
                    spinner.Wait(2);
                }
                break;


                case 4: // Load Goals
                {
                    progress.LoadFile();
                    spinner.Wait(2);
                }
                break;


                case 5: // Record Event // Exceed requirements: I added some guardrail to make sure that the number input is a number and within the range of the available goals
                {
                    int index = -1;
                    while (index == -1)
                    {
                        index = progress.GetGoalIndex();
                    }
                    Goal goal = progress.GetGoal(index);
                    progress.TotalPoints += goal.RecordEvent();
                }
                break;
            }
        } while (optionMain != 6);
    
    Console.Clear();
    Console.WriteLine("Goodbye!");
    }
}