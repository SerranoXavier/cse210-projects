using System;

class Program
{
    static void Main(string[] args)
    {
        // creation of the program main menu
        Menu mainMenu = new Menu();
        mainMenu.AddMenuItem(1, "Write");
        mainMenu.AddMenuItem(2, "Display");
        mainMenu.AddMenuItem(3, "Load");
        mainMenu.AddMenuItem(4, "Save");
        mainMenu.AddMenuItem(5, "Export");
        mainMenu.AddMenuItem(6, "Prompt Manager");
        mainMenu.AddMenuItem(7, "Quit");

        // creation of the prompt manager menu (exceed requirements)
        Menu promptMenu = new Menu();
        promptMenu.AddMenuItem(1, "Display");
        promptMenu.AddMenuItem(2, "Add");
        promptMenu.AddMenuItem(3, "Remove");
        promptMenu.AddMenuItem(4, "Back");

        // creation of the prompts
        PromptGenerator prompts = new PromptGenerator();
        prompts._fileName = "prompts";
        prompts.LoadFile("prompts.txt");

        // creation of the journal
        Journal journal = new Journal();


        int option = 0;
        int optionPrompt = 0;
        do
        {
            // ask option for main menu
            option = mainMenu.AskOption("My journal");
            Console.WriteLine();

            // option 1: Write
            if (option == 1)
            {
                journal.AddEntry(prompts);
                Console.WriteLine();
            }

            // option 2: Display
            else if (option == 2)
            {
                journal.DisplayJournal();
                Console.WriteLine();
            }

            // option 3: Load
            else if (option == 3)
            {
                journal.LoadFile();
                Console.WriteLine();
            }

            // option 4: Save
            else if (option == 4)
            {
                journal.SaveJournal();
                Console.WriteLine();
            }

            // option 5: Export (exceed requirements: exports the journal in a more readable format.)
            else if (option == 5)
            {
                journal.ExportJournal();
                Console.WriteLine();
            }

            // option 6: Prompt Manager (exceed requirements: manage prompts to display them, add a prompt or remove one.)
            else if (option == 6)
            {
                do
                {
                    // ask option for prompt manager menu
                    optionPrompt = promptMenu.AskOption("Prompt Manager");
                    Console.WriteLine();

                    // option 1: Display prompts
                    if (optionPrompt == 1)
                    {
                        prompts.DisplayPrompts(false);
                        Console.WriteLine();
                    }
                    // option 2: Add a prompt
                    else if (optionPrompt == 2)
                    {
                        prompts.AddPrompt();
                        Console.WriteLine();
                    }
                    // option 3: Remove a prompt
                    else if (optionPrompt == 3)
                    {
                        prompts.RemovePrompt();
                        Console.WriteLine();
                    }
                }
                while (optionPrompt != 4);
            }

        }
        while (option != 7);

        Console.WriteLine();
        Console.WriteLine("Goodbye");
    }
}