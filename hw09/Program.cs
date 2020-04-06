using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace hw09
{
    public interface IHomework09
    {
        IEnumerable<IProduct> GetAllProducts();
        void AddProductToCart(IProduct product);
        IEnumerable<IProduct> GetProductsInCart();

    }

    public interface IProduct
    {
        string SKU { get; set; }
        string Name { get; set; }
        double Price { get; set; }
    }

    class ProductToo : IProduct, IHomework09

    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }



        public ProductToo() { }
        IProduct[] products = new IProduct[10];


        // public string SKU() { }
        public IEnumerable<IProduct> GetAllProducts()
        {
            SetAllProductCSV();
            return products;

        }

        public void AddProductToCart(IProduct product)
        {

        }
        public IEnumerable<IProduct> GetProductsInCart()
        {
            return products;
        }
        public void SetAllProductCSV()
        {

            IEnumerable<IProduct> enumerable = GetAllProducts();
            foreach (var iiii in enumerable)
            {

            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {


        // ProductToo products = new ProductToo();
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
            double sum = 0.0;

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

                        double x = Convert.ToInt32(v);
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

                }



                Console.WriteLine("----------------------");
                Console.WriteLine("Total amount: " + sum + " Baht");


            } while (true);

        }

    }
}
