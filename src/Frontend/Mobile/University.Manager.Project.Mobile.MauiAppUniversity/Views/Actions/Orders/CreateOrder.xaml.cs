using Microsoft.VisualBasic;
using System.Net.Mail;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Enums;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Orders;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Orders;

public partial class CreateOrder : ContentPage
{
    private readonly IOrderService _service;
    private readonly IStudentService _studentService;
    private readonly IServiceProvider _serviceProvider;
    public CreateOrder(IOrderService service, IStudentService studentService, IServiceProvider serviceProvider)
    {
        _service = service;
        _studentService = studentService;

        InitializeComponent();
        _serviceProvider = serviceProvider;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var itens = await _studentService.FindAll("");

        StudentPicker.ItemsSource = itens.ToList();
        OrderType.ItemsSource = Enum.GetValues(typeof(ETypeOrder)).Cast<ETypeOrder>().ToList();
    }
    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        var student = (StudentViewModel)StudentPicker.SelectedItem;
        var model = new OrderViewModel
        {
            Message= Message.Text,
            Attachment= AttachmentInput.Text,
            Title= Title.Text,
            OrderType= (ETypeOrder)OrderType.SelectedItem,
            UserId= student.Id
        };
        var response = await _service.Create(model, "");
        if (response.Count() <= 0)
        {
            var modal = _serviceProvider.GetRequiredService<OrdersList>();
            await Navigation.PushModalAsync(modal);
        }
        else
        {
            await DisplayAlert("Error", "Error", "Ok");
        }
    }
}