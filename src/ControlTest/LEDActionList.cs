// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LEDActionList.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The LED action list class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ControlTest
{
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;

    /// <summary>
    /// The LED action list class.
    /// </summary>
    public class LedActionList : DesignerActionList
    {
        /// <summary>
        /// The LED.
        /// </summary>
        private readonly Led led;

        /// <summary>
        /// Initializes a new instance of the <see cref="LedActionList"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public LedActionList(IComponent component) : base(component)
        {
            this.led = (Led)component;
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public string Caption
        {
            get => this.led.Caption;
            set => this.led.Caption = value;
        }

        /// <summary>
        /// Gets or sets the caption position.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public ECaptionPosition CaptionPosition
        {
            get => this.led.CaptionPosition;
            set => this.led.CaptionPosition = value;
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public Font Font
        {
            get => this.led.Font;
            set => this.led.Font = value;
        }

        /// <summary>
        /// Gets or sets the LED color.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public EColor LedColor
        {
            get => this.led.LedColor;
            set => this.led.LedColor = value;
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public EState State
        {
            get => this.led.State;
            set => this.led.State = value;
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public EShape Shape
        {
            get => this.led.Shape;
            set => this.led.Shape = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the LED is on or off.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool BooleanState
        {
            get => this.led.BooleanState;
            set => this.led.BooleanState = value;
        }

        /// <summary>
        /// Gets the sorted action items.
        /// </summary>
        /// <returns>A new <see cref="DesignerActionItemCollection"/>.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var sortedActionItems = base.GetSortedActionItems();
            sortedActionItems.Clear();
            sortedActionItems.Add(new DesignerActionHeaderItem("LED Eigenschaften:", "LED"));
            sortedActionItems.Add(new DesignerActionPropertyItem("Caption", "Caption"));
            sortedActionItems.Add(new DesignerActionPropertyItem("CaptionPosition", "CaptionPosition"));
            sortedActionItems.Add(new DesignerActionPropertyItem("Font", "Font"));
            sortedActionItems.Add(new DesignerActionPropertyItem("LEDColor", "LEDColor"));
            sortedActionItems.Add(new DesignerActionPropertyItem("State", "State"));
            sortedActionItems.Add(new DesignerActionPropertyItem("Shape", "Shape"));
            sortedActionItems.Add(new DesignerActionPropertyItem("BooleanState", "BooleanState"));
            return sortedActionItems;
        }
    }
}