using System;


class Scripture
{
    private string _book;
    private int _chapter;
    private List<int> _versesNumbers;
    private List<Verse> _verses;

    public Scripture() {
        _book = "Abraham";
        _chapter = 3;
        _versesNumbers = new List<int> {22, 23};
        _verses = new List<Verse> {new Verse(
            "Abraham", 3, 22, "Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones;"
            ),
            new Verse(
                "Abraham", 3, 23, "And God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born."
            )
            };
    }
    public Scripture(string book, int chapter, List<int> verse, List<Verse> verses) {
        _book = book;
        _chapter = chapter;
        _versesNumbers = verse;
        _verses = verses;
    }
    private void DisplayReference() {
        string output = Reference (_book, _chapter, _versesNumbers);
        Console.WriteLine(output);
    }
    private void DisplayVerses() {
        foreach (Verse verse in _verses) {
            verse.Display();
        }
    }
    public void Display() {
        Console.WriteLine();
        DisplayReference();
        DisplayVerses();
        Console.WriteLine();
    }
    public void HideWords(int minimum, int maximum) {
        foreach (Verse verse in _verses) {
            verse.HideWords(minimum, maximum);
        }
    }
    public bool AreAllHidden() {
        bool AllHidden = true;
        foreach (Verse verse in _verses) {
            if (verse.AreAllHidden() == false) {
                AllHidden = false;
                break;
            }
        }
        return AllHidden;
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
}