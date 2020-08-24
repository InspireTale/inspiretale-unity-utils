using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadingController : MonoBehaviour
{
    [SerializeField]
    private Image fadingImage = null;

    public float fadingValue { get { return fadingImage.color.a; } }
    private Color fadingRGBColor;

    private static SceneFadingController _Instance = null;

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

    public static SceneFadingController GetInstance()
    {
        if (!_Instance)
        {
            throw new Exception("SceneFadingController is not exist in the scene. Please move prefab into the scene before use it");
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
