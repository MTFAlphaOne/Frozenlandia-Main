using FL_Main.Coroutines;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server = Exiled.Events.Handlers.Server;
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
    }
}
