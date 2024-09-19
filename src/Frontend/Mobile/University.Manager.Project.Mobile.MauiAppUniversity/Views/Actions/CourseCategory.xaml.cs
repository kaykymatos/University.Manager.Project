
using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;

public partial class CourseCategory : ContentPage
{
    public CourseCategory()
    {

        InitializeComponent();

        var list = new List<CourseCategoryViewModel>
        {
            new CourseCategoryViewModel
            {
                Name="aa",
                Description="teste"
            },
            new CourseCategoryViewModel
            {
                Name="aa",
                Description="teste"
            },
        };

        listView.ItemsSource = list;
    }
}