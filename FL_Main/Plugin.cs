using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using FL_Main.EventHandlers;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
using Player = Exiled.Events.Handlers.Player;
using System.Collections.Generic;
using MEC;
using FL_Main.Coroutines;
using LiteDB;
using System.IO;
using FL_Main.ConfigObjects;

namespace FL_Main
{
    /// <summary>
    /// This is the Main Plugin File
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        /// <inheritdoc/>
        public override string Name { get; } = "FrozenLandia Main Plugin";

        /// <inheritdoc/>
        public override string Prefix { get; } = "FrozenLandia";

        /// <inheritdoc/>
        public override string Author { get; } = "Dashtiss & Frozenlandia";

        public override PluginPriority Priority { get; } = PluginPriority.Higher;



        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 8, 3);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(8, 4, 0);


        // all the variables to make this plugin work. ahhhh


        public Dictionary<Exiled.API.Features.Player, float> SCPDamage = new Dictionary<Exiled.API.Features.Player, float>();

        public Dictionary<Exiled.API.Features.Player, int> SCPKills = new Dictionary<Exiled.API.Features.Player, int>();


        public Dictionary<string, string> buddies = new Dictionary<string, string>();

        public Dictionary<string, Exiled.API.Features.Player> buddyRequests = new Dictionary<string, Exiled.API.Features.Player>();

        public bool WeaponDeliverySystemEnable = false;

        public CoroutineHandle supplyDropCoroutine;


        public static Plugin singleton = new Plugin();


        public bool DevBuild = false;

        public Dictionary<Exiled.API.Features.Player, int> Coins = new Dictionary<Exiled.API.Features.Player, int>();

        public Dictionary<Exiled.API.Features.Player, float> PlayerTime = new Dictionary<Exiled.API.Features.Player, float>();

        public string DatabasePath;

        public Dictionary<string, string> PlayerNicks = new Dictionary<string, string>();

        public override void OnEnabled()
        {

            RegisterEvents();

            Directory.CreateDirectory(Config.SavePath);

           
            // Gets all the stuff and sees if it is a dev build

            if (DevBuild)
            {
                Log.Warn("This is a dev Build of FL-Main. Some Features are in testing and may break the server");
            }





            DatabasePath = $"{Config.SavePath}/{Config.DatabaseName}";

            using (var db = new LiteDatabase(DatabasePath))
            {
                var playerCoinsCollection = db.GetCollection<PlayerCoin>("PlayerCoins");

                // Clear the existing data in the dictionary
                Coins.Clear();

                foreach (var playerCoin in playerCoinsCollection.FindAll())
                {
                    // Populate the Plugin.singleton.Coins dictionary with data from the database
                    Coins[playerCoin.Player] = playerCoin.CoinAmount;
                }

                var PyTime = db.GetCollection < Dictionary < Exiled.API.Features.Player, float>>("PlayerTime");
                foreach (var vale in PyTime.FindAll())
                {
                    foreach (var player in vale.Keys)
                    {
                        PlayerTime[player] = vale[player];
                    }
                }
            }

            singleton.WeaponDeliverySystemEnable = Config.EnableSupplyDrops;


            base.OnEnabled();
        }
        
        public override void OnDisabled()
        {
            UnRegisterEvents();


            Timing.KillCoroutines();
            Log.Warn("FL-Main is disables and all coin systems will be down and the API too.");
            
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            UnRegisterEvents();
            RegisterEvents();
            base.OnReloaded();
        }


        private void RegisterEvents()
        {
            MapHandlers MapHandlers = new MapHandlers();
            ServerHandlers serverHandlers = new ServerHandlers();
            PlayerHandlers playerHandlers = new PlayerHandlers();
            BuddyHandler buddyHandler = new BuddyHandler();
            Main mainCoroutine = new Main();
            Server.RespawningTeam += MapHandlers.OnRespawningTeam;
            Warhead.Detonated += MapHandlers.OnDetonated;

            Server.RoundStarted += serverHandlers.OnRoundStarted;
            Server.RoundEnded += serverHandlers.OnRoundEnded;

            Player.UsingRadioBattery += playerHandlers.UsingRadioBattery;
            Player.InteractingElevator += playerHandlers.InteractingWithElevator;
            

            Server.RoundStarted += buddyHandler.OnRoundStart;
            Timing.RunCoroutine(mainCoroutine.PlayerTime());


           
            // Player.Hurting += SCPHandlers.OnHurting;
            // Player.ChangingRole += playerHandlers.ChangeRole;
            // Timing.RunCoroutine((IEnumerator<float>)SCPHandlers.SCPHints());




            // This is the handlers for all the coins system
            CoinsEvents coinsEvents = new CoinsEvents();
            Player.Died += coinsEvents.OnPlayerDeath;



            Log.Info("FL-Main Plugin All Registered");
        }



        private void UnRegisterEvents()
        {
            MapHandlers MapHandlers = null;
            ServerHandlers serverHandlers = null;
            PlayerHandlers playerHandlers = null;
            BuddyHandler buddyHandler = null;
            Main mainCoroutine = null;
            Server.RespawningTeam -= MapHandlers.OnRespawningTeam;
            Warhead.Detonated -= MapHandlers.OnDetonated;

            Server.RoundStarted -= serverHandlers.OnRoundStarted;
            Server.RoundEnded -= serverHandlers.OnRoundEnded;

            Player.UsingRadioBattery -= playerHandlers.UsingRadioBattery;
            Player.InteractingElevator -= playerHandlers.InteractingWithElevator;
            

            Server.RoundStarted -= buddyHandler.OnRoundStart;
            Timing.RunCoroutine(mainCoroutine.PlayerTime());
            singleton.WeaponDeliverySystemEnable = Config.EnableSupplyDrops;

            // Player.Hurting += SCPHandlers.OnHurting;
            // Player.ChangingRole += playerHandlers.ChangeRole;
            // Timing.RunCoroutine((IEnumerator<float>)SCPHandlers.SCPHints());
            Log.Info("FL-Main Plugin All Unregistered");
        }
    }
}
