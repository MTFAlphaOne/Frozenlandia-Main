using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using MEC;
using UnityEngine;
using System;
using System.Collections.Generic;

public class MapHandlers
{
    readonly System.Random random;

    public void OnDetonated()
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

    public void OnRespawningTeam(Exiled.Events.EventArgs.Server.RespawningTeamEventArgs ev)
    {
        if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
        {
            for (int i = 0; i < 3; i++)
            {
                foreach (Room room in Room.List)
                {
                    room.Color = Color.blue;
                }
                Timing.WaitForSeconds((float)(random.NextDouble() * (0.5 - 0.2) + 0.2)); // Replace random. with random.Next(minValue, maxValue)
                foreach (Room room in Room.List)
                {
                    room.Color = Color.clear;
                }
            }
        }
        else if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
        {
            for (int i = 0; i < 3; i++)
            {
                foreach (Room room in Room.List)
                {
                    room.Color = Color.green;
                }
                Timing.WaitForSeconds((float)(random.NextDouble() * (0.5 - 0.2) + 0.2)); // Replace random. with random.Next(minValue, maxValue)
                foreach (Room room in Room.List)
                {
                    room.Color = Color.clear;
                }
            }
        }
    }
}
