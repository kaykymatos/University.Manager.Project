using System.Security.Cryptography;
using System.Text;
using University.Manager.Project.Student.Application.Interfaces;

namespace University.Manager.Project.Student.Application.Services
{
    public class SecurityService : ISecurityService
    {

        public string EncryptPassword(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = SHA256.HashData(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}
