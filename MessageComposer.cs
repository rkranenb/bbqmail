using System;
using System.Net.Mail;

namespace bbqmail {

    public interface IMessageComposer {
        MailMessage Compose(MailData data);
    }

    public class MessageComposer : IMessageComposer {

        private readonly IAddressBuilder addressBuilder;

        public MessageComposer(IAddressBuilder addressBuilder) {
            this.addressBuilder = addressBuilder;
        }
        public MailMessage Compose(MailData data) {
            var message = new MailMessage {
                Body = "Hello World!",
                //IsBodyHtml=true,
                Subject = "Test"
            };
            message.To.Add(addressBuilder.Build(data.Address));
            return message;
        }

    }

}