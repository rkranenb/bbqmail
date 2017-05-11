using System.Collections.Generic;

namespace bbqmail {

    public interface IMailDataProvider {
        IEnumerable<MailData> GetData();
    }

    public class MailDataProvider : IMailDataProvider {

        public IEnumerable<MailData> GetData() {
            yield return new MailData {
                Address = "rkranenburg",
                FirstName = "Robert",
                LastName = "Kranenburg"
            };
        }

    }

}
