using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player = Exiled.Events.EventArgs.Player;
namespace FL_Main.EventHandlers
{
    public class PlayerHandlers
    {
        public void UsingRadioBattery(Player.UsingRadioBatteryEventArgs ev)
        {
            Config config = new Config();
            if (config.UnlimitedRadioBattery)
            {
                ev.Radio.BatteryLevel = 100;
                ev.Drain = 0f;
            }
            else
            {
                ev.Drain *= config.BatteryPowerLoss;
            }
        }
        /* public void ChangeRole(ChangingRoleEventArgs ev)
        {
            
            if (ev.Player.IsScp)
            {
        Log.Debug($"Player {ev.Player.DisplayNickname} is now a SCP");

                Plugin.singleton.SCPKills.Add(ev.Player, 0);
                Plugin.singleton.SCPDamage.Add(ev.Player, 0);
            }
            else if (ev.Player.Role == RoleTypeId.Spectator && Plugin.singleton.SCPKills.ContainsKey(ev.Player) || Plugin.singleton.SCPDamage.ContainsKey(ev.Player))
            {
                Plugin.singleton.SCPKills.Remove(ev.Player);
                Plugin.singleton.SCPDamage.Remove(ev.Player);
            }
        }*/
        public void InteractingWithElevator(InteractingElevatorEventArgs ev)
        {
            Random random = new Random();
            float minValue = -1.5f;
            float maxValue = 1.5f;
            float time = ev.Lift.AnimationTime;
            time += (float)random.NextDouble() * (maxValue - minValue) + minValue;
            ev.Lift.AnimationTime = time;
        }
    }
}
