using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.GUI.Data;
using AtgVerwaltung.GUI.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace AtgVerwaltung.GUI.ViewModel
{
    public class AllCustomersViewModel : BaseViewModel
    {
        private ObservableCollection<CustomerWrapper> _customers;
        public ObservableCollection<CustomerWrapper> Customers
        {
            get { return _customers; }
            set { _customers = value; RaisePropertyChanged();}
        }

        private CustomerWrapper _currentCustomer;
        public CustomerWrapper CurrentCustomer
        {
            get { return _currentCustomer; }
            set { _currentCustomer = value; RaisePropertyChanged();}
        }
        
        public RelayCommand LoadedCommand { get; set; }
        public RelayCommand<object> SelectionChangedCommand { get; set; }
        public RelayCommand AddCustomerCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        public AllCustomersViewModel()
        {
            LoadedCommand = new RelayCommand(LoadExecute);
            SelectionChangedCommand = new RelayCommand<object>(SelectionChangedExecute);
            AddCustomerCommand = new RelayCommand(AddCustomerExecute);
            CloseCommand = new RelayCommand(CloseExecute);
        }

        private void CloseExecute()
        {
            Messenger.Default.Send<CloseMessage>(new CloseMessage(this));   
        }

        private void AddCustomerExecute()
        {
            Customers.Add(new CustomerWrapper());
        }

        private void SelectionChangedExecute(object obj)
        {
            var cst = (CustomerWrapper) obj;
            if (cst == null)
                return;

            CurrentCustomer = cst;
        }

        private async void LoadExecute()
        {
            await Task.Run(() =>
            {
                Customers = new ObservableCollection<CustomerWrapper>();
                GlobalData.Repo.Customers.ForEach(c => Customers.Add(c));
            });
        }
    }
}
