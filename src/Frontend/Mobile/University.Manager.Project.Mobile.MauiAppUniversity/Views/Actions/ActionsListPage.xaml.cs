using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;

public partial class ActionsListPage : ContentPage
{

    private readonly IServiceProvider _serviceProvider;

    public ActionsListPage(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }
    private void OnCoursesTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<Courses>();
        Navigation.PushModalAsync(modal);
    }
    private void OnCourseCategoriesTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<CourseCategory>();
        Navigation.PushModalAsync(modal);
    }
    private void OnStudentsTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<Student>();
        Navigation.PushModalAsync(modal);
    }
    private void OnInstallmentsTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<Installments>();
        Navigation.PushModalAsync(modal);
    }
    private void OnOrdersTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<Orders>();
        Navigation.PushModalAsync(modal);
    }

}