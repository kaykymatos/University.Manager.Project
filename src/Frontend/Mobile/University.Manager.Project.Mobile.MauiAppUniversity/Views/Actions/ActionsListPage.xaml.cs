using University.Manager.Project.Mobile.MauiAppUniversity.Views.CourseCategory;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Courses;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Installments;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Orders;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Student;

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
        var modal = _serviceProvider.GetRequiredService<CoursesList>();
        Navigation.PushModalAsync(modal);
    }
    private void OnCourseCategoriesTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<CourseCategoriesList>();
        Navigation.PushModalAsync(modal);
    }
    private void OnStudentsTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<StudentsList>();
        Navigation.PushModalAsync(modal);
    }
    private void OnInstallmentsTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<InstallmentsList>();
        Navigation.PushModalAsync(modal);
    }
    private void OnOrdersTapped(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<OrdersList>();
        Navigation.PushModalAsync(modal);
    }

}