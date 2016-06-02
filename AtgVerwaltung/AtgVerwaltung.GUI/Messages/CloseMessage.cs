using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace AtgVerwaltung.GUI.Messages
{
    public class CloseMessage
    {
        public ViewModelBase T { get; set; }

        public CloseMessage(ViewModelBase t)
        {
            T = t;
        }
    }
}
