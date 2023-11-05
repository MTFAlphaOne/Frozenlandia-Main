# FL_Main

## Overview

This plugin enhances the gaming experience in SCP: Secret Laboratory by introducing a variety of unique features. This README will provide a comprehensive overview of the plugin and its functionalities. Please note that some features are still under development.

## Features

| Feature                 | What It Does                                                          | Implementation Status |
|-------------------------|-----------------------------------------------------------------------|-----------------------|
| Explosive Doors and Gates| When the Warhead explodes, all Doors and Gates explode with it.     | ✔️ Done               |
| Flickering Lights       | As soon as MTF/Chaos spawns, every light in the facility should flicker green or blue for 3 seconds.     | ✔️ Done               |
| Kills and Damage Display| Kills and damage should be displayed for the SCPs.                  | In Progress           |
| Buddy System            | Buddysystem: Easily send friend requests and play cooperatively.    | ✔️ Done               |
| Friendly Fire           | At the end of the round, Friendly Fire should activate.             | ✔️ Done               |
| Endless Radio Battery   | Radios have endless battery life for constant communication.        | ✔️ Done               |
| Random Elevator Speed   | Elevators go up/down faster or slower, always completely randomly.  | ✔️ Done               |
| Weapons Deliveries      | Weapons and ammunition deliveries for Chaos/MTF every 6 minutes.    | ✔️ Done               |

## Installation

To install this plugin, follow these steps:

1. Download the latest release from the [Releases](https://github.com/Dashtiss/FL_Main/releases) page.
2. Place the downloaded `.dll` file in your server's `Plugins` folder.
3. Configure the plugin according to your preferences (if necessary).
4. Start your server.

## Configuration

| Name                           | Description                                     | Variable Type           | Default                   |
|--------------------------------|-------------------------------------------------|-------------------------|---------------------------|
| **Main Plugin Settings**       |                                                 |                         |                           |
| IsEnabled                       | Enable the main plugin                         | boolean                 | true                      |
| Debug                           | Enable debug mode                              | boolean                 | false                     |
| **Supply Drops**               |                                                 |                         |                           |
| EnableSupplyDrops               | Enable supply drops                            | boolean                 | true                      |
| SupplyDropMinutes               | Time until supply drop (minutes)               | float                   | 6.0                       |
| SupplyDropConfigs               | Supply drop time randomization                 | SupplyDropConfigRandom  | IsRandomTimeAllowed: true, Min: 30, Max: 90 |
| MTFItems                        | Items during MTF delivery                      | List<ItemSpawn>         | See code                  |
| ChaosItems                      | Items during Chaos delivery                    | List<ItemSpawn>         | See code                  |
| **CASSIE Announcements**       |                                                 |                         |                           |
| MTFDelCassie                    | CASSIE announcement for MTF delivery          | string                  | "jam_012_0 yield_01 arrival of mobile task force materials has entered the facility area" |
| MTFDelCassieSub                 | CASSIE subtitle for MTF delivery               | string                  | "Arrival of MTF Materials has arrived" |
| ChaosDelCassie                  | CASSIE announcement for Chaos delivery        | string                  | "jam_012_0 yield_01 arrival of chaos insurgency materials has entered the facility area" |
| ChaosDelCassieSub               | CASSIE subtitle for Chaos delivery             | string                  | "Arrival of Chaos Insurgency Materials has arrived" |
| **Spawn Positions**            |                                                 |                         |                           |
| MTFSpawnPositions                | Spawn positions for MTF                        | List<Vector3>           | See code                  |
| ChaosSpawnPositions             | Spawn positions for Chaos                      | List<Vector3>           | See code                  |
| **Buddy System**               |                                                 |                         |                           |
| BuddySytemEnabled               | Enable the buddy system (non-functional)       | boolean                 | true                      |
| SpawnAbleRoles                  | Roles for buddies to spawn as                 | List<RoleTypeId>        | ClassD, Scientist, FacilityGuard |
| SCPNeeded                       | SCP roles for buddies when SCP is needed      | List<RoleTypeId>        | Scp173, Scp106, Scp939     |
| **End of Round Settings**     |                                                 |                         |                           |
| FriendlyFireAtEndOfRound       | Enable friendly fire at the end of the round  | boolean                 | true                      |
| **Radio Battery Settings**    |                                                 |                         |                           |
| UnlimitedRadioBattery           | Unlimited radio battery                        | boolean                 | true                      |
| BatteryPowerLoss                | Radio battery power loss adjustment            | integer                 | 1                         |
| **Warhead Door**               |                                                 |                         |                           |
| WarheadDoorOpenAndLock          | Control warhead door open and lock behavior   | boolean                 | true                      |
| **Entry Lights**              |                                                 |                         |                           |
| FlashingLights                  | MTF and Chaos entry flashing lights            | boolean                 | true                      |

## Credits

This plugin if for the FROZENLANDIA server ([Discord](https://discord.gg/UBuY8e2W)). This is made by Dashtiss

