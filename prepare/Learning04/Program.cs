using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Caesar", "History");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        MathAssignment assignment2 = new MathAssignment("Pythagore", "Math", "7.3", "8-12");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment assignment3 = new WritingAssignment("Platon", "Phylosophy", "Why am I systematicaly wrong?");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
        Console.WriteLine();
    }
}