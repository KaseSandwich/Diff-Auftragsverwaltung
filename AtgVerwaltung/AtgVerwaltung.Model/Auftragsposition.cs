using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtgVerwaltung.Model
{
    class Auftragsposition
    {
        #region props

        public string Uid { get; set; }
        public string AuftragsUid { get; set; }
        public int Bestellmenge { get; set; }
        public int Liefermenge { get; set; }
        public double Rabatt { get; set; }
        private readonly IDisountProvider DiscountProvider; 

        #endregion

        #region constructors

        public Auftragsposition(IDisountProvider disountProvider  ,int bestellMenge, int lieferMenge, double rabatt)
        {
            Uid = Guid.NewGuid().ToString();
            AuftragsUid = Guid.NewGuid().ToString();
            DiscountProvider = disountProvider;
            Bestellmenge = bestellMenge;
            Liefermenge = lieferMenge;
            Rabatt = rabatt;
        }


        public Auftragsposition()
        {
            
        }

        #endregion

        public double GetPositionRabatt()
        {
            return Rabatt;
            //ToDo mit Marco besprechen was es tut. 
        }

    }
}
