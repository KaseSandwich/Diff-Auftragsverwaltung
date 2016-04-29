using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AtgVerwaltung.GUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand LoadedCommand { get; set; }
        public RelayCommand CreateCustomerCommand { get; set; }
        public RelayCommand CreateArticleCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SaveFileCommand { get; set; }
        public RelayCommand ReadFileCommand { get; set; }

        public MainViewModel()
        {
            LoadedCommand = new RelayCommand(LoadedExecute);
            CreateCustomerCommand = new RelayCommand(CreateCustomerExecute);
            CreateArticleCommand = new RelayCommand(CreateArticleExecute);
            CloseCommand = new RelayCommand(CloseExecute);
            SaveFileCommand = new RelayCommand(SaveFileExecute);
            ReadFileCommand = new RelayCommand(ReadFileExecute);
        }

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
            MessageBox.Show("Neuer Artikel");
        }

        private void CreateCustomerExecute()
        {
            MessageBox.Show("Neuer Kunde");
        }

        private async void LoadedExecute()
        {
            IsLoading = true;

            await Task.Delay(1500);

            IsLoading = false;
        }
    }
}