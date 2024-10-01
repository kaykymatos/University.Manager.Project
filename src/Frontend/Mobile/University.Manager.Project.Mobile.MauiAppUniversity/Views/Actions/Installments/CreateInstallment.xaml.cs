using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Enums;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Installments;

public partial class CreateInstallment : ContentPage
{
    private readonly ICourseInstallmentService _courseInstallmentService;
    private readonly IStudentService _studentService;
    public CreateInstallment(ICourseInstallmentService courseInstallmentService, IStudentService studentService)
    {
        _courseInstallmentService = courseInstallmentService;
        _studentService = studentService;

        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var itens = await _studentService.FindAll("");
      
        StudentPicker.ItemsSource = itens.ToList();
        InstallmentStatusPicker.ItemsSource =Enum.GetValues(typeof(EInstallmentStatus)).Cast<EInstallmentStatus>().ToList();
        PaymentMethodPicker.ItemsSource = Enum.GetValues(typeof(EPaymentMethod)).Cast<EPaymentMethod>().ToList();
    }
    private void OnEnviarClicked(object sender, EventArgs e)
    {
        var student = (StudentViewModel)StudentPicker.SelectedItem;
        var pessoa = new CourseInstallmentViewModel
        {

            InstallmentPrice = long.Parse(InstallmentPrice.Text),
            StudentId = student.Id,
            InstallmentStatus = (EInstallmentStatus)InstallmentStatusPicker.SelectedItem,
            PaymentDate = PaymentDate.Date,
            DueDate = DueDate.Date,
            PaymentMethod=(EPaymentMethod)PaymentMethodPicker.SelectedItem,
        };
    }
}