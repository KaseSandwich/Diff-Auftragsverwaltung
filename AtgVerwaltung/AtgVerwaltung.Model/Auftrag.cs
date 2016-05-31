using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtgVerwaltung.Model
{
    [Serializable]
    public class Auftrag
    {
        #region props
        public string Uid { get; set; }
        public DateTime AuftragsDatum { get; set; }
        public DateTime LieferDatum { get; set; }
        public int Status { get; set; }
        public string KundenUid { get; set; }
        public double Rabatt { get; set; }
        private readonly IBillingProvider BillingProvider;
        private readonly IDisountProvider DiscountProvider;
        #endregion

        #region constructers

        public Auftrag(string kundenUid, IBillingProvider billingProvider, IDisountProvider discountProvider)
        {
            Uid = Guid.NewGuid().ToString();
            KundenUid = kundenUid;
            BillingProvider = billingProvider;
            DiscountProvider = discountProvider;
        }

        public Auftrag()
        {
            
        }

        #endregion

        public void GetAuftragRabtt()
        {
            Rabatt = DiscountProvider.GetAtgDiscount(Uid);
        }

        public string ErstelleRechnung()
        {
            return BillingProvider.GetRechnung(Uid);
        }
    }
}
