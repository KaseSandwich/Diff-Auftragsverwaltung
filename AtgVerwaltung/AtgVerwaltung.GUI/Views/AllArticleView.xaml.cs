using AtgVerwaltung.GUI.Messages;
using AtgVerwaltung.GUI.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;

namespace AtgVerwaltung.GUI.Views
{
    /// <summary>
    /// Interaction logic for AllArticleView.xaml
    /// </summary>
    public partial class AllArticleView : MetroWindow
    {
        public AllArticleView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseMessage>(this, CloseExecute);
        }

        private void CloseExecute(CloseMessage obj)
        {
            if (obj.T.GetType() == typeof (AllArticlesViewModel))
                this.Close();
        }
    }
}
