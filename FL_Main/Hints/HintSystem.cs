using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Hints
{
    public class HintSystem
    {
        public void ShowHint(string hint, Player player, int duration=3)
        {
            player.ShowHint(hint, duration);
        }
    }
}
