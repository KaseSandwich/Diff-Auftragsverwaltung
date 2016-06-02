using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using AtgVerwaltung.GUI.ViewModel;
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
            this.DataContext = vm;
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AtgWindow_OnClosing(object sender, CancelEventArgs e)
        {
            HandleAtgOpen();
        }

        private void HandleAtgOpen()
        {
            var vm = (AuftragViewModel)this.DataContext;
            if (vm != null)
                vm.Auftrag.IsOpen = false;
        }
    }
}
