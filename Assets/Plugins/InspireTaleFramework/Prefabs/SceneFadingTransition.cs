using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace InspireTaleFramework
{
    public class SceneFadingTransition : MonoSingleton<SceneFadingTransition>
    {
        [SerializeField]
        private Image fadingImage = null;

        public float fadingValue { get { return fadingImage.color.a; } }

        private Color fadingRGBColor;
        private Coroutine fadingCoroutine = null;

        protected override void Awake()
        {
            base.Awake();
            fadingRGBColor = fadingImage.color;
        }

        public void FadeImageAlphaTask(float startValue, float endValue, float time_s)
        {
            if (fadingCoroutine != null)
            {
                StopCoroutine(fadingCoroutine);
            }

            fadingCoroutine = StartCoroutine(DoFadeImageAlphaTask(startValue, endValue, time_s));
        }

        private void SetImageAlphaValue(float alpha)
        {
            fadingImage.color = new Color(fadingRGBColor.r,
                                        fadingRGBColor.g,
                                        fadingRGBColor.b,
                                        alpha);

        }

        private IEnumerator DoFadeImageAlphaTask(float startValue, float endValue, float time_s)
        {
            float alphaChangeInTime = ((endValue - startValue) / time_s) * Time.deltaTime;

            SetImageAlphaValue(startValue);

            for (float i = time_s; i > 0; i -= Time.deltaTime)
            {
                SetImageAlphaValue(fadingValue + alphaChangeInTime);
                yield return null;
            }

            SetImageAlphaValue(endValue);
        }
    }
}
