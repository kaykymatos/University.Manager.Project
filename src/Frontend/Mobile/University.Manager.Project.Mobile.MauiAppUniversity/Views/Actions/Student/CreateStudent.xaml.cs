using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Student;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Student;

public partial class CreateStudent : ContentPage
{
    private readonly ICourseService _courseService;
    private readonly IStudentService _service;
    private readonly IServiceProvider _serviceProvider;
    public CreateStudent(ICourseService courseService, IStudentService service, IServiceProvider serviceProvider)
    {
        _courseService = courseService;
        _service = service;

        InitializeComponent();
        _serviceProvider = serviceProvider;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var itens = await _courseService.FindAll("");

        CoursePicker.ItemsSource = itens.ToList();
    }
    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        var course = (CourseViewModel)CoursePicker.SelectedItem;
        var model = new StudentViewModel
        {
            Email = EmailInput.Text,
            CourseId = course.Id,
            Name = NameInput.Text,
            RegisterCode = RegisterCodeInput.Text,
        };
        var response = await _service.Create(model, "");
        if (response.Count() <= 0)
        {
            var modal = _serviceProvider.GetRequiredService<StudentsList>();
            await Navigation.PushModalAsync(modal);
        }
        else
        {
            await DisplayAlert("Error", "Error", "Ok");
        }
    }
}