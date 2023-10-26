using Exiled.API.Features;
using Exiled.Events.Patches.Generic;
using FL_Main.Commands;
using FL_Main.Coroutines;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerArgs = Exiled.Events.EventArgs.Server;
namespace FL_Main.EventHandlers
{
    public class ServerHandlers
    {
        private readonly Config config;

        public void OnRoundStarted()
        {
            if (config.EnableSupplyDrops)
            {
                SupplyDrop supplyDrop = new SupplyDrop();
                Timing.RunCoroutine(supplyDrop.MyCoroutine());
            }
        }
        public void OnRoundEnded(ServerArgs.RoundEndedEventArgs ev)
        {
            
            if (config.FriendlyFireAtEndOfRound)
            {
                Log.Debug($"end of round lead team was {ev.LeadingTeam} and will be restarting in {ev.TimeToRestart}");
                Server.FriendlyFire = true;
            }
        }
    }
}
