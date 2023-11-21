using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using FL_Main.EventHandlers;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
using Player = Exiled.Events.Handlers.Player;
using FL_Main.Commands;
using System.Collections.Generic;
using MEC;
using FL_Main.Coroutines;
using LiteDB;
using System.IO;
using FL_Main.ConfigObjects;
using YamlDotNet.Serialization;

namespace FL_Main
{
    public class Plugin : Plugin<Config.Config>
    {
        /// <inheritdoc/>
        public override string Name { get; } = "FL Main Plugin";

        /// <inheritdoc/>
        public override string Prefix { get; } = "FL-Main";

        /// <inheritdoc/>
        public override string Author { get; } = "Dashtiss & Frozenlandia";



        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 7, 1);

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


        public bool DevBuild = true;

        public Dictionary<Exiled.API.Features.Player, int> Coins = new Dictionary<Exiled.API.Features.Player, int>();

        public Dictionary<Exiled.API.Features.Player, float> PlayerTime = new Dictionary<Exiled.API.Features.Player, float>();

        public string DatabasePath;

        public override void OnEnabled()
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
            Log.Info("FL-Main Plugin All Registered");

            Server.RoundStarted += buddyHandler.OnRoundStart;
            Timing.RunCoroutine(mainCoroutine.PlayerTime());
            singleton.WeaponDeliverySystemEnable = Config.EnableSupplyDrops;
            // Player.Hurting += SCPHandlers.OnHurting;
            // Player.ChangingRole += playerHandlers.ChangeRole;
            // Timing.RunCoroutine((IEnumerator<float>)SCPHandlers.SCPHints());

            Log.Warn($"{Config.SavePath}");
            Directory.CreateDirectory(Config.SavePath);

           
            // Gets all the stuff and sees if it is a dev build

            if (DevBuild)
            {
                Log.Warn("This is a dev Build of FL-Main");
            }

            DatabasePath = $"{Config.SavePath}/{Config.DatabaseName}";

            using (var db = new LiteDatabase(DatabasePath))
            {
                var playerCoinsCollection = db.GetCollection<PlayerCoin>("PlayerCoins");

                // Clear the existing data in the dictionary
                Plugin.singleton.Coins.Clear();

                foreach (var playerCoin in playerCoinsCollection.FindAll())
                {
                    // Populate the Plugin.singleton.Coins dictionary with data from the database
                    Plugin.singleton.Coins[playerCoin.Player] = playerCoin.CoinAmount;
                }

                var PyTime = db.GetCollection < Dictionary < Exiled.API.Features.Player, float>>("PlayerTime");
                foreach (var vale in PyTime.FindAll())
                {
                    foreach (var player in vale.Keys)
                    {
                        Plugin.singleton.PlayerTime[player] = vale[player];
                    }
                }
            }

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            MapHandlers MapHandlers = new MapHandlers();
            ServerHandlers serverHandlers = new ServerHandlers();
            PlayerHandlers playerHandlers = new PlayerHandlers();
            SCPHandlers SCPHandlers = new SCPHandlers();

            Server.RespawningTeam -= MapHandlers.OnRespawningTeam;
            Warhead.Detonated -= MapHandlers.OnDetonated;

            Server.RoundStarted -= serverHandlers.OnRoundStarted;
            Server.RoundEnded -= serverHandlers.OnRoundEnded;

            Player.UsingRadioBattery -= playerHandlers.UsingRadioBattery;

            //Player.Hurting -= SCPHandlers.OnHurting;
            //Player.ChangingRole -= playerHandlers.ChangeRole;

            Timing.KillCoroutines();
            Log.Info("FL-Main Plugin All Unregistered");
            base.OnDisabled();
        }
    }
}
