using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using FL_Main.EventHandlers;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
using Player = Exiled.Events.Handlers.Player;
using FL_Main.Commands;
using System.Collections.Generic;

namespace FL_Main
{
    public class Plugin : Plugin<Config>
    {
        private readonly MapHandlers MapHandlers = new MapHandlers();
        private readonly ServerHandlers serverHandlers = new ServerHandlers();
        private readonly PlayerHandlers playerHandlers = new PlayerHandlers();
        /// <inheritdoc/>
        public override string Name { get; } = "FL Main Plugin";

        /// <inheritdoc/>
        public override string Prefix { get; } = "FLMain";

        /// <inheritdoc/>
        public override string Author { get; } = "Dashtiss";



        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1,3,1);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(8, 2, 1);




        public Dictionary<string, string> buddies = new Dictionary<string, string>();

        public Dictionary<string, Exiled.API.Features.Player> buddyRequests = new Dictionary<string, Exiled.API.Features.Player>();

        public bool WeaponDeliverySystemEnable = true;

        public MEC.CoroutineHandle supplyDropCoroutine;


        public static Plugin singleton;





        public override void OnEnabled()
        {
            Server.RespawningTeam += MapHandlers.OnRespawningTeam;
            Warhead.Detonated += MapHandlers.OnDetonated;

            Server.RoundStarted += serverHandlers.OnRoundStarted;
            Server.RoundEnded += serverHandlers.OnRoundEnded;

            Player.UsingRadioBattery += playerHandlers.UsingRadioBattery;
            Log.Info("FL-Main Plugin All Registered");

            WeaponDeliverySystemEnable = Config.EnableSupplyDrops;


            base.OnEnabled();
        }
        public override void OnDisabled()
        {

            Server.RespawningTeam -= MapHandlers.OnRespawningTeam;
            Warhead.Detonated -= MapHandlers.OnDetonated;
            Server.RoundStarted -= serverHandlers.OnRoundStarted;
            Log.Info("FL-Main Plugin All Unregistered");
            base.OnDisabled();
        }
    }
}
