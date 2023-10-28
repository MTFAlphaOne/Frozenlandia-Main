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

namespace FL_Main
{
    public class Plugin : Plugin<Config>
    {
        private Config _config;

        /// <inheritdoc/>
        public override string Name { get; } = "FL Main Plugin";

        /// <inheritdoc/>
        public override string Prefix { get; } = "FLMain";

        /// <inheritdoc/>
        public override string Author { get; } = "Dashtiss";



        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 3, 2);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(8, 2, 1);


        // all the variables to make this plugin work. ahhhh


        public Dictionary<Exiled.API.Features.Player, float> SCPDamage = new Dictionary<Exiled.API.Features.Player, float>();

        public Dictionary<Exiled.API.Features.Player, int> SCPKills = new Dictionary<Exiled.API.Features.Player, int>();


        public Dictionary<string, string> buddies = new Dictionary<string, string>();

        public Dictionary<string, Exiled.API.Features.Player> buddyRequests = new Dictionary<string, Exiled.API.Features.Player>();

        public bool WeaponDeliverySystemEnable { get; set; } = true;

        public CoroutineHandle supplyDropCoroutine;


        public static Plugin singleton = new Plugin();


        public bool DevBuild = true;



        public override void OnEnabled()
        {

            MapHandlers MapHandlers = new MapHandlers();
            ServerHandlers serverHandlers = new ServerHandlers();
            PlayerHandlers playerHandlers = new PlayerHandlers();
            SCPHandlers SCPHandlers = new SCPHandlers();

            Server.RespawningTeam += MapHandlers.OnRespawningTeam;
            Warhead.Detonated += MapHandlers.OnDetonated;

            Server.RoundStarted += serverHandlers.OnRoundStarted;
            Server.RoundEnded += serverHandlers.OnRoundEnded;

            Player.UsingRadioBattery += playerHandlers.UsingRadioBattery;
            Player.InteractingElevator += playerHandlers.InteractingWithElevator;
            Log.Info("FL-Main Plugin All Registered");

            // Player.Hurting += SCPHandlers.OnHurting;
            // Player.ChangingRole += playerHandlers.ChangeRole;
            // Timing.RunCoroutine((IEnumerator<float>)SCPHandlers.SCPHints());


            WeaponDeliverySystemEnable = Config.EnableSupplyDrops;


            // Gets all the stuff and sees if it is a dev build

            if (DevBuild)
            {
                Log.Warn("This is a dev Build of FL-Main");
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
