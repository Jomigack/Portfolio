using System;
using System.IO;

namespace Survey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define the base directory relative to the executable
            string baseDirectory = "Surveys";

            Console.WriteLine("Welcome to my Survey! Please enter your request:");
            Console.WriteLine("Create: Answer a survey \nLook: Look at a previous survey result");
            string userOption = Console.ReadLine().ToLower();
            string filePath = "";

            // Create or look loop
            do
            {
                if (userOption == "create")
                {
                    bool isPickName = true;
                    // Right name loop
                    do
                    {
                        Console.WriteLine("Okay, first, please enter your name:");
                        string userName = Console.ReadLine().ToLower();
                        Console.WriteLine($"Is this your name?: {userName} \n(y/n)");
                        string userYN = Console.ReadLine().ToLower();
                        bool isYesOrNo = true;

                        // Check if user entered the right name
                        do
                        {
                            if (userYN == "y")
                            {
                                // Create the file path
                                filePath = Path.Combine(baseDirectory, userName + ".txt"); //Combines part of the path to get the whole path where it will reside, in the debug folder under surveys

                                // Create the file
                                try
                                {
                                    // Ensure the directory exists
                                    Directory.CreateDirectory(baseDirectory);

                                    // Create the file
                                    using (FileStream fs = File.Create(filePath))
                                    {
                                        Console.WriteLine("File created successfully!");
                                    }

                                    isYesOrNo = false;
                                    isPickName = false;
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error creating the file: {ex.Message}");
                                    isYesOrNo = false;
                                    break;
                                }
                            }
                            else if (userYN == "n")
                            {
                                isYesOrNo = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Enter 'y' or 'n' if this is your valid name: {userName}");
                                userYN = Console.ReadLine().ToLower();
                            }
                        } while (isYesOrNo);


                    } while (isPickName);
                    StreamWriter writer = new StreamWriter(filePath);
                    string q1 = "Question One: What is your favorite color?";
                    Console.WriteLine($"Okay, {q1}");
                    string q1A = answerQuestion(q1, writer);

                    string q2 = "Question Two: What is you favorite animal?";
                    Console.WriteLine($"Next, {q2}");
                    string q2A = answerQuestion(q2, writer);

                    string q3 = "Question Three: WHat's your best feature?";
                        Console.WriteLine($"Lastly, {q3}");
                    string q3A = answerQuestion(q3, writer);
                    // Don't forget to close the StreamWriter after writing to the file
                    writer.Close();
                    Console.WriteLine("Thanks for answering my survey! Please re open the program and enter your name in look to see your responses! Enter any key to exit");
                    Console.ReadKey();
                    Environment.Exit(0); //Closes Console
                }
                else if (userOption == "look")
                {
                    Console.WriteLine("Enter the name of the file you want to open:");
                    string userSelect = Console.ReadLine().ToLower();
                    bool isRightName = false;

                    // Check if the user entered a valid name
                    do
                    {
                        filePath = Path.Combine(baseDirectory, userSelect + ".txt");

                        if (File.Exists(filePath))
                        {
                            Console.WriteLine($"{filePath} exists");
                            string text = File.ReadAllText(filePath); // Stores all text from the file
                            Console.WriteLine(text);

                            isRightName = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid file name, enter again:");
                            userSelect = Console.ReadLine().ToLower();
                        }
                    } while (!isRightName);
                    Console.WriteLine("Enter any key to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Input invalid, please input: \nCreate: Answer a survey \nLook: Look at a previous survey result ");
                    userOption = Console.ReadLine().ToLower();
                }
            } while (userOption != "create" || userOption != "look");
        }

        static string answerQuestion(string question, StreamWriter writer)
        {
            string answer = Console.ReadLine();
            bool isRightAnswer = false;
            bool reCheck = false;
            do
            {
                Console.WriteLine($"{question}  \nIs this the answer you wanted for the question?: {answer} \n(y/n)");
                string userYN = Console.ReadLine().ToLower();
                do
                {
                    if (userYN == "y")
                    {
                        // Write to the StreamWriter without using 'using' statement
                        writer.WriteLine("\n" + question + "\n" + answer);
                        reCheck = false;
                        isRightAnswer = true;
                    }
                    else if (userYN == "n")
                    {
                        Console.WriteLine($"Then lets do this again: \n{question}");
                        answer = Console.ReadLine();
                        reCheck = true;
                    }
                    else
                    {
                        Console.WriteLine($"{question}  \nIs this the answer you wanted for the question?: {answer} \n(y/n)");
                        userYN = Console.ReadLine().ToLower();
                    }
                } while (!isRightAnswer);
            } while (reCheck);

            return answer;
        }
    }
}
