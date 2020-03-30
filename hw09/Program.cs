using System.Collections.Generic;
using System.IO;
using System.Collections;
using System;
namespace hw09
{

    class Program
    {
        static void Main(string[] args)
        {

            using (var reader = new StreamReader(@"product.csv"))
            {
                List<string> SKU = new List<string>();
                List<string> Name = new List<string>();
                List<string> Price = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    SKU.Add(values[0]);
                    Name.Add(values[1]);
                    Price.Add(values[2]);
                }
                ArrayList ProductName = new ArrayList();
                ArrayList ProductPrice = new ArrayList();
                int sum = 0;

                do
                {

                    Console.Write("Please input a product key:  ");
                    string inputSKU = Console.ReadLine();
                    for (int i = 0; i < SKU.Count; i++)
                    {
                        if (inputSKU == SKU[i])
                        {


                            ProductName.Add(Name[i]);
                            ProductPrice.Add(Price[i]);
                            string v = Price[i];
                            int x = Convert.ToInt32(v);
                            sum = sum + x;

                        }



                    }



                    Console.WriteLine("Products in your cart are: ");

                    for (int iii = 1; iii <= ProductName.Count; iii++)
                    {
                        if (iii <= ProductName.Count)
                        {
                            int Number = Convert.ToInt32(iii);
                            int Order = Number - 1;

                            Console.WriteLine(Number + ". " + ProductName[Order] + "  " + ProductPrice[Order]);
                        }
                        else
                        {
                            Console.WriteLine("none");
                        }

                    }
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Total amount: " + sum + " Baht");
                    // Console.Write(sum + " Bath");

                } while (true);

            }

        }
    }
}
