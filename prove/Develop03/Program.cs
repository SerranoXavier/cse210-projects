using System;


class Program
{
    static void Main(string[] args)
    {
        // creation of the program main menu
        Menu mainMenu = new Menu();
        mainMenu.AddMenuItem(1, "Search a scripture");
        mainMenu.AddMenuItem(2, "Random scripture");

        // Creation of the scriptures dictionary
        ScripturesDictionary dict = new ScripturesDictionary();
        dict.LoadFile("scripture_mastery_dictionnary.txt");

        // initiate variables
        int option = 0;
        string reference = "";
        Scripture scripture = new Scripture();
        int minimum = 5; // minimum words to hide per verse
        int maximum = 10; // maximum words to hide per verse
        string continuing = "";

        // ask option for main menu
        option = mainMenu.AskOption("Scripture Mastery Memorizer");
        Console.WriteLine();

        // The requirements were to provide a scripture. I exceeded requirements as I made available two choices: get a particular reference or get a random scripture.
        // option 1: Search a scripture (exceeds requirement)
        if (option == 1)
        {
            Console.Write("Type a reference: ");
            reference = Console.ReadLine();
            if (dict.getScripture(reference) != null) {
                scripture = dict.getScripture(reference);
            }
            else {
                Console.WriteLine();
                Console.WriteLine("Sorry, this scripture is not referenced."); // if reference is not known, display a message before ending the program
                scripture = null;
            }
        }
        // option 2: Take a random scripture (exceeds requirements)
        else if (option == 2) {
            scripture = dict.getScriptureRandom();
        }
        
        // now scripture is set

        // display the scripture and at each turn hide words
        if (scripture != null) { // check if scripture is not null before displaying it
            Console.Clear();
            scripture.Display();
            do {
                Console.WriteLine("Press enter to continue or type 'quit' to quit");
                Console.Write("> ");
                continuing = Console.ReadLine();
                if (continuing.ToLower() != "quit") {
                    Console.Clear();
                    if (scripture.AreAllHidden() == false) {
                        scripture.HideWords(minimum, maximum);
                        scripture.Display();
                    }
                }
                else {
                    break;
                }
            }
            while (scripture.AreAllHidden() == false);
        }

    }
}