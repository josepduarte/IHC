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
            intialize_components();
        }
        public Add_Negocio(DateTime date)
        {
            InitializeComponent();
            intialize_components();
            inicio.SelectedDate = date;
            fim.SelectedDate = date;
        }

        public void intialize_components()
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

        private void Adicionar(object sender, RoutedEventArgs e)
        {
            try
            {
                

                String cliente = textbox_nome.Text;
                int contacto = (Convert.ToInt32(textbox_contacto.Text));
                String morada = textbox_morada.Text;
                DateTime _inicio = Convert.ToDateTime(inicio.Text);
                DateTime _fim = Convert.ToDateTime(fim.Text);
                String descricao = textbox_descricao.Text;

                bool can_create =true;
                foreach (DateTime date in Dates.dates)
                {
                    if(DateTime.Compare(date, _inicio) > 0 && DateTime.Compare(date, _fim) < 0)
                    {
                        can_create = false;
                        break;
                    }
               
                }
                if (can_create)
                {
                    ListaNegocios.getLista().add_Negocio(cliente, contacto, morada, _inicio, _fim, descricao);

                    MessageBox.Show("Negócio criado. ");
                    this.NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Não pode criar este negócio. Datas sobrepostas com outro negócio. ");
                }                
                
            }
            catch
            {
                MessageBox.Show("Erro na introdução dos dados. ");
            }
            
        }

        private void TextBoxMorada_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_morada.Text = "";
            textbox_morada.Foreground = Brushes.AntiqueWhite;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
