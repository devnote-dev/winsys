using System.CommandLine;

namespace WinSys.Commands;

public static class ClipboardCommand
{
    public static Command Register()
    {
        Command command = new("clipboard", "clipboard controls");
        command.SetHandler(Run);

        return command;
    }

    public static void Run()
    {
        var view = Clipboard.GetContent();
        Console.WriteLine(view);
        Console.WriteLine(view.Properties);
        Console.WriteLine(view.Properties.Title);
        Console.WriteLine(view.Properties.Count);
        Console.WriteLine(view.Properties.Values);
    }
}
