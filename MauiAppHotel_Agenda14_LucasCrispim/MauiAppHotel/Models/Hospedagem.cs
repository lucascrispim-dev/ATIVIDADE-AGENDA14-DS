namespace MauiAppHotel.Models
{
    /// <summary>
    /// Dados da hospedagem escolhida pelo hóspede.
    /// É enviada para a tela HospedagemContratada através do BindingContext.
    /// As propriedades validam os dados no "set" e lançam ArgumentException quando algo está errado.
    /// </summary>
    public class Hospedagem
    {
        private Quarto _quartoSelecionado = new();
        private int _qntAdultos = 1;
        private int _qntCriancas;
        private DateTime _dataCheckIn = DateTime.Today;
        private DateTime _dataCheckOut = DateTime.Today.AddDays(1);

        public Quarto QuartoSelecionado
        {
            get { return _quartoSelecionado; }
            set { _quartoSelecionado = value ?? throw new ArgumentException("Selecione uma suíte."); }
        }

        public int QntAdultos
        {
            get { return _qntAdultos; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("A reserva precisa de pelo menos 1 adulto.");

                _qntAdultos = value;
            }
        }

        public int QntCriancas
        {
            get { return _qntCriancas; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("A quantidade de crianças não pode ser negativa.");

                _qntCriancas = value;
            }
        }

        public DateTime DataCheckIn
        {
            get { return _dataCheckIn; }
            set
            {
                if (value.Date < DateTime.Today)
                    throw new ArgumentException("O check-in não pode ser em uma data passada.");

                _dataCheckIn = value.Date;
            }
        }

        public DateTime DataCheckOut
        {
            get { return _dataCheckOut; }
            set
            {
                if (value.Date <= _dataCheckIn)
                    throw new ArgumentException("O check-out deve ser depois do check-in.");

                _dataCheckOut = value.Date;
            }
        }

        public int TotalHospedes => QntAdultos + QntCriancas;

        public int Estadia => (DataCheckOut - DataCheckIn).Days;

        public double ValorDiaria => QuartoSelecionado.CalcularDiaria(QntAdultos, QntCriancas);

        public double ValorTotal => ValorDiaria * Estadia;

        /// <summary>
        /// Regra de negócio: o grupo precisa caber na suíte escolhida.
        /// </summary>
        public void ValidarCapacidade()
        {
            if (TotalHospedes > QuartoSelecionado.Capacidade)
                throw new ArgumentException(
                    $"A {QuartoSelecionado.Descricao} acomoda até {QuartoSelecionado.Capacidade} hóspedes. " +
                    $"Você informou {TotalHospedes}.");
        }
    }
}
