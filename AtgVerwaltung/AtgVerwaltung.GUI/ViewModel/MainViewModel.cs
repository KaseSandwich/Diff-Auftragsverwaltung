using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AtgVerwaltung.GUI.Data;
using AtgVerwaltung.GUI.DesignData;
using AtgVerwaltung.GUI.Views;
using AtgVerwaltung.Lib;
using AtgVerwaltung.Lib.ModelWrapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;

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

            Kunden = new ObservableCollection<CustomerWrapper>();
        }
        
        #region CommandHandler
        private void ReadFileExecute()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Json Dateien(*.json) | *.json"
            };

            string json = "";
            if (!dlg.ShowDialog().Value)
            {
                MessageBox.Show("Üngltige Datei ausgewählt!");
                return;
            }

            json = File.ReadAllText(dlg.FileName);

            try
            {
                GlobalData.Repo = JsonConvert.DeserializeObject<TempRepoMapper>(json);
                Kunden?.Clear();
                GlobalData.Repo.Customers.ForEach(c => Kunden.Add(c));
            }
            catch (Exception e)
            {
                MessageBox.Show("Fehler beim Lesen der Json Datei!");
            }

        }

        private void SaveFileExecute()
        {
            var json = JsonConvert.SerializeObject(GlobalData.Repo);

            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "Json Dateien(*.json) | *.json"
            };

            if(dlg.ShowDialog().Value)
                File.WriteAllText(dlg.FileName, json);
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
            var customerView = new AllCustomersView();
            customerView.ShowDialog();
        }

        private async void LoadedExecute()
        {
            IsLoading = true;

            IsLoading = false;
        }
        
        private void OpenAtgExecute()
        {
            if (SelectedAuftrag == null)
                return;
            
            var vm = new AuftragViewModel(SelectedAuftrag);
            var win = new AtgWindow(vm);
            win.ShowDialog();
        }
        #endregion
    }
}