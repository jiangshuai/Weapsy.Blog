﻿using System.Threading.Tasks;

namespace Weapsy.Blog.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
