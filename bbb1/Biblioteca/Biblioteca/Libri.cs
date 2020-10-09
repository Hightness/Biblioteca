using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Libri
    {
        private List<Libro> libri = new List<Libro>();

        public void Popola(string[] testo)
        {
            Libro libroNuovo;

            for (int i = 0; i < testo.Length; i += 5)
            {
                int pagine = 100;
                if (i + 4 > testo.Length - 1)
                {
                    break;
                } //per quando il file è vuoto o l'utente sbaglia la sintassi
                try
                {
                    pagine = Convert.ToInt32(testo[i + 4]);
                }
                catch
                {
                    Console.WriteLine("Errore inserimento numero di pagine .. setto a default 100..");
                }
                libroNuovo = new Libro(testo[i], testo[i + 1], testo[i + 2], testo[i + 3], pagine);
                GetLibri().Add(libroNuovo);
                //due substring per togliere ultimo carattere (che contiene il comando esc , e darebbe errore nel riconoscimento del genere)
            }
        }

        public List<Libro> GetLibri()
        {
            return libri;
        }

        public void SetLibri(List<Libro> value)
        {
            libri = value;
        }
        public void AggiungiLibro(Libro k)
        {
            GetLibri().Add(k);
        }
    }
}
