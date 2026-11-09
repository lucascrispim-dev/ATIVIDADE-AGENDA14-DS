using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

/// <summary>
/// Nova tela (Agenda 14): lista todas as suítes do hotel.
/// Ao tocar em uma suíte, ela é devolvida para a tela de cálculo já selecionada no Picker.
/// </summary>
public partial class NossasSuites : ContentPage
{
    private readonly Action<Quarto> _aoEscolher;

    public NossasSuites(List<Quarto> suites, Action<Quarto> aoEscolher)
    {
        InitializeComponent();

        _aoEscolher = aoEscolher;
        cv_suites.ItemsSource = suites;
    }

    private async void cv_suites_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Quarto quarto)
            return;

        _aoEscolher(quarto);
        await Navigation.PopAsync();
    }
}
