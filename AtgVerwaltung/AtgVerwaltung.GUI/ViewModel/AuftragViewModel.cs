using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

        private PositionWrapper _currentPosition;
        public PositionWrapper CurrentPosition
        {
            get { return _currentPosition; }
            set { _currentPosition = value; RaisePropertyChanged(); }
        }

        public RelayCommand LoadedCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand CalculateCommand { get; set; }
        public RelayCommand<DataGrid> CellEditedCommand { get; set; }

        public AuftragViewModel(AuftragWrapper auftrag)
        {
            Auftrag = auftrag;
            LoadedCommand = new RelayCommand(LoadedExecute);
            CloseCommand = new RelayCommand(CloseExecute);
            CalculateCommand = new RelayCommand(CalculateExecute);
        }
        
        public void CalculateExecute()
        {
            Auftrag.RefreshNetto();
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
