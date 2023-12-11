using CommandSystem;
using FL_Main.Coroutines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class ListDataBase : ICommand
    {
        public  string Command { get; } = "Will List out the DataBase";

        public  string[] Aliases { get; } = new string[] { "WepDel" };

        public  string Description { get; } = "This will Force a Weapon Delivery. Must be 'chaos' or 'mtf'";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string test = string.Empty;
            foreach (var Coin in Plugin.singleton.Coins)
            {
                test += $"Player {Coin.Key} has {Coin.Value} coins\n";
            }
            test += "Player time\n";
            foreach (var player in Plugin.singleton.PlayerTime)
            {
                test += $"Player {player.Key} has {player.Value} time on server\n";
            }
            response = test;
            return true;
        }
    }
}
