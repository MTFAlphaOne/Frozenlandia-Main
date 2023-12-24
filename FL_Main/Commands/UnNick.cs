using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FL_Main.Commands;
namespace FL_Main.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class UnNick : ICommand
    {
        public string Command { get; } = "unnick";

        public string[] Aliases { get; } = new string[] { "unick" };

        public string Description { get; } = "undo your nick";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender.CheckPermission("fl.nick"))
            {
                Player player = (Player)sender;
                if (Plugin.singleton.PlayerNicks.ContainsKey(player.DisplayNickname))
                {
                    player.DisplayNickname = Plugin.singleton.PlayerNicks[player.DisplayNickname];
                    response = "Unnicked";
                    return true;
                }
                else;
                {
                    response = "";
                    return false;
                }
            }
            else
            {
                response = "Du hast nicht die erforderlichen Rechte, um dich zu nicken.";
                return false;
            }
        }
    }
}
