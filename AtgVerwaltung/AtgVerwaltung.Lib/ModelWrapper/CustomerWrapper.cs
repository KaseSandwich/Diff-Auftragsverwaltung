using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.Model;
using GalaSoft.MvvmLight;

namespace AtgVerwaltung.GUI
{
    public class CustomerWrapper : ObservableObject
    {
        private Kunde _kunde;
        public Kunde Kunde
        {
            get { return _kunde; }
            set { _kunde = value; RaisePropertyChanged();}
        }

        private ObservableCollection<Auftrag> _auftraege;
        public ObservableCollection<Auftrag> Auftraege
        {
            get { return _auftraege; }
            set { _auftraege = value; RaisePropertyChanged(); }
        }


    }
}
