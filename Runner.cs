namespace bbqmail {

    public interface IRunner {
        void Run(string[] args);
    }

    public class Runner : IRunner {

        private readonly IMailDataProvider dataProvider;
        private readonly IMailer mailer;

        public Runner(IMailDataProvider dataProvider, IMailer mailer) {
            this.mailer = mailer;
            this.dataProvider = dataProvider;
        }

        public void Run(string[] args) {
            foreach (var data in dataProvider.GetData()) {
                mailer.Send(data);
            }
        }

    }

}
