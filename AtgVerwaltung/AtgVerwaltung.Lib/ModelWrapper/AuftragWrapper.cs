using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.Model;
using GalaSoft.MvvmLight;

namespace AtgVerwaltung.Lib.ModelWrapper
{
    public class AuftragWrapper : ObservableObject
    {
        private Auftrag _auftrag;
        public Auftrag Auftrag
        {
            get { return _auftrag; }
            set { _auftrag = value; RaisePropertyChanged();}
        }

        private Kunde _kunde;
        public Kunde Kunde
        {
            get { return _kunde; }
            set { _kunde = value; RaisePropertyChanged();}
        }


        private ObservableCollection<PositionWrapper> _positionen;
        public ObservableCollection<PositionWrapper> Positionen
        {
            get { return _positionen; }
            set { _positionen = value; RaisePropertyChanged(); }
        }

        public AuftragWrapper(Auftrag atg)
        {
            Auftrag = atg;
            Positionen = new ObservableCollection<PositionWrapper>();
        }

        public AuftragWrapper()
        {
            Positionen = new ObservableCollection<PositionWrapper>();
        }
    }
}
