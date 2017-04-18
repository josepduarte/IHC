﻿using System;
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

namespace DETI
{
    /// <summary>
    /// Interaction logic for DETI_Home.xaml
    /// </summary>
    public partial class DETI_Home : Page
    {
        public DETI_Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DETI_Cursos cursosPage = new DETI_Cursos();
            /*
            try {
            */
                String nome = ((ListBoxItem)CursosListBox.SelectedValue).Content.ToString();
                cursosPage.CourseNameLabel.Content = nome;
                this.NavigationService.Navigate(cursosPage);
            /*
            } catch (NullReferenceException e) // try to implement try catch
            {
                MessageBox.Show("Selecione um curso", "Erro", MessageBoxButton.OK);
            }
            */





            }

        private void CursosListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DETI_Cursos cursosPage = new DETI_Cursos();
            String nome = ((ListBoxItem)CursosListBox.SelectedValue).Content.ToString();

            cursosPage.CourseNameLabel.Content = nome;

            this.NavigationService.Navigate(cursosPage);
        }
    }
    public class Curso
    {
        private string _nome;
        private int _CodCurso;
        public int CodCurso
        {
            get { return _CodCurso; }
            set { _CodCurso = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
    }
    public class ListaCursos : ObservableCollection<Curso>
    {
        public ListaCursos()
        {
            Add(new Curso { Nome = "Computadores e Telemática", CodCurso = 8240 });
            Add(new Curso { Nome = "Electrónica e Telecomunicações", CodCurso = 8204 });
            Add(new Curso { Nome = "Engenharia Informática", CodCurso = 8295, });
        }
    }

}
