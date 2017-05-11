namespace bbqmail {

    public interface IMessageTemplateProvider {
        string GetTemplate(string templateName);
    }

    public class MessageTemplateProvider : IMessageTemplateProvider {

        public string GetTemplate(string templateName) {
            return "Hallo {{FirstName}}, Hierbij nodig ik je uit voor de teamborrel / bbq. Groet, Hullie";
        }

    }

}
