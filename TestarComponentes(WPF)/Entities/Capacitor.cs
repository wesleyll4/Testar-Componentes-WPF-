
namespace TestarComponentes_WPF_.Entities
    {
    class Capacitor : Componente
        {
        public void ConverterTipo()
            {
            if (Tipo == "uF")
                {
                ValorMedido = ValorMedido * 1000000;
                }
            else if (Tipo == "nF")
                {
                ValorMedido = ValorMedido * 1000;
                }

            if (Vbtipo == "uF")
                {
                ValorBom = ValorBom * 1000000;
                }
            else if (Vbtipo == "nF")
                {
                ValorBom = ValorBom * 1000;
                }
            }
        public void VoltarTipo()
            {
            if (Tipo == "uF")
                {
                ValorMedido = ValorMedido / 1000000;
                Min = Min / 1000000;
                Max = Max / 1000000;
                }
            else if (Tipo == "nF")
                {
                ValorMedido = ValorMedido / 1000;
                Min = Min / 1000;
                Max = Max / 1000;
                }
            if (Vbtipo == "uF")
                {
                ValorBom = ValorBom / 1000000;
                }
            else if (Vbtipo == "nF")
                {
                ValorBom = ValorBom / 1000;

                }
            }

        }
    }
