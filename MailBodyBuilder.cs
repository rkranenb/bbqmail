namespace bbqmail {

    public interface IMailBodyBuilder {
        string Build(MailData data);
    }

    public class MailBodyBuilder : IMailBodyBuilder {

        private readonly IMessageTemplateProvider templateProvider;

        public MailBodyBuilder(IMessageTemplateProvider templateProvider) {
            this.templateProvider = templateProvider;
        }

        public string Build(MailData data) {
            string template = templateProvider.GetTemplate(data.TemplateName);
            template.Replace("{{FirstName}}", data.FirstName);
            return template;
        }

    }

}
