using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgVerwaltung.Model;
using GalaSoft.MvvmLight;

namespace AtgVerwaltung.Lib.ModelWrapper
{
    public class PositionWrapper : ObservableObject
    {
        private Auftragsposition _position;
        public Auftragsposition Position
        {
            get { return _position; }
            set { _position = value; RaisePropertyChanged(); RaisePropertyChanged(nameof(Netto)); }
        }

        private Artikel _artikel;
        public Artikel Artikel
        {
            get { return _artikel; }
            set
            {
                _artikel = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Netto));
            }
        }

        public void RefreshNetto()
        {
            RaisePropertyChanged(() => Netto);
        }

        public double Netto => Position.Bestellmenge*Artikel.Preis*(1 - Position.Rabatt/100);
    }
}
