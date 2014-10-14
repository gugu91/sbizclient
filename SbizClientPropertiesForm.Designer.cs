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
            this.SbizClientIPAddressLabel = new System.Windows.Forms.Label();
            this.SbizClientIpAddress = new System.Windows.Forms.TextBox();
            this.SbizClientConnectButton = new System.Windows.Forms.Button();
            this.SbizClientPortLabel = new System.Windows.Forms.Label();
            this.SbizClientNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SbizClientStatusStrip = new System.Windows.Forms.StatusStrip();
            this.SbizClientConnectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SbizClientPanel = new System.Windows.Forms.Panel();
            this.SbizClientPort = new System.Windows.Forms.NumericUpDown();
            this.SbizClientMenuStrip = new System.Windows.Forms.MenuStrip();
            this.SbizClientMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientExitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientMenuView = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientToggleFullscreenToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientMenuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientInfoToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientStatusStrip.SuspendLayout();
            this.SbizClientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientPort)).BeginInit();
            this.SbizClientMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SbizClientIPAddressLabel
            // 
            this.SbizClientIPAddressLabel.AutoSize = true;
            this.SbizClientIPAddressLabel.Location = new System.Drawing.Point(85, 48);
            this.SbizClientIPAddressLabel.Name = "SbizClientIPAddressLabel";
            this.SbizClientIPAddressLabel.Size = new System.Drawing.Size(58, 13);
            this.SbizClientIPAddressLabel.TabIndex = 0;
            this.SbizClientIPAddressLabel.Text = "IP Address";
            // 
            // SbizClientIpAddress
            // 
            this.SbizClientIpAddress.Location = new System.Drawing.Point(88, 64);
            this.SbizClientIpAddress.Name = "SbizClientIpAddress";
            this.SbizClientIpAddress.Size = new System.Drawing.Size(100, 20);
            this.SbizClientIpAddress.TabIndex = 1;
            this.SbizClientIpAddress.Text = "127.0.0.1";
            // 
            // SbizClientConnectButton
            // 
            this.SbizClientConnectButton.Location = new System.Drawing.Point(186, 119);
            this.SbizClientConnectButton.Name = "SbizClientConnectButton";
            this.SbizClientConnectButton.Size = new System.Drawing.Size(75, 23);
            this.SbizClientConnectButton.TabIndex = 4;
            this.SbizClientConnectButton.Text = "Connect";
            this.SbizClientConnectButton.UseVisualStyleBackColor = true;
            this.SbizClientConnectButton.Click += new System.EventHandler(this.SbizClientConnectButton_Click);
            // 
            // SbizClientPortLabel
            // 
            this.SbizClientPortLabel.AutoSize = true;
            this.SbizClientPortLabel.Location = new System.Drawing.Point(257, 48);
            this.SbizClientPortLabel.Name = "SbizClientPortLabel";
            this.SbizClientPortLabel.Size = new System.Drawing.Size(26, 13);
            this.SbizClientPortLabel.TabIndex = 3;
            this.SbizClientPortLabel.Text = "Port";
            // 
            // SbizClientNotifyIcon
            // 
            this.SbizClientNotifyIcon.Text = "notifyIcon1";
            this.SbizClientNotifyIcon.Visible = true;
            // 
            // SbizClientStatusStrip
            // 
            this.SbizClientStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientConnectionStatusLabel});
            this.SbizClientStatusStrip.Location = new System.Drawing.Point(0, 200);
            this.SbizClientStatusStrip.Name = "SbizClientStatusStrip";
            this.SbizClientStatusStrip.Size = new System.Drawing.Size(447, 22);
            this.SbizClientStatusStrip.TabIndex = 5;
            this.SbizClientStatusStrip.Text = "statusStrip1";
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
            this.SbizClientPanel.Controls.Add(this.SbizClientPort);
            this.SbizClientPanel.Controls.Add(this.SbizClientIpAddress);
            this.SbizClientPanel.Controls.Add(this.SbizClientIPAddressLabel);
            this.SbizClientPanel.Controls.Add(this.SbizClientPortLabel);
            this.SbizClientPanel.Controls.Add(this.SbizClientConnectButton);
            this.SbizClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SbizClientPanel.Location = new System.Drawing.Point(0, 0);
            this.SbizClientPanel.Name = "SbizClientPanel";
            this.SbizClientPanel.Size = new System.Drawing.Size(447, 200);
            this.SbizClientPanel.TabIndex = 6;
            // 
            // SbizClientPort
            // 
            this.SbizClientPort.Location = new System.Drawing.Point(260, 65);
            this.SbizClientPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SbizClientPort.Name = "SbizClientPort";
            this.SbizClientPort.Size = new System.Drawing.Size(100, 20);
            this.SbizClientPort.TabIndex = 2;
            this.SbizClientPort.Value = new decimal(new int[] {
            15001,
            0,
            0,
            0});
            // 
            // SbizClientMenuStrip
            // 
            this.SbizClientMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientMenu,
            this.SbizClientMenuView,
            this.SbizClientMenuInfo});
            this.SbizClientMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.SbizClientMenuStrip.Name = "SbizClientMenuStrip";
            this.SbizClientMenuStrip.Size = new System.Drawing.Size(447, 24);
            this.SbizClientMenuStrip.TabIndex = 7;
            this.SbizClientMenuStrip.Text = "menuStrip2";
            // 
            // SbizClientMenu
            // 
            this.SbizClientMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientExitToolStrip});
            this.SbizClientMenu.Name = "SbizClientMenu";
            this.SbizClientMenu.Size = new System.Drawing.Size(71, 20);
            this.SbizClientMenu.Text = "SbizClient";
            // 
            // SbizClientExitToolStrip
            // 
            this.SbizClientExitToolStrip.Name = "SbizClientExitToolStrip";
            this.SbizClientExitToolStrip.Size = new System.Drawing.Size(92, 22);
            this.SbizClientExitToolStrip.Text = "Exit";
            this.SbizClientExitToolStrip.Click += new System.EventHandler(this.SbizClientExit_Click);
            // 
            // SbizClientMenuView
            // 
            this.SbizClientMenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientToggleFullscreenToolStrip});
            this.SbizClientMenuView.Name = "SbizClientMenuView";
            this.SbizClientMenuView.Size = new System.Drawing.Size(44, 20);
            this.SbizClientMenuView.Text = "View";
            // 
            // SbizClientToggleFullscreenToolStrip
            // 
            this.SbizClientToggleFullscreenToolStrip.Name = "SbizClientToggleFullscreenToolStrip";
            this.SbizClientToggleFullscreenToolStrip.Size = new System.Drawing.Size(167, 22);
            this.SbizClientToggleFullscreenToolStrip.Text = "Fullscreen Toggle";
            this.SbizClientToggleFullscreenToolStrip.Click += new System.EventHandler(this.SbizClientToggleFullscreen_Click);
            // 
            // SbizClientMenuInfo
            // 
            this.SbizClientMenuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientInfoToolStrip});
            this.SbizClientMenuInfo.Name = "SbizClientMenuInfo";
            this.SbizClientMenuInfo.Size = new System.Drawing.Size(24, 20);
            this.SbizClientMenuInfo.Text = "?";
            // 
            // SbizClientInfoToolStrip
            // 
            this.SbizClientInfoToolStrip.Name = "SbizClientInfoToolStrip";
            this.SbizClientInfoToolStrip.Size = new System.Drawing.Size(147, 22);
            this.SbizClientInfoToolStrip.Text = "SbizClientInfo";
            // 
            // SbizClientPropertiesForm
            // 
            this.AcceptButton = this.SbizClientConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 222);
            this.Controls.Add(this.SbizClientMenuStrip);
            this.Controls.Add(this.SbizClientPanel);
            this.Controls.Add(this.SbizClientStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SbizClientPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SbizClient";
            this.TopMost = true;
            this.SbizClientStatusStrip.ResumeLayout(false);
            this.SbizClientStatusStrip.PerformLayout();
            this.SbizClientPanel.ResumeLayout(false);
            this.SbizClientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientPort)).EndInit();
            this.SbizClientMenuStrip.ResumeLayout(false);
            this.SbizClientMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SbizClientIPAddressLabel;
        private System.Windows.Forms.TextBox SbizClientIpAddress;
        private System.Windows.Forms.Button SbizClientConnectButton;
        private System.Windows.Forms.Label SbizClientPortLabel;
        private System.Windows.Forms.NotifyIcon SbizClientNotifyIcon;
        private System.Windows.Forms.StatusStrip SbizClientStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SbizClientConnectionStatusLabel;
        private System.Windows.Forms.Panel SbizClientPanel;
        private System.Windows.Forms.MenuStrip SbizClientMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SbizClientMenu;
        private System.Windows.Forms.ToolStripMenuItem SbizClientExitToolStrip;
        private System.Windows.Forms.ToolStripMenuItem SbizClientMenuView;
        private System.Windows.Forms.ToolStripMenuItem SbizClientToggleFullscreenToolStrip;
        private System.Windows.Forms.ToolStripMenuItem SbizClientMenuInfo;
        private System.Windows.Forms.ToolStripMenuItem SbizClientInfoToolStrip;
        private System.Windows.Forms.NumericUpDown SbizClientPort;
    }
}

