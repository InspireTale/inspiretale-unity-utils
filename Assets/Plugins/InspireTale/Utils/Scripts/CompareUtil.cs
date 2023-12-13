using UnityEngine;

namespace InspireTale.Utils
{
    public static class CompareUtil
    {
        public static bool CompareFloat(float value1, float value2, float Epsilon = float.Epsilon)
        {
            return Epsilon > Mathf.Abs(value1 - value2);
        }
    }
}
