using System;
using System.Collections.Generic;
using System.Linq;

namespace SiemensInternship
{
    public class OrderService
    {
        public void PrintOrderSummary(Order order)
        {
            Console.WriteLine("Order Summary");
            Console.WriteLine("------------------");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Email: {order.Customer.Email}");
            Console.WriteLine();

            foreach (var item in order.Items)
            {
                Console.WriteLine($"{item.ProductName} - {item.Quantity} x {item.Price} = {item.GetTotal()}");
            }

            Console.WriteLine();
            Console.WriteLine($"Subtotal: {order.GetSubtotal()}");
            Console.WriteLine($"Final Total: {order.GetFinalTotal()}");
        }

        // 2.3
        public string GetTopSpenderCustomerName(List<Order> orders)
        {
            if (orders == null || orders.Count == 0) return string.Empty;

            var top = orders
                .GroupBy(o => o.Customer.Name)
                .Select(g => new
                {
                    CustomerName = g.Key,
                    TotalSpent = g.Sum(o => o.GetFinalTotal())
                })
                .OrderByDescending(x => x.TotalSpent)
                .First();

            return top.CustomerName;
        }

        // 2.4 (Bonus)
        public Dictionary<string, int> GetPopularProductsWithTotalQuantity(List<Order> orders)
        {
            if (orders == null) return new Dictionary<string, int>();

            return orders
                .SelectMany(o => o.Items)
                .GroupBy(i => i.ProductName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(i => i.Quantity)
                );
        }
    }
}