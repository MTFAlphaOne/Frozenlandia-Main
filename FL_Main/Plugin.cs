using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.Handlers;
using MEC;
using UnityEngine;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
namespace FL_Main
{
    public class Plugin : Plugin<Config>
    {
        private readonly MapHandlers MapHandlers = new MapHandlers();
        /// <inheritdoc/>
        public override string Name { get; } = "FL Main Plugin";

        /// <inheritdoc/>
        public override string Prefix { get; } = "FLMain";

        /// <inheritdoc/>
        public override string Author { get; } = "Dashtiss";

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.High;

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1,0,0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(8, 2, 1);

        public override void OnEnabled()
        {
            
            base.OnEnabled();
        }
        public override void OnDisabled()
        {

            base.OnDisabled();
        }
        private void RegisterEvents()
        {
            Server.RespawningTeam += MapHandlers.OnRespawningTeam;
            Warhead.Detonated += MapHandlers.OnDetonated;
        }

    }
}
