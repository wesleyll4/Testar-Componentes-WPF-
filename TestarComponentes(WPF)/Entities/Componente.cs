
namespace TestarComponentes_WPF_.Entities
    {
    class Componente
        {
        public string Tipo { get; set; }
        public double Porcentagem { get; set; }
        public double ValorMedido { get; set; }
        public double ValorBom { get; set; }
        public string Vbtipo { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        public Componente()
            {
            }


        public Componente(string tipo, double porcentagem, double valorMedido, double valorBom, string vbtipo, double min, double max)
            {
            Tipo = tipo;
            Porcentagem = porcentagem;
            ValorMedido = valorMedido;
            ValorBom = valorBom;
            Vbtipo = vbtipo;
            Min = min;
            Max = max;
            }

        public double ValorPorcentagemBom()
            {
            return ValorBom * Porcentagem / 100;
            }
        public double ValorPorcentagemMedido()
            {
            return ValorMedido * Porcentagem / 100;
            }

        }
    }
