using CommandSystem;
using Exiled.API.Features;
using FL_Main.Hints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TestHint : ICommand
    {
        public string Command { get; set; } = "testHint";

        public string[] Aliases { get; set; } = new string[] { "TH" };

        public string Description { get; set; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((CommandSender)sender).SenderId);
            HintSystem hintSystem = new HintSystem();
            string test = string.Empty;
            foreach (string arg in arguments)
            {
                test += arg.ToString();
            }
            hintSystem.ShowHint(test, player);
            response = test;
            return true;
        }
    }
}
