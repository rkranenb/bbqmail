using System;
using System.Net.Mail;

namespace bbqmail {

    public interface IMessageComposer {
        MailMessage Compose(MailData data);
    }

    public class MessageComposer : IMessageComposer {

        private readonly IAddressBuilder addressBuilder;
        private readonly IMailBodyBuilder bodyBuilder;

        public MessageComposer(IAddressBuilder addressBuilder, IMailBodyBuilder bodyBuilder) {
            this.addressBuilder = addressBuilder;
            this.bodyBuilder = bodyBuilder;
        }
        public MailMessage Compose(MailData data) {
            var message = new MailMessage {
                Body = bodyBuilder.Build(data),
                IsBodyHtml=true,
                Subject = "Test"
            };
            message.To.Add(addressBuilder.Build(data.Address));
            return message;
        }

    }

}