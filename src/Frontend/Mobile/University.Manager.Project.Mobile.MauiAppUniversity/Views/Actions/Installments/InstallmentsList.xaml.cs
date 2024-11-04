using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Enums;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Installments;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Installments;

public partial class InstallmentsList : ContentPage
{
    private readonly ICourseInstallmentService _service;
    private readonly IServiceProvider _serviceProvider;
    public InstallmentsList(ICourseInstallmentService service, IServiceProvider serviceProvider)
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
        var modal = _serviceProvider.GetRequiredService<CreateInstallment>();
        Navigation.PushModalAsync(modal);
    }
}