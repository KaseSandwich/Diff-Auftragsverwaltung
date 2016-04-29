using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtgVerwaltung.Model
{
    public class Auftragsposition
    {
        #region props

        public string Uid { get; set; }
        public string AuftragsUid { get; set; }
        public string ArtikelUid { get; set; }
        public int Bestellmenge { get; set; }
        public int Liefermenge { get; set; }
        public double Rabatt { get; set; }
        private readonly IDisountProvider DiscountProvider; 

        #endregion

        #region constructors

        public Auftragsposition(string auftragUid, IDisountProvider disountProvider)
        {
            Uid = Guid.NewGuid().ToString();
            AuftragsUid = auftragUid;
            DiscountProvider = disountProvider;
        }
        
        #endregion

        public void GetPositionRabatt()
        {
            Rabatt = DiscountProvider.GetPositionDiscount(Uid, Bestellmenge);
        }
    }
}
