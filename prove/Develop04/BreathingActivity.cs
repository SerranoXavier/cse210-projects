using System;

class BreathingActivity : Activity
{
    private string _breatheIn;
    private string _holdBreath;
    private string _breatheOut;
    private int _durationBreatheIn;
    private int _durationHoldBreath;
    private int _durationBreatheOut;


    public BreathingActivity(
        string startingMessage,
        string endingMessage,
        List<string> prompts,
        string breatheIn,
        string holdBreath,
        string breatheOut,
        int durationBreatheIn,
        int durationHoldBreath,
        int durationBreatheOut)
        : base(startingMessage, endingMessage, prompts)
    {
        _breatheIn = breatheIn;
        _holdBreath = holdBreath;
        _breatheOut = breatheOut;
        _durationBreatheIn = durationBreatheIn;
        _durationHoldBreath = durationHoldBreath;
        _durationBreatheOut = durationBreatheOut;
    }

    private void DisplayBreathe(string breath, int waitingTime)
    {
        ProgressBar progressBar = new ProgressBar  // exceeding requirements: I coded a progress bar for displaying the duration of the activity
        (
            type: "time",
            length: 50,
            duration:  waitingTime,
            fillChar: '-',
            emptyChar: ' '
        );
        Console.WriteLine(breath);
        progressBar.Progression();
    }
    public void DisplayBreatheIn(int waitingTime)
    {
        DisplayBreathe(_breatheIn, waitingTime);
    }
    public void DisplayHoldBreath(int waitingTime)
    {
        DisplayBreathe(_holdBreath, waitingTime);
    }
    public void DisplayBreatheOut(int waitingTime)
    {
        DisplayBreathe(_breatheOut, waitingTime);
    }
}