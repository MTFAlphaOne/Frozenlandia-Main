/// <summary>
/// This is the main class for all the stuff
/// </summary>
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.API
{
    public class Features
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

        /// <summary>
        /// This is the main Class that will run all the shop
        /// </summary>
        public class Shop
        {
            /// <summary>
            /// Will add a item to the shop
            /// </summary>
            /// <param name="Item"></param>
            /// <param name="Cost"></param>
            public void AddBuyableItem(ItemType Item, int Cost)
            {
                if (!Plugin.singleton.Config.ItemCosts.ContainsKey(Item))
                {
                    Plugin.singleton.Config.ItemCosts.Add(Item, Cost);
                }
            }

            /// <summary>
            /// Will change the cost of a item
            /// </summary>
            /// <param name="Item"></param>
            /// <param name="NewCost"></param>
            public void ChangeCost(ItemType Item, int NewCost)
            {
                if (Plugin.singleton.Config.ItemCosts.ContainsKey(Item))
                {
                    Plugin.singleton.Config.ItemCosts[Item] = NewCost;
                }
            }
            /// <summary>
            /// Will make a player buy a item. will return false if inventor is full or if player doesnt have enough coins for all items
            /// </summary>
            /// <param name="Player"></param>
            /// <param name="Item"></param>
            /// <param name="Ammount"></param>
            /// <returns></returns>
            public bool? BuyItem(
                Player Player, 
                ItemType Item, 
                int Ammount= 1
                )
            {
                if (Plugin.singleton.Coins[Player] >= (Plugin.singleton.Config.ItemCosts[Item] * Ammount))
                {
                    if (Player == null) { return null; }
                    if (!Player.IsInventoryFull)
                    {
                        for (int i = 0; i < Ammount; i++)
                        {
                            if (Player.IsInventoryFull)
                            {
                                return false;
                            }
                            else
                            {
                                Player.AddItem(Item);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public class Nick
        {
            /// <summary>
            /// This is the dictionary that 
            /// </summary>
            public Dictionary<Player, int> PlayersCoins { get; set; } = Plugin.singleton.Coins;


            /// <summary>
            /// Function to set a player's nickname
            /// </summary>
            /// <param name="player"></param>
            /// <param name="Nick"></param>
            public void SetPlayerNick(Player player, string Nick)
            {
                Plugin.singleton.PlayerNicks.Add(Nick, player.DisplayNickname);
                player.DisplayNickname = Nick;
            }

            /// <summary>
            /// function to remove a players nickname
            /// </summary>
            /// <param name="player"></param>
            /// <returns>a null if player is null else true or false if the players name was reset</returns>
            public bool? RemovePlayerNick(Player player)
            {
                if (Plugin.singleton.PlayerNicks[player.DisplayNickname].Contains(player.DisplayNickname))
                {
                    string oldname = Plugin.singleton.PlayerNicks[player.DisplayNickname];

                    player.DisplayNickname = Plugin.singleton.PlayerNicks[player.DisplayNickname];

                    Plugin.singleton.PlayerNicks.Remove(oldname);
                    return true;
                }
                else if (player == null)
                {
                    return null;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
