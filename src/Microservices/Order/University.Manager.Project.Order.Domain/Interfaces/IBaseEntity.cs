namespace University.Manager.Project.Order.Domain.Interfaces
{
    public interface IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        void UpdateDomain(IBaseEntity model);
    }
}
