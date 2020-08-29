using UnityEngine;

namespace InspireTaleFramework
{
    public class RandomUtil
    {
        public static bool RandomByPercenntage(float percentage)
        {
            return Random.value <= (percentage*0.01);
        }
    }
}
