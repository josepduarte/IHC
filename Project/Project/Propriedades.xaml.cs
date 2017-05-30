using Microsoft.Maps.MapControl.WPF;
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
    /// </summary>    /// Interaction logic for Propriedades.xaml

    /// 

    
    public partial class Propriedades : Page
    {
        public Propriedades()
        {
            InitializeComponent();
            foreach (Pushpin pin in ListaPropriedades.pushpins_getList())
            {
                // pushpin
                this.myMap.Children.Add(pin);

                // button
                /*
                Label label = new Label();
                label.Content = "Propriedade " + Convert.ToString(prop.index) + "\nRua: " + prop.rua + "\nFreguesia: " + prop.freguesia + "\nConcelho: " + prop.concelho;
                label.Height = 100;
                label.HorizontalContentAlignment = HorizontalAlignment.Left;
                this.labelContainer.Children.Add(label);
                */

            }
        }
        public Propriedades(object data) : this()
        {
            this.DataContext = data;
        }


        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));
        }

        /* Botão "Adicionar Propriedade" */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

              this.NavigationService.Navigate(new Add_Propriedade());           
        }

        private void Button_anterior(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void StackPanel_GotTouchCapture(object sender, TouchEventArgs e)
        {

        }
        private void Apagar_propriedade(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(this.propriedadesListBox.SelectedItem.ToString());
                DialogResult dialogResult = form1.Show("Confirmar remoção", "Tem a certeza que pretende apagar?", "", "Sim", "Não");
                if (dialogResult == DialogResult.Yes)
                {
                    this.NavigationService.Refresh();
                    Console.WriteLine(this.propriedadesListBox.SelectedItem);
                    String cord_x = Convert.ToString(TypeDescriptor.GetProperties(this.propriedadesListBox.SelectedItem)["cord_x"].GetValue(this.propriedadesListBox.SelectedItem));
                    Console.WriteLine(cord_x);
                    Propriedade toRemove = ListaPropriedades.getLista().Single(r => Convert.ToString(r.cord_x) == cord_x); // && r.contacto == contacto && r.morada == morada && (r.inicio.CompareTo(inicio) == 0) && (r.fim.CompareTo(fim) == 0) && r.descricao == descricao);
                    Pushpin pinToRemove = ListaPropriedades.pushpins_getList().Single(r => Convert.ToString(r.Location.Latitude) == cord_x);
                    this.myMap.Children.Remove(pinToRemove);

                    ListaPropriedades.getLista().Remove(toRemove);
                    System.Windows.MessageBox.Show("Encomenda Apagada. ");
                    this.NavigationService.Refresh();
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Nenhuma encomenda selecionada. ");
                this.NavigationService.Refresh();
            }
        }
    }
    public class Propriedade
    {
        private int _index;
        private string _rua;
        private string _freguesia;
        private string _concelho;
        private double _cord_x;
        private double _cord_y;

        public int index
        {
            get { return _index; }
            set { _index = value;  }
        }
        public string rua
        {
            get { return _rua; }
            set { _rua = value; }
        }
        public string freguesia
        {
            get { return _freguesia; }
            set { _freguesia = value; }
        }
        public string concelho
        {
            get { return _concelho; }
            set { _concelho = value; }
        }
        public double cord_x
        {
            get { return _cord_x; }
            set { _cord_x = value; }
        }
        public double cord_y
        {
            get { return _cord_y; }
            set { _cord_y = value; }
        }


    }

    public class ListaPropriedades : ObservableCollection<Propriedade>
    {
        static int count = 0;
        static ListaPropriedades lista = new ListaPropriedades();
        static List<Pushpin> pushpins = new List<Pushpin>();
        List<Pushpin> pushpins2 = new List<Pushpin>();
        public ListaPropriedades()
        {
            add_Propriedade("Outeiro", "Préstimo", "Águeda", 40.56206879475859, - 8.447628021240234);
            pushpins = pushpins2;
            lista = this;

        }
        public static ListaPropriedades getLista()
        {
            return lista;
        }
        public static List<Pushpin> pushpins_getList()
        {
            return pushpins;
        }
        public void add_Propriedade(string rua, string freguesia, string concelho, double cord_x, double cord_y)
        {           
            this.Add(new Propriedade { index=count, rua=rua, freguesia=freguesia, concelho=concelho, cord_x=cord_x, cord_y=cord_y });

            Pushpin pin = new Pushpin();
            pin.Content = count;
            pin.Location = new Location(cord_x, cord_y);

            this.pushpins2.Add(pin);
            

            count++;
        }
    }
}