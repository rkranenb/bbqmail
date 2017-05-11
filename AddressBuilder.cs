using System.Net.Mail;

namespace bbqmail {

    public interface IAddressBuilder {
        MailAddress Build(string address);
    }

    public class AddressBuilder : IAddressBuilder {

        public MailAddress Build(string address) {
            if (address.Contains("@")) return new MailAddress(address);
            return new MailAddress($"{address.Trim()}@wehkamp.nl");
        }

    }

}
