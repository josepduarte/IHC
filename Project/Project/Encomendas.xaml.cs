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
    /// Interaction logic for Encomendas.xaml
    /// </summary>
    public partial class Encomendas : Page
    {
        static public int numEncomendas = 0;
        static public string[] encomendas = new string[100];

        public Encomendas()
        {
            InitializeComponent();
        }

        public Encomendas(object data) : this()
        {
            this.DataContext = data;
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));
        }

        /* Botão "Adicionar Encomenda" */
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Add_Encomenda.xaml", UriKind.Relative));
        }

        private void Apagar_encomenda(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.Refresh();
                String cliente = Convert.ToString(TypeDescriptor.GetProperties(this.encomendasListBox.SelectedItem)["cliente"].GetValue(this.encomendasListBox.SelectedItem));

                Encomenda toRemove = ListaEncomendas.getLista().Single(r => r.cliente == cliente); // && r.contacto == contacto && r.morada == morada && (r.inicio.CompareTo(inicio) == 0) && (r.fim.CompareTo(fim) == 0) && r.descricao == descricao);
                ListaEncomendas.getLista().Remove(toRemove);
                MessageBox.Show("Encomenda Apagada. ");
                this.NavigationService.Refresh();
            }
            catch{
                MessageBox.Show("Nenhuma encomenda selecionada. ");
                this.NavigationService.Refresh();
            }
            
        }

        private void Adicionar_encomenda(object sender, RoutedEventArgs e)
        {
           Add_Encomenda PaginaAddEncomenda = new Add_Encomenda();
           this.NavigationService.Navigate(PaginaAddEncomenda);
        }
    }
    public class Encomenda
    {
        private string _cliente;
        private int _contacto;
        private string _morada;
        private string _tipo_madeira;
        private string _quantidade;
        private string _preco;
        private DateTime _data;


        public string cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public int contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }
        public string morada
        {
            get { return _morada; }
            set { _morada = value; }
        }
        public string tipo_madeira
        {
            get { return _tipo_madeira; }
            set { _tipo_madeira = value; }
        }
        public string quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public string preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
        public DateTime data
        {
            get { return _data; }
            set { _data = value; }
        }

    }

    public class ListaEncomendas : ObservableCollection<Encomenda>
    {
        static ListaEncomendas lista = new ListaEncomendas();
        public ListaEncomendas()
        {
            add_Encomenda("Maria Madeira Eu Quero", 93423221, "nº102, Rua das Plantas", "Eucalipto", "20 m2", "100.57", Convert.ToDateTime("2017-05-10"));
            add_Encomenda("Carlos Josefiino Andrade", 1234212, "nº10, Rua dos Arrozes Perfeito", "Sobreiro", "40 m2", "180.50", Convert.ToDateTime("2017-05-12"));
            add_Encomenda("Marta Carvalho", 9123121, "nº 20, Rua dos Carvalhos Perdidos", "Carvalhos", "10 m2", "50.05", Convert.ToDateTime("2017-10-11"));
            lista = this;

        }
        public static ListaEncomendas getLista()
        {
            return lista;
        }
        public void add_Encomenda(string cliente, int contacto, string morada, string tipo_madeira, string quantidade, string preco, DateTime data)
        {
            this.Add(new Encomenda { cliente = cliente, contacto = contacto, morada = morada, tipo_madeira = tipo_madeira, quantidade = quantidade, preco = String.Concat(preco, "€"), data = data });

        }
    }

}
