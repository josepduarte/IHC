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
    /// Interaction logic for Material.xaml
    /// </summary>
    public partial class Material : Page
    {
        public Material()
        {
            InitializeComponent();
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
            ns.Navigate(new Uri("Add_Material.xaml", UriKind.Relative));
        }

        private void Adicionar_material(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Add_Material());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button delete = (System.Windows.Controls.Button)e.OriginalSource;
            DialogResult dialogResult = form1.Show("Confirmar remoção", "Tem a certeza que pretende apagar?", "", "Sim", "Não");
            if (dialogResult == DialogResult.No)
                delete.Command = ApplicationCommands.NotACommand;

        }
    }
    public class Material_class
    {
        private string _tipo;
        private int _quantidade;
        private string _unidade;
        private string _descricao;

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public int quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public string unidade
        {
            get { return _unidade; }
            set { _unidade = value; }
        }
        public string descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    

    }

    public class ListaMateriais : ObservableCollection<Material_class>
    {
        static ListaMateriais lista = new ListaMateriais();
        public ListaMateriais()
        {
            add_Material("Trator", 2, "unidades", "Dois tratores de 2006 de grandes dimensões. ");
            add_Material("Moto-serra", 3, "unidades", "Em boas condições. ");
            add_Material("Gasolina de moto-serra", 25, "litros", "Nos estaleiros de Trás-as-Encostas. ");
            lista = this;

        }
        public static ListaMateriais getLista()
        {
            return lista;
        }
        public void add_Material(string tipo, int quantidade, string unidade, string descricao)
        {
            this.Add(new Material_class { tipo = tipo, unidade = unidade, descricao=descricao, quantidade = quantidade });

        }
    }
}
