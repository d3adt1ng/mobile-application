
namespace assignment_2425
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Orders", typeof(OrdersPage));
            Routing.RegisterRoute("Home", typeof(MainPage));
            Routing.RegisterRoute("Food/Groceries", typeof(FoodGroceriesPage));
        }

    }
}
