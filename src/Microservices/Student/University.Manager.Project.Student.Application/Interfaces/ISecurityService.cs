namespace University.Manager.Project.Student.Application.Interfaces
{
    public interface ISecurityService
    {
        string EncryptPassword(string password);
    }
}
