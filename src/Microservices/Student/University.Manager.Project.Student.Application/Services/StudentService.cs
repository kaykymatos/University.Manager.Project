using AutoMapper;
using University.Manager.Project.Student.Application.DTOs;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Application.Interfaces;
using University.Manager.Project.Student.Domain.Entities;
using University.Manager.Project.Student.Domain.Interfaces;

namespace University.Manager.Project.Student.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task DeleteMultipleAsync(IEnumerable<long> ids)
        {
            var deleteModel = await _studentRepository.DeleteMultipleAsync(ids);
            if (!deleteModel)
                throw new ApplicationException("Error on delete a Students");
        }
        public async Task CreateModelAsync(StudentEntityRequestDTO entity)
        {
            StudentEntity model = _mapper.Map<StudentEntity>(entity);
            StudentEntity createModel = await _studentRepository.CreateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on create a new Student");
        }

        public async Task DeleteModelAsync(StudentEntityDTO entity)
        {
            StudentEntity model = _mapper.Map<StudentEntity>(entity);

            StudentEntity deleteModel = await _studentRepository.DeleteModelAsync(model);
            if (deleteModel == null)
                throw new ApplicationException("Error on delete a Student");
        }

        public async Task<IEnumerable<StudentEntityDTO>> GetAllAsync()
        {
            IEnumerable<StudentEntity> listStudents = await _studentRepository.GetAllAsync();
            return listStudents == null ?
                throw new ApplicationException("Error on list a Students")
                : _mapper.Map<IEnumerable<StudentEntityDTO>>(listStudents);
        }

        public async Task<StudentEntityDTO> GetByIdAsync(long id)
        {
            StudentEntity model = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentEntityDTO>(model);
        }

        public async Task<StudentEntityDTO> GetStudentByCourseId(long id)
        {
            StudentEntity model = await _studentRepository.GetStudentByCourseId(id);
            return _mapper.Map<StudentEntityDTO>(model);
        }

        public async Task UpdateModelAsync(StudentEntityRequestDTO entity)
        {
            StudentEntity model = _mapper.Map<StudentEntity>(entity);
            StudentEntity createModel = await _studentRepository.UpdateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on delete a Student");

        }
    }
}
