using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InspireTaleFramework
{
    public class RandomUtil
    {
        public static bool RandomPercenntage(float percentage)
        {
            return Random.value <= (percentage*0.01);
        }
    }
}
