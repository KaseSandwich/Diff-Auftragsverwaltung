using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.Lib
{
    public interface IDataProvider
    {
        List<Kunde> GetKunden();
        List<Artikel> GetArtikle();
        List<Auftrag> GetAuftraege();
        List<Auftragsposition> GetAuftragspositionen();
    }
}