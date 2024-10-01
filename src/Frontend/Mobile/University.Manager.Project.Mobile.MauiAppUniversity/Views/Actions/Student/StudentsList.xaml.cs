using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Student;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Student;

public partial class StudentsList : ContentPage
{
    private readonly IStudentService _service;
    private readonly IServiceProvider _serviceProvider;
    public StudentsList(IStudentService service, IServiceProvider serviceProvider)
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
    private void CreateNew(object sender, TappedEventArgs e)
    {
        var modal = _serviceProvider.GetRequiredService<CreateStudent>();
        Navigation.PushModalAsync(modal);
    }
    private async Task LoadDataAsync()
    {
        var list = await _service.FindAll("");
        listView.ItemsSource = list;
    }
}