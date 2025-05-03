namespace assignment_2425
{
    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = new OrdersViewModel();
        }
    }
}