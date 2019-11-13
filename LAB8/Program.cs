using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LAB8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] {
                "Anthony Trask",
                "Brittany Skull",
                "Cathrine Ruggy",
                "Darrell Quell",
                "Eric Powell",
                "Franklin Oswell",
                "Greg Nelson",
                "Howard Mitchell",
                "Ingram Louis",
                "Jillian Kelly",
                "Keith Juntz",
                "Mitchell Hooper",
                "Nathan Gordon",
                "Olson Freddrick",
                "Percy Eddles",
                "Qienton Deedles",
                "Ryan Cook",
                "Samantha Beatle",
                "Timothy Adams", 
                "Myron Moss"};
            string[] hometown = new string[]{
                "Atlanta",
                "Boston",
                "Charlotte",
                "Detroit",
                "Philliadelphia",
                "Austin",
                "Jacksonville",
                "Fort Worth",
                "San Francisco",
                "Columbus",
                "Indianapolis",
                "Seattle",
                "Denvor",
                "Washington",
                "El Paso",
                "Nashville",
                "Portland",
                "Oklahoma City",
                "Memphis",
                "Detroit",};
            string[] food = new string[]{
                "Apple Pie",
                "Bufflo Wings",
                "Meatloaf",
                "Frito Pie",
                "Ribs",
                "Macaroni and Cheese",
                "Tator Tots",
                "S'mores",
                "Sausage",
                "Nachos",
                "Lobster Rolls",
                "Chocolate Chip Cookies",
                "Cobb Salad",
                "Chicken Fried Steak",
                "Clam Chowder",
                "BLT",
                "Hot Dogs",
                "Chilli",
                "Pizza",
                "Jambalaya",};

            Console.WriteLine("Welcome to our C# class, Where you can get Information about our Students!");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            //Options for User to see array of names
            Console.WriteLine("Would you like to see the class list before entering a number? (y/n)\n******************************************************************");
            string option = Console.ReadLine().ToLower();
            while (!isValid(option, "(y)|(n)"))
            {
                Console.WriteLine("Enter either (y/n)");
                option = Console.ReadLine().ToLower();
            }

            if (option == "y")
            {
                Console.WriteLine("C# Class List");
                Console.WriteLine("*************");
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine((i + 1) + $". {names[i]}");
                }
            }

            //USER INPUT TO CHOOSE STUDENT
            bool resumeApp = false;
            do
            {
                Console.WriteLine("Enter a student number between 1-20: ");
                int input;
                //Verify input is a number. Uses try parse for all Exceptions.
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 - 20.");
                }
                //Choses student from array and verifies in Range from 1-20.
                try
                {
                    Console.WriteLine($"Student number {input} is {names[input - 1]}.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("That student does not exist, please enter a number between 1 - 20.");
                }
                //MORE INFORMATION FOR CHOSEN STUDENT FROM USER
                string moreInfo; //had to declar string outside of loop to work
                do
                {
                    Console.WriteLine($"What would you like to know about {names[input - 1]}? (Choose either Hometown or Favorite Food.");
                    string choice = Console.ReadLine().ToLower();
                    while (choice != "hometown" && choice != "favorite food" && choice != "favoritefood" && choice != "food" && choice != "favorite")
                    {
                        Console.WriteLine("Response is Not Valid!: (enter either Hometown or Favorite Food)");
                        choice = Console.ReadLine().ToLower();
                    }
                    if (choice == "hometown")
                    {
                        Console.WriteLine($"{names[input - 1]} is from {hometown[input - 1]}.");
                    }
                    if (choice == "favorite food" || choice == "favoritefood" || choice == "food" || choice == "favorite")
                    {
                        Console.WriteLine($"{names[input - 1]}'s favorite food is {food[input - 1]}.");
                    }
                    Console.WriteLine($"Would you like to know more about {names[input - 1]}? (y/n)");
                    moreInfo = Console.ReadLine().ToLower();// could not declar new string
                    while (!isValid(moreInfo, "(y)|(n)"))
                    {
                        Console.WriteLine("Enter either (y/n)");
                        moreInfo = Console.ReadLine().ToLower();
                    }
                } while (moreInfo == "y");

                //PROMPT USER TO CHOOSE ANOTHER STUDENT OR CLOSE APP
                Console.WriteLine("Would you like to know more about another Student? (y/n)");
                string difStudent = Console.ReadLine().ToLower();
                while (!isValid(difStudent, "(y)|(n)"))
                {
                    Console.WriteLine("Enter either (y/n)");
                    difStudent = Console.ReadLine().ToLower();
                }
                if (difStudent == "n")
                {
                   resumeApp = false;
                }
            } while (resumeApp == true);

        }

        public static bool isValid(string x, string y)
        {
            if (Regex.IsMatch(x, y))
            {
                return true;
            }
            return false;
        }
    }
}
