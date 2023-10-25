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
        public void OnRoundStarted()
        {
            SupplyDrop supplyDrop = new SupplyDrop();
            Timing.RunCoroutine(supplyDrop.MyCoroutine());
        }
#pragma warning disable IDE0060 // Remove unused parameter
        public void OnRoundEnded(ServerArgs.RoundEndedEventArgs ev)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            Exiled.API.Features.Server.FriendlyFire = true;
        }
    }
}
