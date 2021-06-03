using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextAdventure
{
    class FileHandler
    {
        public static void AddAttempt()
        {
            string file_name = "C:/Users/Shani/source/repos/TextAdventure/attemptcount.txt";
            try
            {
                // Open the text file using a stream reader.
                using var sr = new StreamReader(file_name);
                // Read the stream and store as int variable
                int attempts = Int32.Parse(sr.ReadToEnd());
                sr.Close();
                StreamWriter objWriter;
                objWriter = new StreamWriter(file_name);
                attempts++;
                objWriter.Write(attempts);
                objWriter.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }
        }

        public static void GetAttempts()
        {
            string file_name = "C:/Users/Shani/source/repos/TextAdventure/attemptcount.txt";
            try
            {
                // Open the text file using a stream reader.
                using var sr = new StreamReader(file_name);
                // Read the stream and store as int variable
                int attempts = Int32.Parse(sr.ReadToEnd());
                Console.WriteLine("You took {0} attempts", attempts);
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }

        }

    }
    }

