using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Coroutines
{
    public class BuddyHandler
    {

        public IEnumerable<float> Buddy()
        {
            yield return Timing.WaitForSeconds(1);
            yield break;
        }
    }
}
