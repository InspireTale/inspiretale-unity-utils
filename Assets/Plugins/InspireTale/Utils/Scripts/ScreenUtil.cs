using UnityEngine;

namespace InspireTale.Utils
{
    public static class ScreenUtil
    {
        public static int ScreenWidth
        {
            get { return Screen.width; }
        }
        public static int ScreenHeight
        {
            get { return Screen.height; }
        }
        public class Screen2D
        {
            public static float LeftScreenEdgePosition
            {
                get
                {
                    var leftScreenPoint = new Vector2(0, 0);
                    return Camera.main.ScreenToWorldPoint(leftScreenPoint).x;
                }
            }
            public static float RightScreenEdgePosition
            {
                get
                {
                    var rightScreenPoint = new Vector2(ScreenWidth, 0);
                    return Camera.main.ScreenToWorldPoint(rightScreenPoint).x;
                }
            }
            public static float TopScreenEdgePosition
            {
                get
                {
                    var topScreenPoint = new Vector2(0, ScreenHeight);
                    return Camera.main.ScreenToWorldPoint(topScreenPoint).y;
                }
            }
            public static float BottomScreenEdgePosition
            {
                get
                {
                    var bottomScreenPoint = new Vector2(0, 0);
                    return Camera.main.ScreenToWorldPoint(bottomScreenPoint).y;
                }
            }
            public static Vector4 ScreenEdgePostion
            {
                get
                {
                    var topAndRightScreenPoint = new Vector2(ScreenWidth, ScreenHeight);
                    var botAndLeftScreenPoint = new Vector2(0, 0);

                    var topAndRightWorldPoint = Camera.main.ScreenToWorldPoint(topAndRightScreenPoint);
                    var botAndLeftWorldPoint = Camera.main.ScreenToWorldPoint(botAndLeftScreenPoint);

                    return new Vector4(topAndRightWorldPoint.y, topAndRightWorldPoint.x, botAndLeftWorldPoint.y, botAndLeftWorldPoint.x);
                }
            }
        }
    }
}