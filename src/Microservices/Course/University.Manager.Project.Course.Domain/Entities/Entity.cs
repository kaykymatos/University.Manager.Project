using University.Manager.Project.Course.Domain.Interfaces;

namespace University.Manager.Project.Course.Domain.Entities
{
    public class Entity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }

        public virtual void UpdateDomain(IBaseEntity model)
        {
            model.UpdatedData = DateTime.Now;
        }
    }
}
