namespace AtgVerwaltung.Model
{
    public interface IDisountProvider
    {
        double GetPositionDiscount(string artikelUid, int menge);
        double GetAtgDiscount(string auftragUid);
    }
}