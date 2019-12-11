using System;
using System.IO;
using System.Text;

namespace ConsoleController
{
    public class ConsoleHelper : TextWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.ASCII;
            }
        }

        public override void WriteLine(string line)
        {
            Console.WriteLine("test");
        }

    }
}
