using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using AtgVerwaltung.Model;

namespace AtgVerwaltung.Lib
{
    public interface IDataProvider
    {
        void FillRepository(DataRepository repo); 
        void SaveRepository(DataRepository repo);
    }
}