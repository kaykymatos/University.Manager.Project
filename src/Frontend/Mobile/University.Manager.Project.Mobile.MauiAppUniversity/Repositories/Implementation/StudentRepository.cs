using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class StudentRepository : BaseRepository<StudentViewModel>
    {
        public StudentRepository(LiteDatabase database) : base(database, "Students")
        {
        }
    }
}
