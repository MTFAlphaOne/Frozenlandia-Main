using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using FL_Main.ConfigObjects;
using LiteDB;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FL_Main.EventHandlers
{
    public class PlayerHandlers
    {
        private readonly Config.Config config = Plugin.singleton.Config;
        public void UsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            
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
            Timing.RunCoroutine(Elevator(ev));
        }
        private IEnumerator<float> Elevator(InteractingElevatorEventArgs ev)
        {
            Random random = new Random();
            float minValue = -1f;
            float maxValue = 1f;
            float time = ev.Lift.AnimationTime;
            float Randflt = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
            time += Randflt;
            yield return Timing.WaitForSeconds(ev.Lift.DoorCloseTime);
            ev.Lift.AnimationTime = time;
            yield return Timing.WaitForSeconds(time + (-1 * Randflt));
            ev.Lift.AnimationTime = time + (-1 * Randflt);
            yield break;


        }

        public void OnVerified(VerifiedEventArgs ev)
        {
            if (ev.Player == null) { return; }
            using (var db = new LiteDatabase(Plugin.singleton.DatabasePath))
            {
                var playerCoinsCollection = db.GetCollection<Dictionary<Player, int>>("PlayerCoins");
                foreach (var playerCoins in playerCoinsCollection.FindAll())
                {
                    if (playerCoins.ContainsKey(ev.Player))
                    {
                        // Update the dictionary with the loaded data
                        Plugin.singleton.Coins[ev.Player] = playerCoins[ev.Player];
                    }
                    else
                    {
                        Plugin.singleton.Coins.Add(ev.Player, 0);
                    }
                }
            }
        }
    }
}
