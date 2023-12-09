using CommandSystem;
using Exiled.API.Features;
using FL_Main.Coroutines;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
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

        private readonly Config config;
        private readonly SupplyDrop supplyDrop;
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!config.EnableSupplyDrops)
            {
                response = "Supply drops are disabled in config";
                return true;

            }
            try
            {
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

                        case "disable":
                           
                            Plugin.singleton.WeaponDeliverySystemEnable = false;
                            Timing.KillCoroutines(Plugin.singleton.supplyDropCoroutine);
                            response = "Weapons will now stop";
                            return true;
                        case "enable":
                            Plugin.singleton.WeaponDeliverySystemEnable = true;
                            Plugin.singleton.supplyDropCoroutine = Timing.RunCoroutine(supplyDrop.MyCoroutine());
                            response = "Weapons will now continue";
                            return true;

                        default:
                            response = string.Empty;
                            if (Plugin.singleton.WeaponDeliverySystemEnable)
                            {
                                response = "Current Status of Weapons Delivery: Enabled. Usage: WeaponDelivery mtf/chaos or disable/enable";
                            }
                            else
                            {
                                response = $" Current Status of Weapons Delivery Disabled. Usage: WeaponDelivery mtf/chaos or disable/enable";
                            }
                            return true;
                    }
                }
                else
                {
                    response = string.Empty;
                    if (Plugin.singleton.WeaponDeliverySystemEnable)
                    {
                        response = "Current Status of Weapons Delivery: Enabled. Usage: WeaponDelivery mtf/chaos or disable/enable";
                    }
                    else
                    {
                        response = $" Current Status of Weapons Delivery Disabled. Usage: WeaponDelivery mtf/chaos or disable/enable";
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                
                Log.Warn($"Error User {sender} Ran Command WeaponDelivery with args {arguments}. Error: {ex}");
                response = "A Error Occured. look at your console and talk to @Dashtiss about this";
                return true;
            }
        }
    }
}
