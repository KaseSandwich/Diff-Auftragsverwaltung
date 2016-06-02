using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.GUI.Messages;
using AtgVerwaltung.Lib.ModelWrapper;
using AtgVerwaltung.Model;
using GalaSoft.MvvmLight.Command;

namespace AtgVerwaltung.GUI.ViewModel
{
    public class AuftragViewModel : BaseViewModel
    {
        private AuftragWrapper _auftrag;
        public AuftragWrapper Auftrag
        {
            get { return _auftrag; }
            set { _auftrag = value; RaisePropertyChanged(); }
        }

        private Auftragsposition _selectedPos;
        public Auftragsposition SelectedPos
        {
            get { return _selectedPos; }
            set { _selectedPos = value; RaisePropertyChanged(); }
        }
        
        public AuftragViewModel(AuftragWrapper auftrag)
        {
            _auftrag = auftrag;
        }
    }
}
