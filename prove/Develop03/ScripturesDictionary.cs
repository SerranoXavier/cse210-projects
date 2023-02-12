using System;


class ScripturesDictionary
{
    private Dictionary<string, Scripture> _scripturesDictionary;

    public void LoadFile(string fileName) {
        _scripturesDictionary = new Dictionary<string, Scripture>();
        // read the file
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines) {
            string[] parts = line.Split("|");
            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            List<string> versesNumbersString = new List<string>(parts[2].Split(","));
            List<int> versesNumbers = versesNumbersString.Select(int.Parse).ToList();
            
            List<string> versesTexts = new List<string>();
            for (int i = 3; i < parts.Count(); i ++) {
                versesTexts.Add(parts[i]);
            };

            List<Verse> verses = new List<Verse>();
            for (int i = 0; i < versesTexts.Count(); i ++) {
                Verse verse = new Verse(book, chapter, versesNumbers[i], versesTexts[i]);
                verses.Add(verse);
            }

            Scripture scripture = new Scripture(book, chapter, versesNumbers, verses);

            string reference = Reference(book, chapter, versesNumbers);
            _scripturesDictionary.Add(reference, scripture);
            };
        }
    private string Reference (string book, int chapter, List<int> verses) {
        string versesOutput = Verses(verses);
        return (book + " " + chapter + ":" + versesOutput);
    }
    private string Verses (List<int> verses) {
        string output = "";
        for (int i = 0; i < verses.Count(); i ++) {
            if (i == 0) {
                output += verses[i];
            }
            else if (i == (verses.Count() - 1)) {
                output += ("-" + verses[i]);
            }
            else if (verses[i] != (verses[i-1] + 1)) {
                output += (", " + verses[i]);
            }
            else {
            }
        }
        return output;
    }
    public Scripture getScripture(string reference) {
        if (_scripturesDictionary.ContainsKey(reference)) {
            return _scripturesDictionary[reference];
        }
        else return null;
    }
    public Scripture getScriptureRandom() {
        Random rand = new Random();
        int index = rand.Next(0, 101);
        return _scripturesDictionary.ElementAt(index).Value;
    }
}