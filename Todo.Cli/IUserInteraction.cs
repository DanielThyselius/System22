using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Cli
{
    internal interface IUserInteraction
    {
        void DisplayMessage(string s);
        string GetInput(string prompt);
    }
}
