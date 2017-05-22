namespace bbqmail {

    public class MailData {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
        public string TemplateName { get; set; } = "bbq2017";
    }

    static class MailDataExtensions {

        public static string FullName(this MailData data) {
            return $"{data.FirstName} {data.LastName}";
        }
    }

}
