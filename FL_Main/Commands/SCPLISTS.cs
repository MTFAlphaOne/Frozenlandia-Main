using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SCPLISTS : ICommand
    {
        public string Command { get; } = "scps";

        public string[] Aliases { get; } = new string[] { "scp-list", "list-scps" };

        public string Description { get; } = "Lists All Custom SCPs On Frozenlandia";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = Plugin.singleton.Config.SCPReturn;
            return true;
        }
    }
}
