﻿namespace eproject2.Reposatory.Interface
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
        Task<bool> SendEmailAsync(object email, string v, string emailBody);
    }
}
