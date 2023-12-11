using CommandSystem;
using Exiled.API.Features;
using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace FL_Main.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ShopCommand : ICommand
    {
        public string Command { get; } = "shop";

        public string[] Aliases { get; } = new string[] { "shop" };

        public string Description { get; } = "You can buy items with your coins";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            try
            {

                Player player = (Player)sender;
                if (arguments.Count > 0)
                {
                    if (player != null)
                    {
                        foreach (var item in Plugin.singleton.Config.ItemCosts)
                        {
                            if (item.Key.ToString() == arguments.Array[0])
                            {
                                if (Plugin.singleton.Coins[player] >= item.Value)
                                {
                                    if (!player.IsInventoryFull)
                                    {
                                        player.AddItem(item.Key);
                                        response = $"You bought item {item.Value} for {item.Key}\n You have {Plugin.singleton.Coins[player]} coins left";
                                        return true;
                                    }
                                    else
                                    {
                                        response = "Your inventory if full, Please empty a item to buy something.";
                                        return false;
                                    }
                                }
                                else
                                {
                                    response = "You do not have enough coins to buy this item";
                                    return false;
                                }
                            }
                        }
                        if (arguments.Array[0] == "list")
                        {
                            string text = string.Empty;
                            foreach (var item in Plugin.singleton.Config.ItemCosts)
                            {
                                text += $"{item.Key} costs {item.Value}\n";
                            }
                            response = text;
                            return true;
                        }
                        else
                        {
                            response = "You must enter a item that you want to buy, if you want to buy something, please put the name of the item or put list to list the items that you can buy";
                            return false;
                        }
                    }
                    else
                    {
                        response = $"Something happened and your null please report this to a admin\nDev stuff, please send a screen shot of this to the admin\nPlayer: {player.DisplayNickname}\nPlayer id {player.Id}\nis null: {player == null}";
                        Log.Error($"A Player just ran the command .shop and was null\nPlayer: {player.DisplayNickname}\nPlayer id {player.Id}\nis null: {player == null}");
                        return false;
                    }
                }
                else
                {
                    response = "You must enter a item that you want to buy, if you want to buy something, please put the name of the item or put list to list the items that you can buy";
                    return false;
                }
            }
            catch (Exception e) 
            {
                response = $"A Error has accored, {e}";
                Log.Error (e);
                return false;
            }
        }
    }
}
