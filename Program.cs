using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using WinSys.Commands;

namespace WinSys;

class Program
{
    static int Main(string[] args)
    {
        Command root = new("winsys");
        root.AddCommand(VersionCommand.Register());

        var parser = new CommandLineBuilder(root)
            .UseParseErrorReporting()
            .CancelOnProcessTermination()
            .UseSuggestDirective()
            .Build();

        return parser.Invoke(args);
    }
}
