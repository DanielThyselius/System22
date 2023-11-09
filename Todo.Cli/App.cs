using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core;

namespace Todo.Cli
{
    internal class App
    {
        private readonly ITodoList todoList;
        private readonly IStorage storage;
        private readonly IUserInteraction userInteraction;

        public App(
            ITodoList todoList, 
            IStorage storage,
            IUserInteraction userInteraction)
        {
            this.todoList = todoList;
            this.storage = storage;
            this.userInteraction = userInteraction;
        }
        internal void Start()
        {

        }
    }
}
