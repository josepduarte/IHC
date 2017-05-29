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
using System.Windows.Forms;
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
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button delete = (System.Windows.Controls.Button)e.OriginalSource;
            DialogResult dialogResult = form1.Show("Confirmar remoção", "Tem a certeza que pretende apagar?", "", "Sim", "Não");
            if (dialogResult == DialogResult.No)
                delete.Command = ApplicationCommands.NotACommand;

        }

        private void Adicionar_encomenda(object sender, RoutedEventArgs e)
        {
           Add_Encomenda PaginaAddEncomenda = new Add_Encomenda();
           this.NavigationService.Navigate(PaginaAddEncomenda);
        }

        private void Button_anterior(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }


        private void DataGrid_AutoGeneratingColumn_1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "cliente")
                e.Column.Header = "Cliente";
            if (e.Column.Header.ToString() == "contacto")
                e.Column.Header = "Contacto";
            if (e.Column.Header.ToString() == "morada")
                e.Column.Header = "Morada";
            if (e.Column.Header.ToString() == "tipo_madeira")
                e.Column.Header = "Tipo de Madeira";
            if (e.Column.Header.ToString() == "data")
                e.Column.Header = "Data";
            if (e.Column.Header.ToString() == "quantidade")
                e.Column.Header = "Quantidade";
            if (e.Column.Header.ToString() == "preco")
                e.Column.Header = "Preço";
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
            add_Encomenda("Maria Madeira Eu Quero", 93423221, "nº102, Rua das Plantas", "Eucalipto", "20", "100.57 ", Convert.ToDateTime("2017-05-10"));
            add_Encomenda("Carlos Josefiino Andrade", 1234212, "nº10, Rua dos Arrozes Perfeito", "Sobreiro", "40", "180.50", Convert.ToDateTime("2017-05-12"));
            add_Encomenda("Marta Carvalho", 9123121, "nº 20, Rua dos Carvalhos Perdidos", "Carvalhos", "10", "50.05", Convert.ToDateTime("2017-10-11"));
            lista = this;

        }
        public static ListaEncomendas getLista()
        {
            return lista;
        }
        public void add_Encomenda(string cliente, int contacto, string morada, string tipo_madeira, string quantidade, string preco, DateTime data)
        {
            this.Add(new Encomenda { cliente = cliente, contacto = contacto, morada = morada, tipo_madeira = tipo_madeira, quantidade = String.Concat(quantidade, " m2"), preco = String.Concat(preco, " €"), data = data });

        }
    }

}
