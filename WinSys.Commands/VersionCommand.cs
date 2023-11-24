using System.CommandLine;

namespace WinSys.Commands;

public static class VersionCommand
{
    public static Command Register()
    {
        Command command = new("version", "display version information");
        command.SetHandler(Run);

        return command;
    }

    public static void Run()
    {
        Console.WriteLine("winsys version 0.1.0");
    }
}
