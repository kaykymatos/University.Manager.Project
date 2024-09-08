using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
       
    }

    private void NavigateToInfo(object sender, EventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<InfoPage>();
        Navigation.PushModalAsync(modal);
    }
    private void NavigateToAtions(object sender, EventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<ActionsListPage>();
        Navigation.PushModalAsync(modal);
    }

}