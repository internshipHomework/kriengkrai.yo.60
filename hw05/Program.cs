using System;

namespace hw05
{
    public interface IHomework05
    {
        string DisplayLEDOnScreen(string ledNo);
    }

    class LEDPanel : IHomework05
    {
        bool[] leds = new bool[10];

        public LEDPanel()
        {

        }

        public void Flip(String x)

        {
            // Console.WriteLine("bornborn");
            int i = Convert.ToInt32(x, 16);
            leds[i - 1] = !leds[i - 1];

        }

        public string Display()
        {
            string display = "";
            for (int i = 0; i < leds.Length; i++)
            {
                // Console.Write(leds[i]);
                display += leds[i] ? "[!] " : "[ ] ";
            }
            return display;


        }
        public string DisplayLEDOnScreen(string x)
        {
            Flip(x);

            return Display();

        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            LEDPanel panel = new LEDPanel();
            do
            {
                Console.Write("Please choose LED to turn On/Off: ");
                string x = Console.ReadLine();
                Console.WriteLine(panel.DisplayLEDOnScreen(x));
                // Console.WriteLine(panel.Display());
                Console.WriteLine(" 1   " + "2   " + "3   " + "4   " + "5   " + "6   " + "7   " + "8   " + "9   " + "A");

                // Console.ReadKey();


            } while (true);
        }
    }
}