using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.API
{
    public class API
    {
        public class FLMainDatabase
        { 
            /// <summary>
            /// Gets a players time has been on the server 
            /// </summary>
            /// <param name="player"></param>
            /// <returns>a float value, a return of null means player is null, value of 0 means player hasnt been on the server</returns>
            public float? GetPlayerTime(Player player)
            {
                if (player == null)
                {
                    return null;
                }
                if (Plugin.singleton.PlayerTime.ContainsKey(player))
                {
                    return Plugin.singleton.PlayerTime[player];
                }
                return 0f;
            }

            /// <summary>
            /// Will get the coins from a player
            /// </summary>
            /// <param name="player"></param>
            /// <returns>will return the value of coins. Will return null if player is null</returns>
            public int? GetPlayerCoins(Player player)
            {
                if (player == null)
                {
                    return null;
                }
                if (Plugin.singleton.Coins.ContainsKey(player))
                {
                    return Plugin.singleton.Coins[player];
                }
                return 0;
            }

            /// <summary>
            /// Gives Coins to a player
            /// </summary>
            /// <param name="player"></param>
            /// <param name="Coins"></param>
            /// <exception cref="ArgumentNullException"> Will throw the exception when player is null</exception>
            public int? AddCoins(Player player, int Coins) 
            {
                if (player == null) 
                {
                    return null;
                    throw new ArgumentNullException("Player is null");
                }
                if (Plugin.singleton.Coins.ContainsKey(player))
                {
                    Plugin.singleton.Coins[player] += Coins;
                    return Plugin.singleton.Coins[player];
                }
                else
                {
                    Plugin.singleton.Coins[player] = Coins;
                    return Coins;
                }
            }

            /// <summary>
            /// Will remove coins from a player
            /// </summary>
            /// <param name="player"></param>
            /// <param name="Coins"></param>
            /// <returns>null is invalid player    else remaining coins to player</returns>
            public int? RemoveCoins(Player player, int Coins) 
            {
                if (player == null)
                {
                    return null;
                }
                if (Plugin.singleton.Coins.ContainsKey(player) && Plugin.singleton.Coins[player] >= Coins)
                {
                    Plugin.singleton.Coins[player] -= Coins;
                }
                else
                {
                    Plugin.singleton.Coins[player] = 0;
                }
                return 0;
            }
            
        }
    }
}
