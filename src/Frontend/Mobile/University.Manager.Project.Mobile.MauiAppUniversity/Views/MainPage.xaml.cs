using IdentityModel.OidcClient;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views;

public partial class MainPage : TabbedPage
{
    public MainPage(InfoPage infoPage, HomePage homePage, ActionsListPage actionsPage)
    {
        InitializeComponent();

        Children.Add(new NavigationPage(infoPage) { Title = "Info", IconImageSource = "config.png" });
        Children.Add(new NavigationPage(homePage) { Title = "Home", IconImageSource = "house.png" });
        Children.Add(new NavigationPage(actionsPage) { Title = "Actions", IconImageSource = "plus.png" });

        this.CurrentPage = this.Children[1];
    }
}