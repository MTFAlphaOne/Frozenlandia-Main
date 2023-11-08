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
    public class ListDataBase : ParentCommand
    {
        public override string Command { get; } = "Will List out the DataBase";

        public override string[] Aliases { get; } = new string[] { "WepDel" };

        public override string Description { get; } = "This will Force a Weapon Delivery. Must be 'chaos' or 'mtf'";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string test = string.Empty;
            foreach (var Coin in Plugin.singleton.Coins)
            {
                test += $"Player {Coin.Key} has {Coin} coins\n";
            }
            response = test;
            return true;
        }
    }
}
