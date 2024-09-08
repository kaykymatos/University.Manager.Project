using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;

public partial class ActionsListPage : ContentPage
{
	public ActionsListPage()
	{
		InitializeComponent();
	}
    public void NavigateToInfo(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<InfoPage>();
        Navigation.PushModalAsync(modal);
    }
    public void NavigateToHome(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<HomePage>();
        Navigation.PushModalAsync(modal);
    }
}