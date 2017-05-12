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
    /// Interaction logic for Add_Negocio.xaml
    /// </summary>
    public partial class Add_Negocio : Page
    {
        public Add_Negocio()
        {
            InitializeComponent();
            // Nome
            textbox_nome.Text = " Insira o nome do negócio aqui. ";
            textbox_nome.Foreground = Brushes.AntiqueWhite;
            // Contacto 
            textbox_contacto.Text = " Insira o contacto aqui. ";
            textbox_contacto.Foreground = Brushes.AntiqueWhite;
            // Descricao
            textbox_descricao.Text = "Insira uma descrição pessoal do negócio aqui. ";
            textbox_descricao.Foreground = Brushes.AntiqueWhite;
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

        private void TextBoxDescricao_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_descricao.Text = "";
            textbox_descricao.Foreground = Brushes.AntiqueWhite;
        }
    }
}
