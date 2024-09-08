using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

public partial class InfoPage : ContentPage
{
    public InfoPage()
    {
        InitializeComponent();
    }
    public void NavigateToHome(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<HomePage>();
        Navigation.PushModalAsync(modal);
    }
    public void NavigateToAtions(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<ActionsListPage>();
        Navigation.PushModalAsync(modal);
    }
}