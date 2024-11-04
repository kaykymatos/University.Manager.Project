using IdentityModel.OidcClient;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;

public partial class HomePage : ContentPage
{
    private readonly OidcClient _client;
    public HomePage(OidcClient client)
    {
        InitializeComponent();
        _client = client;
    }
    private async void Login_Click(object sender, EventArgs e)
    {
        var result = await _client.LoginAsync(new LoginRequest());
        
        var res = result;
    }

}