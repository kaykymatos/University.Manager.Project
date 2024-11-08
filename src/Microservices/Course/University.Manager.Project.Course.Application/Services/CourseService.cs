﻿using AutoMapper;
using University.Manager.Project.Course.Application.DTOs;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;
using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Interfaces;

namespace University.Manager.Project.Course.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task CreateModelAsync(CourseEntityRequestDTO entity)
        {
            CourseEntity model = _mapper.Map<CourseEntity>(entity);

            CourseEntity createModel = await _courseRepository.CreateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on create a new Course");
        }

        public async Task DeleteModelAsync(CourseEntityDTO entity)
        {
            CourseEntity model = _mapper.Map<CourseEntity>(entity);

            CourseEntity deleteModel = await _courseRepository.DeleteModelAsync(model);
            if (deleteModel == null)
                throw new ApplicationException("Error on delete a Course");
        }
        public async Task DeleteMultipleAsync(IEnumerable<long> ids)
        {
            var deleteModel = await _courseRepository.DeleteMultipleAsync(ids);
            if (!deleteModel)
                throw new ApplicationException("Error on delete a Course");
        }

        public async Task<IEnumerable<CourseEntityDTO>> GetAllAsync()
        {
            IEnumerable<CourseEntity> listCourses = await _courseRepository.GetAllAsync();
            return listCourses == null ?
                throw new ApplicationException("Error on list a Courses")
                : _mapper.Map<IEnumerable<CourseEntityDTO>>(listCourses);
        }

        public async Task<CourseEntityDTO> GetByIdAsync(long id)
        {
            CourseEntity model = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseEntityDTO>(model);
        }

        public async Task<IEnumerable<CourseEntityDTO>> GetCourseByCategoryId(long categoryId)
        {
            IEnumerable<CourseEntity> model = await _courseRepository.GetCourseByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<CourseEntityDTO>>(model);
        }

        public async Task UpdateModelAsync(CourseEntityRequestDTO entity)
        {
            CourseEntity model = _mapper.Map<CourseEntity>(entity);
            CourseEntity createModel = await _courseRepository.UpdateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on delete a Course");

        }
    }
}
