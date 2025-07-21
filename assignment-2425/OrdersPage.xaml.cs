using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace assignment_2425
{
    public partial class OrdersPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Order> PastOrders { get; set; } = new();
        private List<Order> allOrders = new();

        private string _recentOrder;
        public string RecentOrder
        {

            get => _recentOrder;
            set
            {
                _recentOrder = value;
                OnPropertyChanged(nameof(RecentOrder));

            }
        }

        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = this;

            LoadOrders();
        }

        private void LoadOrders()
        {
            var loadedOrders = new List<Order>
            {
                new Order { Name = "Dixy Chicken", Date = "July 10", ItemName = "Mega Mix Burger" },
                new Order { Name = "McDonald's", Date = "July 5", ItemName = "Cheeseburger" },
                new Order { Name = "Pizza Hut", Date = "June 30", ItemName = "Pepperoni Pizza" },
                new Order { Name = "KFC", Date = "June 25", ItemName = "Zinger Burger" },
                new Order { Name = "Subway", Date = "June 20", ItemName = "Veggie Delight" }
            };

            allOrders = loadedOrders;
            PastOrders.Clear();

            foreach (var order in loadedOrders)
            {
                PastOrders.Add(order);
            }

            RecentOrder = loadedOrders.FirstOrDefault()?.ItemName ?? "No recent orders";
        }
        private void OnOrderTapped(object sender, EventArgs e)
        {
            if (sender is TapGestureRecognizer tap && tap.CommandParameter is Order selectedOrder)
            {
                DetailRestaurant.Text = selectedOrder.Name;
                DetailItem.Text = selectedOrder.ItemName;
                DetailDate.Text = selectedOrder.Date;
                DetailPrice.Text = selectedOrder.Price != null ? $"${selectedOrder.Price:F2}" : "Price not available";
                OrderDetailsFrame.IsVisible = true;
            }
        }
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = e.NewTextValue?.ToLower() ?? "";

            var filtered = allOrders
                .Where(o => o.Name.ToLower().Contains(searchText) ||
                            o.ItemName.ToLower().Contains(searchText))
                .ToList();

            PastOrders.Clear();
            foreach (var order in filtered)
            {
                PastOrders.Add(order);
            }
        }
        public new event PropertyChangedEventHandler PropertyChanged;
        protected new void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));



        private void OnCloseDetails(object sender, EventArgs e)
        {
            OrderDetailsFrame.IsVisible = false;
        }

        public class Order
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public string ItemName { get; set; }
            public string Price { get; set; }
        }
    }
}
