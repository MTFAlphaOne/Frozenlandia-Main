using Exiled.API.Features;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.Coroutines
{
    public class BuddyHandler
    {
        public void OnRoundStart()
        {
            Config cfg = new Config();
            Random rnd = new Random();

            /*Dictionary<RoleTypeId, int> roles = new Dictionary<RoleTypeId, int>();
            foreach (Player ply in Player.List)
            {
                roles[ply.Role.Type]++;
            }*/


            Dictionary<string, string> buddys = Plugin.singleton.buddies;
            foreach (String buddy in buddys.Keys) 
            {
                Player Player = Player.Get(buddy);
                Player buddyPlayer = Player.Get(buddys[buddy]);
                if (Player == null) continue;
                if (buddyPlayer == null) continue;

                int index = rnd.Next(cfg.SpawnAbleRoles.Count());
                RoleTypeId role = cfg.SpawnAbleRoles[index];
                Player.Role.Set(role);
                buddyPlayer.Role.Set(role);
            }
            bool ISSCP = false;
            foreach (Player ply in Player.List)
            {
                if (ply.IsScp)
                {
                    ISSCP = true;
                    break;
                }
            }
            if (!ISSCP)
            {
                Config config = new Config();
                List<string> options = new List<string> { };
                foreach (string key in buddys.Keys)
                {
                    options.Add(key);
                    options.Add(buddys[key]);
                }
                Random rad = new Random();
                int index = rad.Next(options.Count);
                Player player = Player.Get(options[index]);
                int scpIndex = rad.Next(config.SCPNeeded.Count);
                RoleTypeId role = config.SCPNeeded[scpIndex];
                player.Role.Set(role);
            }
        }
    }
}
