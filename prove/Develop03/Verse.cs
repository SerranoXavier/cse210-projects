using System;


class Verse
{
    private string _book;
    private int _chapter;
    private int _verse;
    private List<Word> _words;
    private int _length;

    public Verse() {
        _book = "Moses";
        _chapter = 3;
        _verse = 39;
        _words = Parse("For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man.");
        _length = _words.Count;
    }
    public Verse(string book, int chapter, int verse, string text) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _words = Parse(text);
        _length = _words.Count;
    }
    private List<Word> Parse(string input) {
        char[] delimiterChars = { ' ' };
        string[] arrayWords = input.Split(delimiterChars);
        List<Word> output = new List<Word>{};
        foreach (var word in arrayWords) {
            output.Add(new Word(word.ToString()));
        }
        return output;
    }
    public int NumberVisibleWords() {
        int countVisibleWords = 0;
        foreach (Word word in _words) {
            if (word.IsHidden() == false) {
                countVisibleWords ++;
            }
        }
        return countVisibleWords;
    }
    public void Display() {
        foreach (Word word in _words) {
            if (_words.IndexOf(word) == _words.Count - 1){
                word.Display(true);
            }
            else {
                word.Display(false);
            }
        }
    }
    public void HideWords(int minimum, int maximum) {
        int numberVisibleWords = NumberVisibleWords();
        if (numberVisibleWords < maximum) {
            minimum = numberVisibleWords - 1;
            maximum = numberVisibleWords;
        }
        Random random = new Random();
        int numberWordsToHide = random.Next(minimum, (maximum + 1));
        int i = 0;
        do {
            int indexWordToHide = random.Next(0, _length);
            if (_words[indexWordToHide].IsHidden() == false) {
                _words[indexWordToHide].Hide();
                i ++;
            }
        }
        while ( i < numberWordsToHide);
    }
    public bool AreAllHidden() {
        bool AllHidden = true;
        foreach (Word word in _words) {
            if (word.IsHidden() == false) {
                AllHidden = false;
                break;
            }
        }
        return AllHidden;
    }
}