﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AtgVerwaltung.GUI.Messages;
using AtgVerwaltung.GUI.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;

namespace AtgVerwaltung.GUI.Views
{
    /// <summary>
    /// Interaction logic for AtgWindow.xaml
    /// </summary>
    public partial class AtgWindow : MetroWindow
    {
        public AtgWindow(AuftragViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            Messenger.Default.Register<CloseMessage>(this, CloseExecute);
        }

        private void CloseExecute(CloseMessage obj)
        {
            if(obj.T.GetType() == typeof(AuftragViewModel))
                this.Close();
        }
    }
}
