namespace Dependency_Injection.Services
{
    public interface IEmailSenderServices
    {
        void SendEmail(string email);   
    }
    public class EmailSenderServices : IEmailSenderServices
    {
        public void SendEmail(string email)
        {
            Console.WriteLine ( email);
        }
    }
}
