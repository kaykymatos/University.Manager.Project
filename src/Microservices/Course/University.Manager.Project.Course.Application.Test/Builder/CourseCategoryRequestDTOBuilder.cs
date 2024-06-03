using FizzWare.NBuilder;

namespace University.Manager.Project.Course.Application.Test.Builder
{
    public class CourseCategoryRequestDTOBuilder : BuilderBase<CourseCategoryRequestDTO>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<CourseCategoryRequestDTO>.CreateNew()
                .With(x => x.Id = 1)
                .With(x => x.Name = "Teste")
                .With(x => x.Description = "Teste");
        }
    }
}
