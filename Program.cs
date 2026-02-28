using System;
using System.Collections.Generic;
using System.Linq;

namespace SiemensInternship
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create customers
            var customer1 = new Customer("Diana Mihalescu", "diana@email.com");
            var customer2 = new Customer("Andrei Popescu", "andrei@email.com");

            // Create orders
            var order1 = new Order(customer1);
            order1.AddItem(new OrderItem("Laptop", 3500m, 1));
            order1.AddItem(new OrderItem("Mouse", 150m, 2));
            order1.AddItem(new OrderItem("Keyboard", 300m, 1));

            var order2 = new Order(customer2);
            order2.AddItem(new OrderItem("Mouse", 150m, 1));
            order2.AddItem(new OrderItem("Monitor", 900m, 1));

            var order3 = new Order(customer1);
            order3.AddItem(new OrderItem("Keyboard", 300m, 2));
            order3.AddItem(new OrderItem("Headphones", 400m, 1));

            var orders = new List<Order> { order1, order2, order3 };

            var service = new OrderService();

            // Demo order summary
            service.PrintOrderSummary(order1);

            Console.WriteLine();
            Console.WriteLine("=== 2.3 Top spender customer ===");
            Console.WriteLine($"Top spender: {service.GetTopSpenderCustomerName(orders)}");

            Console.WriteLine();
            Console.WriteLine("=== 2.4 Popular products (total quantity sold) ===");

            var popular = service.GetPopularProductsWithTotalQuantity(orders);

            foreach (var kvp in popular.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}