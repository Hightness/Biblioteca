using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class DeafultSet
    {
        private static string[] generi = new string[] { "Drammatico", "Comico", "Letteratura", "Arte", "Hobby", "Attualità" };
        private static string[] scaffali = new string[] { "Scaffale1", "Scaffale2", "Scaffale3", "Scaffale4" };
        public string[] Generi() { return generi; }
        public string[] Scaffali() { return scaffali; }

        public void LibriDeafult(Libri Collezione)
        {
            Libro def = new Libro();
            def.Descriz("Default", "Arron Koyle", "Drammatico", 333, "Scaffale2");
            Collezione.A().Add(def);
            def = new Libro();
            def.Descriz("Default", "Arron Koyle", "Letteratura", 333, "Scaffale1");
            Collezione.A().Add(def);
            def = new Libro();
            def.Descriz("Gazzella", "Arron Koyle", "Comico", 333, "Scaffale3");
            Collezione.A().Add(def);
            def = new Libro();
            def.Descriz("Gazzella", "Arron Koyle", "Comico", 333, "Scaffale2");
            Collezione.A().Add(def);
            def = new Libro();
            def.Descriz("Gazzella", "Arron Koyle", "Arte", 333, "Scaffale2");
            Collezione.A().Add(def);
        }//inizializzazione collezione con libri default
    }
}
