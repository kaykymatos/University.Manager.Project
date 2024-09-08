using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class StudentRepository : BaseRepository<StudentViewModel>,IStudentRepository
    {
        public StudentRepository(LiteDatabase database) : base(database, "Students")
        {
        }
    }
}
