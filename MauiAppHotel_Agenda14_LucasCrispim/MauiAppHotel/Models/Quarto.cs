namespace MauiAppHotel.Models
{
    /// <summary>
    /// Representa uma suíte disponível no Hotel Horizonte.
    /// Os valores são encapsulados: o "set" valida o dado antes de gravar no campo privado.
    /// </summary>
    public class Quarto
    {
        private string _descricao = string.Empty;
        private double _valorDiariaAdulto;
        private double _valorDiariaCrianca;
        private int _capacidade = 2;

        public Quarto() { }

        public Quarto(string descricao, double valorAdulto, double valorCrianca, int capacidade, string detalhes)
        {
            Descricao = descricao;
            ValorDiariaAdulto = valorAdulto;
            ValorDiariaCrianca = valorCrianca;
            Capacidade = capacidade;
            Detalhes = detalhes;
        }

        public string Descricao
        {
            get { return _descricao; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A descrição da suíte é obrigatória.");

                _descricao = value;
            }
        }

        public double ValorDiariaAdulto
        {
            get { return _valorDiariaAdulto; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("O valor da diária de adulto não pode ser negativo.");

                _valorDiariaAdulto = value;
            }
        }

        public double ValorDiariaCrianca
        {
            get { return _valorDiariaCrianca; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("O valor da diária de criança não pode ser negativo.");

                _valorDiariaCrianca = value;
            }
        }

        /// <summary>Quantidade máxima de hóspedes (adultos + crianças).</summary>
        public int Capacidade
        {
            get { return _capacidade; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("A capacidade deve ser de pelo menos 1 hóspede.");

                _capacidade = value;
            }
        }

        public string Detalhes { get; set; } = string.Empty;

        /// <summary>Texto pronto para exibir na lista de suítes.</summary>
        public string ResumoPrecos => $"Adulto {ValorDiariaAdulto:C} · Criança {ValorDiariaCrianca:C}";

        public string ResumoCapacidade => $"Até {Capacidade} hóspedes";

        /// <summary>Método: calcula o valor de uma diária para o grupo informado.</summary>
        public double CalcularDiaria(int adultos, int criancas)
        {
            return (adultos * ValorDiariaAdulto) + (criancas * ValorDiariaCrianca);
        }
    }
}
