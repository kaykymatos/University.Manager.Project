namespace University.Manager.Project.Course.Application.Interfaces
{
    public interface IBaseModel
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}
