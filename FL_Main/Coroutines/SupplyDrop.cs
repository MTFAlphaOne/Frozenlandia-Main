using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
namespace FL_Main.Coroutines
{
    public class SupplyDrop
    {
        private readonly Config config;

        readonly Random random;
        public IEnumerator<float> MyCoroutine()
        {
            float time = config.SupplyDropMinutes*60+GetRandomFloat(
                config.SupplyDropConfigs.Min,

                config.SupplyDropConfigs.Max
                                            );
            yield return Timing.WaitForSeconds(config.SupplyDropMinutes * 60 + time);
        }
        private float GetRandomFloat(float min, float max)
        {
            if (config.SupplyDropConfigs.IsRandomAllowed)
            {
                return (float)(random.NextDouble() * (max - min) + min);
            }
            return 0f;
        }
    }
}
