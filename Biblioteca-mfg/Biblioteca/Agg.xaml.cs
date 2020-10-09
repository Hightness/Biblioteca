using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Logica di interazione per Agg.xaml
    /// </summary>
    /// 
    public partial class Agg : Window
    {
        private Libri collezione = new Libri(); // lista con tutti i libri
        private DeafultSet strutturaB = new DeafultSet();


        public Agg(Libri C,string s, string g)
        {
            InitializeComponent();
            this.DataContext = this;
            Collezione = C;
            foreach (string gt in strutturaB.Generi())
            {
                GeneriCombo.Items.Add(gt);
            }
            foreach (string st in strutturaB.Scaffali())
            {
                ScaffaliCombo.Items.Add(st);
            }
            GeneriCombo.SelectedItem = g;
            ScaffaliCombo.SelectedItem = s;
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            Libro l4 = new Libro();
            l4.Descriz(Titolo.Text, Autore.Text, GeneriCombo.SelectedItem.ToString(), Convert.ToInt32(Num_P.Text), ScaffaliCombo.SelectedItem.ToString()); // creo il nuovo libro
            Collezione.A().Add(l4);
            MainWindow a = new MainWindow(Collezione); // mostro mainwindow con nuova collezione
            this.Close();
            a.ShowDialog();
        }

        public Libri Collezione
        {
            get { return collezione; }
            set { collezione = value; }
        } // setto e acquisisco collezione di libri (variabile coll)
    }
}
