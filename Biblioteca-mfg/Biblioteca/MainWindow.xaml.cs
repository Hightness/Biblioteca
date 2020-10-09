using System;
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

namespace Biblioteca
{


    public partial class MainWindow : Window
    {
        private Libri collezione = new Libri(); // lista con tutti i libri
        private string scaffale=null, genere=null;
        private DeafultSet strutturaB = new DeafultSet();
        public MainWindow()
        {
            InitializeComponent();
            Deff(); // inizializzio  con generi e scaffali di default
            strutturaB.LibriDeafult(Collezione);//inizializzo con libri  di default la lista collezione
            Visualizza();//popolo i vari scaffali con i libri presenti in collezione

        }
        public MainWindow(Libri l)
        {
            InitializeComponent();
            Collezione = l ;//aggiorno collezione con nuovo libro
            Deff(); // inizializzo  con generi e scaffali di default
            Visualizza();//popolo i vari scaffali con i libri presenti in collezione

        }



        /// <summary>
        /// gestione dell espansione e chiusura del TreeViewElement scaffale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scaffale_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem scaffaleAperto = (TreeViewItem)sender;
            SetScaffale = scaffaleAperto.Header.ToString();
        }
        private void Scaffale_Collapsed(object sender, RoutedEventArgs e)
        {
            TreeViewItem scaffaleChiuso = (TreeViewItem)sender;
            SetScaffale = null;
        }



        /// <summary>
        /// gestione dell espansione e chiusura del TreeViewElement genere
        /// </summary>
        /// <param name="sender"></param>
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
        /// Apertura e gestione della finestra Agg.xaml 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Agg x = new Agg(Collezione ,SetScaffale, SetGenere);
            this.Close();
            x.ShowDialog();
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
            tit.Content = selectedBook.titolo;
            autor.Content = selectedBook.autore;
            npag.Content = selectedBook.num_pag.ToString();

        }
        
        private void Deff()
        {//inizializza  con generi e scaffali di default
            TreeViewItem sss, ggg,bbb;
            
            bbb = new TreeViewItem();
            bbb.Header = "Biblioteca";
            for (int i = 0; i < strutturaB.Generi().Count(); i++)
            {
                ggg = new TreeViewItem();
                ggg.Header = strutturaB.Generi()[i];
                for (int j = 0; j < strutturaB.Scaffali().Count(); j++)
                {
                    sss = new TreeViewItem();
                    sss.Header = strutturaB.Scaffali()[j];
                    sss.Collapsed += Scaffale_Collapsed;
                    sss.Expanded += Scaffale_Expanded;
                    ggg.Items.Add(sss);
                }
                ggg.Collapsed += Genere_Collapsed;
                ggg.Expanded += Genere_Expanded;

                bbb.Items.Add(ggg);
                
            }
            ContenitoreGeneri.Items.Add(bbb);
        } //inizializzazione form con generi e scaffali di default

        private void Visualizza()
        {
            TreeViewItem Biblio = new TreeViewItem();
            Biblio = (TreeViewItem)ContenitoreGeneri.Items[0];
            TreeViewItem TitoloLibro;
            foreach (Libro libro in Collezione.A())
            {
                int i = Array.IndexOf(strutturaB.Generi(), libro.genere);
                TreeViewItem percGenere = (TreeViewItem)Biblio.Items[i];
                i = Array.IndexOf(strutturaB.Scaffali(), libro.scaffale);
                TreeViewItem percScaffale = (TreeViewItem)percGenere.Items[i];

                TitoloLibro = new TreeViewItem();
                TitoloLibro.Header = libro.titolo;
                TitoloLibro.Tag = libro;
                TitoloLibro.Selected += TitoloLibro_Selected;

                percScaffale.Items.Add(TitoloLibro);
            }
        }



        /// <summary>
        /// set e get per tute le variabili globali private
        /// </summary>
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
