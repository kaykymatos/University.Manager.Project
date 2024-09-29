
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.CourseCategory;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.CourseCategory;

public partial class CourseCategoriesList : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICourseCategoryService _service;
    public CourseCategoriesList(ICourseCategoryService service, IServiceProvider serviceProvider)
    {
        _service = service;
        _serviceProvider = serviceProvider;

        InitializeComponent();
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
        var modal = _serviceProvider.GetRequiredService<CreateCourseCategory>();
        Navigation.PushModalAsync(modal);
    }
}