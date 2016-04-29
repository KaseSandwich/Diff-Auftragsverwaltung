using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.Lib
{
    class DataRepository
    {
        #region props
        public List<Kunde> Kunden { get; set; }
        public List<Artikel> Artikel { get; set; }
        public List<Auftrag> Auftaege { get; set; }
        public List<Auftragsposition> Auftragspositionen { get; set; }
        private readonly IDataProvider DataProvider;
        #endregion

        #region constructors

        public DataRepository(IDataProvider dataProvider)
        {
            
        }
        #endregion

        public string ErstelleKunde()
        {
            throw new NotImplementedException();
            //ToDO
        }

        public string ErstelleAuftrag(Kunde kunde)
        {
            throw new NotImplementedException();
            //ToDO
        }

        public string ErstelleAzftragPosition(Auftrag auftrag)
        {
            throw new NotImplementedException();
            //ToDO
        }

        public string ErstelleAkrtikel()
        {
            throw new NotImplementedException();
            //ToDO
        }


    }
}
