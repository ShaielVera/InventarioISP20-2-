namespace AppMovil
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Cliqueaste {count} vez";
            else
                CounterBtn.Text = $"Cliqueaste {count} veces";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
