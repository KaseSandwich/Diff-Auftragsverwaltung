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
        private bool _isOpen;

        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; RaisePropertyChanged(); }
        }
        
        private Auftrag _auftrag;
        public Auftrag Auftrag
        {
            get { return _auftrag; }
            set { _auftrag = value; RaisePropertyChanged();}
        }

        private ObservableCollection<Auftragsposition> _positionen;
        public ObservableCollection<Auftragsposition> Positionen
        {
            get { return _positionen; }
            set { _positionen = value; RaisePropertyChanged(); }
        }

        public AuftragWrapper(Auftrag atg)
        {
            Auftrag = atg;
            Positionen = new ObservableCollection<Auftragsposition>();
        }

        public AuftragWrapper()
        {
            Positionen = new ObservableCollection<Auftragsposition>();
        }
    }
}
