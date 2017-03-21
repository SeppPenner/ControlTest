using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ControlTest
{
    [Designer(typeof(LedDesigner))]
    public partial class Led : UserControl
    {
        public enum ECaptionPos
        {
            Left,
            Right
        }

        public enum EColor
        {
            Red,
            Green,
            Yellow,
            Blue
        }


        public enum EShape
        {
            Circle,
            Rectangle
        }

        public enum EState
        {
            StateUnknown = 99,
            StateOn = -1,
            StateOff
        }

        private string _mCaption = string.Empty;
        private ECaptionPos _mCaptionPos = ECaptionPos.Left;
        private EColor _meColor = EColor.Red;
        private EShape _meShape = EShape.Circle;
        private EState _meState = EState.StateUnknown;
        private Font _mFont = new Font("Arial", 12f);
        private LedGradientColor _moGradientColor;

        public Led()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        public string Caption
        {
            get { return _mCaption; }
            set
            {
                _mCaption = value;
                Redraw();
            }
        }

        public ECaptionPos CaptionPos
        {
            get { return _mCaptionPos; }
            set
            {
                _mCaptionPos = value;
                Redraw();
            }
        }

        public new Font Font
        {
            get { return _mFont; }
            set
            {
                _mFont = value;
                Redraw();
            }
        }

        public EColor LedColor
        {
            get { return _meColor; }
            set
            {
                _meColor = value;
                Redraw();
            }
        }

        public EState State
        {
            get { return _meState; }
            set
            {
                lock (this)
                {
                    _meState = value;
                    Redraw();
                }
            }
        }

        public EShape Shape
        {
            get { return _meShape; }
            set
            {
                _meShape = value;
                Redraw();
            }
        }

        public bool BooleanState
        {
            get { return State == EState.StateOn; }
            set { State = value ? EState.StateOn : EState.StateOff; }
        }

        private void Redraw()
        {
            if (State == EState.StateOn)
                switch (LedColor)
                {
                    case EColor.Red:
                        _moGradientColor.HighlightColor = Color.FromArgb(255, 220, 220);
                        _moGradientColor.BackColor = Color.FromArgb(220, 0, 0);
                        break;
                    case EColor.Green:
                        _moGradientColor.HighlightColor = Color.FromArgb(220, 255, 220);
                        _moGradientColor.BackColor = Color.FromArgb(0, 200, 0);
                        break;
                    case EColor.Yellow:
                        _moGradientColor.HighlightColor = Color.FromArgb(255, 255, 220);
                        _moGradientColor.BackColor = Color.FromArgb(220, 220, 0);
                        break;
                    case EColor.Blue:
                        _moGradientColor.HighlightColor = Color.FromArgb(220, 220, 255);
                        _moGradientColor.BackColor = Color.FromArgb(0, 0, 190);
                        break;
                }
            else
                switch (LedColor)
                {
                    case EColor.Red:
                        _moGradientColor.HighlightColor = Color.FromArgb(200, 180, 180);
                        _moGradientColor.BackColor = Color.FromArgb(70, 50, 50);
                        break;
                    case EColor.Green:
                        _moGradientColor.HighlightColor = Color.FromArgb(180, 200, 180);
                        _moGradientColor.BackColor = Color.FromArgb(50, 70, 50);
                        break;
                    case EColor.Yellow:
                        _moGradientColor.HighlightColor = Color.FromArgb(200, 200, 180);
                        _moGradientColor.BackColor = Color.FromArgb(70, 70, 50);
                        break;
                    case EColor.Blue:
                        _moGradientColor.HighlightColor = Color.FromArgb(200, 200, 180);
                        _moGradientColor.BackColor = Color.FromArgb(50, 50, 70);
                        break;
                }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphicsPath = new GraphicsPath())
            {
                var rectangle = new Rectangle(0, 0, Width, Height);
                if (Caption.Length > 0)
                    using (var genericDefault = StringFormat.GenericDefault)
                    {
                        genericDefault.Alignment = StringAlignment.Center;
                        genericDefault.LineAlignment = StringAlignment.Center;
                        genericDefault.Trimming = StringTrimming.Character;
                        switch (CaptionPos)
                        {
                            case ECaptionPos.Left:
                                rectangle.Location = new Point(Width - Height, 0);
                                rectangle.Size = new Size(Height, Height);
                                genericDefault.Alignment = StringAlignment.Near;
                                e.Graphics.DrawString(Caption, Font, Brushes.Black,
                                    new RectangleF(0f, 0f, rectangle.Left, rectangle.Height), genericDefault);
                                break;
                            case ECaptionPos.Right:
                                rectangle.Location = new Point(0, 0);
                                rectangle.Size = new Size(Height, Height);
                                genericDefault.Alignment = StringAlignment.Near;
                                e.Graphics.DrawString(Caption, Font, Brushes.Black,
                                    new RectangleF(rectangle.Width + 1, 0f, Width - rectangle.Width - 1,
                                        rectangle.Height), genericDefault);
                                break;
                        }
                    }
                switch (Shape)
                {
                    case EShape.Circle:
                        graphicsPath.AddEllipse(rectangle.Left, rectangle.Top, rectangle.Width - 3, rectangle.Height - 3);
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (var solidBrush = new SolidBrush(Color.FromArgb(64, 0, 0, 0)))
                        {
                            e.Graphics.FillEllipse(solidBrush, rectangle.Left + 2, rectangle.Top + 2,
                                rectangle.Width - 3, rectangle.Height - 3);
                        }
                        using (var solidBrush = new SolidBrush(Color.FromArgb(96, 0, 0, 0)))
                        {
                            e.Graphics.FillEllipse(solidBrush, rectangle.Left + 1, rectangle.Top + 1,
                                rectangle.Width - 3, rectangle.Height - 3);
                        }
                        e.Graphics.SmoothingMode = SmoothingMode.Default;
                        break;
                    case EShape.Rectangle:
                        graphicsPath.AddRectangle(new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 3,
                            rectangle.Height - 3));
                        break;
                }
                using (var pathGradientBrush = new PathGradientBrush(graphicsPath))
                {
                    pathGradientBrush.CenterColor = _moGradientColor.HighlightColor;
                    pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(rectangle.Width / 4) + rectangle.Left,
                        Convert.ToSingle(rectangle.Height / 4) + rectangle.Top);
                    Color[] surroundColors =
                    {
                        _moGradientColor.BackColor
                    };
                    pathGradientBrush.SurroundColors = surroundColors;
                    e.Graphics.FillPath(pathGradientBrush, graphicsPath);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    switch (Shape)
                    {
                        case EShape.Circle:
                            e.Graphics.DrawEllipse(Pens.Black, rectangle.Left, rectangle.Top, rectangle.Width - 3,
                                rectangle.Height - 3);
                            break;
                        case EShape.Rectangle:
                            e.Graphics.DrawRectangle(Pens.Black, rectangle.Left, rectangle.Top, rectangle.Width - 3,
                                rectangle.Height - 3);
                            using (var pen = new Pen(Color.FromArgb(128, 0, 0, 0)))
                            {
                                e.Graphics.DrawLine(pen, rectangle.Left + 1, rectangle.Height - 2, rectangle.Width - 2,
                                    rectangle.Height - 2);
                                e.Graphics.DrawLine(pen, rectangle.Width - 2, rectangle.Height - 3, rectangle.Width - 2,
                                    rectangle.Top);
                            }
                            using (var pen = new Pen(Color.FromArgb(64, 0, 0, 0)))
                            {
                                e.Graphics.DrawLine(pen, rectangle.Left + 2, rectangle.Height - 1, rectangle.Width - 1,
                                    rectangle.Height - 1);
                                e.Graphics.DrawLine(pen, rectangle.Width - 1, rectangle.Height - 2, rectangle.Width - 1,
                                    rectangle.Top);
                            }
                            break;
                    }
                    if (State != EState.StateUnknown) return;
                    using (var font = new Font(Font.Name, Convert.ToSingle(rectangle.Height / 2), FontStyle.Bold))
                    {
                        using (var genericDefault = StringFormat.GenericDefault)
                        {
                            genericDefault.Alignment = StringAlignment.Center;
                            genericDefault.LineAlignment = StringAlignment.Center;
                            genericDefault.Trimming = StringTrimming.Character;
                            e.Graphics.DrawString("?", font, Brushes.White,
                                new RectangleF(rectangle.Left, rectangle.Top, rectangle.Width - 1,
                                    rectangle.Height - 1), genericDefault);
                        }
                    }
                }
            }
        }
    }
}