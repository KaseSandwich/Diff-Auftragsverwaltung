using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtgVerwaltung.Model
{
    class Kunde
    {
        #region props
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Str { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public int Klassifizirung { get; set; }
        #endregion

        #region constructors 

        public Kunde(string name, string str, string plz, string ort, int klassifizirung)
        {
            Uid = Guid.NewGuid().ToString();
            Name = name;
            Str = str;
            Plz = plz;
            Ort = ort;
            Klassifizirung = klassifizirung;
        }

        public Kunde()
        {
            
        }
        #endregion 
    }
}
