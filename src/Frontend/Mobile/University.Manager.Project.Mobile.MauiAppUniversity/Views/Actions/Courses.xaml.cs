using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;

public partial class Courses : ContentPage
{
    public Courses()
    {
        InitializeComponent();
        var list = new List<CourseViewModel>
        {
            new CourseViewModel
            {
                Name="aa",
                Description="teste",
                CourseCategoryId=1,
                CreationData=DateTime.Now,
                CourseCategory=new CourseCategoryViewModel
                {
                    Name="teste"
                },
                TotalValue=1000,
                UpdatedData=DateTime.Now,
                Workload=100
            },
            new CourseViewModel
            {
                 Name="aa2",
                Description="teste2",
                CourseCategoryId=1,
                CreationData=DateTime.Now,
                CourseCategory=new CourseCategoryViewModel
                {
                    Name="teste"
                },
                TotalValue=1000,
                UpdatedData=DateTime.Now,
                Workload=100
            },
        };

        listView.ItemsSource = list;
    }
}