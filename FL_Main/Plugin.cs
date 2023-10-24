using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using FL_Main.EventHandlers;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
namespace FL_Main
{
    public class Plugin : Plugin<Config>
    {
        private readonly MapHandlers MapHandlers = new MapHandlers();
        private readonly ServerHandlers serverHandlers = new ServerHandlers();
        /// <inheritdoc/>
        public override string Name { get; } = "FL Main Plugin";

        /// <inheritdoc/>
        public override string Prefix { get; } = "FLMain";

        /// <inheritdoc/>
        public override string Author { get; } = "Dashtiss";



        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1,2,0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(8, 2, 1);

        public override void OnEnabled()
        {
            Server.RespawningTeam += MapHandlers.OnRespawningTeam;
            Warhead.Detonated += MapHandlers.OnDetonated;
            Server.RoundStarted += serverHandlers.OnRoundStarted;
            Log.Info("FL-Main Plugin All Registered");

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
