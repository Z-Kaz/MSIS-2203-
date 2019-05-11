using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class Program
    {
        static void WrongInput()
        {
            Console.Write("That was not an acceptable choice. Hit any key to try again: ");
            Console.ReadKey();
            Console.Clear();
        }
        static void PrintingStudentDictionary(Dictionary<string, List<int>> students)
        {
            foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
            {
                Console.Write($"Student Name: {namesAndGrades.Key}\nScores: ");

                foreach (int scores in namesAndGrades.Value)
                {
                    Console.Write($"{scores}% ");
                }

                Console.WriteLine("\n\n");
            }
        }
        static void TopXStudentNames(Dictionary<string, List<int>> students)
        {//method to check to see the top x amount of students
            int topXStudents = 0;
            double average = 0;
            double average2 = 0;
            List<double> grades = new List<double>();
            List<string> topStudentNames = new List<string>();

            try
            {
                Console.Clear();
                Console.Write("Please enter the top x amount of students with the highest averages that you'd like to view: ");
                topXStudents = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"The top {topXStudents} students:\n");
            }
            catch (Exception)
            {
                WrongInput();
            }
            
            foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
            {
                average = namesAndGrades.Value.Average();
                grades.Add(average);
                grades.Sort();
                grades.Reverse();
            }
            foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
            {
                average2 = namesAndGrades.Value.Average();
                if(average2 >= grades[topXStudents - 1])
                {
                    topStudentNames.Add(namesAndGrades.Key);
                    topStudentNames.Sort();
                    topStudentNames.Reverse();
                    Console.Write($"Student Name: {namesAndGrades.Key}\nAverage: {Math.Round(average2, 2)}%\nScores: ");
                    foreach (int scores in namesAndGrades.Value)
                    {
                        Console.Write($"{scores}% ");
                    }
                    Console.WriteLine('\n');
                }
            }
        }
        static void CheckingForParticularStudent(Dictionary<string, List<int>> students)
        {//method for checking to see the grades of a particular student
            while (true)
            {
                string reportChoice;
                int counter = 0;
                Console.Write("To look at a particular students grades please enter their name: ");//asks for students name
                reportChoice = Console.ReadLine();

                foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
                {
                    if (namesAndGrades.Key.Equals(reportChoice))//checks to see if name is in list
                    {
                        Console.Clear();
                        Console.Write($"Student Name: {namesAndGrades.Key}\nScores: ");

                        foreach (int scores in namesAndGrades.Value)
                        {
                            Console.Write($"{scores}% ");
                            counter = 0;
                        }
                        break;
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                }
                if (counter != 0)
                {
                    WrongInput();
                    PrintingStudentDictionary(students);
                    continue;
                }
                break;
            }
        }
        static void HighestGradeAverage(Dictionary<string, List<int>> students)
        {//method for checking which student has the highest grade average
            double average = 0;
            double highestscore = 0;
            string highestStudentGradeName = null;

            Console.Clear();
            Console.Write("Highest Average:\n");

            foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
            {
                average = namesAndGrades.Value.Average();//gets each students average
                if (average > highestscore)//checks to see if any average is higher than previously highest average
                {
                    highestscore = average;//replaces new highest average as the highest average to be tested against
                    highestStudentGradeName = namesAndGrades.Key;
                }
            }
            Console.WriteLine($"{highestStudentGradeName} with an average score of {Math.Round(highestscore, 2)}%\n");
        }
        static Dictionary<string, List<int>> ChangeStudentNames(Dictionary<string, List<int>> students)
        {//method to change a students name
            string managementChoice;
            string managementChoice2;
            int counter = 0;

            while (true)
            {
                Console.Write("Please enter the name of the student you'd like to change: "); //asks for the name that the user wants to change
                managementChoice = Console.ReadLine();

                foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
                {
                    if (namesAndGrades.Key.Equals(managementChoice))//checks to see is name is in the list
                    {
                        Console.Clear();
                        Console.Write("Please enter the new name: "); //asks for the new name that will replace the old one
                        managementChoice2 = Console.ReadLine();
                        Console.WriteLine($"Student name being replaced: {namesAndGrades.Key}"); // prints out the old name
                        students.Remove(namesAndGrades.Key);
                        students.Add(managementChoice2, namesAndGrades.Value);
                        Console.Write($"Student name changed to: {managementChoice2}"); // prints out the new name
                        counter = 0;
                        break;
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                }
                if (counter != 0)
                {
                    WrongInput();
                    PrintingStudentDictionary(students);
                    continue;
                }
                return students;
            }
        }
        static void AddStudentNames(Dictionary<string, List<int>> students)
        {//method that adds a name
            string managementChoice;
            Console.Clear();
            Console.Write("Please enter the name of the student you would like to enter: ");//asks user for name
            managementChoice = Console.ReadLine();
            students.Add(managementChoice, new List<int> { });//adds name to list

            Console.WriteLine($"Student name added: {managementChoice}");
        }
        static Dictionary<string, List<int>> DeleteStudentNames(Dictionary<string, List<int>> students)
        {//method for deleting student names
            while (true)
            {
                string managementChoice;
                int counter = 0;

                Console.Clear();
                Console.Write("Please enter the name of the student you would like to delete: ");//asks user for students name
                managementChoice = Console.ReadLine();

                foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
                {
                    if (namesAndGrades.Key.Equals(managementChoice))//checks to see if name is in list 
                    {
                        students.Remove(namesAndGrades.Key);//delete name
                        Console.Write($"Student name deleted: {managementChoice} ");
                        counter = 0;
                        break;
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                }
                if (counter != 0)
                {
                    WrongInput();
                    PrintingStudentDictionary(students);
                    continue;
                }
                return students;
            }
        }
        static Dictionary<string, List<int>> ChangeGrades(Dictionary<string, List<int>> students)
        {//method that changes a students grade
            while (true)
            {
                string managementChoice;
                int managementChoice2;
                int managementChoice3;
                int i = 1;

                Console.Clear();
                Console.Write("Please enter the name of the student for whom you would like the change the grades: ");//asks for students name
                managementChoice = Console.ReadLine();
                foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
                {
                    if (namesAndGrades.Key.Equals(managementChoice))//checks to see if name is in list
                    {
                        foreach (int scores in namesAndGrades.Value)
                        {
                            Console.Write($"({i}) {scores}%\n");
                            i++;
                        }
                        Console.Write("Enter the number beside the grade that you would like to change: ");//asks for which grade user would like to change
                        while (true)
                        {
                            try
                            {
                                managementChoice2 = Convert.ToInt32(Console.ReadLine());
                                managementChoice2--;
                                namesAndGrades.Value.RemoveAt(managementChoice2);//removes old grade
                                break;
                            }
                            catch (Exception)
                            {
                                WrongInput();
                                continue;
                            }
                        }
                        Console.Write("Enter the grade that you would like to add: ");//asks user for new grade
                        while (true)
                        {
                            try
                            {
                                managementChoice3 = Convert.ToInt32(Console.ReadLine());
                                if(managementChoice3 < 0 || managementChoice3 > 100)
                                {
                                    WrongInput();
                                    continue;
                                }
                                namesAndGrades.Value.Insert(managementChoice2, managementChoice3);//adds new grade
                                break;
                            }
                            catch (Exception)
                            {
                                WrongInput();
                                continue;
                            }
                        }
                        break;
                    }
                }
                return students;
            }
        }
        static Dictionary<string, List<int>> AddGrades(Dictionary<string, List<int>> students)
        {//method that add grades for a chosen student
            while (true)
            {
                string managementChoice;
                int managementChoice2;
                int i = 1;

                Console.Clear();
                Console.Write("Please enter the name of the student for whom you would like to add a grade: ");
                managementChoice = Console.ReadLine();
                foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
                {
                    if (namesAndGrades.Key.Equals(managementChoice))//checks to see if name is in list
                    {
                        foreach (int scores in namesAndGrades.Value)
                        {
                            Console.Write($"({i}) {scores}%\n");
                            i++;
                        }

                        Console.Write("Enter the grade that you would like to add: ");
                        while (true)
                        {
                            try
                            {
                                managementChoice2 = Convert.ToInt32(Console.ReadLine());
                                if (managementChoice2 < 0 || managementChoice2 > 100)
                                {
                                    WrongInput();
                                    continue;
                                }
                                namesAndGrades.Value.Add(managementChoice2);//adds new grade
                                break;
                            }
                            catch (Exception)
                            {
                                WrongInput();
                                continue;
                            }
                        }
                        break;
                    }
                }
                return students;
            }
        }
        static Dictionary<string, List<int>> DeleteGrades(Dictionary<string, List<int>> students)
        {//the method that deletes a grade for a chosen student
            while (true)
            {
                string managementChoice;
                int managementChoice2;
                int i = 1;

                Console.Clear();
                Console.Write("Please enter the name of the student for whom you would like to delete a grade: ");//asks for the students name
                managementChoice = Console.ReadLine();
                foreach (KeyValuePair<string, List<int>> namesAndGrades in students)
                {
                    if (namesAndGrades.Key.Equals(managementChoice))//checks to see if name is in list
                    {
                        foreach (int scores in namesAndGrades.Value)
                        {
                            Console.Write($"({i}) {scores}%\n");
                            i++;
                        }
                        Console.Write("Enter the number beside the grade that you would like to change: ");
                        while (true)
                        {
                            try
                            {
                                managementChoice2 = Convert.ToInt32(Console.ReadLine());
                                managementChoice2--;
                                namesAndGrades.Value.RemoveAt(managementChoice2);//removes grade
                                break;
                            }
                            catch (Exception)
                            {
                                WrongInput();
                                continue;
                            }
                        }
                    }
                }
                return students;
            }
        }
        static void Main(string[] args) //Main method that runs the program
        {
            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>()
            {
                {"Alfred S. McKenzie",new List<int> {48, 96, 64}},
                {"Alison W. MacDonald",new List<int> {54, 99, 72}},
                {"Allan Y. Nguyen",new List<int> {42, 42, 41}},
                {"Audrey M. Kern",new List<int> {49, 67, 93}},
                {"Barry V. Gordon",new List<int> {66, 57, 52}},
                {"Beth G. Swanson",new List<int> {67, 55, 70}},
                {"Billy P. Carroll",new List<int> {70, 58, 80}},
                {"Calvin A. Diaz",new List<int> {86, 42, 50}},
                {"Charlotte G. Hamrick",new List<int> {43, 74, 40}},
                {"Chris Anderson",new List<int> {72, 67, 76}},
                {"Claire Q. Gray",new List<int> {63, 90, 47}},
                {"Clara H. Best",new List<int> {59, 63, 69}},
                {"Clifford Garrett",new List<int> {87, 89, 72}},
                {"Dean Leach",new List<int> {95, 40, 100}},
                {"Edgar P. Stuart",new List<int> {96, 49, 91}},
                {"Edna H. Hoyle",new List<int> {66, 70, 88}},
                {"Eileen Olson",new List<int> {100, 85, 51}},
                {"Franklin M. Coley",new List<int> {59, 63, 97}},
                {"Frederick J. McCall",new List<int> {97, 52, 57}},
                {"Glen R. Kramer",new List<int> {70, 48, 52}},
                {"Gordon D. Berman",new List<int> {88, 74, 46}},
                {"Jean M. Griffin",new List<int> {48, 86, 99}},
                {"Jeff T. Kaplan",new List<int> {54, 91, 72}},
                {"Joanna L. Middleton",new List<int> {43, 88, 73}},
                {"Joanne L. Bowling",new List<int> {78, 79, 79}},
                {"Julian E. Hendrix",new List<int> {99, 51, 91}},
                {"Keith X. Schwartz",new List<int> {97, 86, 97}},
                {"Ken T. Kennedy",new List<int> {80, 66, 40}},
                {"Kim T. Matthews",new List<int> {75, 95, 55}},
                {"Kristen O. Fisher",new List<int> {44, 72, 57}},
                {"Louise F. Coble",new List<int> {67, 63, 98}},
                {"Luis A. Burnett",new List<int> {85, 74, 52}},
                {"Luis N. Turner",new List<int> {86, 53, 86}},
                {"Margaret M. Burgess",new List<int> {76, 93, 63}},
                {"Martin Y. Hester",new List<int> {61, 74, 51}},
                {"Mary G. Byrd",new List<int> {95, 40, 95}},
                {"Nina Y. Savage",new List<int> {73, 41, 84}},
                {"Pauline N. Coley",new List<int> {73, 51, 87}},
                {"Penny Lamb",new List<int> {49, 94, 61}},
                {"Peter L. Guthrie",new List<int> {75, 70, 44}},
                {"Rhonda Chan",new List<int> {94, 52, 93}},
                {"Richard E. Hull",new List<int> {76, 99, 59}},
                {"Robyn K. Shapiro",new List<int> {45, 82, 68}},
                {"Samantha I. Hardin",new List<int> {89, 42, 95}},
                {"Sara Lucas",new List<int> {80, 60, 85}},
                {"Stephen Finch",new List<int> {84, 95, 70}},
                {"Tammy L. Lang",new List<int> {62, 73, 56}},
                {"Vincent Y. Fischer",new List<int> {79, 88, 92}},
                {"William S. McCormick",new List<int> {99, 68, 65}}
            };//dictionary of names and grades

            while (true)
            {
                string userChoice = null;
                string userChoice2 = null;

                try
                {
                    Console.Clear();//the welcome title
                    Console.Write("Welcome to the student gradebook!\n\n\nTo show reports for all students select (1).\n\nTo manage students select (2).\n\nThe manage student grades select (3).\n\nTo close the program select (4).\n\nPlease enter your selection: ");
                    userChoice = Console.ReadLine();

                    while(true)
                    {
                        if (userChoice == "1")//if the user chooses the first option
                        {
                            Console.Clear();
                            Console.Write("To view a particular students grades press (1).\nTo view the student with the highest grade average select (2).\nTo view the top x amount of students, alphabetically, with the highest x scores press (3).\nTo exit to the main menu select (4).\nPlease enter your selection: ");
                            userChoice2 = Console.ReadLine();
                            if (userChoice2 == "1")
                            {
                                Console.Clear();
                                PrintingStudentDictionary(students);
                                CheckingForParticularStudent(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "2")
                            {
                                HighestGradeAverage(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "3")
                            {
                                TopXStudentNames(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "4")
                            {
                                break;
                            }
                            else
                            {
                                WrongInput();
                                continue;
                            }
                        }
                        else if (userChoice == "2") //if the user chooses the second option
                        {
                            Console.Clear();

                            Console.Write("To change one or more students names select (1).\nTo add one or more students select (2).\nTo delete one or more students select (3).\nTo exit to the main menu select (4).\nPlease enter your selection: ");
                            userChoice2 = Console.ReadLine();
                            if (userChoice2 == "1")
                            {
                                Console.Clear();
                                PrintingStudentDictionary(students);
                                ChangeStudentNames(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "2")
                            {
                                AddStudentNames(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "3")
                            {
                                DeleteStudentNames(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "4")
                            {
                                break;
                            }
                            else
                            {
                                WrongInput();
                                continue;
                            }
                        }
                        else if (userChoice == "3")//if the user chooses the third option
                        {
                            Console.Clear();
                            Console.Write("To change one or more grades for a particular student select (1).\nTo add one or more grades for a particular student select (2).\nTo delete one or more grades for a particular student select (3).\nTo exit to the main menu select (4).\nPlease enter your selection: ");
                            userChoice2 = Console.ReadLine();
                            if (userChoice2 == "1")
                            {
                                ChangeGrades(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "2")
                            {
                                AddGrades(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "3")
                            {
                                DeleteGrades(students);
                                Console.ReadKey();
                            }
                            else if (userChoice2 == "4")
                            {
                                break;
                            }
                            else
                            {
                                WrongInput();
                                continue;
                            }
                        }
                        else if (userChoice == "4")//if the user chooses the fourth option the program closes
                        {
                            Console.Clear();
                            Console.Write("Thanks for using my program!");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }
                        else
                        {
                            WrongInput();
                            continue;
                        }
                        continue;
                    }
                }
                catch (Exception)
                {
                    WrongInput();
                    continue;
                }
            }
        }
    }
}
