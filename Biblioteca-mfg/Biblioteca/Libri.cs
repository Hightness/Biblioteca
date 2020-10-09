using System.Collections.Generic;

namespace Biblioteca
{
    public class Libri
    {
        private List<Libro> libri = new List<Libro>();
        public List<Libro> A() { return libri; }
        public void A(Libro k) { libri.Add(k); }
    }
}
