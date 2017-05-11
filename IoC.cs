using StructureMap;

namespace bbqmail {

    static class IoC {

        public static IContainer Initialize() {

            return new Container(registry => {
                registry.Scan(scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
                registry.For<IMailer>().Singleton().Use<Mailer>();
            });

        }

    }

}
