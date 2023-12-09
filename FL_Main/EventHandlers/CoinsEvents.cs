using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.EventHandlers
{
    public class CoinsEvents
    {
        public void OnPlayerDeath(Exiled.Events.EventArgs.Player.DiedEventArgs ev)
        {
            if (ev != null)
            {
                if (ev.Player != null)
                {
                    Plugin.singleton.Coins[ev.Attacker] += 5;
                }
            }
        }
    }
}
