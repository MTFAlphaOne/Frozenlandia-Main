using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ItemLists : ICommand
    {
        public string Command { get; } = "items";

        public string[] Aliases { get; } = new string[] { "items-list", "list-items" };

        public string Description { get; } = "Lists All Custom items On Frozenlandia";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = Plugin.singleton.Config.ItemReturn;
            return true;
        }
    }
}
