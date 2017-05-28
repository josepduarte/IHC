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
    /// Interaction logic for Stock.xaml
    /// </summary>
    /// 

    public partial class Stock : Page
    {
        public Stock()
        {

            InitializeComponent();
            
            to_save = new ListaMadeiras((ListaMadeiras.getLista().Select(madeira => new Madeira(madeira.tipo, madeira.quantidade)).ToList()));
            foreach (Madeira element in to_save)
            {
                System.Console.WriteLine(element.quantidade);
            }

        }
        ListaMadeiras to_save;

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
                tipo.ToString();
                System.Windows.Controls.Button delete = (System.Windows.Controls.Button)e.OriginalSource;
                DialogResult dialogResult = form1.Show("Confirmar remoção", "Tem a certeza que pretende apagar?", "", "Sim", "Não");
                if (dialogResult == DialogResult.Yes)
                { 

                    Madeira toRemove = ListaMadeiras.getLista().Single(r => r.tipo == tipo); // && r.contacto == contacto && r.morada == morada && (r.inicio.CompareTo(inicio) == 0) && (r.fim.CompareTo(fim) == 0) && r.descricao == descricao);
                    ListaMadeiras.getLista().Remove(toRemove);
                    System.Windows.MessageBox.Show("Tipo de madeira apagado. ");
                    this.NavigationService.Refresh();
                }                
            }
            catch
            {
                System.Windows.MessageBox.Show("Nenhum tipo selecionado. ");
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

       
        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void restaurar_valor(object sender, RoutedEventArgs e)
        {
            stockListBox.ItemsSource = null;
            foreach (Madeira element in ListaMadeiras.getLista())
            {
                if((to_save.ToList().Find(x => x.tipo == element.tipo)) != null){
                    element.quantidade = to_save.ToList().Find(x => x.tipo == element.tipo).quantidade;
                }
            }
            stockListBox.ItemsSource = ListaMadeiras.getLista();

            this.NavigationService.Refresh();
            
        }

        private void guardar(object sender, RoutedEventArgs e)
        {
            foreach (Madeira element in to_save)
            {
                if ((ListaMadeiras.getLista().ToList().Find(x => x.tipo == element.tipo)) != null)
                {
                    element.quantidade = ListaMadeiras.getLista().ToList().Find(x => x.tipo == element.tipo).quantidade;
                }
            }
        }
    }
    public class Madeira
    {
        private string _tipo;
        private string _quantidade;

        public Madeira(string tipo, string quantidade)
        {
            this.tipo = tipo;
            this.quantidade = quantidade;
        }

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
            add_Madeira("Eucalipto", "100");
            add_Madeira("Carvalho", "240");
            add_Madeira("Sobreiro", "70");
            lista = this;

        }
        public ListaMadeiras(IList<Madeira> source) : base(source)
        {
        }
        public static ListaMadeiras getLista()
        {
            return lista;
        }
        public void add_Madeira(string tipo, string quantidade)
        {
            this.Add(new Madeira(tipo,quantidade));

        }
    }
}
