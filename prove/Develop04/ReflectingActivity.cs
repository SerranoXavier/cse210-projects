using System;

public class ReflectingActivity : Activity
{
    private List<string> _questions;
    private int _durationQuestion;
    private List<int> _indexesQestionsAsked;


    public ReflectingActivity
    (
        string startingMessage,
        string endingMessage,
        List<string> prompts,
        List<string> questions,
        int durationQuestion
    ) : base(startingMessage, endingMessage, prompts)
    {
        _questions = questions;
        _durationQuestion = durationQuestion;
        _indexesQestionsAsked = new List<int>();
    }

    public void DisplayRandomQuestion(int waitingTime)
    {
        Random random = new Random();
        bool indexOk = false;
        int index = -1;
        do  // exceeding requirements: I coded a management for not having twice the same question
        {
            index = random.Next(0, _questions.Count);
            if (_indexesQestionsAsked.Contains(index))
            {
                indexOk = false;
            }
            else
            {
                indexOk = true;
                _indexesQestionsAsked.Add(index);
            }
        } while (indexOk);

        ProgressBar progressBar = new ProgressBar  // exceeding requirements: I coded a progress bar for displaying the duration of the activity
        (
            type: "time",
            length: 50,
            duration:  waitingTime,
            fillChar: '-',
            emptyChar: ' '
        );

        Console.WriteLine(_questions[index]);
        progressBar.Progression();
    }
}