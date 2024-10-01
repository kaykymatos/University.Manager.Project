using System.Text.Json;
using System.Text.Json.Serialization;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Courses;

public partial class CreateCourse : ContentPage
{
    private readonly ICourseService _courseService;
    private readonly ICourseCategoryService _courseCategoryService;
    public CreateCourse(ICourseService courseService, ICourseCategoryService courseCategoryService)
    {
        _courseService = courseService;
        _courseCategoryService = courseCategoryService;

        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var itens = await _courseCategoryService.FindAll("");

        CategoryPicker.ItemsSource = itens.ToList();
    }
    private void OnEnviarClicked(object sender, EventArgs e)
    {
        var category = (CourseCategoryViewModel)CategoryPicker.SelectedItem;
        var pessoa = new CourseViewModel
        {
            Name = Name.Text,
            Description = Description.Text,
            CourseCategoryId = category.Id,
            CourseCategory = category,
            TotalValue = long.Parse(TotalValue.Text),
            Workload = long.Parse(Workload.Text)
        };
    }
}