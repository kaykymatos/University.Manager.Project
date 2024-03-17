using FizzWare.NBuilder;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Student.Application.Test.Builder
{
    public class StudentEntityRequestDTOBuilder : BuilderBase<StudentEntityRequestDTO>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<StudentEntityRequestDTO>.CreateNew()
                .With(x => x.CourseId = 1)
                .With(x => x.StudentId = 1)
                .With(x => x.RegisterCode = "1234");
        }
    }
}
