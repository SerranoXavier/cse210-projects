using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    public string _fileName;

    public string GeneratePrompt() // randomly generate a prompt from the list
    {
        var random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    public void LoadFile(string fileName) // load prompts from a txt file (exceed requirements)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            _prompts.Add(line);
        }
    }
    public void DisplayPrompts(bool remove) // display all the prompts (exceed requirements)
    {
        int indexDisplay = 1;
        foreach (string prompt in _prompts)
        {
            Console.WriteLine($"{indexDisplay} - {prompt}");
            indexDisplay ++;
        };
        if (remove == false)
        {
            Console.WriteLine();
            Console.Write("Press any key...");
            Console.ReadLine();
        }
        Console.WriteLine();
    }
    public void SavePrompts() // save all the prompts to a txt file (exceed requirements)
    {
        using (StreamWriter outputFile = new StreamWriter($"{_fileName}.txt"))
        {
            foreach (string prompt in _prompts)
            {
                outputFile.WriteLine(prompt);
            }
        }
    }
    public void AddPrompt() // add a prompt (exceed requirements)
    {
        Console.Write("Enter the new prompt: ");
        string newPrompt = Console.ReadLine();
        _prompts.Add(newPrompt);
        SavePrompts();
    }
    public void RemovePrompt() // remove a prompt (exceed requirements)
    {
        DisplayPrompts(true);
        Console.Write("Enter the index of the prompt you want to remove: ");
        int indexRemove = int.Parse(Console.ReadLine());
        _prompts.RemoveAt(indexRemove - 1);
        SavePrompts();

    }
}