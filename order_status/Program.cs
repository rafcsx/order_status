using order_status.Entities;
using order_status.Entities.Enums;
using System;
using System.Globalization;

namespace order_status
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birthdate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");

                Console.Write("Product name: ");
                string prod_name = Console.ReadLine();

                Console.Write("Product price: ");
                double prod_price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(prod_name, prod_price);

                Console.Write("Quantity: ");
                int prod_qnt = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(prod_qnt, prod_price, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}