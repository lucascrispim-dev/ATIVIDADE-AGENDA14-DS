using MauiAppHotel.Models;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        /// <summary>
        /// Array de objetos (List) com as suítes do Hotel Horizonte.
        /// Fonte de dados do Picker e da tela "Nossas Suítes".
        /// </summary>
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto("Suíte Standard",     120.0,  60.0, 2, "Cama de casal, ar-condicionado e frigobar."),
            new Quarto("Suíte Vista Mar",    180.0,  90.0, 3, "Varanda com vista para o mar e café da manhã."),
            new Quarto("Suíte Família",      220.0, 110.0, 5, "Dois quartos integrados, ideal para crianças."),
            new Quarto("Suíte Luxo",         250.0, 125.0, 3, "Banheira de hidromassagem e roupão."),
            new Quarto("Suíte Presidencial", 420.0, 210.0, 4, "Sala de estar, adega e serviço de quarto 24h."),
        };

        public App()
        {
            // Datas e valores em R$ no padrão brasileiro
            var cultura = new System.Globalization.CultureInfo("pt-BR");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultura;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultura;
            System.Globalization.CultureInfo.CurrentCulture = cultura;
            System.Globalization.CultureInfo.CurrentUICulture = cultura;

            InitializeComponent();

            // O layout foi pensado para o tema claro (evita controles invisíveis no modo escuro)
            UserAppTheme = AppTheme.Light;

            MainPage = new NavigationPage(new Views.ContratacaoHospedagem())
            {
                BarBackgroundColor = Color.FromArgb("#0F5257"),
                BarTextColor = Colors.White
            };
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Title = "Hotel Horizonte";
            window.Width = 420;
            window.Height = 680;
            window.X = 40;
            window.Y = 10;

            return window;
        }
    }
}
