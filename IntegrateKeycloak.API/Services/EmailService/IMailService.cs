namespace IntegrateKeycloak.API.Services.EmailService
{
    public interface IMailService
    {
        bool SendMail(MailData Mail_Data);
    }
}
