using Exiled.API.Enums;
using Exiled.API.Features;
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
                    if (Plugin.singleton.Coins.TryGetValue(ev.Attacker, out int attackerCoins))
                    {
                        Plugin.singleton.Coins[ev.Attacker] = attackerCoins + config.KillCost;
                        SendHint(ev.Player, config.KillCost);
                    }
                    else
                    {
                        Plugin.singleton.Coins.Add(ev.Attacker, config.KillCost);
                        SendHint(ev.Player, config.KillCost);
                    }

                }
            }
        }
        public void PlayerEscaping(EscapingEventArgs ev)
        {
            if (ev.EscapeScenario != EscapeScenario.CuffedClassD || ev.EscapeScenario != EscapeScenario.CuffedScientist)
            {
                if (Plugin.singleton.Coins.ContainsKey(ev.Player))
                {
                    Plugin.singleton.Coins[ev.Player] += config.EscapeCost;
                    SendHint(ev.Player, config.EscapeCost);
                }
                else
                {
                    Plugin.singleton.Coins.Add(ev.Player, config.EscapeCost);
                    SendHint(ev.Player, config.EscapeCost);
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
                    Plugin.singleton.Coins[ev.Player] += config.CoinCost;
                    SendHint(ev.Player, config.CoinCost);
                }
                else
                {
                    Plugin.singleton.Coins.Add(ev.Player, config.CoinCost);
                    SendHint(ev.Player, config.CoinCost);
                }
            }
        }
        public void OnItemUsed(UsingItemEventArgs ev)
        {
            if (config.ItemAmmount.ContainsKey(ev.Item.Type))
            {
                if (Plugin.singleton.Coins.ContainsKey(ev.Player))
                {
                    Plugin.singleton.Coins[ev.Player] += config.ItemAmmount[ev.Item.Type];
                    SendHint(ev.Player, config.ItemAmmount[ev.Item.Type]);
                }
                else
                {
                    Plugin.singleton.Coins.Add(ev.Player, config.ItemAmmount[ev.Item.Type]);
                    SendHint(ev.Player, config.ItemAmmount[ev.Item.Type]);
                }
            }
        }
        private void SendHint(Player player, int NewCoins) 
        {
            string response = config.PlayerGetsCoins;
            if (response.Contains("{coins}"))
            {
                response.Replace("{coins}", NewCoins.ToString());
            }
            player.ShowHint(response);
        }
    }
}
