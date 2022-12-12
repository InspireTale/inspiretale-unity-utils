//  *******STANDARD IMPORT*******
using UnityEngine;
using UnityEngine.UI;

//  *******LOCAL IMPORT*******

namespace InspireTaleFramework
{
    /// <summary>This component will be adjust Thai unicode string
    /// for display in Unity
    /// - Require "Text" class to be attach on object
    /// - To get and set text you can use "text" property
    ///     <example>textAdjuster.text = "hello"<example>
    /// - To access "Text" component you can access by "component" property
    ///     <example>textAdjuster.component.AddEventListener(...)</example>
    ///</summary>
    public class TextAdjuster: MonoBehaviour
    {
        //  *******PROPERTY*******
        //  property to get and set Text string
        public string text
        {
            //  when get text return unadjest string
            get { return unAdjustString; }

            //  when set text will
            //  1. set unadjustString as input value
            //  2. set adjustString with ThaiFontAdjuster with unadjustString
            set {
                this.unAdjustString = value;
                this.adjustedString = ThaiFontAdjuster.Adjust(this.unAdjustString);

                //  update value to Text component
                this.m_text.text = this.text;
            }
        }

        //  shortcut to access Text component
        public Text component
        {
            get { return this.m_text; }
        }

        //  *******PUBLIC VARIABLE*******

        //  *******PRIVATE VARIABLE*******
        //  holding value of text string
        private string adjustedString;

        //  display value of text string
        private string unAdjustString;

        //  Text component instance
        private Text m_text;

        //  *******UNITY HOOK*******
        void Awake ()
        {
            this.m_text = GetComponent<Text>();
            this.text = this.m_text.text;
        }

        //  *******PUBLIC FUNCTION*******

        //  *******PRIVATE FUNCTION*******
    }
}
