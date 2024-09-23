using University.Manager.Project.Mobile.MauiAppUniversity.Views;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;

namespace University.Manager.Project.Mobile.MauiAppUniversity
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // Use o serviço para resolver a MainPage com dependências injetadas
            MainPage = serviceProvider.GetRequiredService<MainPage>();
        }
    }
}
