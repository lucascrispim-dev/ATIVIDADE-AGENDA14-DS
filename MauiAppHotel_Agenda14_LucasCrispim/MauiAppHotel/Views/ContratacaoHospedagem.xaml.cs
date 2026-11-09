using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current!;

        // Fonte de dados do Picker: array de objetos (List<Quarto>) definido no App
        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        // Validação do DatePicker de check-in: a partir de hoje, até 1 mês à frente
        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddMonths(1);

        // Validação do DatePicker de check-out: no mínimo 1 dia depois do check-in, até 6 meses
        AtualizarLimitesCheckout(dtpck_checkin.Date);
    }

    private void AtualizarLimitesCheckout(DateTime data_checkin)
    {
        dtpck_checkout.MinimumDate = data_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_checkin.AddMonths(6);

        if (dtpck_checkout.Date <= data_checkin)
            dtpck_checkout.Date = data_checkin.AddDays(1);

        AtualizarNoites();
    }

    private void AtualizarNoites()
    {
        int noites = (dtpck_checkout.Date - dtpck_checkin.Date).Days;
        lbl_noites.Text = noites == 1 ? "1 noite de estadia" : $"{noites} noites de estadia";
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        AtualizarLimitesCheckout(e.NewDate);
    }

    private void dtpck_checkout_DateSelected(object sender, DateChangedEventArgs e)
    {
        AtualizarNoites();
    }

    private async void btn_avancar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem is not Quarto quarto)
            {
                await DisplayAlert("Atenção", "Selecione uma suíte para continuar.", "OK");
                return;
            }

            // Instancia o objeto Hospedagem; os "set" das propriedades validam cada dado
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = quarto,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            h.ValidarCapacidade();

            // Envia os dados para a próxima tela via BindingContext
            await Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = h
            });
        }
        catch (ArgumentException ex)
        {
            await DisplayAlert("Verifique os dados", ex.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void btn_suites_Clicked(object sender, EventArgs e)
    {
        // Nova tela: ao escolher uma suíte, ela volta selecionada no Picker
        await Navigation.PushAsync(new NossasSuites(PropriedadesApp.lista_quartos,
            quarto => pck_quarto.SelectedItem = quarto));
    }

    private async void btn_sobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
