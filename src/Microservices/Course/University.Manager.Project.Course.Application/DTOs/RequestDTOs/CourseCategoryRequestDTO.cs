namespace University.Manager.Project.Course.Application.DTOs.RequestDTOs
{
    public class CourseCategoryRequestDTO
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
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
