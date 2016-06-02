using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.Lib
{
    [Serializable]
    public class DataRepository
    {
        #region props
        public List<Kunde> Kunden { get; set; }
        public List<Artikel> Artikel { get; set; }
        public List<Auftrag> Auftaege { get; set; }
        public List<Auftragsposition> Auftragspositionen { get; set; }
        private readonly IDataProvider DataProvider;
        #endregion

        #region constructors
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">is the place were data are Stored for example in a Json file "C://josonTest.joson" or a connection strin
        /// for a DataBase.</param>
        public DataRepository(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        public void Init()
        {
            DataProvider.FillRepository(this);
        }

        public DataRepository()
        {
        }
        #endregion


        /*

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">is the place were data are Stored for example in a Json file "C://josonTest.joson" or a connection strin
        /// for a DataBase.</param>
        public void ErstelleKunde(string connection)
        {
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">is the place were data are Stored for example in a Json file "C://josonTest.joson" or a connection strin
        /// for a DataBase.</param>
        public void ErstelleAuftrag(string connection)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">is the place were data are Stored for example in a Json file "C://josonTest.joson" or a connection strin
        /// for a DataBase.</param>
        public void ErstelleAzftragPosition(string connection)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">is the place were data are Stored for example in a Json file "C://josonTest.joson" or a connection strin
        /// for a DataBase.</param>
        public void ErstelleAkrtikel(string connection)
        {
        }

        */
    }
}
