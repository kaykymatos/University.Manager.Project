using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Enums;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Installments;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Installments;

public partial class CreateInstallment : ContentPage
{
    private readonly ICourseInstallmentService _service;
    private readonly IStudentService _studentService;
    private readonly IServiceProvider _serviceProvider;
    public CreateInstallment(ICourseInstallmentService service, IStudentService studentService, IServiceProvider serviceProvider)
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
        InstallmentStatusPicker.ItemsSource =Enum.GetValues(typeof(EInstallmentStatus)).Cast<EInstallmentStatus>().ToList();
        PaymentMethodPicker.ItemsSource = Enum.GetValues(typeof(EPaymentMethod)).Cast<EPaymentMethod>().ToList();
    }
    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        var student = (StudentViewModel)StudentPicker.SelectedItem;
        var model = new CourseInstallmentViewModel
        {

            InstallmentPrice = long.Parse(InstallmentPrice.Text),
            StudentId = student.Id,
            InstallmentStatus = (EInstallmentStatus)InstallmentStatusPicker.SelectedItem,
            PaymentDate = PaymentDate.Date,
            DueDate = DueDate.Date,
            PaymentMethod=(EPaymentMethod)PaymentMethodPicker.SelectedItem,
        };
        var response = await _service.Create(model, "");
        if (response.Count() <= 0)
        {
            var modal = _serviceProvider.GetRequiredService<InstallmentsList>();
            await Navigation.PushModalAsync(modal);
        }
        else
        {
            await DisplayAlert("Error", "Error", "Ok");
        }
    }
}