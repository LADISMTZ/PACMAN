namespace Pacman
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PCT_CANVAS = new PictureBox();
            ScoreLabel = new Label();
            TIMER = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.BackColor = Color.Black;
            PCT_CANVAS.Location = new Point(56, 71);
            PCT_CANVAS.Margin = new Padding(2, 1, 2, 1);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(914, 800);
            PCT_CANVAS.TabIndex = 0;
            PCT_CANVAS.TabStop = false;
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new Font("STHupo", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ScoreLabel.ForeColor = SystemColors.ButtonFace;
            ScoreLabel.Location = new Point(56, 25);
            ScoreLabel.Margin = new Padding(2, 0, 2, 0);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new Size(87, 31);
            ScoreLabel.TabIndex = 4;
            ScoreLabel.Text = "Score";
            // 
            // TIMER
            // 
            TIMER.Enabled = true;
            TIMER.Interval = 40;
            TIMER.Tick += TIMER_Tick;
            // 
            // button1
            // 
            button1.Font = new Font("STHupo", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button1.Location = new Point(803, 12);
            button1.Name = "button1";
            button1.Size = new Size(167, 44);
            button1.TabIndex = 5;
            button1.Text = "Play Again";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1022, 840);
            Controls.Add(button1);
            Controls.Add(ScoreLabel);
            Controls.Add(PCT_CANVAS);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PCT_CANVAS;
        private Label ScoreLabel;
        private System.Windows.Forms.Timer TIMER;
        private Button button1;
    }
}
