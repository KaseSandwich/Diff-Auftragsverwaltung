using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.GUI;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.Lib.ModelWrapper
{
    [Serializable]
    public class TempRepoMapper
    {
        public List<CustomerWrapper> Customers { get; set; }
        public List<Artikel> Articles { get; set; }
    }
}
