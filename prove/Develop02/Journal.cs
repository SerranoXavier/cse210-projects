using System;
using System.IO;

public class Journal
{
    public string _author; // exceed requirements
    public List<Entry> _entries = new List<Entry>();

    public void DisplayJournal()
    {
        // if no entries, display a message
        if (!_entries.Any())
        {
            Console.WriteLine("Your journal is empty.");
            Console.WriteLine();
            Console.Write("Press any key...");
            Console.ReadLine();
        }
        // if entries, display them
        else{
            Console.WriteLine($"Journal of {_author}");
            Console.WriteLine();
            foreach (Entry entry in _entries)
            {
                entry.DisplayEntry();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Press any key...");
            Console.ReadLine();
        };
    }
    public void AddEntry(PromptGenerator prompts)
    {
        // if journal author is null, then ask to add it
        if (CheckAuthor() == false)
        {
            AddAuthor();
        };
        // Add entry
        Entry entry = new Entry();
        entry._date = DateTime.Now;
        entry._prompt = prompts.GeneratePrompt();
        Console.WriteLine(entry._prompt);
        Console.Write("> ");
        entry._response = Console.ReadLine();

        _entries.Add(entry);
    }
    public bool CheckAuthor() // check if author is present (exceed requirements)
    {
        // check if author is null
        if (_author == null)
            {
                return false;
            }
        else
        {
            return true;
        };
    }
    public void AddAuthor() // add an author (exceed requirements)
    {
        // Add author
        Console.Write("Enter your name: ");
        _author = Console.ReadLine();
        Console.WriteLine();
    }
    public void ExportJournal() // export the journal in a more readable format (exceed requirements)
    {
        // ask for the file name
        Console.Write("Enter the name of the file: ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter($"{fileName}.txt"))
        {
            // first line is the author
            outputFile.WriteLine($"Journal of {_author}");
            outputFile.WriteLine();
            // the other lines are the entries
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry._date.ToShortDateString());
                outputFile.WriteLine(entry._prompt);
                outputFile.Write("> ");
                outputFile.WriteLine(entry._response);
                outputFile.WriteLine();
            }
        }
    }
    public void SaveJournal() // save the journal in a txt file, first line being the author and the others the entries, one entry per line
    {
        // ask for the file name
        Console.Write("Enter the name of the file: ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter($"{fileName}.txt"))
        {
            // the first line is the author
            outputFile.WriteLine(_author);
            // the other lines are the entries
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }
    public void LoadFile() // loading the journal from a txt file
    {
        // Ask for the file name
        Console.Write("Enter the file name: ");
        string fileName = Console.ReadLine();
        // read the file
        string[] lines = System.IO.File.ReadAllLines(fileName);
        int count = 0;
        foreach (string line in lines)
        {
            // first line is the author
            if (count == 0)
            {
                _author = line;
            }
            // the other lines are the entries
            else
            {
                Entry entry = new Entry();
                string[] parts = line.Split("|");
                entry._date = DateTime.Parse(parts[0]);
                entry._prompt = parts[1];
                entry._response = parts[2];
                _entries.Add(entry);
            }
            count ++;
        }
    }
}