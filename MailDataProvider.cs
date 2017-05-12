using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace bbqmail {

    public interface IMailDataProvider {
        IEnumerable<MailData> GetData();
    }

    public class MailDataProvider : IMailDataProvider {

        public IEnumerable<MailData> GetData() {

            using (var reader = new StreamReader("bbq2017.json")) {
                return JsonConvert.DeserializeObject<MailData[]>(reader.ReadToEnd());
            }

            //yield return new MailData {
            //    Address = "rkranenburg",
            //    FirstName = "Robert",
            //    LastName = "Kranenburg"
            //};
        }

    }

}
