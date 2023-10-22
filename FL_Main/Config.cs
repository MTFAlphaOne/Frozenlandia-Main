using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FL_Main.ConfigObjects;
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
        public SupplyDropConfigRandom SupplyDropConfigs { get; set;} = new SupplyDropConfigRandom 
        {
            IsRandomAllowed = true,
            Min = 30,
            Max= 90,
        };

    }
}
