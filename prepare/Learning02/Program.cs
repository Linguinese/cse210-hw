using System;
using System.Security.AccessControl;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        
        Job job2 = new Job();
        job2._jobTitle = "Manager";

        Job company1 = new Job();
        company1._company = "Microsoft";

        Job company2 = new Job();
        company2._company = "Apple";

        Console.WriteLine(company1._company);
        Console.WriteLine(company2._company);
    }
}