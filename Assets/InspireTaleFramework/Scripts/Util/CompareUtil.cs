using UnityEngine;

namespace InspireTaleFramework{
    public class CompareUtil
    {
        public static bool CompareFloat(float value1,float value2)
        {
            return float.Epsilon > Mathf.Abs(value1) - Mathf.Abs(value2);
        }
    }
}
