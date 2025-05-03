namespace assignment_2425
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
                MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Startup Error: {ex.Message}");


                MainPage = new ContentPage
                {
                    Content = new Label { Text = "Startup failed: " + ex.Message }
                };
            }
        }
    }
}
