using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Patches.Generic;
using FL_Main.Commands;
using FL_Main.ConfigObjects;
using FL_Main.Coroutines;
using LiteDB;
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
        private readonly Config config = new Config();
        private readonly SupplyDrop supplyDrop = new SupplyDrop();
        private readonly BuddyHandler buddyHandler = new BuddyHandler();
        public void OnRoundStarted()
        {
            if (supplyDrop != null)
            {
                Plugin.singleton.supplyDropCoroutine = Timing.RunCoroutine(supplyDrop.MyCoroutine());
                // Plugin.singleton.SCPDamage.Clear();
                // Plugin.singleton.SCPKills.Clear();
            }
            else
            {
                Log.Warn("Error With suppy drop being null");
            }
            buddyHandler.OnRoundStart();
        }
        public void OnRoundEnded(ServerArgs.RoundEndedEventArgs ev)
        {
            Log.Debug($"end of round lead team was {ev.LeadingTeam} and will be restarting in {ev.TimeToRestart}");
            Server.FriendlyFire = true;
        }
        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            ev.TimeToRestart = 5;
            
            using (var db = new LiteDatabase(Plugin.singleton.DatabasePath))
            {
                var playerCoinsCollection = db.GetCollection<PlayerCoin>("PlayerCoins");

                // Clear the existing data in the collection
                playerCoinsCollection.DeleteAll();

                // Create a list to store all the PlayerCoins
                var playerCoinList = new List<PlayerCoin>();

                foreach (var entry in Plugin.singleton.Coins)
                {
                    // Create a PlayerCoin object for each key-value pair
                    var playerCoin = new PlayerCoin
                    {
                        Player = entry.Key,
                        CoinAmount = entry.Value
                    };

                    // Add the PlayerCoin to the list
                    playerCoinList.Add(playerCoin);
                }

                // Insert the entire list into the LiteDB collection
                playerCoinsCollection.InsertBulk(playerCoinList);
            }
        }
    }
}
