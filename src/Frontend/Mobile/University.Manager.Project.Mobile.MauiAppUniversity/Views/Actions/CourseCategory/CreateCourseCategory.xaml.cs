using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.CourseCategory;

public partial class CreateCourseCategory : ContentPage
{
	public CreateCourseCategory()
	{
		InitializeComponent();
	}
    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        // Capturar os valores inseridos nos campos
        var pessoa = new CourseCategoryViewModel
        {
            Name = Name.Text,
            Description = Description.Text
        };

    }
}