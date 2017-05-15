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
    /// Interaction logic for Add_Encomenda.xaml
    /// </summary>
    public partial class Add_Encomenda : Page
    {
        public Add_Encomenda()
        {
            InitializeComponent();
            initialize_components();
        }
        public void initialize_components()
        {
            // Nome
            textbox_nome.Text = " Insira o nome do negócio aqui. ";
            textbox_nome.Foreground = Brushes.AntiqueWhite;
            // Contacto 
            textbox_contacto.Text = " Insira o contacto aqui. ";
            textbox_contacto.Foreground = Brushes.AntiqueWhite;
            // Morada
            textbox_morada.Text = "Insira a morada aqui. ";
            textbox_morada.Foreground = Brushes.AntiqueWhite;
            // Tipo de madeira
            textbox_tipo_madeira.Text = "Insira o tipo de madeira aqui. ";
            textbox_tipo_madeira.Foreground = Brushes.AntiqueWhite;
            // Quantidade
            textbox_quantidade.Text = "Insira a quantidade pretendida aqui. ";
            textbox_quantidade.Foreground = Brushes.AntiqueWhite;
            // Preço
            textbox_preco.Text = "Insira o preço aqui. ";
            textbox_preco.Foreground = Brushes.AntiqueWhite;
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Homepage PaginaInicial = new Homepage();
            this.NavigationService.Navigate(PaginaInicial);
        }

        private void TextBoxNome_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_nome.Text = "";
            textbox_nome.Foreground = Brushes.AntiqueWhite;
        }

        private void TextBoxContacto_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_contacto.Text = "";
            textbox_contacto.Foreground = Brushes.AntiqueWhite;
        }
        private void TextBoxMorada_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_morada.Text = "";
            textbox_morada.Foreground = Brushes.AntiqueWhite;
        }
        private void TextBox_tipo_madeira_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_tipo_madeira.Text = "";
            textbox_tipo_madeira.Foreground = Brushes.AntiqueWhite;
        }
        private void TextBox_quantidade_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_quantidade.Text = "";
            textbox_quantidade.Foreground = Brushes.AntiqueWhite;
        }
        private void TextBox_preco_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_preco.Text = "";
            textbox_preco.Foreground = Brushes.AntiqueWhite;
        }

        private void Adicionar(object sender, RoutedEventArgs e)
        {
            try
            {
                String cliente = textbox_nome.Text;
                int contacto = (Convert.ToInt32(textbox_contacto.Text));
                String morada = textbox_morada.Text;
                DateTime _data = Convert.ToDateTime(data.Text);
                String tipo_madeira = textbox_tipo_madeira.Text;
                String quantidade = textbox_quantidade.Text;
                double preco = (Convert.ToDouble(textbox_preco.Text));

                ListaEncomendas.getLista().add_Encomenda(cliente, contacto, morada, tipo_madeira, quantidade, preco, _data);

                MessageBox.Show("Encomenda criada. ");
                this.NavigationService.Refresh();
                initialize_components();
            }
            catch
            {
                MessageBox.Show("Erro na introdução dos dados. ");
            }
        }
    }
}
