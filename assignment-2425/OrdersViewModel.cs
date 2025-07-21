using System.Collections.ObjectModel;

namespace assignment_2425
{
    public class OrdersViewModel 
    { 
        public string RecentOrder { get; set; }

        public ObservableCollection<OrderItem> PastOrders { get; set; }

        public OrdersViewModel() 
        {

            RecentOrder = "Dixy's Chicken Order from Yesterday";

            PastOrders = new ObservableCollection<OrderItem>
            {
                new OrderItem {Name = "Burger", Date = "March 20, 2025"},
                new OrderItem {Name = "Sushi", Date = "March 21, 2025"},
                new OrderItem {Name = "Tacos", Date = "Match 22, 2025"}
            };

        }

        internal void FilterOrders(string newTextValue)
        {
            throw new NotImplementedException();
        }
    }
    public class OrderItem 
    { 
        public string Name { get; set; }
        public string Date { get; set; }
    }
}