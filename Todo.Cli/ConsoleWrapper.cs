using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Cli
{
    internal class ConsoleWrapper : IConsoleWrapper
    {
        public void Clear() => Console.Clear();

        public string ReadLine() => Console.ReadLine();

        public void WriteLine(string s) => Console.WriteLine(s);

    }
}
