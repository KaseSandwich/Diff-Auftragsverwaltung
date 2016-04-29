namespace AtgVerwaltung.Model
{
    public interface IBillingProvider
    {
        string GetRechnung(string auftragUid);
    }
}