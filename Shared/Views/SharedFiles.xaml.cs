using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Shared.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SharedFiles : Page
    {
        public SharedFiles()
        {
            this.InitializeComponent();
            this.Loaded += SharedFilesPage_Loaded;
        }

        private void SharedFilesPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (Frame.Parent is NavigationView navigationView)
            {
                navigationView.Header = null;
            }
        }
    }
}
