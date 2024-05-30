using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Manager.Project.Course.Application.Test.Builder
{
    public class CourseEntityRequestDTOBuilder : BuilderBase<CourseEntityRequestDTO>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<CourseEntityRequestDTO>.CreateNew()
                .With(x => x.Id=1)
                .With(x=>x.TotalValue=1000)
                .With(x=>x.CourseCategoryId=1)
                .With(x=>x.Workload=1000)
                .With(x=>x.Description="Teste")
                .With(x=>x.Name="Teste");
        }
    }
}
