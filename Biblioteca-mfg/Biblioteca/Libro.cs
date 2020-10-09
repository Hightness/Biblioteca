using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Libro
    {
            public string titolo, autore, genere, scaffale;
            public int num_pag;
            public void Descriz(string t, string a, string g, int np, string s)
            {
                titolo = t;
                scaffale = s;
                autore = a;
                genere = g;
                num_pag = np;
            }
    }
}
