using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.GUI.Messages;
using AtgVerwaltung.Lib.ModelWrapper;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace AtgVerwaltung.GUI.ViewModel
{
    public class AuftragViewModel : BaseViewModel
    {
        private AuftragWrapper _auftrag;
        public AuftragWrapper Auftrag
        {
            get { return _auftrag; }
            set { _auftrag = value; RaisePropertyChanged();}
        }

        public RelayCommand LoadedCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        public AuftragViewModel(AuftragWrapper auftrag)
        {
            Auftrag = auftrag;
            LoadedCommand = new RelayCommand(LoadedExecute);
            CloseCommand = new RelayCommand(CloseExecute);
        }

        private void CloseExecute()
        {
            Messenger.Default.Send<CloseMessage>(new CloseMessage(this));
        }

        private void LoadedExecute()
        {
            
        }
    }
}
