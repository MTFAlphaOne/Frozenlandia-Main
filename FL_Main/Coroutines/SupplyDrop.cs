using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using FL_Main.ConfigObjects;
using MEC;
using UnityEngine;


namespace FL_Main.Coroutines
{
    public class SupplyDrop
    {
        private readonly Config.Config config = new Config.Config();
        private int MTFChance = 50;
        private int ChaosChance = 50;
        private float time = 0;
        public IEnumerator<float> MyCoroutine()
        {
            System.Random random = new System.Random();

            if (config.SupplyDropConfigs.IsRandomTimeAllowed) 
            {
                time = config.SupplyDropMinutes * 60 + GetRandomFloat(
                    config.SupplyDropConfigs.Min,

                    config.SupplyDropConfigs.Max
                                                );
            }
            else
            {
                 time = config.SupplyDropMinutes * 60;
            }
            yield return Timing.WaitForSeconds(config.SupplyDropMinutes * 60 + time);
            int Chance = random.Next(100);
            int Team = random.Next(0, 1);    // 0 is mtf \ 1 is chaos

            if (Team == 0)
            {
                if (Chance < MTFChance)
                {
                    MTFHelp();
                    ChaosChance++;
                    MTFChance--;
                }
                else
                {
                    ChaosHelp();
                    ChaosChance--;
                    MTFChance++;
                }
            }
            else if (Team == 1) ;
            {
                if (Chance < ChaosChance)
                {
                    ChaosHelp();
                    ChaosChance--;
                    MTFChance++;

                }
                else
                {
                    MTFHelp();
                    ChaosChance++;
                    MTFChance--;
                }
            }
        }
        private float GetRandomFloat(float min, float max)
        {
            System.Random random = new System.Random();
            if (config.SupplyDropConfigs.IsRandomTimeAllowed)
            {
                return (float)(random.NextDouble() * (max - min) + min);
            }
            return 0f;
        }
        public IEnumerable<float> MTFHelp()
        {
            System.Random random = new System.Random();
            Respawn.SummonNtfChopper();
            yield return Timing.WaitForSeconds(15);
            Cassie.MessageTranslated(config.MTFDelCassie, config.MTFDelCassieSub);
            foreach (ItemSpawn itemSpawn in config.MTFItems)
            {
                int id = random.Next(config.MTFSpawnPostitions.Count());
                Vector3 vector = config.MTFSpawnPostitions[id];
                Item item = Item.Create(itemSpawn.Item);
                int ItemAmmount = random.Next(itemSpawn.MinAmmount, itemSpawn.MaxAmmount);
                for (int i = 0; i < ItemAmmount; i++)
                {
                    item.CreatePickup(vector);
                }
            }
            yield break;
        }
        public IEnumerable<float> ChaosHelp()
        {
            System.Random random = new System.Random();
            Respawn.SummonChaosInsurgencyVan();
            yield return Timing.WaitForSeconds(15);
            Cassie.MessageTranslated(config.ChaosDelCassie, config.ChaosDelCassieSub);
            foreach (ItemSpawn itemSpawn in config.ChaosItems)
            {
                int id = random.Next(config.ChaosSpawnPositions.Count());
                Vector3 vector = config.ChaosSpawnPositions[id];
                Item item = Item.Create(itemSpawn.Item);
                int ItemAmmount = random.Next(itemSpawn.MinAmmount, itemSpawn.MaxAmmount);
                for (int i = 0; i < ItemAmmount; i++)
                {
                    item.CreatePickup(vector);
                }
            }
            yield break;
        }
    }
}
