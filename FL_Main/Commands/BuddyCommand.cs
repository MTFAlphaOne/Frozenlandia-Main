using CommandSystem;
using Exiled.API.Features;
using Exiled.Events.Handlers;
using FL_Main.Hints;
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
        private readonly Config _config;
        public string Command { get; set; } = "buddy";

        public string[] Aliases { get; set; } = new string[] { "bud" };

        public string Description { get; set; } = "You can Buddy with your friends, args 'accept' or '{Player name}'";

        private readonly bool _enabled = false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (_enabled && _config.BuddySytemEnabled)
            {
                if (Exiled.API.Features.Round.IsStarted)
                {
                    response = "Round has already started";
                    return true;
                }
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
                response = "Error that command doesnt work, please do not report this, this is not a bug, command is disabled";
                return true;
            }
        }
        private string HandleBuddyCommand(Player p, string[] args)
        {
            HintSystem hintSystem = new HintSystem();
            //get the player who the request was sent to
            Player buddy = null;

            string lower = args[0].ToLower();
            if (lower == "accept")
            {
                Dictionary<string,Exiled.API.Features.Player> Values = Plugin.singleton.buddyRequests;
                foreach (Player value in Values.Values)
                {
                    if (value == p) 
                    {
                        foreach (string key in Values.Keys)
                        {
                            if (Values[key] == p )
                            {
                                Plugin.singleton.buddyRequests.Remove(key);
                                Plugin.singleton.buddies.Add(key, p.UserId);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Player player1 in Player.List)
                {
                    if (player1 == null) continue;
                    if (player1.Nickname.ToLower().Contains(lower) && player1.UserId != p.UserId)
                    {
                        buddy = player1;
                        break;
                    }
                }
                if (buddy == null)
                {
                    return "That player is not a player";
                }
                Plugin.singleton.buddyRequests.Add(p.UserId, buddy);
                hintSystem.ShowHint($"You have a buddy request from {p.Nickname}", buddy, 5);
                return $"Buddy Request sent to {buddy.Nickname}";
            }
            return "Some error has occured in the HandleBuddyCommand function on the code side. please tell a admin to report this issue";
        }
    }
}