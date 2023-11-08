using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FL_Main.ConfigObjects;
using UnityEngine;
using PlayerRoles;
using System.IO;
using Exiled.API.Features;

namespace FL_Main
{
    public class Config : IConfig
    {
        // Main Plugin Settings
        [Description("Enable the main plugin")]
        public bool IsEnabled { get; set; } = true;
        [Description("Enable debug mode")]
        public bool Debug { get; set; } = false;

        // Supply Drops
        [Description("Enable supply drops")]
        public bool EnableSupplyDrops { get; set; } = true;
        [Description("Time until supply drop (minutes)")]
        public float SupplyDropMinutes { get; set; } = 6;
        [Description("Supply drop time randomization")]
        public SupplyDropConfigRandom SupplyDropConfigs { get; set; } = new SupplyDropConfigRandom
        {
            IsRandomTimeAllowed = true,
            Min = 30,
            Max = 90,
        };

        // Items that can spawn during MTF delivery
        [Description("Items during MTF delivery")]
        public List<ItemSpawn> MTFItems { get; set; } = new List<ItemSpawn>
        {
            new ItemSpawn
            {
                Item = ItemType.GunE11SR,
                MinAmmount = 4,
                MaxAmmount = 4
            },
            new ItemSpawn
            {
                Item = ItemType.Adrenaline,
                MinAmmount = 1,
                MaxAmmount = 3
            },
            new ItemSpawn
            {
                Item = ItemType.Ammo556x45,
                MinAmmount = 10,
                MaxAmmount = 20
            }
        };

        // Items that can spawn during Chaos delivery
        [Description("Items during Chaos delivery")]
        public List<ItemSpawn> ChaosItems { get; set; } = new List<ItemSpawn>
        {
            new ItemSpawn
            {
                Item = ItemType.GunAK,
                MinAmmount = 4,
                MaxAmmount = 5,
            },
            new ItemSpawn
            {
                Item = ItemType.Ammo762x39,
                MinAmmount = 10,
                MaxAmmount = 15,
            },
            new ItemSpawn
            {
                Item = ItemType.Medkit,
                MinAmmount = 4,
                MaxAmmount = 6,
            }
        };

        // CASSIE announcements
        [Description("CASSIE announcement for MTF delivery")]
        public string MTFDelCassie { get; set; } = "jam_012_0 yield_01 arrival of mobile task force materials has entered the facility area";
        [Description("CASSIE subtitle for MTF delivery")]
        public string MTFDelCassieSub { get; set; } = "Arrival of MTF Materials has arrived";
        [Description("CASSIE announcement for Chaos delivery")]
        public string ChaosDelCassie { get; set; } = "jam_012_0 yield_01 arrival of chaos insurgency materials has entered the facility area";
        [Description("CASSIE subtitle for Chaos delivery")]
        public string ChaosDelCassieSub { get; set; } = "Arrival of Chaos Insurgency Materials has arrived";

        // Spawn positions for MTF
        [Description("Spawn positions for MTF")]
        public List<Vector3> MTFSpawnPostitions { get; set; } = new List<Vector3>
        {
            new Vector3((float)123.715,(float)995.456,(float)-44.860),
            new Vector3((float)124.865, (float)995.456, (float)-40.821),
            new Vector3((float)129.121,(float)995.456,(float)-40.420),
            new Vector3((float)127.847,(float)995.456,(float)-45.676),
            new Vector3((float)132.116,(float)995.456, (float)-45.793),
            new Vector3((float)133.123, (float)995.456, (float)-42.567),
            new Vector3((float)124.654, (float)995.456, (float)-43.789),
            new Vector3((float)128.987, (float)995.456, (float)-45.123),
            new Vector3((float)127.345, (float)995.456, (float)-44.567),
            new Vector3((float)131.234, (float)995.456, (float)-44.987)
        };

        // Spawn positions for Chaos
        [Description("Spawn positions for Chaos")]
        public List<Vector3> ChaosSpawnPositions { get; set; } = new List<Vector3>
        {
            new Vector3((float)8.340,(float)991.649,(float)-38.516),
            new Vector3((float)9.125,(float)991.649,(float)-46.570),
            new Vector3((float)-5.245,(float)991.649,(float)-38.366),
            new Vector3((float)-8.949, (float)991.649,(float)-43.551),
            new Vector3((float)10.543, (float)991.649, (float)-41.789),
            new Vector3((float)7.876, (float)991.649, (float)-43.234),
            new Vector3((float)-7.654, (float)991.649, (float)-37.876),
            new Vector3((float)-8.567, (float)991.649, (float)-44.123),
            new Vector3((float)1.234, (float)991.649, (float)-40.345)
        };

        // Buddy System
        [Description("Enable the buddy system (currently non-functional)")]
        public bool BuddySytemEnabled { get; set; } = true;
        [Description("Roles for buddies to spawn as")]
        public List<RoleTypeId> SpawnAbleRoles { get; set; } = new List<RoleTypeId>
        {
            RoleTypeId.ClassD,
            RoleTypeId.Scientist,
            RoleTypeId.FacilityGuard
        };
        [Description("SCP roles for buddies when SCP is needed")]
        public List<RoleTypeId> SCPNeeded { get; set; } = new List<RoleTypeId>
        {
            RoleTypeId.Scp173,
            RoleTypeId.Scp106,
            RoleTypeId.Scp939,
        };

        // End of Round Settings
        [Description("Enable friendly fire at the end of the round")]
        public bool FriendlyFireAtEndOfRound { get; set; } = true;

        // Radio Battery Settings
        [Description("Unlimited radio battery")]
        public bool UnlimitedRadioBattery { get; set; } = true;
        [Description("Radio battery power loss adjustment")]
        public int BatteryPowerLoss { get; set; } = 1;

        // Warhead Door
        [Description("Control warhead door open and lock behavior")]
        public bool WarheadDoorOpenAndLock { get; set; } = true;

        // Entry Lights
        [Description("MTF and Chaos entry flashing lights")]
        public bool FlashingLights { get; set; } = true;


        [Description("save path for DataBase")]
        public string SavePath { get; set; } = Path.Combine(Paths.Config, "FL-Main");
        [Description("DataBase Name")]
        public string DatabaseName { get; set; } = "FrozenCoins.db";

    }
}  