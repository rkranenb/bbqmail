using System.IO;

namespace bbqmail {

    public interface IMessageTemplateProvider {
        string GetTemplate(string templateName);
    }

    public class MessageTemplateProvider : IMessageTemplateProvider {

        public string GetTemplate(string templateName) {
            var path = $"{templateName}.html";
            using (var reader = new StreamReader(path)) {
                return reader.ReadToEnd();
            }
        }

    }

}
