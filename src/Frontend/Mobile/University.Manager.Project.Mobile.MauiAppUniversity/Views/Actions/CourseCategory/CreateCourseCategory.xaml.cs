using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.CourseCategory;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.CourseCategory;

public partial class CreateCourseCategory : ContentPage
{
    private readonly ICourseCategoryService _service;
    private readonly IServiceProvider _serviceProvider;
    public CreateCourseCategory(ICourseCategoryService service, IServiceProvider serviceProvider)
	{
        _service = service;
        _serviceProvider = serviceProvider;

        InitializeComponent();
	}
    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        // Capturar os valores inseridos nos campos
        var model = new CourseCategoryViewModel
        {
            Name = Name.Text,
            Description = Description.Text
        };
        var response = await _service.Create(model, "");
        if (response.Count()<=0) {
            var modal = _serviceProvider.GetRequiredService<CourseCategoriesList>();
            await Navigation.PushModalAsync(modal);
        }
        else
        {
            await DisplayAlert("Error", "Error", "Ok");
        }
    }
}