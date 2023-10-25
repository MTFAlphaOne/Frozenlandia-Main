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

namespace FL_Main
{
    public class Config : IConfig
    {

        [Description("Main Plugin Settings")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Supply Drops")]
        public bool EnableSupplyDrops { get; set; } = true;
        [Description("How much time till the supply drop will happen. please put it in minutes not seconds")]
        public float SupplyDropMinutes { get; set; } = 6;
        [Description("Does it add random time so it isnt equal and how much time in seconds")]
        public SupplyDropConfigRandom SupplyDropConfigs { get; set; } = new SupplyDropConfigRandom
        {
            IsRandomTimeAllowed = true,
            Min = 30,
            Max = 90,
        };
        [Description("What items can Spawn in and how many")]
        public List<ItemSpawn >MTFItems { get; set; } = new List<ItemSpawn>
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

        [Description("What will Chaos Spawn Delivery spawn in")]
        public List<ItemSpawn> ChaosItems { get; set; } = new List<ItemSpawn>
        {
            new ItemSpawn
            {
                Item=ItemType.GunAK, 
                MinAmmount=4,
                MaxAmmount=5,
            },
            new ItemSpawn
            {
                Item=ItemType.Ammo762x39, 
                MinAmmount=10,
                MaxAmmount =15,
            },
            new ItemSpawn
            {
                Item=ItemType.Medkit,
                MinAmmount=4,
                MaxAmmount=6,
            }
        };
        [Description("What CASSIE will say when the MTF dilivery happens")]
        public string MTFDelCassie { get; set; } = "jam_012_0 yield_01 arrival of mobile task force materials has entered the facility area";
        public string MTFDelCassieSub { get; set; } = "Arrival of MTF Materials has arrived";
        [Description("What CASSIE will say when the Chaos dilivery happens")]
        public string ChaosDelCassie { get; set; } = "jam_012_0 yield_01 arrival of chaos insurgency materials has entered the facility area";
        public string ChaosDelCassieSub { get; set; } = "Arrival of Chaos Insurgency Materials has arrived";

        [Description("Don't Mess with these unless you know what your doing")]
        public List<Vector3> MTFSpawnPostitions { get; set; } = new List<Vector3>
        {
            new Vector3((float)123.715,(float)995.456,(float)-44.860),
            new Vector3((float)124.865, (float)995.456, (float)-40.821),
            new Vector3((float)129.121,(float)995.456,(float)-40.420),
            new Vector3((float)127.847,(float)995.456,(float)-45.676),
            new Vector3((float)132.116,(float)995.456, (float)-45.793)

        };
        public List<Vector3> ChaosSpawnPositions { get; set; } = new List<Vector3>
        {
            new Vector3((float)8.340,(float)991.649,(float)-38.516),
            new Vector3((float)9.125,(float)991.649,(float)-46.570),
            new Vector3((float)-5.245,(float)991.649,(float)-38.366),
            new Vector3((float)-8.949, (float)991.649,(float)-43.551),
        };
    }
}
