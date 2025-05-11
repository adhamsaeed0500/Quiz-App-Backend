namespace Quiz_App.Services.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email ,string message,string subject);
    }
}
