using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.GUI.Messages;
using AtgVerwaltung.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace AtgVerwaltung.GUI.ViewModel
{
    public class AllArticlesViewModel : BaseViewModel
    {
        private ObservableCollection<Artikel> _artikel;
        public ObservableCollection<Artikel> Artikel
        {
            get { return _artikel; }
            set { _artikel = value; RaisePropertyChanged();}
        }

        public RelayCommand AddArticleCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        public AllArticlesViewModel()
        {
            Artikel = new ObservableCollection<Artikel>()
            {
                new Artikel()
                {
                    Bezeichnung = "TestArtikel1",
                    IstLieferbar = true,
                    Preis = 5.50
                },
                new Artikel()
                {
                    Bezeichnung = "TestArtikel2",
                    IstLieferbar = false,
                    Preis = 12.67
                }
            };

            AddArticleCommand = new RelayCommand(AddArticleExecute);
            CloseCommand = new RelayCommand(CloseExecute);
        }

        private void CloseExecute()
        {
            //TODO Save
            Messenger.Default.Send<CloseMessage>(new CloseMessage(this));
        }

        private void AddArticleExecute()
        {
            Artikel.Add(new Artikel() {Bezeichnung = "Neuer Artikel", IstLieferbar = false, Preis = 0.0});
        }
    }
}
