using StructureMap;
using System;
using System.Linq;

namespace bbqmail {

    static class IoC {

        public static IContainer Initialize() {

            return new Container(registry => {

                registry.Scan(scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                if (Environment.GetCommandLineArgs().Contains("-n")) {
                    registry.For<IMailer>().Singleton().Use<NullMailer>();
                } else {
                    registry.For<IMailer>().Singleton().Use<SmtpMailer>();
                }

            });

        }

    }

}
