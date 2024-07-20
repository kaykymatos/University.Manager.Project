using University.Manager.Project.Course.Domain.Interfaces;

namespace University.Manager.Project.Course.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }

    }
}
