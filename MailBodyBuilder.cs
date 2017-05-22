using System.Text;

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
            var template = new StringBuilder(templateProvider.GetTemplate(data.TemplateName));
            template.Replace("{{FirstName}}", data.FirstName);
            template.Replace("{{Id}}", data.Id);
            return template.ToString();
        }

    }

}
