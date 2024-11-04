using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Courses;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Courses;

public partial class CoursesList : ContentPage
{
    private readonly ICourseService _service;
    private readonly IServiceProvider _serviceProvider;
    public CoursesList(ICourseService service, IServiceProvider serviceProvider)
    {
        _service = service;

        InitializeComponent();
        _serviceProvider = serviceProvider;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var list = await _service.FindAll("");
        listView.ItemsSource = list;
    }
    private void CreateNew(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<CreateCourse>();
        Navigation.PushModalAsync(modal);
    }
}