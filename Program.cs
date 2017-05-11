using System;

namespace bbqmail {

    class Program {

        static void Main(string[] args) {

            var color = Console.ForegroundColor;
            try {
                IoC.Initialize().GetInstance<IRunner>().Run(args);
            } catch (Exception e) {
                while (e != null) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = color;
                    e = e.InnerException;
                }
            }

        }

    }

}
