using System;
<<<<<<< HEAD
using System.Formats.Asn1;
using System.Globalization;
using System.Xml;
=======
>>>>>>> d845c0640b5a1670ecf18b950fc3550c9b5f1364

class Program
{
    static void Main(string[] args)
    {
<<<<<<< HEAD
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);

        string letter;

        if (gradePercentage >= 100)
        {
            letter = "Genius";
        }
        else if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";

        if (gradePercentage < 100)
        {
            int lastDigit = gradePercentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3) 
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (gradePercentage >= 100)
        {
            Console.WriteLine("You are a genius. Not even AI is capable of such a thing");
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course! Go celebrate with a Root BEER");
        }
        else
        {
            Console.WriteLine("You did not pass the course. Try harder.");
        }
=======
        Console.WriteLine("Hello Prep2 World!");
>>>>>>> d845c0640b5a1670ecf18b950fc3550c9b5f1364
    }
}