using University.Manager.Project.Mobile.MauiAppUniversity.Views;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;

namespace University.Manager.Project.Mobile.MauiAppUniversity
{
    public partial class App : Application
    {
        public App( )
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
