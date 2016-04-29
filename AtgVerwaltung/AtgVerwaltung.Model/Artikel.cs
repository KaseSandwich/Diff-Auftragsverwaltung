using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtgVerwaltung.Model
{
    class Artikel
    {
        #region props
        public string Uid { get; set; }
        public string Bezeichnung { get; set; }
        public double Preis { get; set; }
        public bool IstLieferbar { get; set; }
        #endregion

        #region constructers
        public Artikel(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
            Uid = Guid.NewGuid().ToString();
        }

        public Artikel()
        {
            
        }
#endregion
    }
}
