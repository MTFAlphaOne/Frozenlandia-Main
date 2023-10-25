using CommandSystem;
using Exiled.API.Features;
using Exiled.Events.Handlers;
using PluginAPI.Core;
using RemoteAdmin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log = Exiled.API.Features.Log;
using Player = Exiled.API.Features.Player;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class BuddyCommand : ICommand
    {
        public string Command { get; set; } = "buddy";

        public string[] Aliases { get; set; } = new string[] { "bud" };

        public string Description { get; set; } = "You can Buddy with your friends";

        private readonly bool _enabled = false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (_enabled)
            {
                response = "";
                string[] args = arguments.ToArray();
                if (sender is PlayerCommandSender)
                {
                    Player player = Player.Get(((CommandSender)sender).SenderId);
                    if (args.Length != 1)
                    {
                        response = "You must put a player id or name";
                        return true;
                    }
                    try
                    {
                        response = HandleBuddyCommand(player, args);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                        response = "A Error has Occured, Please tell a admin";
                        return true;
                    }
                }
                return true;
            }
            else
            {
                response = "Error that command doesnt work.";
                return true;
            }
        }
        private string HandleBuddyCommand(Player p, string[] args)
        {
            //get the player who the request was sent to
            Player buddy = null;

            string lower = args[0].ToLower();
            foreach (Player player1 in Player.List)
            {
                if (player1 == null) continue;
                if (player1.Nickname.ToLower().Contains(lower) && player1.UserId != p.UserId)
                {
                    buddy = player1;
                    break;
                }
            }
            return string.Empty;
        }
    }
}