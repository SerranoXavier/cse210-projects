using System;


class Word
{
    private string _word;
    private bool _hidden;
    private int _length;

    public Word(string word) {
        _word = word;
        _hidden = false;
        _length = word.Length;
    }
    public void Display(bool last) {
        if (IsHidden() == false) {
            if (last == true) {
                Console.WriteLine(_word + " ");
            }
            else {
                Console.Write(_word + " ");
            };
        }
        else {
            string output = "";
            foreach (char letter in _word) {
                if (IsPunctuation(letter)) {
                    output += letter;
                }
                else {
                    output += "_";
                };
            };
            if (last == true) {
                Console.WriteLine(output + " ");
            }
            else {
                Console.Write(output + " ");
            };
        };
    }
    private int Length() {
        return _length;
    }
    public bool IsHidden() {
        return _hidden;
    }
    public void Hide() {
        _hidden = true;
    }
    private bool IsPunctuation(char letter) {
        char[] punctuation = {',', '.', ':', '—', ';', '!', '?'};
        if (punctuation.Contains(letter)) {
            return true;
        }
        else {
            return false;
        };
    }
}