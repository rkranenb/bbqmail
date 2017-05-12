using System;

namespace bbqmail {

    public interface ILogger {
        void WriteLine(string format, params object[] args);
    }

    public class Logger : ILogger {

        public void WriteLine(string format, params object[] args) {
            Console.WriteLine(format, args);
        }

    }

    static class LoggerExtensions {
        public static void Warn(this ILogger logger, string format, params object[] args) {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            logger.WriteLine(format, args);
            Console.ForegroundColor = color;
        }
        public static void Info(this ILogger logger, string format, params object[] args) {
            logger.WriteLine(format, args);
        }

        public static void Error(this ILogger logger, string format, params object[] args) {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            logger.WriteLine(format, args);
            Console.ForegroundColor = color;
        }
    }

}
