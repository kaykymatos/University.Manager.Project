using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;

public partial class ActionsListPage : ContentPage
{
	public ActionsListPage()
	{
		InitializeComponent();
	}
    private void OnCoursesTapped(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<Courses>();
        Navigation.PushModalAsync(modal);
    }
    private void OnCourseCategoriesTapped(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<CourseCategory>();
        Navigation.PushModalAsync(modal);
    }
    private void OnStudentsTapped(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<Student>();
        Navigation.PushModalAsync(modal);
    }
    private void OnInstallmentsTapped(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<Installments>();
        Navigation.PushModalAsync(modal);
    }
    private void OnOrdersTapped(object sender, TappedEventArgs e)
    {
        var modal = Handler.MauiContext.Services.GetService<Orders>();
        Navigation.PushModalAsync(modal);
    }

}