

namespace TestarComponentes_WPF_.Entities
    {
    class Resistor : Componente
        {

        public void KiloOHm()
            {
            if (Tipo == "kOhm")
                {
                ValorMedido = ValorMedido * 1000;
                }
            if (Vbtipo == "kOhm")
                {
                ValorBom = ValorBom * 1000;
                }
            }
        public void VoltarTipo()
            {
            if (Tipo == "kOhm")
                {
                ValorMedido = ValorMedido / 1000;
                Min = Min / 1000;
                Max = Max / 1000;
                }
            if (Vbtipo == "kOhm")
                {
                ValorBom = ValorBom / 1000;
                }
            }

        }
    }
