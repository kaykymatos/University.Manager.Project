using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using Microsoft.Maui.Controls;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

public partial class InfoPage : ContentPage
{
    public InfoPage()
    {
        InitializeComponent();
        
        VersionLabel.Text = AppInfo.VersionString;
        NameLabel.Text = AppInfo.Name;
    }
 
}