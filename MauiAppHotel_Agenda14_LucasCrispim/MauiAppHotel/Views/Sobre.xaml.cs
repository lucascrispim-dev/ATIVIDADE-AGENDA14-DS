namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();

        // Versão definida no projeto (ApplicationDisplayVersion)
        lbl_versao.Text = "Versão 1.1 · Agenda 14";
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
