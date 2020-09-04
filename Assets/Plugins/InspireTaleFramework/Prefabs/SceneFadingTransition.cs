using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace InspireTaleFramework
{
    public class SceneFadingTransition : MonoBehaviour
    {
        [SerializeField]
        private Image fadingImage = null;

        public float fadingValue { get { return fadingImage.color.a; } }
        private Color fadingRGBColor;

        private static SceneFadingTransition _Instance = null;

        void Awake()
        {
            if (fadingImage)
            {
                fadingRGBColor = fadingImage.color;
            }

            _Instance = this;
        }

        void OnDestroy()
        {
            _Instance = null;
        }

        public static SceneFadingTransition GetInstance()
        {
            if (!_Instance)
            {
                throw new Exception("SceneFadingTransition is not exist in the scene. Please move prefab into the scene before use it");
            }

            return _Instance;
        }

        public async Task FadeImageAlphaTask(float startValue, float endValue, float time_s)
        {
            float changeValueStepByInTime = (endValue - startValue) / time_s * Time.deltaTime;

            SetImageAlphaValue(startValue);

            while (fadingValue != endValue)
            {
                float offsetValue = Mathf.Abs(endValue - fadingValue);

                if (offsetValue < 0.01f)
                {
                    SetImageAlphaValue(endValue);
                    continue;
                }

                SetImageAlphaValue(fadingValue + changeValueStepByInTime);

                await Task.Delay(TimeSpan.FromSeconds(Time.deltaTime));
            }
        }

        private void SetImageAlphaValue(float alpha)
        {
            fadingImage.color = new Color(fadingRGBColor.r,
                                        fadingRGBColor.g,
                                        fadingRGBColor.b,
                                        alpha);

        }
    }
}
