//  *******STANDARD IMPORT*******
using UnityEngine;
using TMPro;

//  *******LOCAL IMPORT*******

namespace InspireTale.Utils
{
    /// <summary>This component will be adjust Thai unicode string
    /// for display in Unity
    /// - Require "TextMeshProGUI" class to be attach on object
    /// - To get and set text you can use "text" property
    ///     <example>textAdjuster.text = "hello"<example>
    /// - To access "TextMeshProGUI" component you can access by "component" property
    ///     <example>textAdjuster.component.AddEventListener(...)</example>
    ///</summary>
    public class TextMeshAdjuster : MonoBehaviour
    {
        //  *******PROPERTY*******
        //  property to get and set TextMeshProRUI string
        public string text
        {
            get { return unAdjustString; }
            set {
                this.unAdjustString = value;
                this.adjustedString = ThaiFontAdjuster.Adjust(this.unAdjustString);

                if (this.m_textMeshProGUI == null)
                {
                    this.m_textMeshProGUI = GetComponent<TextMeshProUGUI>();
                }

                this.m_textMeshProGUI.text = this.text;
            }
        }

        //  shortcut to access TextMeshProRUI component

        //  *******PUBLIC VARIABLE*******

        //  *******PRIVATE VARIABLE*******
        //  holding value of text string
        private string adjustedString;

        //  display value of text string
        private string unAdjustString;

        private TextMeshProUGUI m_textMeshProGUI;

        //  *******UNITY HOOK*******
        void Awake()
        {
            this.m_textMeshProGUI = GetComponent<TextMeshProUGUI>();
            this.text = this.m_textMeshProGUI.text;
        }

        //  *******PUBLIC FUNCTION*******

        //  *******PRIVATE FUNCTION*******
    }
}

