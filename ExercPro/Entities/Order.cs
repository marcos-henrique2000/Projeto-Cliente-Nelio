using ExercPro.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ExercPro.Entities
{
    class Order
    {
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Item { get; set; } = new List<OrderItem>();
        public OrderStatus status { get; set; }

        public Order(){}

        public Order(DateTime date, Client client, OrderStatus status)
        {
            Date = date;
            Client = client;
            this.status = status;
        }

        public void AddItem(OrderItem item)
        {
            Item.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Item.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;

            foreach (OrderItem item in Item)
            {
                sum += item.subTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Date.ToString());
            sb.Append("Order status: ");
            sb.AppendLine(status.ToString());
            sb.Append("Client: ");
            sb.AppendLine(Client.ToString());

            sb.AppendLine("Order items: ");

            foreach (OrderItem item in Item)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }

    }
}
