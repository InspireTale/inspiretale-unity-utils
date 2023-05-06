using UnityEngine;

namespace InspireTale.Utils
{
    public static class RandomUtil
    {
        public static bool RandomByPercentage(float percentage)
        {
            return Random.value <= (percentage*0.01);
        }
    }
}
