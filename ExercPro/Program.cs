using ExercPro.Entities;
using ExercPro.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExercPro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data");
            DateTime dt = DateTime.Now;

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birth);
            Order order = new Order(dt, client, status);

            Console.Write("How many items to this order?: ");
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                int qtda = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(qtda, price, product);

                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMARY: ");
            Console.WriteLine(order);
        }
    }
}
