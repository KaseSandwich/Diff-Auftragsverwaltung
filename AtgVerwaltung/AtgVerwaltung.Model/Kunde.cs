using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtgVerwaltung.Model
{
    public class Kunde
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

        public Kunde()
        {
            Uid = Guid.NewGuid().ToString();
        }

        #endregion 
    }
}
