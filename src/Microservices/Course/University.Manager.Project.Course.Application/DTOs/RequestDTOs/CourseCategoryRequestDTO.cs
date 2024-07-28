using University.Manager.Project.Course.Application.Interfaces;

namespace University.Manager.Project.Course.Application.DTOs.RequestDTOs
{
    public class CourseCategoryRequestDTO : IBaseModel
    {
        public CourseCategoryRequestDTO(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public CourseCategoryRequestDTO()
        {

        }
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}
