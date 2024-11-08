using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's your grade? ");
        string grade = Console.ReadLine();
        int grade_number = int.Parse(grade);
        string final_grade = "";
        if (grade_number >= 90){
            final_grade = "A";
        }
        else if (grade_number >= 80){
            final_grade = "B";
        }
        else if (grade_number >= 70){
            final_grade = "C";
        }
        else if (grade_number >= 60){
            final_grade = "D";
        }
        else if (grade_number < 60){
            final_grade = "F";
        }

        Console.WriteLine($"Your Grade is {final_grade}");

    }
}