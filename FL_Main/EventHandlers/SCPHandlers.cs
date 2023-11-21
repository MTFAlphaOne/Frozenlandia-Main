using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using FL_Main.Hints;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FL_Main.EventHandlers
{
    public class SCPHandlers
    {
        


        public IEnumerator<float> SCPHints()
        {
            yield return Timing.WaitForSeconds(0.1f);
            foreach (Player ply in Player.List)
            {
                Log.Debug($"Player Checking {ply.DisplayNickname}");
                if (ply == null) {continue;}
                if (ply.IsScp)
                {
                    Log.Debug("Player is a SCP");
                    if (!Plugin.singleton.SCPDamage.ContainsKey(ply))
                    {
                        Log.Debug("adding player to SCPDammage");
                        Plugin.singleton.SCPDamage[ply] = 0;
                    }
                    if (!Plugin.singleton.SCPKills.ContainsKey(ply))
                    {
                        Log.Debug("adding player to Plugin.singleton.SCPKills");
                        Plugin.singleton.SCPKills[ply] = 0;

                    }
                    Log.Debug($"{ply.DisplayNickname} is getting shown the hint");
                    ply.ShowHint($"<align=\"left\"><voffset=1000em><b><color=#ed0606ff>You have done {{Plugin.singleton.SCPDamage[ply]}} damage and have {{Plugin.singleton.SCPKills[ply]}} Kills</color></b></voffset>", 0.1f);

                }
            }
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if (Plugin.singleton.SCPDamage.ContainsKey(ev.Attacker))
            {
                Plugin.singleton.SCPDamage[ev.Attacker] += ev.Amount;
            }
           
        }
        public void OnDeath(DiedEventArgs ev)
        {
            if (Plugin.singleton.SCPKills.ContainsKey(ev.Attacker))
            {
                Plugin.singleton.SCPKills[ev.Attacker]++;
            }
            else
            {
                if (ev.Attacker.IsScp)
                {
                    Plugin.singleton.SCPKills.Add(ev.Attacker, 1);
                }
            }
        }
    }
}
