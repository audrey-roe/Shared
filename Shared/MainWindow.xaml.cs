using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Shared
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "Shared";

            this.InitializeComponent();
            (Application.Current as App).EnsureSettings();
            ApplyTheme();

            NavigationView.PaneOpening += NavigationView_PaneOpening;
            NavigationView.PaneClosing += NavigationView_PaneClosing;
        }
        private void NavigationView_PaneOpening(NavigationView sender, object args)
        {
            // Find the MenuItem and LibraryItem by name and make them visible
            var menuItem = NavigationView.FindName("MenuItem") as NavigationViewItem;
            var libraryItem = NavigationView.FindName("LibraryItem") as NavigationViewItem;
            var appname = NavigationView.FindName("AppName") as NavigationViewItem;
            if (menuItem != null && libraryItem != null && appname!=null)
            {
                menuItem.Visibility = Visibility.Visible;
                libraryItem.Visibility = Visibility.Visible;
                appname.Visibility = Visibility.Visible;
            }
        }

        private void NavigationView_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
        {
            // Find the MenuItem and LibraryItem by name and hide them
            var menuItem = NavigationView.FindName("MenuItem") as NavigationViewItem;
            var libraryItem = NavigationView.FindName("LibraryItem") as NavigationViewItem;
            var appname = NavigationView.FindName("AppName") as NavigationViewItem;


            if (menuItem != null && libraryItem != null)
            {
                menuItem.Visibility = Visibility.Collapsed;
                libraryItem.Visibility = Visibility.Collapsed;
                appname.Visibility = Visibility.Collapsed;

            }
        }


        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = (Application.Current as App).Settings;
            settings.IsLightTheme = !settings.IsLightTheme;
            (Application.Current as App).SaveSettings();
            Root.ActualThemeChanged += Root_ActualThemeChanged;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            var settings = (Application.Current as App).Settings;
            Root.RequestedTheme = settings.IsLightTheme ? ElementTheme.Light : ElementTheme.Dark;
        }
        private void Root_ActualThemeChanged(FrameworkElement sender, object args)
        {
            // Theme change refinements (e.g. content dialogs and title bar).
        }
    }
}
