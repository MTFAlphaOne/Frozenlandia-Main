using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class GetPlayTime : ICommand
    {
        public string Command { get; } = "gettime";

        public string[] Aliases { get; } = new string[] { "mytime", "time"};

        public string Description { get; } = "Will get how much time you have played on the server";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = sender as Player;
            if (sender == null)
            {
                response = null;
                return false;
            }
            response = string.Empty;
            if (Plugin.singleton.PlayerTime.ContainsKey(player))
            {
                response = $"You have {Math.Round(Plugin.singleton.PlayerTime[player] / 60)} hours and {Math.Round(Plugin.singleton.PlayerTime[player] - (Math.Round(Plugin.singleton.PlayerTime[player] / 60) * 60))}";
                return true;
            }
            response = "a Error has occured and you have no time";
            return false;
        }
    }
}
