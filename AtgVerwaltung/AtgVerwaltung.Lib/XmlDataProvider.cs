using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AtgVerwaltung.GUI;
using AtgVerwaltung.Lib.ModelWrapper;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.Lib
{
    [Serializable]
    public class XmlDataProvider : IDataProvider
    {
        private readonly string FilePath;

        public XmlDataProvider(string filePath)
        {
            FilePath = filePath;
        }

        public void FillRepository(DataRepository repo)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataRepository));
            using (var stream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                repo = (DataRepository)ser.Deserialize(stream);
            }
        }

        public void SaveRepository(DataRepository repo)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataRepository));
            using (var stream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                ser.Serialize(stream, repo);
            }
        }

        public void GenTestData()
        {
            var kunde1 = new Kunde()
            {
                Klassifizirung = 1,
                Name = "TestKunde1",
                Ort = "Darmstadt",
                Plz = "64283",
                Str = "Stauffenbergstraße 56"
            };

            var kunde2 = new Kunde()
            {
                Klassifizirung = 0,
                Name = "TestKunde2",
                Ort = "Taunusstein",
                Plz = "65232",
                Str = "Bleidenstädterstraße 5"
            };

            var kunde3 = new Kunde()
            {
                Klassifizirung = 2,
                Name = "TestKunde3",
                Ort = "Darmstadt",
                Plz = "64293",
                Str = "Otto-Röhm-Straße 69"
            };

            var artikel1 = new Artikel()
            {
                Bezeichnung = "TestArtikel1",
                IstLieferbar = true,
                Preis = 5.50
            };

            var artikel2 = new Artikel()
            {
                Bezeichnung = "TestArtikel2",
                IstLieferbar = false,
                Preis = 12.67
            };

            var atg1Kd1 = new Auftrag(kunde1.Uid, new TestBillingProvider(), new TestDiscountProvider())
            {
                AuftragsDatum = new DateTime(2016, 1, 1),
                LieferDatum = new DateTime(2016, 05, 01),
                Status = 2
            };

            var pos1atg1 = new Auftragsposition(atg1Kd1.Uid, new TestDiscountProvider())
            {
                ArtikelUid = artikel1.Uid,
                Bestellmenge = 5,
                Liefermenge = 5
            };

            var pos2atg1 = new Auftragsposition(atg1Kd1.Uid, new TestDiscountProvider())
            {
                ArtikelUid = artikel2.Uid,
                Bestellmenge = 41,
                Liefermenge = 20
            };

            var ser = new XmlDataProvider(Environment.CurrentDirectory + "\\Test.xml");
            var repo = new DataRepository(this)
            {
                Artikel = new List<Artikel>() {artikel1, artikel2},
                Kunden = new List<Kunde>() {kunde1, kunde2, kunde3},
                Auftaege = new List<Auftrag>() {atg1Kd1},
                Auftragspositionen = new List<Auftragsposition>() {pos2atg1, pos1atg1}
            };

            ser.SaveRepository(repo);
        }
    }

    public class TestDiscountProvider : IDisountProvider
    {
        public double GetPositionDiscount(string artikelUid, int menge)
        {
            return 0;
        }

        public double GetAtgDiscount(string auftragUid)
        {
            return 0;
        }
    }

    public class TestBillingProvider : IBillingProvider
    {
        public string GetRechnung(string auftragUid)
        {
            return $"TestRechnung für {auftragUid}";
        }
    }
}
