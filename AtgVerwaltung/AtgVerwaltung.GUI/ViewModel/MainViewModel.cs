using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AtgVerwaltung.GUI.Views;
using AtgVerwaltung.Lib;
using AtgVerwaltung.Lib.ModelWrapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AtgVerwaltung.GUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<CustomerWrapper> _kunden;
        public ObservableCollection<CustomerWrapper> Kunden
        {
            get { return _kunden; }
            set { _kunden = value; RaisePropertyChanged();}
        }

        private CustomerWrapper _selectedKunde;
        public CustomerWrapper SelectedKunde
        {
            get { return _selectedKunde; }
            set { _selectedKunde = value; RaisePropertyChanged(); }
        }

        private AuftragWrapper _selectedAuftrag;
        public AuftragWrapper SelectedAuftrag
        {
            get { return _selectedAuftrag; }
            set { _selectedAuftrag = value; RaisePropertyChanged(); }
        }

        #region Commands
        public RelayCommand LoadedCommand { get; set; }
        public RelayCommand CreateCustomerCommand { get; set; }
        public RelayCommand CreateArticleCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SaveFileCommand { get; set; }
        public RelayCommand ReadFileCommand { get; set; }
        public RelayCommand OpenAtgCommand { get; set; }
        #endregion

        public MainViewModel()
        {
            LoadedCommand = new RelayCommand(LoadedExecute);
            CreateCustomerCommand = new RelayCommand(CreateCustomerExecute);
            CreateArticleCommand = new RelayCommand(CreateArticleExecute);
            CloseCommand = new RelayCommand(CloseExecute);
            SaveFileCommand = new RelayCommand(SaveFileExecute);
            ReadFileCommand = new RelayCommand(ReadFileExecute);
            OpenAtgCommand = new RelayCommand(OpenAtgExecute);
        }
        
        #region CommandHandler
        private void ReadFileExecute()
        {
            MessageBox.Show("Lesen");
        }

        private void SaveFileExecute()
        {
            MessageBox.Show("Speichern");
        }

        private void CloseExecute()
        {
            Application.Current.Shutdown(0);
        }

        private void CreateArticleExecute()
        {
            var articleView = new AllArticleView();
            articleView.ShowDialog();
        }

        private void CreateCustomerExecute()
        {
            MessageBox.Show("Neuer Kunde");
        }

        private async void LoadedExecute()
        {
            IsLoading = true;

            await Task.Run(() =>
            {
#if DEBUG
                Kunden = DesignData.DesginDataProvider.GetKunden();
#endif
            });

            IsLoading = false;
        }
        
        private void OpenAtgExecute()
        {
            MessageBox.Show(SelectedAuftrag.Auftrag.Uid);
        }
        #endregion
    }
}