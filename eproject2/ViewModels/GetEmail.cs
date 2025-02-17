using Microsoft.Build.Framework;

namespace eproject2.ViewModels
{
    public class GetEmail
    {
        public string SecretKey { get; set; }
        public string From { get; set; }
   
        public string SmtpServer { get; set; }


        public int Port { get; set; }
        public bool EnableSsl { get; set; }
       
        
    }
}
