using Todo.Cli;
using Todo.Core;

internal class Program
{
    private static void Main(string[] args)
    {
        var todoList = new TodoList();
        var storage = new Storage();
        var consoleWrapper = new ConsoleWrapper();
        var userInteraction = new UserInteraction(consoleWrapper);

        var app = new App(todoList, storage, userInteraction);
        app.Start();
    }
}