using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using MEC;
using UnityEngine;
using System;
using System.Collections.Generic;
using Random = System.Random;
using Config = FL_Main.Config;
public class MapHandlers
{
    public void OnDetonated()
    {
        Config config = new Config();
        if (config.WarheadDoorOpenAndLock)
        {
            Door.LockAll(999999, DoorLockType.Warhead);
            foreach (Door door in Door.List)
            {
                door.Lock(9999999999, DoorLockType.Warhead);
                door.IsOpen = true;
                if (!door.IsGate)
                {
                    Map.Explode(door.Position, ProjectileType.FragGrenade);
                }
            }
        }
    }

    public void OnRespawningTeam(Exiled.Events.EventArgs.Server.RespawningTeamEventArgs ev)
    {
        Timing.RunCoroutine(FlickerLights(ev));
    }
    private IEnumerator<float> FlickerLights(Exiled.Events.EventArgs.Server.RespawningTeamEventArgs ev)
    {
        Config config = new Config();
        if (config.FlashingLights)
        {
            Log.Debug("Running Random Lights");
            Random random = new Random();
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                Log.Debug("Running MTF Lights");
                for (int i = 0; i < random.Next(10); i++)
                {
                    foreach (Room room in Room.List)
                    {
                        room.Color = Color.blue;
                    }
                    yield return Timing.WaitForSeconds((float)random.NextDouble());
                    foreach (Room room in Room.List)
                    {
                        room.Color = Color.clear;
                    }
                }
            }
            else if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                Log.Debug("Running Chaos Lights");
                for (int i = 0; i < random.Next(10); i++)
                {
                    foreach (Room room in Room.List)
                    {
                        room.Color = Color.green;
                    }
                    yield return Timing.WaitForSeconds((float)random.NextDouble());
                    foreach (Room room in Room.List)
                    {
                        room.Color = Color.clear;
                    }
                }
            }
        }
        yield break;
    }
}
