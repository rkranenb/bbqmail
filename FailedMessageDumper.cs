using System;
using System.IO;
using System.Net.Mail;

namespace bbqmail {

    public interface IFailedMessageDumper {
        string Dump(MailMessage message);
    }

    public class FailedMessageDumper : IFailedMessageDumper {

        public string Dump(MailMessage message) {
            var guid = Guid.NewGuid().ToString().ToLower();
            var path = $"{guid}.txt";
            using (var writer = new StreamWriter(path)) {
                writer.Write(message.Body);
            }
            return guid;
        }

    }

}
