using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Manager.Project.Financial.Application.DTOs;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;
using University.Manager.Project.Financial.Application.Interfaces;
using University.Manager.Project.Financial.Domain.Entities;
using University.Manager.Project.Financial.Domain.Interfaces;

namespace University.Manager.Project.Financial.Application.Services
{
    public class CourseInstallmentsService : ICourseInstallmentsService
    {
        private readonly ICourseInstallmentsRepository _courseInstallmentRepository;
        private readonly IMapper _mapper;

        public CourseInstallmentsService(ICourseInstallmentsRepository courseInstallmentRepository, IMapper mapper)
        {
            _courseInstallmentRepository = courseInstallmentRepository;
            _mapper = mapper;
        }
        public async Task CreateModelAsync(CourseInstallmentsRequestDTO entity)
        {
            var model = _mapper.Map<CourseInstallments>(entity);

            var createModel = await _courseInstallmentRepository.CreateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on create a new CourseInstallment");
        }

        public async Task DeleteModelAsync(CourseInstallmentsDTO entity)
        {
            var model = _mapper.Map<CourseInstallments>(entity);

            var deleteModel = await _courseInstallmentRepository.DeleteModelAsync(model);
            if (deleteModel == null)
                throw new ApplicationException("Error on delete a CourseInstallment");
        }

        public async Task<IEnumerable<CourseInstallmentsDTO>> GetAllAsync()
        {
            var listCourseInstallments = await _courseInstallmentRepository.GetAllAsync();
            return listCourseInstallments == null ?
                throw new ApplicationException("Error on list a CourseInstallments")
                : _mapper.Map<IEnumerable<CourseInstallmentsDTO>>(listCourseInstallments);
        }

        public async Task<CourseInstallmentsDTO> GetByIdAsync(long id)
        {
            var model = await _courseInstallmentRepository.GetByIdAsync(id);
            return _mapper.Map<CourseInstallmentsDTO>(model);
        }
        public async Task UpdateModelAsync(CourseInstallmentsRequestDTO entity)
        {
            var model = _mapper.Map<CourseInstallments>(entity);

            var createModel = await _courseInstallmentRepository.UpdateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on delete a CourseInstallment");

        }
    }
}
