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
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    /// 


    public partial class App : Application
    {
        private Libri collezione = new Libri(); // lista con tutti i libri
        private DeafultSet strutturaB = new DeafultSet();
        MainWindow principale = new MainWindow();
        Agg aggiungi;
        public App()
        {
            principale.Show();
            this.Collezione = principale.Collezione;
            this.StrutturaB = principale.StrutturaB;
            principale.btnAggiungi.Click += BtnAggiungi_Click;
            principale.btnModifica.Click += BtnAggiungi_Click;

            principale.btnElimina.Click += BtnElimina_Click;
            principale.Generi.Click += BtnGenere_Click;
            principale.Scaffali.Click += BtnGenere_Click;

        }



        /// <summary>
        /// Apertura e gestione della finestra Agg.xaml 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnElimina_Click(object sender, RoutedEventArgs e)
        {
            this.Collezione.GetLibri().Remove(principale.LibroSelezionato);
            MessageBox.Show("eliminato");
            #region aggiorno file libri.txt con nuova collezione
            File.WriteAllText("Libri.txt", string.Empty);
            foreach (Libro libro in this.Collezione.GetLibri())
            {
                File.AppendAllText("Libri.txt", libro.Titolo + '-' + libro.Autore + '-' + libro.Genere + '-' + libro.Scaffale + '-' + libro.Num_P.ToString() + '-');
            }
            #endregion
            NuovaFinestra();//ricarica nuova finestra principale aggiungendo tutti gli eventi
            
        }
        private void BtnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            aggiungi = new Agg(principale.Collezione.GetLibri().IndexOf(principale.LibroSelezionato), Collezione, principale.SetScaffale, principale.SetGenere, StrutturaB);
            aggiungi.Show();
            aggiungi.Bottone.Click += Button_Click;
        }
        private void BtnGenere_Click(object sender, RoutedEventArgs e)
        {
            this.StrutturaB.SGeneri = principale.strutturaSelezionata.Text;
            File.AppendAllText(((Button)sender).Name + ".txt", '-' + principale.strutturaSelezionata.Text);
            NuovaFinestra();//ricarica nuova finestra principale aggiungendo tutti gli eventi
        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((aggiungi.GeneriCombo.SelectedItem == null) || (aggiungi.ScaffaliCombo.SelectedItem == null) || (aggiungi.Titolo.Text == null) || (aggiungi.Autore.Text == null))
            {
                MessageBox.Show("Assicurati di aver riempito tutti i campi..");
            }
            else
            {
                try
                {
                    Convert.ToInt32(aggiungi.Num_P.Text);
                    Libro l4 = new Libro(aggiungi.Titolo.Text, aggiungi.Autore.Text, aggiungi.GeneriCombo.SelectedItem.ToString(), aggiungi.ScaffaliCombo.SelectedItem.ToString(), Convert.ToInt32(aggiungi.Num_P.Text));
                    if (aggiungi.IndiceLibroDaModificare > -1)
                    {
                        Collezione.GetLibri()[aggiungi.IndiceLibroDaModificare] = l4;
                    }
                    else
                    {
                        Collezione.AggiungiLibro(l4);
                    }
                    #region aggiorno file in biblioteca/bin/debug con nuova collezione
                    File.WriteAllText("Libri.txt", string.Empty);
                    foreach (Libro libro in Collezione.GetLibri())
                    {
                        File.AppendAllText("Libri.txt", libro.Titolo + '-' + libro.Autore + '-' + libro.Genere + '-' + libro.Scaffale + '-' + libro.Num_P.ToString() + '-');
                    }
                    #endregion
                    aggiungi.Close();
                    NuovaFinestra();//ricarica nuova finestra principale aggiungendo tutti gli eventi
                    
                }
                catch
                {
                    MessageBox.Show("Inserire un numero di pagine Valido");
                }
            }

        }
        public void NuovaFinestra()
        {
            
            MainWindow a = new MainWindow();
            a.Show();
            a.btnAggiungi.Click += BtnAggiungi_Click;
            a.btnModifica.Click += BtnAggiungi_Click;

            a.btnElimina.Click += BtnElimina_Click;
            a.Generi.Click += BtnGenere_Click;
            a.Scaffali.Click += BtnGenere_Click;
            principale.Close();
            principale = a;

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

    }
}
