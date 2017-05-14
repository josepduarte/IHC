using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Negocios.xaml
    /// </summary>
    public partial class Negocios : Page
    {
        static Negocios negocios;
        public Negocios()
        {
            InitializeComponent();
            negocios = this;
        }
        public static void selectDate(DateTime date)
        {
            Console.WriteLine("Blaaaaa: ");
            Console.WriteLine(negocios);
           // negocios.CalendarNegocios.SelectedDates.Add(date);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Adcionar_Negocio(object sender, RoutedEventArgs e)
        {
            Add_Negocio PaginaAddNegocio = new Add_Negocio();
            this.NavigationService.Navigate(PaginaAddNegocio);
        }
    }
    public class Negocio
    {
        private string _cliente;
        private int _contacto;
        private string _morada;
        private DateTime _inicio;
        private DateTime _fim;
        private string _descricao;


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
        public DateTime inicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }
        public DateTime fim
        {
            get { return _fim; }
            set { _fim = value; }
        }
        public string descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

    }

    public class ListaNegocios : ObservableCollection<Negocio>
    {
        static ListaNegocios lista = new ListaNegocios();
        public ListaNegocios()
        {
            add_Negocio("Matilde Guimarães", 234824022, "Rua dos cordelinhos", Convert.ToDateTime("2017-05-10"), Convert.ToDateTime("2017-05-10"), "2000 m2 de eucaliptos");
            add_Negocio("Carla Antónia", 234124012, "Rua das Azeitonas, nº23", Convert.ToDateTime("2017-06-12"), Convert.ToDateTime("2017-08-12"), "6000 m2 de pinheiros");
            add_Negocio("Joaquim Manel", 232412312, "Rua dos Sobreiros", Convert.ToDateTime("2017-10-12"), Convert.ToDateTime("2017-11-12"), "2000 m2 de sobreiros");
            lista = this;

        }
        public static ListaNegocios getLista()
        {
            return lista;
        }
        public void add_Negocio(string cliente, int contacto, string morada, DateTime inicio, DateTime fim, string descricao)
        {
            this.Add(new Negocio { cliente = cliente, contacto = contacto, morada = morada, inicio = inicio, fim = fim, descricao = descricao });

            // Select dates in calendar
           // Negocios.selectDate(inicio);
           // DateTime temp_inicio = inicio.AddDays(1);
          //  Negocios.selectDate(temp_inicio);
        }
    }


}
