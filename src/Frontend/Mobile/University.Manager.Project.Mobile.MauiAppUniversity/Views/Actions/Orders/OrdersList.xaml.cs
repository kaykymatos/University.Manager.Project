using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Enums;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Orders;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Orders;

public partial class OrdersList : ContentPage
{
    private readonly IOrderService _service;
    private readonly IServiceProvider _serviceProvider;
    public OrdersList(IOrderService service, IServiceProvider serviceProvider)
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
        var modal = _serviceProvider.GetRequiredService<CreateOrder>();
        Navigation.PushModalAsync(modal);
    }
    private async Task LoadDataAsync()
    {
        var list = await _service.FindAll("");
        listView.ItemsSource = list;
    }
}