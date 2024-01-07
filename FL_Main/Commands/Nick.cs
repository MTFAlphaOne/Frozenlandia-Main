using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Nick : ICommand
    {
        public string Command { get; } = "nick";

        public string[] Aliases { get; } = new string[] { "setnick" };

        public string Description { get; } = "Set your nick";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender.CheckPermission("fl.nick"))
            {
                Player player = sender as Player;
                if (arguments.
                if (arguments.Count == 1)
                {
                    Plugin.singleton.PlayerNicks[player.DisplayNickname] = arguments.Array[0];
                    player.DisplayNickname = arguments.Array[0];
                    response = "Du hast deinen Namen erfolgreich geändert.";
                    return true;
                }
                else if (arguments.Count == 0)
                {
                    response = "Nutze: .nick (GEWÜNSCHTER NICKNAME)";
                    return false;
                }
                else
                {
                    response = "Es dürfen keine Leer/Sonderzeichen vorkommen.";
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
