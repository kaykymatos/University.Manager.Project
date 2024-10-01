using System.Text.Json;
using System.Text.Json.Serialization;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Courses;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Courses;

public partial class CreateCourse : ContentPage
{
    private readonly ICourseService _service;
    private readonly ICourseCategoryService _courseCategoryService;
    private readonly IServiceProvider _serviceProvider;
    public CreateCourse(ICourseService service, ICourseCategoryService courseCategoryService, IServiceProvider serviceProvider)
    {
        _service = service;
        _courseCategoryService = courseCategoryService;
        _serviceProvider = serviceProvider;

        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var itens = await _courseCategoryService.FindAll("");

        CategoryPicker.ItemsSource = itens.ToList();
    }
    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        var category = (CourseCategoryViewModel)CategoryPicker.SelectedItem;
        var model = new CourseViewModel
        {
            Name = Name.Text,
            Description = Description.Text,
            CourseCategoryId = category.Id,
            CourseCategory = category,
            TotalValue = long.Parse(TotalValue.Text),
            Workload = long.Parse(Workload.Text)
        };
        var response = await _service.Create(model, "");
        if (response.Count() <= 0)
        {
            var modal = _serviceProvider.GetRequiredService<CoursesList>();
            await Navigation.PushModalAsync(modal);
        }
        else
        {
            await DisplayAlert("Error", "Error", "Ok");
        }
    }
}