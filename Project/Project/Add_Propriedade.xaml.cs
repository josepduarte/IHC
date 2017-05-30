using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;

namespace Project
{
    /// <summary>
    /// Interaction logic for Add_Propriedade.xaml
    /// </summary>
    public partial class Add_Propriedade : Page
    {
        public string rua { get; set; }
        public string freguesia { get; set; }
        public string concelho { get; set; }
        public double coordX { get; set; }
        public double coordY { get; set; }

        public Add_Propriedade()
        {
            InitializeComponent();
            initialize_components();
            DataContext = this;
        }
        public void initialize_components()
        {
            textBox.Text = " Insira a rua aqui. ";
            textBox.Foreground = Brushes.AntiqueWhite;
            textBox1.Text = " Insira a freguesia aqui. ";
            textBox1.Foreground = Brushes.AntiqueWhite;
            textBox2.Text = "Insira o concelho aqui. ";
            textBox2.Foreground = Brushes.AntiqueWhite;
            textBox3.Text = "Insira a latitude aqui. (coordenadas)";
            textBox3.Foreground = Brushes.AntiqueWhite;
            textBox4.Text = "Insira a longitude aqui. (coordenadas)";
            textBox4.Foreground = Brushes.AntiqueWhite;
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Propriedades propPage = new Propriedades();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));

            
        }

        /* Botão "Guardar" */
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                String rua = textBox.Text;
                String freguesia = textBox1.Text;
                String concelho = textBox2.Text;
                Double coord_x = Convert.ToDouble(textBox3.Text);
                Double coord_y = Convert.ToDouble(textBox4.Text);

                ListaPropriedades.getLista().add_Propriedade(rua, freguesia, concelho, coord_x, coord_y);

                MessageBox.Show("Propriedade adicionado. ");

                this.NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Erro na introdução dos dados. ");
            }   
            
        }

        private void Button_anterior(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            textBox.Foreground = Brushes.AntiqueWhite;
        }

        private void TextBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox1.Foreground = Brushes.AntiqueWhite;
        }

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox2.Text = "";
            textBox2.Foreground = Brushes.AntiqueWhite;
        }

        private void TextBox3_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox3.Text = "";
            textBox3.Foreground = Brushes.AntiqueWhite;
        }

        private void TextBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox4.Text = "";
            textBox4.Foreground = Brushes.AntiqueWhite;
        }
    }


}
