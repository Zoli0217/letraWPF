using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfAppLetra.Models
{
    public class Jatekos
    {
        string nev;
        SolidColorBrush szin;
        List<int> lepesek;

        public Jatekos(string nev, SolidColorBrush szin)
        {
            this.nev = nev;
            this.szin = szin;
            lepesek = new List<int>();
        }
        public Jatekos(string nev, SolidColorBrush szin, List<int> eddigiLepesek)
        {
            this.nev = nev;
            this.szin = szin;
            lepesek = eddigiLepesek;
        }

        public string Nev { get => nev; }
        public SolidColorBrush Szin { get => szin; }
        public List<int> Lepesek { get => lepesek; }

        public int Pozicio
        {
            get
            {
                if (lepesek.Count == 0) return 0;
                return lepesek[lepesek.Count - 1];
            }
        }

        public void Lep(int ujmezo)
        {
            lepesek.Add(ujmezo);
        }

        public void Ujrakzedes()
        {
            lepesek.Clear();
        }
    }
}
