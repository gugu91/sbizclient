namespace SbizClient
{
    partial class SbizClientPropertiesForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SbizClientPropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.IpAddress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SbizClientConnectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SbizClientPanel = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.SbizClientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // IpAddress
            // 
            this.IpAddress.Location = new System.Drawing.Point(88, 64);
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.Size = new System.Drawing.Size(100, 20);
            this.IpAddress.TabIndex = 1;
            this.IpAddress.Text = "127.0.0.1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(260, 64);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(100, 20);
            this.Port.TabIndex = 2;
            this.Port.Text = "15001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientConnectionStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 200);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(447, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SbizClientConnectionStatusLabel
            // 
            this.SbizClientConnectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.SbizClientConnectionStatusLabel.Name = "SbizClientConnectionStatusLabel";
            this.SbizClientConnectionStatusLabel.Size = new System.Drawing.Size(88, 17);
            this.SbizClientConnectionStatusLabel.Text = "Not Connected";
            // 
            // SbizClientPanel
            // 
            this.SbizClientPanel.Controls.Add(this.IpAddress);
            this.SbizClientPanel.Controls.Add(this.label1);
            this.SbizClientPanel.Controls.Add(this.label2);
            this.SbizClientPanel.Controls.Add(this.Port);
            this.SbizClientPanel.Controls.Add(this.button1);
            this.SbizClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SbizClientPanel.Location = new System.Drawing.Point(0, 0);
            this.SbizClientPanel.Name = "SbizClientPanel";
            this.SbizClientPanel.Size = new System.Drawing.Size(447, 200);
            this.SbizClientPanel.TabIndex = 6;
            // 
            // SbizClientPropertiesForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 222);
            this.Controls.Add(this.SbizClientPanel);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SbizClientPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SbizClient";
            this.TopMost = true;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.SbizClientPanel.ResumeLayout(false);
            this.SbizClientPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IpAddress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SbizClientConnectionStatusLabel;
        private System.Windows.Forms.Panel SbizClientPanel;
    }
}

