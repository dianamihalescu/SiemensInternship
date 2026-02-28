using System.Collections.Generic;
using System.Linq;

namespace SiemensInternship
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; }

        public Order(Customer customer)
        {
            Customer = customer;
            Items = new List<OrderItem>();
        }

        public void AddItem(OrderItem item) => Items.Add(item);

        public decimal GetSubtotal()
        {
            return Items.Sum(i => i.GetTotal());
        }

        public decimal GetFinalTotal()
        {
            var subtotal = GetSubtotal();
            if (subtotal > 500m)
                return subtotal * 0.9m; // 10% discount
            return subtotal;
        }
    }
}