using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.Lib.ModelWrapper;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.GUI.DesignData
{
    public static class DesginDataProvider
    {
        public static ObservableCollection<CustomerWrapper> GetKunden()
        {
            var kuden = new ObservableCollection<CustomerWrapper>();

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

            var pos1Wrapper = new PositionWrapper()
            {
                Position = pos1atg1,
                Artikel = artikel1
            };

            var pos2Wrapper = new PositionWrapper()
            {
                Position = pos2atg1,
                Artikel = artikel2
            };

            var atgWrapper = new AuftragWrapper()
            {
                Auftrag = atg1Kd1,
                Positionen = new ObservableCollection<PositionWrapper>() {pos1Wrapper, pos2Wrapper},
                Kunde = kunde1
            };

            var kd1Wrapper = new CustomerWrapper()
            {
                Kunde = kunde1,
                Auftraege = new ObservableCollection<AuftragWrapper>() {atgWrapper}
            };

            var kd2Wrapper = new CustomerWrapper()
            {
                Kunde = kunde2
            };

            var kd3Wrapper = new CustomerWrapper()
            {
                Kunde = kunde3
            };

            return new ObservableCollection<CustomerWrapper>()
            {
                kd1Wrapper,
                kd2Wrapper,
                kd3Wrapper
            };
        }

        public static List<Artikel> GetArtikel()
        {
            return new List<Artikel>()
            {
                new Artikel()
                {
                    Bezeichnung = "TestArtikel1",
                    IstLieferbar = true,
                    Preis = 5.50
                },
                new Artikel()
                {
                    Bezeichnung = "TestArtikel2",
                    IstLieferbar = false,
                    Preis = 12.67
                }
            };
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
