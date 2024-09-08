using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views;

public partial class MainPage : TabbedPage
{
	public MainPage()
	{
		InitializeComponent();
        this.CurrentPage = this.Children[1];
    }
}