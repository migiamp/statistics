// See https://aka.ms/new-console-template for more information


/*class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\miche\source\repos\ConsoleApp1\ConsoleApp1\languageFile";

        try
        {
            // Open the text file using a StreamReader
            using (StreamReader sr = new StreamReader(filePath))
            {
                // Read the entire file and display its contents
                string fileContents = sr.ReadToEnd();
                Console.WriteLine("File Contents:");
                Console.WriteLine(fileContents);
            }
        }
        catch (Exception e)
        {
            // Handle any errors that occur during the process
            Console.WriteLine("Error: " + e.Message);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}*/

using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\miche\source\repos\ConsoleApp1\ConsoleApp1\languageFile";

        try
        {
            // Read all lines from the text file
            string[] lines = File.ReadAllLines(filePath);

            // Dictionary to store word frequencies
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            // Regular expression to match words
            Regex regex = new Regex(@"\b\w+\b");

            // Iterate through each line and count word frequencies
            foreach (string line in lines)
            {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    string word = match.Value.ToLower(); // Convert to lowercase for case-insensitive comparison
                    if (wordFrequency.ContainsKey(word))
                    {
                        wordFrequency[word]++;
                    }
                    else
                    {
                        wordFrequency[word] = 1;
                    }
                }
            }

            // Print word frequency distribution
            Console.WriteLine("Word Frequency Distribution:");
            foreach (var pair in wordFrequency)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
        catch (Exception e)
        {
            // Handle any errors that occur during the process
            Console.WriteLine("Error: " + e.Message);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}





