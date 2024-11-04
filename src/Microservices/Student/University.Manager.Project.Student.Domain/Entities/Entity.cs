using University.Manager.Project.Student.Domain.Interfaces;

namespace University.Manager.Project.Student.Domain.Entities
{
    public class Entity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public virtual void UpdateDomain(IBaseEntity entity)
        {
            UpdatedData = DateTime.Now;
        }
    }
}
