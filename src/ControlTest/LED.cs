// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LED.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The LED class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ControlTest;

/// <summary>
/// The LED class.
/// </summary>
[Designer(typeof(LedDesigner))]
public partial class Led : UserControl
{
    /// <summary>
    /// The caption.
    /// </summary>
    private string caption = string.Empty;

    /// <summary>
    /// The caption position.
    /// </summary>
    private ECaptionPosition captionPosition = ECaptionPosition.Left;

    /// <summary>
    /// The LED color.
    /// </summary>
    private EColor ledColor = EColor.Red;

    /// <summary>
    /// The shape.
    /// </summary>
    private EShape shape = EShape.Circle;

    /// <summary>
    /// The state.
    /// </summary>
    private EState state = EState.StateUnknown;

    /// <summary>
    /// The font.
    /// </summary>
    private Font font = new Font("Arial", 12f);

    /// <summary>
    /// The gradient color.
    /// </summary>
    private LedGradientColor gradientColor;

    /// <summary>
    /// Initializes a new instance of the <see cref="Led"/> class.
    /// </summary>
    public Led()
    {
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.DoubleBuffer, true);
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.UserPaint, true);
    }

    /// <summary>
    /// Gets or sets the caption.
    /// </summary>
    public string Caption
    {
        get => this.caption;
        set
        {
            this.caption = value;
            this.Redraw();
        }
    }

    /// <summary>
    /// Gets or sets the caption position.
    /// </summary>
    public ECaptionPosition CaptionPosition
    {
        get => this.captionPosition;
        set
        {
            this.captionPosition = value;
            this.Redraw();
        }
    }

    /// <summary>
    /// Gets or sets the font.
    /// </summary>
    public new Font Font
    {
        get => this.font;
        set
        {
            this.font = value;
            this.Redraw();
        }
    }

    /// <summary>
    /// Gets or sets the LED color.
    /// </summary>
    public EColor LedColor
    {
        get => this.ledColor;
        set
        {
            this.ledColor = value;
            this.Redraw();
        }
    }

    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    public EState State
    {
        get => this.state;
        set
        {
            lock (this)
            {
                this.state = value;
                this.Redraw();
            }
        }
    }

    /// <summary>
    /// Gets or sets the shape.
    /// </summary>
    public EShape Shape
    {
        get => this.shape;
        set
        {
            this.shape = value;
            this.Redraw();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the LED is on or off.
    /// </summary>
    public bool BooleanState
    {
        get => this.State == EState.StateOn;
        set => this.State = value ? EState.StateOn : EState.StateOff;
    }

    /// <summary>
    /// Handles the component's on paint method.
    /// </summary>
    /// <param name="e">The event args.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using var graphicsPath = new GraphicsPath();
        var rectangle = new Rectangle(0, 0, this.Width, this.Height);
        if (this.Caption.Length > 0)
        {
            using var genericDefault = StringFormat.GenericDefault;
            genericDefault.Alignment = StringAlignment.Center;
            genericDefault.LineAlignment = StringAlignment.Center;
            genericDefault.Trimming = StringTrimming.Character;

            switch (this.CaptionPosition)
            {
                case ECaptionPosition.Left:
                    rectangle.Location = new Point(this.Width - this.Height, 0);
                    rectangle.Size = new Size(this.Height, this.Height);
                    genericDefault.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString(
                        this.Caption,
                        this.Font,
                        Brushes.Black,
                        new RectangleF(0f, 0f, rectangle.Left, rectangle.Height),
                        genericDefault);
                    break;
                case ECaptionPosition.Right:
                    rectangle.Location = new Point(0, 0);
                    rectangle.Size = new Size(this.Height, this.Height);
                    genericDefault.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString(
                        this.Caption,
                        this.Font,
                        Brushes.Black,
                        new RectangleF(
                            rectangle.Width + 1,
                            0f,
                            this.Width - rectangle.Width - 1,
                            rectangle.Height),
                        genericDefault);
                    break;
            }
        }

        switch (this.Shape)
        {
            case EShape.Circle:
                graphicsPath.AddEllipse(rectangle.Left, rectangle.Top, rectangle.Width - 3, rectangle.Height - 3);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var solidBrush = new SolidBrush(Color.FromArgb(64, 0, 0, 0)))
                {
                    e.Graphics.FillEllipse(
                        solidBrush,
                        rectangle.Left + 2,
                        rectangle.Top + 2,
                        rectangle.Width - 3,
                        rectangle.Height - 3);
                }

                using (var solidBrush = new SolidBrush(Color.FromArgb(96, 0, 0, 0)))
                {
                    e.Graphics.FillEllipse(
                        solidBrush,
                        rectangle.Left + 1,
                        rectangle.Top + 1,
                        rectangle.Width - 3,
                        rectangle.Height - 3);
                }

                e.Graphics.SmoothingMode = SmoothingMode.Default;
                break;
            case EShape.Rectangle:
                graphicsPath.AddRectangle(
                    new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 3, rectangle.Height - 3));
                break;
        }

        using var pathGradientBrush = new PathGradientBrush(graphicsPath)
        {
            CenterColor = this.gradientColor.HighlightColor,
            CenterPoint = new PointF(
                Convert.ToSingle(rectangle.Width / 4) + rectangle.Left,
                Convert.ToSingle(rectangle.Height / 4) + rectangle.Top)
        };

        Color[] surroundColors =
        {
                this.gradientColor.BackgroundColor
            };

        pathGradientBrush.SurroundColors = surroundColors;
        e.Graphics.FillPath(pathGradientBrush, graphicsPath);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        switch (this.Shape)
        {
            case EShape.Circle:
                e.Graphics.DrawEllipse(
                    Pens.Black,
                    rectangle.Left,
                    rectangle.Top,
                    rectangle.Width - 3,
                    rectangle.Height - 3);
                break;
            case EShape.Rectangle:
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    rectangle.Left,
                    rectangle.Top,
                    rectangle.Width - 3,
                    rectangle.Height - 3);

                using (var pen = new Pen(Color.FromArgb(128, 0, 0, 0)))
                {
                    e.Graphics.DrawLine(
                        pen,
                        rectangle.Left + 1,
                        rectangle.Height - 2,
                        rectangle.Width - 2,
                        rectangle.Height - 2);
                    e.Graphics.DrawLine(
                        pen,
                        rectangle.Width - 2,
                        rectangle.Height - 3,
                        rectangle.Width - 2,
                        rectangle.Top);
                }

                using (var pen = new Pen(Color.FromArgb(64, 0, 0, 0)))
                {
                    e.Graphics.DrawLine(
                        pen,
                        rectangle.Left + 2,
                        rectangle.Height - 1,
                        rectangle.Width - 1,
                        rectangle.Height - 1);
                    e.Graphics.DrawLine(
                        pen,
                        rectangle.Width - 1,
                        rectangle.Height - 2,
                        rectangle.Width - 1,
                        rectangle.Top);
                }

                break;
        }

        if (this.State != EState.StateUnknown)
        {
            return;
        }

        using var localFont = new Font(this.Font.Name, Convert.ToSingle(rectangle.Height / 2), FontStyle.Bold);
        using (var genericDefault = StringFormat.GenericDefault)
        {
            genericDefault.Alignment = StringAlignment.Center;
            genericDefault.LineAlignment = StringAlignment.Center;
            genericDefault.Trimming = StringTrimming.Character;
            e.Graphics.DrawString(
                "?",
                localFont,
                Brushes.White,
                new RectangleF(
                    rectangle.Left,
                    rectangle.Top,
                    rectangle.Width - 1,
                    rectangle.Height - 1),
                genericDefault);
        }
    }

    /// <summary>
    /// Re-draws the component.
    /// </summary>
    private void Redraw()
    {
        if (this.State == EState.StateOn)
        {
            switch (this.LedColor)
            {
                case EColor.Red:
                    this.gradientColor.HighlightColor = Color.FromArgb(255, 220, 220);
                    this.gradientColor.BackgroundColor = Color.FromArgb(220, 0, 0);
                    break;
                case EColor.Green:
                    this.gradientColor.HighlightColor = Color.FromArgb(220, 255, 220);
                    this.gradientColor.BackgroundColor = Color.FromArgb(0, 200, 0);
                    break;
                case EColor.Yellow:
                    this.gradientColor.HighlightColor = Color.FromArgb(255, 255, 220);
                    this.gradientColor.BackgroundColor = Color.FromArgb(220, 220, 0);
                    break;
                case EColor.Blue:
                    this.gradientColor.HighlightColor = Color.FromArgb(220, 220, 255);
                    this.gradientColor.BackgroundColor = Color.FromArgb(0, 0, 190);
                    break;
            }
        }
        else
        {
            switch (this.LedColor)
            {
                case EColor.Red:
                    this.gradientColor.HighlightColor = Color.FromArgb(200, 180, 180);
                    this.gradientColor.BackgroundColor = Color.FromArgb(70, 50, 50);
                    break;
                case EColor.Green:
                    this.gradientColor.HighlightColor = Color.FromArgb(180, 200, 180);
                    this.gradientColor.BackgroundColor = Color.FromArgb(50, 70, 50);
                    break;
                case EColor.Yellow:
                    this.gradientColor.HighlightColor = Color.FromArgb(200, 200, 180);
                    this.gradientColor.BackgroundColor = Color.FromArgb(70, 70, 50);
                    break;
                case EColor.Blue:
                    this.gradientColor.HighlightColor = Color.FromArgb(200, 200, 180);
                    this.gradientColor.BackgroundColor = Color.FromArgb(50, 50, 70);
                    break;
            }
        }

        this.Invalidate();
    }
}
