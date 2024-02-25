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
        public async Task CreateModelAsync(StudentEntityRequestDTO entity)
        {
            var model = _mapper.Map<StudentEntity>(entity);
            var createModel = await _studentRepository.CreateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on create a new Student");
        }

        public async Task DeleteModelAsync(StudentEntityDTO entity)
        {
            var model = _mapper.Map<StudentEntity>(entity);

            var deleteModel = await _studentRepository.DeleteModelAsync(model);
            if (deleteModel == null)
                throw new ApplicationException("Error on delete a Student");
        }

        public async Task<IEnumerable<StudentEntityDTO>> GetAllAsync()
        {
            var listStudents = await _studentRepository.GetAllAsync();
            return listStudents == null ?
                throw new ApplicationException("Error on list a Students")
                : _mapper.Map<IEnumerable<StudentEntityDTO>>(listStudents);
        }

        public async Task<StudentEntityDTO> GetByIdAsync(long id)
        {
            var model = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentEntityDTO>(model);
        }

        public async Task<StudentEntityDTO> GetStudentByCourseId(long id)
        {
            var model = await _studentRepository.GetStudentByCourseId(id);
            return _mapper.Map<StudentEntityDTO>(model);
        }

        public async Task UpdateModelAsync(StudentEntityRequestDTO entity)
        {
            var model = _mapper.Map<StudentEntity>(entity);
            var createModel = await _studentRepository.UpdateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on delete a Student");

        }
    }
}
