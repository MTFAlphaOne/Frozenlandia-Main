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
    public class GetCoins : ICommand
    {
        public string Command { get; } = "getcoins";

        public string[] Aliases { get; } = new string[] { "mycoins", "coins" };

        public string Description { get; } = "Will tell you how many coins you have on the server";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "null";
                return false;
            }
            if (Plugin.singleton.Coins.ContainsKey(player))
            {
                response = $"You have {Plugin.singleton.Coins[player]} coins";
                return true;
            }
            response = "a Error has occured and you have no coins";
            return false;
        }
    }
}
