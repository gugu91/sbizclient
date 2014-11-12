namespace Sbiz.Client
{
    partial class SbizClientRunningUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SbizClientRunningTextLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.SbizClientRunningTextLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(728, 354);
            this.MainPanel.TabIndex = 7;
            this.MainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.MainPanel.MouseHover += new System.EventHandler(this.MainPanel_MouseHover);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            this.MainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseUp);
            // 
            // SbizClientRunningTextLabel
            // 
            this.SbizClientRunningTextLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientRunningTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SbizClientRunningTextLabel.Location = new System.Drawing.Point(0, 0);
            this.SbizClientRunningTextLabel.Name = "SbizClientRunningTextLabel";
            this.SbizClientRunningTextLabel.Size = new System.Drawing.Size(728, 354);
            this.SbizClientRunningTextLabel.TabIndex = 0;
            this.SbizClientRunningTextLabel.Text = "Welcome!";
            this.SbizClientRunningTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SbizClientRunningTextLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SbizClientRunningTextLabel_MouseDown);
            this.SbizClientRunningTextLabel.MouseLeave += new System.EventHandler(this.SbizClientRunningTextLabel_MouseLeave);
            this.SbizClientRunningTextLabel.MouseHover += new System.EventHandler(this.SbizClientRunningTextLabel_MouseHover);
            this.SbizClientRunningTextLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SbizClientRunningTextLabel_MouseMove);
            this.SbizClientRunningTextLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SbizClientRunningTextLabel_MouseUp);
            // 
            // SbizClientRunningUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainPanel);
            this.Name = "SbizClientRunningUC";
            this.Size = new System.Drawing.Size(728, 354);
            this.EnabledChanged += new System.EventHandler(this.SbizClientRunningUC_EnabledChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SbizClientRunningUC_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SbizClientRunningUC_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SbizClientRunningUC_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SbizClientRunningUC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SbizClientRunningUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SbizClientRunningUC_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SbizClientRunningUC_PreviewKeyDown);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label SbizClientRunningTextLabel;

    }
}
