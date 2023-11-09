using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Cli
{
    internal class UserInteraction : IUserInteraction
    {
        private readonly IConsoleWrapper consoleWrapper;

        public UserInteraction(IConsoleWrapper consoleWrapper)
        {
            this.consoleWrapper = consoleWrapper;
        }

        public void DisplayMessage(string s)
        {
            consoleWrapper.WriteLine(s);
            consoleWrapper.WriteLine("~~~~~~~~");
        }

        public string GetInput(string prompt)
        {
            consoleWrapper.WriteLine(prompt);
            var input = consoleWrapper.ReadLine();

            // skitdålig felhantering, todo: fix
            if (input is null)
                throw new ArgumentNullException("Dåligt...");

            return input;
        }
    }
}
