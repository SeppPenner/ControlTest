namespace ControlTest
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.led1 = new ControlTest.Led();
            this.led2 = new ControlTest.Led();
            this.SuspendLayout();
            // 
            // led1
            // 
            this.led1.BooleanState = true;
            this.led1.Caption = "";
            this.led1.CaptionPos = ControlTest.Led.ECaptionPos.Left;
            this.led1.LedColor = ControlTest.Led.EColor.Yellow;
            this.led1.Location = new System.Drawing.Point(97, 83);
            this.led1.Name = "led1";
            this.led1.Shape = ControlTest.Led.EShape.Circle;
            this.led1.Size = new System.Drawing.Size(50, 46);
            this.led1.State = ControlTest.Led.EState.StateOn;
            this.led1.TabIndex = 0;
            // 
            // led2
            // 
            this.led2.BooleanState = true;
            this.led2.Caption = "Connected";
            this.led2.CaptionPos = ControlTest.Led.ECaptionPos.Right;
            this.led2.LedColor = ControlTest.Led.EColor.Green;
            this.led2.Location = new System.Drawing.Point(97, 135);
            this.led2.Name = "led2";
            this.led2.Shape = ControlTest.Led.EShape.Circle;
            this.led2.Size = new System.Drawing.Size(175, 51);
            this.led2.State = ControlTest.Led.EState.StateOn;
            this.led2.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.led1);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Led led1;
        private Led led2;

    }
}

