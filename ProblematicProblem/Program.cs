using System;
using System.Collections.Generic;
using System.Threading;

class ProblematicProblem
{
    class Program 
    {
        Random rng;
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");

            string yOrN = Console.ReadLine();
            if (yOrN.ToLower() == "yes")
            {
                Console.WriteLine("Great!");
            }
            else if(yOrN.ToLower() == "no")
            {
                Console.WriteLine("Too bad!");
            }
            else
            {
                Console.WriteLine("On we go!");
            }
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? yes/no: ");
            string seeList = Console.ReadLine();
            if (seeList.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addToList = Console.ReadLine();
                Console.WriteLine();
                while (addToList.ToLower()== "yes")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    Console.WriteLine("Added: " + userAddition);
                    Console.WriteLine("Activities in the list:");
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "yes")
                    {
                        Console.WriteLine("Please add: ");
                        addToList = Console.ReadLine();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("On we go!");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("On we go");
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Random rng = new Random();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge >= 20 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                     randomNumber = rng.Next(activities.Count);
                     randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! ");
                Console.WriteLine("Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                string keepOrNew = Console.ReadLine();
                if (keepOrNew.ToLower() == "keep")
                {
                    Console.WriteLine("Great! Have fun!");
                    cont = false; // Exit the loop
                }
                else if (keepOrNew.ToLower() == "redo")
                {
                    activities.Remove(randomActivity);

                    if (activities.Count == 0)
                    {
                        Console.WriteLine("No more activities in the list. Exiting.");
                        cont = false; // Exit the loop
                    }
                    else
                    {
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                       
                    }
                }
                else
                {
                    Console.WriteLine("See you again soon!");
                    cont = false; // Exit the loop
                }

            }
        }
    }
}