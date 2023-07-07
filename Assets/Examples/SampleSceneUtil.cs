using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using InspireTale.Utils;

[ExecuteInEditMode]
public class SampleSceneUtil : MonoBehaviour
{
    [SerializeField]
    private Text m_text = null;

    [SerializeField]
    private Text[] m_MouseButtonTexts;

    private readonly int tickInterval_ms = 1000;
    private long currentTime_ms = 0;

    private readonly StringBuilder stringBuilder = new();


    void Update()
    {
        for (int i = 0; i < this.m_MouseButtonTexts.Length; i++)
        {
            this.HideText(this.m_MouseButtonTexts[i]);
        }

        if (Input.GetMouseButton(MouseButton.Left))
        {
            this.ShowText(this.m_MouseButtonTexts[MouseButton.Left]);
        }

        if (Input.GetMouseButton(MouseButton.Right))
        {
            this.ShowText(this.m_MouseButtonTexts[MouseButton.Center]);
        }

        if (Input.GetMouseButton(MouseButton.Center))
        {
            this.ShowText(this.m_MouseButtonTexts[MouseButton.Right]);
        }

        long currentTime_ms = DateTimeUtil.ToMsTimestamp(DateTime.Now);
        if (currentTime_ms > this.currentTime_ms)
        {
            this.currentTime_ms = currentTime_ms + tickInterval_ms;
            this.UpdatePreview();
        }
    }

    private void HideText(Text text)
    {
        Color currentColor = text.color;
        Color newColor = new(currentColor.r, currentColor.g, currentColor.b, 0);
        text.color = newColor;
    }

    private void ShowText(Text text)
    {
        Color currentColor = text.color;
        Color newColor = new(currentColor.r, currentColor.g, currentColor.b, 1);
        text.color = newColor;
    }

    private void UpdatePreview()
    {
        this.stringBuilder.Clear();
        this.PreviewDateTimeUtil();
        this.PreviewScreenUtil();
        this.PreviewCompareUtil();
        this.PreviewRandomUtil();

        this.m_text.text = this.stringBuilder.ToString();
    }

    private void PreviewDateTimeUtil()
    {
        this.stringBuilder.AppendLine("DateTime Util");

        DateTime dateTime = DateTime.UtcNow;
        this.stringBuilder.AppendLine($"Current UnixTimeStamp: {DateTimeUtil.ToUnixTimestamp(dateTime)}, Current MsTimeStamp: {DateTimeUtil.ToMsTimestamp(dateTime)}");
    }

    private void PreviewScreenUtil()
    {
        this.stringBuilder.AppendLine("Screen Util");
        this.stringBuilder.AppendLine("---Screen Util---");
        this.stringBuilder.AppendLine($"ScreenWidth {ScreenUtil.ScreenWidth}, ScreenHeight {ScreenUtil.ScreenHeight}");
        this.stringBuilder.AppendLine("---Screen 2D---");
        this.stringBuilder.AppendLine($"LeftScreenEdgePosition {ScreenUtil.Screen2D.LeftScreenEdgePosition}, RightScreenEdgePosition {ScreenUtil.Screen2D.RightScreenEdgePosition}, TopScreenEdgePosition {ScreenUtil.Screen2D.TopScreenEdgePosition}, BottomScreenEdgePosition {ScreenUtil.Screen2D.BottomScreenEdgePosition}");
    }

    private void PreviewCompareUtil()
    {
        float a = 1f;
        float b = 2f;

        this.stringBuilder.AppendLine("Compare Util");
        this.stringBuilder.AppendLine("---CompareFloat---");
        this.stringBuilder.AppendLine($"float epsilon: {float.Epsilon}, a = {a}, b = {b}, result: {CompareUtil.CompareFloat(a, b)}");

        a = 1.001f;
        b = 1.0001f;
        float customEpsilon = 0.01f;
        this.stringBuilder.AppendLine($"Custom epsilon: {customEpsilon}, a = {a}, b = {b}, result: {CompareUtil.CompareFloat(a, b, customEpsilon)}");
    }

    private void PreviewRandomUtil()
    {
        float percentage = 80f;

        this.stringBuilder.AppendLine("RandomUtil");
        this.stringBuilder.AppendLine("---RandomByPercentage---");

        this.stringBuilder.Append($"Percentage: {percentage},");
        for (int i = 0; i < 10; i++)
        {
            this.stringBuilder.Append($" {RandomUtil.RandomByPercentage(percentage).ToString()}");
        }

        this.stringBuilder.AppendLine();
    }
}
