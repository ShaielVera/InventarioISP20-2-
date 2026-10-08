namespace Desktop.Views
{
    partial class SplashView
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            progressBar = new ProgressBar();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Baskerville Old Face", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(244, 115);
            label1.Name = "label1";
            label1.Size = new Size(329, 43);
            label1.TabIndex = 0;
            label1.Text = "Inventario Isp Nº20";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 415);
            progressBar.MarqueeAnimationSpeed = 20;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(776, 23);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 1;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 3000;
            timer.Tick += timer_Tick;
            // 
            // SplashView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashView";
            Load += SplashView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
    }
}