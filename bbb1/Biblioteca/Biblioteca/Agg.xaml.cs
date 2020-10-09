using System;
using System.IO;
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
        private int indiceLibroDaModificare;
        private Libri collezione = new Libri(); // lista con tutti i libri
        private DeafultSet strutturaB = new DeafultSet();

        public Agg(int i,Libri C,string s, string g, DeafultSet struttura)// passo struttura di generi e scaffali con struttura
        {
            InitializeComponent();
            this.DataContext = this;
            Collezione = C;
            StrutturaB = struttura;
            IndiceLibroDaModificare = i;
            if (i > -1 )
            {
                ModificaLibro();
            }
            foreach (string gt in StrutturaB.Generi)
            {
                GeneriCombo.Items.Add(gt);
            }
            foreach (string st in StrutturaB.Scaffali)
            {
                ScaffaliCombo.Items.Add(st);
            }
            GeneriCombo.SelectedItem = g;
            ScaffaliCombo.SelectedItem = s;
        }

        public void ModificaLibro()
        {
            List<Libro> libri = Collezione.GetLibri();
            Titolo.Text =   libri[IndiceLibroDaModificare].Titolo;
            Num_P.Text =    libri[IndiceLibroDaModificare].Num_P.ToString();
            Autore.Text =   libri[IndiceLibroDaModificare].Autore;
            Bottone.Content = "Modifica";
            
        }

        public DeafultSet StrutturaB
        {
            get { return strutturaB; }
            set { strutturaB = value; }
        } // setto e acquisisco collezione di libri (variabile coll)
        public Libri Collezione
        {
            get { return collezione; }
            set { collezione = value; }
        } // setto e acquisisco collezione di libri (variabile coll)
        public int IndiceLibroDaModificare
        {
            get { return indiceLibroDaModificare; }
            set { indiceLibroDaModificare = value; }
        } // setto e acquisisco indice libro selezionato (variabile indiceLibroSelezionato)
    }
}
