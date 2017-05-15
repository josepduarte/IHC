using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : Page
    {
        public Stock()
        {
            InitializeComponent();
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));
        }

        private void Apagar_tipo(object sender, RoutedEventArgs e)
        {
            try
            {
                
                String tipo = Convert.ToString(TypeDescriptor.GetProperties(this.stockListBox.SelectedItem)["tipo"].GetValue(this.stockListBox.SelectedItem));

                Madeira toRemove = ListaMadeiras.getLista().Single(r => r.tipo == tipo); // && r.contacto == contacto && r.morada == morada && (r.inicio.CompareTo(inicio) == 0) && (r.fim.CompareTo(fim) == 0) && r.descricao == descricao);
                ListaMadeiras.getLista().Remove(toRemove);
                MessageBox.Show("Tipo de madeira apagado. ");
                this.NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("Nenhuma encomenda selecionada. ");
                this.NavigationService.Refresh();
            }
        }

        private void Adicionar_tipo(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Add_stock());
        }

        private void Atualizar_tipo(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Update_stock());
        }
    }
    public class Madeira
    {
        private string _tipo;
        private string _quantidade;


        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
    }

    public class ListaMadeiras : ObservableCollection<Madeira>
    {
        static ListaMadeiras lista = new ListaMadeiras();
        public ListaMadeiras()
        {
            add_Madeira("Eucalipto", "100 m2");
            add_Madeira("Carvalho", "240 m2");
            add_Madeira("Sobreiro", "70 m2");
            lista = this;

        }
        public static ListaMadeiras getLista()
        {
            return lista;
        }
        public void add_Madeira(string tipo, string quantidade)
        {
            this.Add(new Madeira { tipo = tipo, quantidade = quantidade });

        }
    }
}
