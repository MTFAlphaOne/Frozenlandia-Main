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


        [Description("Database\nsave path for DataBase")]
        public string SavePath { get; set; } = Path.Combine(Paths.Configs, "FL-Main-Config");
        [Description("DataBase Name")]
        public string DatabaseName { get; set; } = "FrozenLandia.db";


        [Description("Commands\nWhat will the .scps command will return")]
        public string SCPReturn { get; set; } = @"• SCP035: Es spawnt ein verfluchtes Item, finde es, um es zu werden! 2500HP (verliert jede Sekunde 10HP). Du kannst Leben dazu bekommen, indem du andere mit deine Aura von 4Metern tötest. Die Leben, die du ihnen entziehst, bekommst du gutgeschrieben!

• SCP999: Spawnt am Anfang eventuell, kann dich wenn du in seiner Nähe bist, heilen.

• SCP-1048: Spawnt am Anfang eventuell, kann mit seinem Geschrei dich taub machen und dir stetig Schaden dadurch geben!

• SCP-575: Die ewige Dunkelheit, kann zu 20% SCP-106 ersetzen, und ist unsichtbar. Man kann ihn nur sehen, wenn er mit einer Taschenlampe angeleuchtet wird.

• SCP-890: Spawnt ab 15 Spielern zu 100%, hat die Fähigkeit, Türen oder Gates zu öffnen, kann jedoch diese aber auch verschließen, wenn man Pech hat!

• SCP-966: Sind unsichtbare, raubtierhafte Wesen, die Menschen im Schlaf angreifen. Sie sind durch Taschenlampen und Licht sichtbar und verursachen erheblichen Schlafentzug, was zu psychologischem Stress und potenziellem Tod führen kann.

• SCP-457: auch der ""Fireman"" genannt, ist eine menschliche Gestalt, welche nur brennt. Sie kann Feuerbälle schießen und gibt dir großen Schaden wenn du in seiner Nähe stehst. Die Cyro-Granate ist ein wirksames Mittel gegen ihn!
";
        [Description("What .items will return")]
        public string ItemReturn { get; set; } = @"• Gas-Granate: Die GasGrante ist die stärkste Grante im Arsenal der Site-19. Sobald sie explodiert, kommt es zu einer radioaktiven Zone, die für 20 Sekunden nicht betreten werden kann. Solltest du dich doch entscheiden, reinzugehen, kein Problem, wirst dann erst beim nächsten Respawn wieder lebendig!

• Cyro-Granate: Eine weitentwickelte Granate, welche beim Aufprall ""eiskalte"" Luft freisetzt. Du wirst schneller gefrieren als du selbst schauen kannst.. Sehr sinnvoll gegen SCP-457

• Mediziner-Waffe: Die medizinische Waffe, äußerlich verwechselbar mit dem Revolver, lässt dich durch das Feuern auf Zombies, diese zurück zu verwandeln und von SCP008 zu heilen!";


        public Dictionary<ItemType, int> ItemCosts { get; set; } = new Dictionary<ItemType, int>()
        {
            { ItemType.Adrenaline, 5 },
            { ItemType.Ammo12gauge, 10},
            { ItemType.Ammo9x19, 10 },
            { ItemType.Radio, 20}
        };



        [Description("This is the config for all the events for coins\nAmmount of coins if a player kills someone")]
        public int KillCost { get; set; } = 5;
        [Description("Ammount of coins the player will recieve when they escape")]
        public int EscapeCost { get; set; } = 8;
        [Description("Chance that a coin will give coins when flipped")]
        public int CoinChance { get; set; } = 1;
        [Description("How muc hwill a coin give")]
        public int CoinCost { get; set; } = 5;
    }
}