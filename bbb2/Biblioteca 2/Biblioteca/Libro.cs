using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Libro
    {
            private string titolo, autore, genere, scaffale;
            private int num_pag;
        public Libro(string titolo, string autore, string genere, string scaffale, int num_pag)
        {
            this.titolo = titolo;
            this.autore = autore;
            this.genere = genere;
            this.scaffale = scaffale;
            this.num_pag = num_pag;

        }
        public string Titolo
        {
            get { return titolo; }
            set { titolo = value; }
        }
        public int Num_P
        {
            get { return num_pag; }
            set { num_pag = value; }
        }
        public string Autore
        {
            get { return autore; }
            set { autore = value; }
        }
        public string Scaffale
        {
            get { return scaffale; }
            set { scaffale = value; }
        }
        public string Genere
        {
            get { return genere; }
            set { genere = value; }
        }
    }
}
