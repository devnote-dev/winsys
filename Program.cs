using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using WinSys.Commands;

[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows")]
namespace WinSys;

class Program
{
    static int Main(string[] args)
    {
        Command root = new("winsys");
        root.AddCommand(AboutCommand.Register());
        root.AddCommand(VersionCommand.Register());

        var parser = new CommandLineBuilder(root)
            .UseParseErrorReporting()
            .CancelOnProcessTermination()
            .UseSuggestDirective()
            .Build();

        return parser.Invoke(args);
    }
}
