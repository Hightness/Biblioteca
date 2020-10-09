using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace Biblioteca
{
    public partial class MainWindow : Window
    {
            
        private Libri collezione = new Libri(); // lista con tutti i libri
        private string scaffale=null, genere=null;
        private Libro libroSelezionato = null;
        private DeafultSet strutturaB = new DeafultSet();


        public MainWindow()
        {
            
            InitializeComponent();
            #region Leggo e scrivo libri , generi e scaffali dai file in biblioteca/bin/debug
            string[] tuttilibri= {""};
            string controllo = File.ReadAllText("Libri.txt");

            if ( controllo.Trim(' ','-','\n','\r')== null)File.AppendAllText("Libri.txt", "-");
                
            using (StreamReader sr = new StreamReader("Libri.txt")) 
            {
              tuttilibri = sr.ReadLine().Split('-', '\n', '\r');
              //Leggo dividendo ogni linea e rimuovendo i caratteri esc
            }
            Collezione.Popola(tuttilibri);

            string[] tuttigeneri;
            using (StreamReader sr = new StreamReader("Generi.txt")) 
            {
                tuttigeneri = sr.ReadToEnd().Split('-', '\n', '\r');

            }
            strutturaB.Generi = tuttigeneri.ToList();

            string[] tuttiscaffali;
            using (StreamReader sr = new StreamReader("Scaffali.txt")) 
            {
                tuttiscaffali = sr.ReadToEnd().Split('-', '\n', '\r');

            }
            strutturaB.Scaffali = tuttiscaffali.ToList();
            #endregion
            Deff(); // inizializzio  con generi e scaffali di default
            Visualizza();//popolo i vari scaffali con i libri presenti in collezione

        }
        /// <summary>
        /// gestione dell espansione e chiusura del TreeViewElement scaffale
        /// </summary>
        /// <param name="sender">scaffale aperto</param>
        /// <param name="e"></param>
        private void Scaffale_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem scaffaleAperto = (TreeViewItem)sender;
            SetScaffale = scaffaleAperto.Header.ToString();
            Info.ItemsSource = scaffaleAperto.Items; // nel binding richiamo Tag.Titolo ... (nel tag c'è il Libro)
        }
        private void Scaffale_Collapsed(object sender, RoutedEventArgs e)
        {
            SetScaffale = null;
            Info.ItemsSource = null;
        }



        /// <summary>
        /// gestione dell espansione e chiusura del TreeViewElement genere
        /// </summary>
        /// <param name="sender">genere aperto</param>
        /// <param name="e"></param>
        private void Genere_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem genereAperto = (TreeViewItem)sender;
            SetGenere = genereAperto.Header.ToString();
        }
        private void Genere_Collapsed(object sender, RoutedEventArgs e)
        {
            SetGenere = null;
            SetScaffale = null;
        }




        /// <summary>
        /// aggiunta informazioni libro selezionato alla grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitoloLibro_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem selectedElement = (TreeViewItem)sender;
            Libro selectedBook = (Libro)selectedElement.Tag;
            LibroSelezionato = selectedBook;
            btnElimina.IsEnabled = true;
            btnModifica.IsEnabled = true;

        }
        private void TestoCambiato(object sender, TextChangedEventArgs e)
        {
            Scaffali.IsEnabled = strutturaSelezionata.Text.Trim(' ') != "" && StrutturaB.Scaffali.IndexOf(strutturaSelezionata.Text) == -1;
            Generi.IsEnabled = strutturaSelezionata.Text.Trim(' ') != "" && StrutturaB.Generi.IndexOf(strutturaSelezionata.Text) == -1;
        }// testo per aggiungere scaffale o genere inserito (attivo i bottoni)


        private void Deff()
        {//inizializza  con generi e scaffali di default

            TreeViewItem sss, ggg,bbb;
            
            bbb = new TreeViewItem();
            bbb.Header = "Biblioteca";
            for (int i = 0; i < StrutturaB.Generi.Count(); i++)
            {
                ggg = new TreeViewItem();
                ggg.Collapsed += Genere_Collapsed;
                ggg.Expanded += Genere_Expanded;
                ggg.Header = StrutturaB.Generi[i];
                for (int j = 0; j < StrutturaB.Scaffali.Count(); j++)
                {
                    sss = new TreeViewItem();
                    sss.Header = StrutturaB.Scaffali[j];
                    sss.Collapsed += Scaffale_Collapsed;
                    sss.Expanded += Scaffale_Expanded;
                    sss.Selected += Scaffale_Expanded;
                    ggg.Items.Add(sss);
                }
                bbb.Items.Add(ggg);
            }
            ContenitoreGeneri.Items.Add(bbb);
        } //inizializzazione form con generi e scaffali di default
        private void Visualizza()
        {
            TreeViewItem Biblio = new TreeViewItem();
            Biblio = (TreeViewItem)ContenitoreGeneri.Items[0];
            TreeViewItem TitoloLibro;
            foreach (Libro libro in Collezione.GetLibri())
            {
                int i = StrutturaB.Generi.IndexOf(libro.Genere);
                if (i == -1) { MessageBox.Show("Il genere '" + libro.Genere + "' non esiste nella collezione generi"); }
                else 
                { 
                    TreeViewItem percGenere = (TreeViewItem)Biblio.Items[i];
                    i = StrutturaB.Scaffali.IndexOf(libro.Scaffale);
                    if (i == -1) { MessageBox.Show("Lo scaffale '" + libro.Scaffale + "' non esiste nella collezione scaffali"); }
                    else
                    {
                        TreeViewItem percScaffale = (TreeViewItem)percGenere.Items[i];
                        TitoloLibro = new TreeViewItem();
                        TitoloLibro.Header = libro.Titolo;
                        TitoloLibro.Tag = libro;
                        TitoloLibro.Selected += TitoloLibro_Selected;
                        percScaffale.Items.Add(TitoloLibro);
                    }
                }
            }
        }
        private void Ricarica()
        {
            MainWindow attuale = new MainWindow();
            this.Close();
            attuale.ShowDialog();
        }


        /// <summary>
        /// set e get per tute le variabili globali private
        /// </summary>
        /// 
        public Libro LibroSelezionato
        {
            get { return libroSelezionato; }
            set { libroSelezionato = value; }
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
        public string SetGenere
        {
            get { return genere; }
            set { genere = value; }
        }// setto e acquisisco genere (variabile genere)
        public string SetScaffale
        {
            get { return scaffale; }
            set { scaffale = value; }
        }// setto e acquisisco scaffale (variabile scaffale)
    }
}
