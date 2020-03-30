using System;

namespace myapp
{
    public class Homework05
    {
        static void Main(string[] args)
        {


            string[] stateDefault = new string[10] { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" };
            string[] lightLED = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "A" };

            do
            {
                Console.WriteLine(String.Join("", stateDefault));
                Console.WriteLine(string.Join("  ", lightLED));
                Console.Write("Please choose LED to turn On/Off: ");

                string userInput = Console.ReadLine();
                for (int i = 0; i < lightLED.Length; i++)
                {
                    if (lightLED[i] == userInput & stateDefault[i] == "[!]")
                    {
                        stateDefault[i] = "[ ]";
                    }
                    else if (lightLED[i] == userInput & stateDefault[i] == "[ ]")
                    {
                        stateDefault[i] = "[!]";
                    }


                }

            } while (true);
        }
    }
}
