using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtgVerwaltung.Model
{
    class Auftrag
    {
        #region props
        public string Uid { get; set; }
        public DateTime AuftragsDatum { get; set; }
        public DateTime LieferDatum { get; set; }
        public int Status { get; set; }
        public string KundenUid { get; set; }
        private readonly IBillingProvider BillingProvider;
        #endregion

        #region constructers
        public Auftrag(IBillingProvider billingProvider, DateTime auftragsDatum , DateTime lieferDatum, int status, string kundenUid)
        {
            Uid = Guid.NewGuid().ToString();
            KundenUid = kundenUid;
            BillingProvider = billingProvider;
            AuftragsDatum = auftragsDatum;
            LieferDatum = lieferDatum;
            Status = status;    
        }

        public Auftrag()
        {
            
        }
        #endregion

        public double GetAuftragRabtt()
        {
            //ToDO
            throw new NotImplementedException();
        }

        public string ErstelleRechnung()
        {
            //ToDO
            throw new NotImplementedException();
        }
    }
}
