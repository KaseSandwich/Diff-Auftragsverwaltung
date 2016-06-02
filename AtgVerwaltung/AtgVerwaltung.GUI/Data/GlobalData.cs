using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.Lib.ModelWrapper;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.GUI.Data
{
    public static class GlobalData
    {
        static GlobalData()
        {
            Repo = new TempRepoMapper()
            {
                Customers = new List<CustomerWrapper>(),
                Articles = new List<Artikel>()
            };
        }

        public static TempRepoMapper Repo { get; set; }
    }
}
