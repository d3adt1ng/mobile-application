namespace assignment_2425
{
    public partial class FoodGroceriesPage : ContentPage
    {
        public FoodGroceriesPage()
        {
            InitializeComponent();
            BindingContext = new FoodGroceriesViewModel();
        }
    }
}