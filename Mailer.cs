using System.Net.Mail;

namespace bbqmail {

    public class MailData {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TemplateName { get; set; } = "bbq2017";
    }

    public interface IMailer {
        void Send(MailData data);
    }

    public class Mailer : IMailer {

        private readonly SmtpClient client = new SmtpClient();
        private readonly IMessageComposer composer;

        public Mailer(IMessageComposer composer) {
            this.composer = composer;
        }

        public void Send(MailData data) {
            var message = composer.Compose(data);
            client.Send(message);
        }

    }

}
