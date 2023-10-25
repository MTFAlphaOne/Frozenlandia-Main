﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player = Exiled.Events.EventArgs.Player;
namespace FL_Main.EventHandlers
{
    public class PlayerHandlers
    {
        public void UsingRadioBattery(Player.UsingRadioBatteryEventArgs ev)
        {
            ev.Radio.BatteryLevel = 100;
            ev.Drain = 0f;
        }
    }
}