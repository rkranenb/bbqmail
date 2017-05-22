using System;
using System.Net.Mail;

namespace bbqmail {    

    public interface IMailer {
        void Send(MailData data);
    }

    public abstract class Mailer : IMailer {

        public void Send(MailData data) {
            SendInternal(data);
        }

        protected abstract void SendInternal(MailData data);

    }

    public class SmtpMailer : Mailer {

        private readonly SmtpClient client = new SmtpClient();
        private readonly IMessageComposer composer;
        private readonly IFailedMessageDumper dumper;
        private readonly ILogger logger;

        public SmtpMailer(IMessageComposer composer, ILogger logger, IFailedMessageDumper dumper) {
            this.composer = composer;
            this.logger = logger;
            this.dumper = dumper;
        }

        protected override void SendInternal(MailData data) {

            var message = composer.Compose(data);

            try {
                client.Send(message);
            } catch (Exception e) {
                var guid = dumper.Dump(message);
                logger.Error("Failed to send message to {1}. Created dump: {0}", guid, data.FullName());
                logger.Error($"Message: {e.Message}");
            }

            foreach (var address in message.To) {
                logger.Info("Send message to {0}", address);
            }

        }

    }

    public class NullMailer : Mailer {

        private readonly IMessageComposer composer;
        private readonly ILogger logger;

        public NullMailer(IMessageComposer composer, ILogger logger) {
            this.composer = composer;
            this.logger = logger;
        }

        protected override void SendInternal(MailData data) {
            var message = composer.Compose(data);

            foreach (var address in message.To) {
                logger.Warn("No-send switch prevented sending message to {0}", address);
            }

        }

    }

}
