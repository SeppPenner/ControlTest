using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;

namespace ControlTest
{
    public class LedActionList : DesignerActionList
    {
        private readonly Led _mLed;

        public LedActionList(IComponent component)
            : base(component)
        {
            _mLed = (Led) component;
        }

        public string Caption
        {
            get { return _mLed.Caption; }
            set { _mLed.Caption = value; }
        }

        public Led.ECaptionPos CaptionPos
        {
            get { return _mLed.CaptionPos; }
            set { _mLed.CaptionPos = value; }
        }

        public Font Font
        {
            get { return _mLed.Font; }
            set { _mLed.Font = value; }
        }

        public Led.EColor LedColor
        {
            get { return _mLed.LedColor; }
            set { _mLed.LedColor = value; }
        }

        public Led.EState State
        {
            get { return _mLed.State; }
            set { _mLed.State = value; }
        }

        public Led.EShape Shape
        {
            get { return _mLed.Shape; }
            set { _mLed.Shape = value; }
        }

        public bool BooleanState
        {
            get { return _mLed.BooleanState; }
            set { _mLed.BooleanState = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var sortedActionItems = base.GetSortedActionItems();
            sortedActionItems.Clear();
            sortedActionItems.Add(new DesignerActionHeaderItem("LED Eigenschaften:", "LED"));
            sortedActionItems.Add(new DesignerActionPropertyItem("Caption", "Caption"));
            sortedActionItems.Add(new DesignerActionPropertyItem("CaptionPos", "CaptionPos"));
            sortedActionItems.Add(new DesignerActionPropertyItem("Font", "Font"));
            sortedActionItems.Add(new DesignerActionPropertyItem("LEDColor", "LEDColor"));
            sortedActionItems.Add(new DesignerActionPropertyItem("State", "State"));
            sortedActionItems.Add(new DesignerActionPropertyItem("Shape", "Shape"));
            sortedActionItems.Add(new DesignerActionPropertyItem("BooleanState", "BooleanState"));
            return sortedActionItems;
        }
    }
}