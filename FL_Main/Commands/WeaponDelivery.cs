using CommandSystem;
using Exiled.API.Features;
using FL_Main.Coroutines;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class WeaponDelivery : ParentCommand
    {
        public override string Command { get; } = "WeaponDelivery";

        public override string[] Aliases { get; } = new string[] { "WepDel" };

        public override string Description { get; } = "This will Force a Weapon Delivery. Must be 'chaos' or 'mtf'";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            try
            {
                SupplyDrop supplyDrop = new SupplyDrop();
                // Check if there is at least one argument
                if (arguments.Count > 0)
                {
                    switch (arguments.At(0).ToLower())
                    {
                        case "mtf":
                            // Call the MTFHelp method from the SupplyDrop class
                            // You need an instance of SupplyDrop to call its methods
                            supplyDrop.MTFHelp();
                            response = "MTF weapon delivery initiated.";
                            return true;

                        case "chaos":
                            // Handle the "chaos" case here if needed
                            supplyDrop.ChaosHelp();
                            response = "Chaos Weapon Delivery iniiated";
                            return true;

                        default:
                            response = "Invalid argument. Usage: WeaponDelivery mtf/chaos";
                            return false;
                    }
                }
                else
                {
                    response = "Missing argument. Usage: WeaponDelivery mtf/chaos";
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                Log.Warn($"Error User {sender} Ran Command WeaponDelivery with args {arguments}. Error: {ex}");
                response = "A Error Occured. look at your console and talk to @Dashtiss about this";
                return false;
            }
        }
    }
}
