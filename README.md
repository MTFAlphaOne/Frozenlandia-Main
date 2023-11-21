# FL_Main

## Overview

The FL_Main plugin is designed to enhance the gameplay experience in SCP: Secret Laboratory by introducing a wide range of unique and exciting features. From explosive doors and flickering lights to buddy systems and weapons deliveries, this plugin aims to create an immersive and dynamic gaming environment. In addition, FL_Main utilizes LiteDB to manage the in-game currency system, known as "FrozenCoins." Whether you're a server admin or a player, FL_Main adds new dimensions to your SCP adventures. Please note that some features are still in development, so stay tuned for updates.


## Features

| Feature                 | What It Does                                                          | Implementation Status | Tested |
|-------------------------|-----------------------------------------------------------------------|-----------------------|--------|
| Explosive Doors and Gates| When the Warhead explodes, all Doors and Gates explode with it.     | ✔️ Done               | ✔️      |
| Flickering Lights       | As soon as MTF/Chaos spawns, every light in the facility should flicker green or blue for 3 seconds.     | ✔️ Done               | ❌      |
| Kills and Damage Display| Kills and damage should be displayed for the SCPs.                  | In Progress           | ❌      |
| Buddy System            | Buddysystem: Easily send friend requests and play cooperatively.    | ✔️ Done               | ❌      |
| Friendly Fire           | At the end of the round, Friendly Fire should activate.             | ✔️ Done               | ✔️      |
| Endless Radio Battery   | Radios have endless battery life for constant communication.        | ✔️ Done               | ✔️      |
| Random Elevator Speed   | Elevators go up/down faster or slower, always completely randomly.  | ✔️ Done               | ✔️      |
| Weapons Deliveries      | Weapons and ammunition deliveries for Chaos/MTF every 6 minutes.    | ✔️ Done               | ✔️      |
| Coin Database           | This is the database that store all the coins that the server does  | ✔️ Done               | ❌      |
| Custom Things Commands  | These commands will list the Custom SCP. Items and Rooms            | ✔️ Done               | ❌      |


## Installation

To install this plugin, follow these steps:

1. Download the latest release from the [Releases](https://github.com/Dashtiss/FL_Main/releases) page.
2. Place the downloaded `.dll` file in your server's `Plugins` folder.
3. Download the [`liteDB.dll`](https://github.com/Dashtiss/FL_Main/releases/download/1.7.1/LiteDB.dll) file and put it into your `dependencies` folder
4. Configure the plugin according to your preferences (if necessary).
5. Start your server.

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
| **Commands**                   |                                                   |                     |                           |
| SCPReturn                  | Commands - .scps return description            | string                  | See code                  |
| ItemReturn                | .items command return description              | string                  | See code                  |


## Credits

This plugin if for the FROZENLANDIA server ([Discord](https://discord.gg/UBuY8e2W)). This is made by Dashtiss

