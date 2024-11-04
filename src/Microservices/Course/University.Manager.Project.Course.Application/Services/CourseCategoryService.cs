using AutoMapper;
using University.Manager.Project.Course.Application.DTOs;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;
using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Interfaces;

namespace University.Manager.Project.Course.Application.Services
{
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly IMapper _mapper;

        public CourseCategoryService(ICourseCategoryRepository courseCategoryRepository, IMapper mapper)
        {
            _courseCategoryRepository = courseCategoryRepository;
            _mapper = mapper;
        }

        public async Task CreateModelAsync(CourseCategoryRequestDTO entity)
        {
            CourseCategory model = _mapper.Map<CourseCategory>(entity);

            CourseCategory createModel = await _courseCategoryRepository.CreateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on create a new Course");
        }

        public async Task DeleteModelAsync(CourseCategoryDTO entity)
        {
            CourseCategory model = _mapper.Map<CourseCategory>(entity);

            CourseCategory deleteModel = await _courseCategoryRepository.DeleteModelAsync(model);
            if (deleteModel == null)
                throw new ApplicationException("Error on delete a Course");
        }

        public async Task<IEnumerable<CourseCategoryDTO>> GetAllAsync()
        {
            IEnumerable<CourseCategory> listCourses = await _courseCategoryRepository.GetAllAsync();
            return listCourses == null ?
                throw new ApplicationException("Error on list a Courses")
                : _mapper.Map<IEnumerable<CourseCategoryDTO>>(listCourses);
        }

        public async Task<CourseCategoryDTO> GetByIdAsync(long id)
        {
            CourseCategory model = await _courseCategoryRepository.GetByIdAsync(id);
            return _mapper.Map<CourseCategoryDTO>(model);
        }
        public async Task UpdateModelAsync(CourseCategoryRequestDTO entity)
        {
            CourseCategory model = _mapper.Map<CourseCategory>(entity);

            CourseCategory createModel = await _courseCategoryRepository.UpdateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on delete a Course");

        }
        public async Task DeleteMultipleAsync(IEnumerable<long> ids)
        {
            var deleteModel = await _courseCategoryRepository.DeleteMultipleAsync(ids);
            if (!deleteModel)
                throw new ApplicationException("Error on delete a Course Category");
        }
    }
}
