// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LEDDesigner.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The designer class for the LED.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ControlTest
{
    using System.ComponentModel.Design;
    using System.Windows.Forms.Design;

    /// <summary>
    /// The designer class for the LED.
    /// </summary>
    internal class LedDesigner : ControlDesigner
    {
        /// <summary>
        /// Gets the designer action list collection.
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                base.ActionLists.Clear();
                base.ActionLists.Add(new LedActionList(this.Component));
                return base.ActionLists;
            }
        }
    }
}