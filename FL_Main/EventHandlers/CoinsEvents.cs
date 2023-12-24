using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.EventHandlers
{
    public class CoinsEvents
    {
        private readonly Config config = Plugin.singleton.Config;


        public void OnPlayerDeath(DiedEventArgs ev)
        {
            if (ev != null)
            {
                if (ev.Attacker != null)
                {
                    Plugin.singleton.Coins[ev.Attacker] += config.KillCost;
                }
            }
        }
        public void PlayerEscaping(EscapingEventArgs ev)
        {
            if (ev.EscapeScenario != EscapeScenario.CuffedClassD || ev.EscapeScenario != EscapeScenario.Scientist)
            {
                if (Plugin.singleton.Coins.ContainsKey(ev.Player))
                {
                    Plugin.singleton.Coins[ev.Player] += config.EscapeCost;
                }
                else
                {
                    Plugin.singleton.Coins.Add(ev.Player, config.EscapeCost);
                }
            }
        }
        public void OnCoinFlip(FlippingCoinEventArgs ev)
        {
            Random ran = new Random();
            if (config.CoinChance >= ran.Next(1, 100)) {
                ev.IsTails = true;
                if (Plugin.singleton.Coins.ContainsKey(ev.Player))
                {
                    Plugin.singleton.Coins[ev.Player] += config.EscapeCost;
                }
                else
                {
                    Plugin.singleton.Coins.Add(ev.Player, config.EscapeCost);
                }
            }
        }
    }
}
