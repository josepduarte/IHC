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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Windows.Controls;

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
            //CalendarNegocios.SelectedDates.Add(Convert.ToDateTime("2017-05-18"));
           // CalendarNegocios.SelectedDates.Add(Convert.ToDateTime("2017-05-06"));
        }
        public static void selectDate(DateTime date)
        {
            Console.WriteLine("Blaaaaa: ");
            Console.WriteLine(negocios);
            try {
           //     negocios.CalendarNegocios.SelectedDates.Add(date);
            }
            catch
            {
                Console.WriteLine("rebentou");
            }
        }
        public static Negocios get_negocios()
        {
            return negocios;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Adcionar_Negocio(object sender, RoutedEventArgs e)
        {
            Add_Negocio PaginaAddNegocio = new Add_Negocio();
            this.NavigationService.Navigate(PaginaAddNegocio);
        }

        private void stack_detail(object sender, MouseButtonEventArgs e)
        {
// Negocio_detalhe detalhePage = new Negocio_detalhe(this.negociosListBox.SelectedItem);
//            this.NavigationService.Navigate(detalhePage);
         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (Convert.ToString(e.Column.Header) == "precipitacao")
                e.Column.Visibility = Visibility.Collapsed;
            else
                e.Column.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button delete = (System.Windows.Controls.Button)e.OriginalSource;
            DialogResult dialogResult = form1.Show("Confirmar remoção", "Tem a certeza que pretende apagar?", "", "Sim", "Não");
            if (dialogResult == DialogResult.No)
                delete.Command = ApplicationCommands.NotACommand;

        }

        private void Button_anterior(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
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
        private string _precipitacao;
        


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
        public string precipitacao
        {
            get { return _precipitacao; }
            set { _precipitacao = value; }
        }

    }

    public class ListaNegocios : ObservableCollection<Negocio>
    {
        static ListaNegocios lista = new ListaNegocios();
        private Random rnd = new Random();
        public ListaNegocios()
        {
            add_Negocio("Matilde Guimarães", 234824022, "Rua dos cordelinhos", Convert.ToDateTime("2017-05-18"), Convert.ToDateTime("2017-05-18"), "2000 m2 de eucaliptos");
            add_Negocio("Carla Antónia", 234124012, "Rua das Azeitonas, nº23", Convert.ToDateTime("2017-06-12"), Convert.ToDateTime("2017-08-12"), "6000 m2 de pinheiros");
            add_Negocio("Joaquim Manel", 232412312, "Rua dos Sobreiros", Convert.ToDateTime("2017-9-12"), Convert.ToDateTime("2017-9-12"), "2000 m2 de sobreiros");
            add_Negocio("Artur Carapau", 32423422, "Rua dos Pescados", Convert.ToDateTime("2017-9-18"), Convert.ToDateTime("2017-9-18"), "200 m2 de eucaliptos");
            add_Negocio("Josefina Aviadora", 23411233, "Rua dos Que Levantam Voo, nº23", Convert.ToDateTime("2017-10-2"), Convert.ToDateTime("2017-10-2"), "60 m2 de pinheiros");
            add_Negocio("Carabinda de Jesus", 232213123, "Rua dos Sobreiros", Convert.ToDateTime("2017-12-9"), Convert.ToDateTime("2017-12-9"), "2000 m2 de eucaliptos");
            lista = this;

        }
        public static ListaNegocios getLista()
        {
            return lista;
        }

        //private static readonly Random rnd = new Random();
        public void add_Negocio(string cliente, int contacto, string morada, DateTime inicio, DateTime fim, string descricao)
        {
            //Random rnd = new Random();
            string precipitacao = String.Concat(Convert.ToString(this.rnd.Next(1, 10) * 10), "%");

            this.Add(new Negocio { cliente = cliente, contacto = contacto, morada = morada, inicio = inicio, fim = fim, descricao = descricao, precipitacao = precipitacao });
            /*
            String url = "api.openweathermap.org/data/2.5/forecast/daily?id=524901&APPID=90933764d690fab7366a6029e0c411a6";
            XmlReader reader = XmlReader.Create(url);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            */

            // Select dates in calendar
            //Negocios.selectDate(inicio);
            // DateTime temp_inicio = inicio.AddDays(1);
            //  Negocios.selectDate(temp_inicio);
        }
    }


}
