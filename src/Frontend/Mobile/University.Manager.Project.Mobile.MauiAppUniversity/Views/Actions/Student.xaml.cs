using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;

public partial class Student : ContentPage
{
    private readonly IStudentService _service;
    public Student(IStudentService service)
    {
        _service = service;

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
}