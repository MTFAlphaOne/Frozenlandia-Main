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
        private readonly Config config = new Config();
        private int MTFChance = 50;
        private int ChaosChance = 50;

        readonly System.Random random;
        public IEnumerator<float> MyCoroutine()
        {
            float time = config.SupplyDropMinutes * 60 + GetRandomFloat(
                config.SupplyDropConfigs.Min,

                config.SupplyDropConfigs.Max
                                            );
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
            if (config.SupplyDropConfigs.IsRandomTimeAllowed)
            {
                return (float)(random.NextDouble() * (max - min) + min);
            }
            return 0f;
        }
        public void MTFHelp()
        {
            Respawn.SummonNtfChopper();
            Timing.WaitForSeconds(15);
            Cassie.MessageTranslated(config.MTFDelCassie, config.MTFDelCassieSub);
            foreach (ItemSpawn itemSpawn in config.MTFItems)
            {
                System.Random random = new System.Random();
                int id = random.Next(config.MTFSpawnPostitions.Count());
                Vector3 vector = config.MTFSpawnPostitions[id];
                Item item = Item.Create(itemSpawn.Item);
                int ItemAmmount = random.Next(itemSpawn.MinAmmount, itemSpawn.MaxAmmount);
                for (int i = 0; i < ItemAmmount; i++)
                {
                    item.CreatePickup(vector);
                }
            }
        }
        public void ChaosHelp()
        {
            Respawn.SummonChaosInsurgencyVan();
            Timing.WaitForSeconds(13);
            Cassie.MessageTranslated(config.ChaosDelCassie, config.ChaosDelCassieSub);
            foreach (ItemSpawn itemSpawn in config.ChaosItems)
            {
                System.Random random = new System.Random();
                int id = random.Next(config.ChaosSpawnPositions.Count());
                Vector3 vector = config.ChaosSpawnPositions[id];
                Item item = Item.Create(itemSpawn.Item);
                int ItemAmmount = random.Next(itemSpawn.MinAmmount, itemSpawn.MaxAmmount);
                for (int i = 0; i < ItemAmmount; i++)
                {
                    item.CreatePickup(vector);
                }
            }
        }
    }
}
