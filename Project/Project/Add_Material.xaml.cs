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
    /// Interaction logic for Add_Material.xaml
    /// </summary>
    public partial class Add_Material : Page
    {
        public Add_Material()
        {
            InitializeComponent();
            initialize_components();
        }
        public void initialize_components()
        {
            textbox_tipo.Text = " Insira o tipo do material aqui. ";
            textbox_tipo.Foreground = Brushes.AntiqueWhite;
            textbox_quantidade.Text = " Insira a quantidade aqui. ";
            textbox_quantidade.Foreground = Brushes.AntiqueWhite;
            textbox_unidade.Text = "Insira a unidade aqui. ";
            textbox_unidade.Foreground = Brushes.AntiqueWhite;
            textbox_descricao.Text = "Insira a descricao aqui. ";
            textbox_descricao.Foreground = Brushes.AntiqueWhite;
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Homepage PaginaInicial = new Homepage();
            this.NavigationService.Navigate(PaginaInicial);
        }

        private void Adicionar(object sender, RoutedEventArgs e)
        {
            try
            {
                String tipo = textbox_tipo.Text;
                int quantidade = Convert.ToInt32(textbox_quantidade.Text);
                String unidade = textbox_unidade.Text;
                String descricao = textbox_descricao.Text;

                ListaMateriais.getLista().add_Material(tipo, quantidade, unidade, descricao);

                MessageBox.Show("Material adicionado. ");
                this.NavigationService.Refresh();
                initialize_components();
            }
            catch
            {
                MessageBox.Show("Erro na introdução dos dados. ");
            }
        }

        private void textbox_tipo_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_tipo.Text = "";
            textbox_tipo.Foreground = Brushes.AntiqueWhite;
        }
        private void TextBox_quantidade_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_quantidade.Text = "";
            textbox_quantidade.Foreground = Brushes.AntiqueWhite;
        }
        private void TextBox_unidade_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_unidade.Text = "";
            textbox_unidade.Foreground = Brushes.AntiqueWhite;
        }
        private void textbox_descricao_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_descricao.Text = "";
            textbox_descricao.Foreground = Brushes.AntiqueWhite;
        }


    }
}
