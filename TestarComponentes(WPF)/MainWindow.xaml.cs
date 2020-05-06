using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TestarComponentes_WPF_.Entities;
using System.Globalization;

namespace TestarComponentes_WPF_
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        public MainWindow()
            {
            InitializeComponent();
            Min.Visibility = System.Windows.Visibility.Hidden;
            Max.Visibility = System.Windows.Visibility.Hidden;
            LabelMin.Visibility = System.Windows.Visibility.Hidden;
            LabelMax.Visibility = System.Windows.Visibility.Hidden;
            }

        private void ValorMedido_TextChanged(object sender, TextChangedEventArgs e)
            {
            if (System.Text.RegularExpressions.Regex.IsMatch(ValorMedido.Text, "[^0-9-.]"))
                {
                ValorMedido.Text = null;
                MessageBox.Show("Digite Apenas Números ou . ", "Ocorreu um Erro");
                }
            }
        private void ValorBom_TextChanged(object sender, TextChangedEventArgs e)
            {
            if (System.Text.RegularExpressions.Regex.IsMatch(ValorBom.Text, "[^0-9-.]"))
                {
                ValorBom.Text = null;
                MessageBox.Show("Digite Apenas Números ou . ");
                }
            }
        private void Porcentagem_TextChanged(object sender, TextChangedEventArgs e)
            {
            if (System.Text.RegularExpressions.Regex.IsMatch(Porcentagem.Text, "[^0-9-.]"))
                {
                Porcentagem.Text = null;
                MessageBox.Show("Digite Apenas Números ou ' . ' ");
                }
            }



        private void Testar_Click(object sender, RoutedEventArgs e)
            {
            try
                {
                if (Vbtipo.SelectedIndex <= 2 && Tipo.SelectedIndex > 2 || Tipo.SelectedIndex <= 2 && Vbtipo.SelectedIndex > 2)
                    {
                    MessageBox.Show("Não pode comparar um Capacitor com um Resistor", "Ocorreu um Erro");
                    }

                else
                    {

                    switch (Vbtipo.SelectedIndex, Tipo.SelectedIndex)
                        {
                        case (3, 4):
                        case (3, 3):
                        case (4, 3):
                        case (4, 4):
                            Resistor NovoR = new Resistor();

                            NovoR.ValorMedido = double.Parse(ValorMedido.Text, CultureInfo.InvariantCulture);
                            NovoR.ValorBom = double.Parse(ValorBom.Text, CultureInfo.InvariantCulture);
                            NovoR.Tipo = Tipo.Text;
                            NovoR.Vbtipo = Vbtipo.Text;
                            NovoR.Porcentagem = double.Parse(Porcentagem.Text);

                            NovoR.KiloOHm();

                            double BomPorcentagemR = NovoR.ValorPorcentagemBom();
                            NovoR.Max = BomPorcentagemR + NovoR.ValorBom;
                            NovoR.Min = NovoR.ValorBom - BomPorcentagemR;

                            if (NovoR.ValorMedido >= NovoR.Min &&
                           NovoR.ValorMedido <= NovoR.Max)
                                {
                                Resultado.Content = "Componente OK";
                                Resultado.Foreground = Brushes.Green;
                                }
                            else
                                {
                                Resultado.Content = "Valor fora do permitido";
                                Resultado.Foreground = Brushes.Red;
                                }
                            NovoR.VoltarTipo();


                            Min.Content = NovoR.Min.ToString(CultureInfo.InvariantCulture) + " " + Tipo.Text;
                            Max.Content = NovoR.Max.ToString(CultureInfo.InvariantCulture) + " " + Tipo.Text;
                            Min.Visibility = System.Windows.Visibility.Visible;
                            Max.Visibility = System.Windows.Visibility.Visible;
                            LabelMin.Visibility = System.Windows.Visibility.Visible;
                            LabelMax.Visibility = System.Windows.Visibility.Visible;
                            break;

                        default:
                            Capacitor Novo = new Capacitor();

                            Novo.ValorMedido = double.Parse(ValorMedido.Text, CultureInfo.InvariantCulture);
                            Novo.ValorBom = double.Parse(ValorBom.Text, CultureInfo.InvariantCulture);
                            Novo.Tipo = Tipo.Text;
                            Novo.Vbtipo = Vbtipo.Text;
                            Novo.Porcentagem = double.Parse(Porcentagem.Text);

                            Novo.ConverterTipo();

                            double BomPorcentagem = Novo.ValorPorcentagemBom();
                            Novo.Max = BomPorcentagem + Novo.ValorBom;
                            Novo.Min = Novo.ValorBom - BomPorcentagem;

                            if (Novo.ValorMedido >= Novo.Min &&
                           Novo.ValorMedido <= Novo.Max)
                                {
                                Resultado.Content = "Componente OK";
                                Resultado.Foreground = Brushes.Green;
                                }
                            else
                                {
                                Resultado.Content = "Valor fora do permitido";
                                Resultado.Foreground = Brushes.Red;
                                }
                            Novo.VoltarTipo();

                            Min.Content = Novo.Min.ToString(CultureInfo.InvariantCulture) + " " + Tipo.Text;
                            Max.Content = Novo.Max.ToString(CultureInfo.InvariantCulture) + " " + Tipo.Text;
                            Min.Visibility = System.Windows.Visibility.Visible;
                            Max.Visibility = System.Windows.Visibility.Visible;
                            LabelMin.Visibility = System.Windows.Visibility.Visible;
                            LabelMax.Visibility = System.Windows.Visibility.Visible;
                            break;
                        }
                    }
                }
            catch (FormatException)
                {
                MessageBox.Show("Preencha Corretamente Todos Os Valores!!", "Ocorreu um Erro");
                Resultado.Content = "Esperando Valores";
                Resultado.Foreground = Brushes.Black;
                }


            }
        }
    }
