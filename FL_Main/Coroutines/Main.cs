using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Coroutines
{
    public class Main
    {
        public IEnumerator<float> PlayerTime()
        {
            yield return Timing.WaitForSeconds(0.01f);
            foreach (Player ply in Player.List)
            {
                Plugin.singleton.PlayerTime[ply] += 0.01f;
            }
        }
    }
}
