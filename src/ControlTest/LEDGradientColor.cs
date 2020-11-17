// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LEDGradientColor.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The LED gradient color.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ControlTest
{
    using System.Drawing;

    /// <summary>
    /// The LED gradient color.
    /// </summary>
    internal struct LedGradientColor
    {
        /// <summary>
        /// Gets or sets the highlight color.
        /// </summary>
        public Color HighlightColor { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public Color BackgroundColor { get; set; }
    }
}