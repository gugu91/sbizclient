namespace SbizClient
{
    partial class SbizClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SbizClientForm));
            this.SbizClientIPAddressLabel = new System.Windows.Forms.Label();
            this.SbizClientIpAddress = new System.Windows.Forms.TextBox();
            this.SbizClientConnectButton = new System.Windows.Forms.Button();
            this.SbizClientPortLabel = new System.Windows.Forms.Label();
            this.SbizClientNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SbizClientPanel = new System.Windows.Forms.Panel();
            this.SbizClientRunningPanel = new System.Windows.Forms.Panel();
            this.SbizClientTextLabel = new System.Windows.Forms.Label();
            this.SbizClientConnectPanel = new System.Windows.Forms.Panel();
            this.SbizClientPort = new System.Windows.Forms.NumericUpDown();
            this.SbizClientMenuStrip = new System.Windows.Forms.MenuStrip();
            this.SbizClientMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientExitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientMenuView = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientToggleFullscreenToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientMenuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientInfoToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SbizClientTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SbizClientStatusStrip = new System.Windows.Forms.StatusStrip();
            this.SbizClientConnectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SbizClientPanel.SuspendLayout();
            this.SbizClientRunningPanel.SuspendLayout();
            this.SbizClientConnectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientPort)).BeginInit();
            this.SbizClientMenuStrip.SuspendLayout();
            this.SbizClientTableLayoutPanel.SuspendLayout();
            this.SbizClientStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SbizClientIPAddressLabel
            // 
            this.SbizClientIPAddressLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientIPAddressLabel.AutoSize = true;
            this.SbizClientIPAddressLabel.Location = new System.Drawing.Point(83, 48);
            this.SbizClientIPAddressLabel.Name = "SbizClientIPAddressLabel";
            this.SbizClientIPAddressLabel.Size = new System.Drawing.Size(58, 13);
            this.SbizClientIPAddressLabel.TabIndex = 0;
            this.SbizClientIPAddressLabel.Text = "IP Address";
            // 
            // SbizClientIpAddress
            // 
            this.SbizClientIpAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientIpAddress.Location = new System.Drawing.Point(86, 64);
            this.SbizClientIpAddress.Name = "SbizClientIpAddress";
            this.SbizClientIpAddress.Size = new System.Drawing.Size(100, 20);
            this.SbizClientIpAddress.TabIndex = 1;
            this.SbizClientIpAddress.Text = "127.0.0.1";
            // 
            // SbizClientConnectButton
            // 
            this.SbizClientConnectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientConnectButton.Location = new System.Drawing.Point(184, 119);
            this.SbizClientConnectButton.Name = "SbizClientConnectButton";
            this.SbizClientConnectButton.Size = new System.Drawing.Size(75, 23);
            this.SbizClientConnectButton.TabIndex = 4;
            this.SbizClientConnectButton.Text = "Connect";
            this.SbizClientConnectButton.UseVisualStyleBackColor = true;
            this.SbizClientConnectButton.Click += new System.EventHandler(this.SbizClientConnectButton_Click);
            // 
            // SbizClientPortLabel
            // 
            this.SbizClientPortLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientPortLabel.AutoSize = true;
            this.SbizClientPortLabel.Location = new System.Drawing.Point(255, 48);
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
            // SbizClientPanel
            // 
            this.SbizClientPanel.Controls.Add(this.SbizClientRunningPanel);
            this.SbizClientPanel.Controls.Add(this.SbizClientConnectPanel);
            this.SbizClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SbizClientPanel.Location = new System.Drawing.Point(3, 23);
            this.SbizClientPanel.Name = "SbizClientPanel";
            this.SbizClientPanel.Size = new System.Drawing.Size(441, 176);
            this.SbizClientPanel.TabIndex = 6;
            // 
            // SbizClientRunningPanel
            // 
            this.SbizClientRunningPanel.Controls.Add(this.SbizClientTextLabel);
            this.SbizClientRunningPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SbizClientRunningPanel.Location = new System.Drawing.Point(0, 0);
            this.SbizClientRunningPanel.Name = "SbizClientRunningPanel";
            this.SbizClientRunningPanel.Size = new System.Drawing.Size(441, 176);
            this.SbizClientRunningPanel.TabIndex = 6;
            this.SbizClientRunningPanel.Visible = false;
            // 
            // SbizClientTextLabel
            // 
            this.SbizClientTextLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientTextLabel.AutoSize = true;
            this.SbizClientTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SbizClientTextLabel.Location = new System.Drawing.Point(64, 48);
            this.SbizClientTextLabel.Name = "SbizClientTextLabel";
            this.SbizClientTextLabel.Size = new System.Drawing.Size(317, 73);
            this.SbizClientTextLabel.TabIndex = 0;
            this.SbizClientTextLabel.Text = "Welcome!";
            this.SbizClientTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SbizClientConnectPanel
            // 
            this.SbizClientConnectPanel.Controls.Add(this.SbizClientIPAddressLabel);
            this.SbizClientConnectPanel.Controls.Add(this.SbizClientIpAddress);
            this.SbizClientConnectPanel.Controls.Add(this.SbizClientPortLabel);
            this.SbizClientConnectPanel.Controls.Add(this.SbizClientPort);
            this.SbizClientConnectPanel.Controls.Add(this.SbizClientConnectButton);
            this.SbizClientConnectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SbizClientConnectPanel.Location = new System.Drawing.Point(0, 0);
            this.SbizClientConnectPanel.Name = "SbizClientConnectPanel";
            this.SbizClientConnectPanel.Size = new System.Drawing.Size(441, 176);
            this.SbizClientConnectPanel.TabIndex = 5;
            // 
            // SbizClientPort
            // 
            this.SbizClientPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientPort.Location = new System.Drawing.Point(258, 65);
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
            this.SbizClientMenuStrip.Size = new System.Drawing.Size(447, 20);
            this.SbizClientMenuStrip.TabIndex = 7;
            this.SbizClientMenuStrip.Text = "menuStrip2";
            // 
            // SbizClientMenu
            // 
            this.SbizClientMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientExitToolStrip});
            this.SbizClientMenu.Name = "SbizClientMenu";
            this.SbizClientMenu.Size = new System.Drawing.Size(71, 16);
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
            this.SbizClientMenuView.Size = new System.Drawing.Size(44, 16);
            this.SbizClientMenuView.Text = "View";
            // 
            // SbizClientToggleFullscreenToolStrip
            // 
            this.SbizClientToggleFullscreenToolStrip.Enabled = false;
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
            this.SbizClientMenuInfo.Size = new System.Drawing.Size(24, 16);
            this.SbizClientMenuInfo.Text = "?";
            // 
            // SbizClientInfoToolStrip
            // 
            this.SbizClientInfoToolStrip.Name = "SbizClientInfoToolStrip";
            this.SbizClientInfoToolStrip.Size = new System.Drawing.Size(147, 22);
            this.SbizClientInfoToolStrip.Text = "SbizClientInfo";
            // 
            // SbizClientTableLayoutPanel
            // 
            this.SbizClientTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SbizClientTableLayoutPanel.ColumnCount = 1;
            this.SbizClientTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SbizClientTableLayoutPanel.Controls.Add(this.SbizClientMenuStrip, 0, 0);
            this.SbizClientTableLayoutPanel.Controls.Add(this.SbizClientStatusStrip, 0, 1);
            this.SbizClientTableLayoutPanel.Controls.Add(this.SbizClientPanel, 0, 1);
            this.SbizClientTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SbizClientTableLayoutPanel.Name = "SbizClientTableLayoutPanel";
            this.SbizClientTableLayoutPanel.RowCount = 2;
            this.SbizClientTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SbizClientTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SbizClientTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SbizClientTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SbizClientTableLayoutPanel.Size = new System.Drawing.Size(447, 222);
            this.SbizClientTableLayoutPanel.TabIndex = 5;
            // 
            // SbizClientStatusStrip
            // 
            this.SbizClientStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbizClientConnectionStatusLabel});
            this.SbizClientStatusStrip.Location = new System.Drawing.Point(0, 202);
            this.SbizClientStatusStrip.Name = "SbizClientStatusStrip";
            this.SbizClientStatusStrip.Size = new System.Drawing.Size(447, 20);
            this.SbizClientStatusStrip.TabIndex = 5;
            this.SbizClientStatusStrip.Text = "statusStrip1";
            // 
            // SbizClientConnectionStatusLabel
            // 
            this.SbizClientConnectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.SbizClientConnectionStatusLabel.Name = "SbizClientConnectionStatusLabel";
            this.SbizClientConnectionStatusLabel.Size = new System.Drawing.Size(88, 15);
            this.SbizClientConnectionStatusLabel.Text = "Not Connected";
            // 
            // SbizClientForm
            // 
            this.AcceptButton = this.SbizClientConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 222);
            this.Controls.Add(this.SbizClientTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SbizClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SbizClient";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SbizClientFormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SbizClientForm_KeyPress);
            this.SbizClientPanel.ResumeLayout(false);
            this.SbizClientRunningPanel.ResumeLayout(false);
            this.SbizClientRunningPanel.PerformLayout();
            this.SbizClientConnectPanel.ResumeLayout(false);
            this.SbizClientConnectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientPort)).EndInit();
            this.SbizClientMenuStrip.ResumeLayout(false);
            this.SbizClientMenuStrip.PerformLayout();
            this.SbizClientTableLayoutPanel.ResumeLayout(false);
            this.SbizClientTableLayoutPanel.PerformLayout();
            this.SbizClientStatusStrip.ResumeLayout(false);
            this.SbizClientStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SbizClientIPAddressLabel;
        private System.Windows.Forms.TextBox SbizClientIpAddress;
        private System.Windows.Forms.Button SbizClientConnectButton;
        private System.Windows.Forms.Label SbizClientPortLabel;
        private System.Windows.Forms.NotifyIcon SbizClientNotifyIcon;
        private System.Windows.Forms.Panel SbizClientPanel;
        private System.Windows.Forms.MenuStrip SbizClientMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SbizClientMenu;
        private System.Windows.Forms.ToolStripMenuItem SbizClientExitToolStrip;
        private System.Windows.Forms.ToolStripMenuItem SbizClientMenuView;
        private System.Windows.Forms.ToolStripMenuItem SbizClientToggleFullscreenToolStrip;
        private System.Windows.Forms.ToolStripMenuItem SbizClientMenuInfo;
        private System.Windows.Forms.ToolStripMenuItem SbizClientInfoToolStrip;
        private System.Windows.Forms.NumericUpDown SbizClientPort;
        private System.Windows.Forms.TableLayoutPanel SbizClientTableLayoutPanel;
        private System.Windows.Forms.Panel SbizClientConnectPanel;
        private System.Windows.Forms.StatusStrip SbizClientStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SbizClientConnectionStatusLabel;
        private System.Windows.Forms.Panel SbizClientRunningPanel;
        private System.Windows.Forms.Label SbizClientTextLabel;
    }
}

