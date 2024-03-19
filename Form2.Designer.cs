namespace Triliza
{
    partial class TicTac
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
            Restart = new Button();
            CPUTIMER = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // Restart
            // 
            Restart.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 161);
            Restart.Location = new Point(1423, 343);
            Restart.Name = "Restart";
            Restart.Size = new Size(127, 61);
            Restart.TabIndex = 0;
            Restart.Text = "Restart";
            Restart.UseVisualStyleBackColor = true;
            Restart.Click += Restart_Click;
            // 
            // TicTac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 875);
            Controls.Add(Restart);
            Name = "TicTac";
            Text = "Form2";
            Load += TicTac_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Restart;
        private System.Windows.Forms.Timer CPUTIMER;
    }
}