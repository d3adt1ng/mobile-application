using System.ComponentModel;
using System.Threading.Tasks;

namespace assignment_2425
{
    public partial class MainPage : ContentPage
    {
        private Button? activeOrderNowButton;
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private async void Place_Tapped(object sender, EventArgs e)
        {
            if (sender is Grid grid) 
            { 
            
                var item = (grid?.GestureRecognizers.FirstOrDefault() as TapGestureRecognizer)?.CommandParameter as Restaurant;
                if (item == null) return;

                if (activeOrderNowButton != null) 
                {

                    await activeOrderNowButton.FadeTo(0, 200);
                    activeOrderNowButton.IsVisible = false;
                    
                }

                var parentGrid = grid?.Parent as Grid;
                var button = parentGrid?.FindByName<Button>("OrderNowButton");
                if (button != null)
                {
                    button.IsVisible = true;
                    button.Opacity = 0;
                    button.TranslationY = 30;

                    await Task.WhenAll(
                            button.FadeTo(1, 300),
                            button.TranslateTo(0, 0, 300)
                    );

                    activeOrderNowButton = button;
                }    
            }
        }
    }
}