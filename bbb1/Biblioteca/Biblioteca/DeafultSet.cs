using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class DeafultSet
    {

        ///Attenzione -- potresti avere un errore dovuto al fatto che Quando si leggono i generi o i libri dal file
        ///viene preso anche il comando esc .


        private List<string> scaffali = new List<string>();
        private List<string> generi = new List<string>();
        public List<string> Generi {
            get { return generi; }
            set { generi = value; }
        }
        public string SGeneri
        {
            set { generi.Add(value); }
        }
        public List<string> Scaffali
        {
            get { return scaffali; }
            set { scaffali = value; }
        }
        public string SScaffali
        {
            set { scaffali.Add(value); }
        }
    }
}
