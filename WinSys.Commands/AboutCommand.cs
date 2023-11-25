using System.CommandLine;
using System.Management;
using System.Text;

namespace WinSys.Commands;

public static class AboutCommand
{
    public static Command Register()
    {
        Command command = new("about", "device information and controls");
        command.SetHandler(Run);

        return command;
    }

    public static void Run()
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
        var collection = searcher.Get().Cast<ManagementObject>();

        // TODO: more to add
        // https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/win32-operatingsystem
        foreach (ManagementObject obj in collection)
        {
            var builder = new StringBuilder()
                .AppendLine("Windows Specifications")
                .AppendFormat("Edition: {0}\n", obj["Caption"])
                .AppendFormat("Version: {0}\n", obj["Version"])
                .AppendFormat("Installed On: {0}\n", obj["InstallDate"])
                .Append("OS Build: N/A\n")
                .Append("Experience: N/A\n");

            Console.WriteLine(builder.ToString());
        }
    }
}
