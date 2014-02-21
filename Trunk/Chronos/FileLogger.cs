using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OrionsBelt.Config
{
    public class FileLogger {

        #region OutoutFile

        private static StreamWriter file = null;
        private static StreamWriter GetFileStream()
        {
            if (file == null) {
                file = new StreamWriter("Tournament.log.txt");
            }
            return file;
        }

        public static void Flush()
        {
            if (file != null) {
                file.Flush();
            }
        }

        #endregion OutoutFile

        #region Write Methods

        public static void Write( string str, params object[] args )
        {
            Write(Console.Out, str, args);
            Write(GetFileStream(), str, args);
        }

        public static void WriteLine(string str, params object[] args)
        {
            WriteLine(Console.Out, str, args);
            WriteLine(GetFileStream(), str, args);
        }

        internal static void WriteLine()
        {
            WriteLine(string.Empty);
        }

        internal static void WriteLine(object obj)
        {
            if (obj == null) {
                WriteLine("(null)");
            } else {
                WriteLine(obj.ToString());
            }
        }

        public static void Write(TextWriter writer, string str, params object[] args)
        {
            writer.Write(string.Format(str, args));
            writer.Flush();
        }

        public static void WriteLine(TextWriter writer, string str, params object[] args)
        {
            writer.WriteLine(string.Format(str, args));
            writer.Flush();
        }

        #endregion Write Methods

    };
}
