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

namespace Project
{
    /// <summary>
    /// Interaction logic for Add_stock.xaml
    /// </summary>
    public partial class Add_stock : Page
    {
        public Add_stock()
        {
            InitializeComponent();
            initialize_components();
        }
        public void initialize_components()
        {
            // Nome
            textbox_tipo.Text = " Insira o tipo aqui. ";
            textbox_tipo.Foreground = Brushes.AntiqueWhite;
            // Quantidade
            textbox_quantidade.Text = " Insira a quantidade aqui. ";
            textbox_quantidade.Foreground = Brushes.AntiqueWhite;
        }

        private void Adicionar(object sender, RoutedEventArgs e)
        {
            try
            {
                String tipo = textbox_tipo.Text;
                String quantidade = textbox_quantidade.Text;
      
                double temp = Convert.ToDouble(textbox_quantidade.Text);

                ListaMadeiras.getLista().add_Madeira(tipo, quantidade);
                Stock.to_save.add_Madeira(tipo, quantidade);

                MessageBox.Show("Tipo de mandeira e quantidade adicionados. ");
                this.NavigationService.GoBack();
                initialize_components();
            }
            catch
            {
                MessageBox.Show("Erro na introdução dos dados. ");
            }
        }

        private void textbox_quantidade_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_quantidade.Text = "";
            textbox_quantidade.Foreground = Brushes.AntiqueWhite;
        }

        private void textbox_tipo_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_tipo.Text = "";
            textbox_tipo.Foreground = Brushes.AntiqueWhite;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));
        }

        private void Button_anterior(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
