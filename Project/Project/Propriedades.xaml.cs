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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for Propriedades.xaml
    /// </summary>
    public partial class Propriedades : Page
    {
        public Propriedades()
        {
            InitializeComponent();
            foreach (Propriedade prop in ListaPropriedades.getLista())
            {
                // pushpin
                Pushpin pin = new Pushpin();
                pin.Content = prop.index;
                pin.Location = new Location(prop.cord_x, prop.cord_y);
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
                this.NavigationService.Refresh();
                Console.WriteLine(this.propriedadesListBox.SelectedItem);
                String cord_x = Convert.ToString(TypeDescriptor.GetProperties(this.propriedadesListBox.SelectedItem)["cord_x"].GetValue(this.propriedadesListBox.SelectedItem));
                Console.WriteLine(cord_x);
                Propriedade toRemove = ListaPropriedades.getLista().Single(r => Convert.ToString(r.cord_x) == cord_x); // && r.contacto == contacto && r.morada == morada && (r.inicio.CompareTo(inicio) == 0) && (r.fim.CompareTo(fim) == 0) && r.descricao == descricao);
                Console.WriteLine(toRemove);
                ListaPropriedades.getLista().Remove(toRemove);
                MessageBox.Show("Encomenda Apagada. ");
                this.NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("Nenhuma encomenda selecionada. ");
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
        public ListaPropriedades()
        {
            add_Propriedade("Outeiro", "Préstimo", "Águeda", 40.56206879475859, - 8.447628021240234);
            
            lista = this;

        }
        public static ListaPropriedades getLista()
        {
            return lista;
        }
        public void add_Propriedade(string rua, string freguesia, string concelho, double cord_x, double cord_y)
        {           
            this.Add(new Propriedade { index=count, rua=rua, freguesia=freguesia, concelho=concelho, cord_x=cord_x, cord_y=cord_y });
            count++;
        }
    }
}