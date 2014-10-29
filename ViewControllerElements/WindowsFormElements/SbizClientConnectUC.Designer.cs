namespace Sbiz.Client
{
    partial class SbizClientConnectUC
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
            this.SbizClientIPAddressLabel = new System.Windows.Forms.Label();
            this.SbizClientIpAddress = new System.Windows.Forms.TextBox();
            this.SbizClientPortLabel = new System.Windows.Forms.Label();
            this.SbizClientPort = new System.Windows.Forms.NumericUpDown();
            this.SbizClientConnectButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientPort)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.SbizClientIPAddressLabel);
            this.MainPanel.Controls.Add(this.SbizClientIpAddress);
            this.MainPanel.Controls.Add(this.SbizClientPortLabel);
            this.MainPanel.Controls.Add(this.SbizClientPort);
            this.MainPanel.Controls.Add(this.SbizClientConnectButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(451, 201);
            this.MainPanel.TabIndex = 6;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SbizClientConnectPanel_Paint);
            // 
            // SbizClientIPAddressLabel
            // 
            this.SbizClientIPAddressLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientIPAddressLabel.AutoSize = true;
            this.SbizClientIPAddressLabel.Location = new System.Drawing.Point(88, 60);
            this.SbizClientIPAddressLabel.Name = "SbizClientIPAddressLabel";
            this.SbizClientIPAddressLabel.Size = new System.Drawing.Size(58, 13);
            this.SbizClientIPAddressLabel.TabIndex = 0;
            this.SbizClientIPAddressLabel.Text = "IP Address";
            // 
            // SbizClientIpAddress
            // 
            this.SbizClientIpAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientIpAddress.Location = new System.Drawing.Point(91, 76);
            this.SbizClientIpAddress.Name = "SbizClientIpAddress";
            this.SbizClientIpAddress.Size = new System.Drawing.Size(100, 20);
            this.SbizClientIpAddress.TabIndex = 1;
            this.SbizClientIpAddress.Text = "127.0.0.1";
            // 
            // SbizClientPortLabel
            // 
            this.SbizClientPortLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientPortLabel.AutoSize = true;
            this.SbizClientPortLabel.Location = new System.Drawing.Point(260, 60);
            this.SbizClientPortLabel.Name = "SbizClientPortLabel";
            this.SbizClientPortLabel.Size = new System.Drawing.Size(26, 13);
            this.SbizClientPortLabel.TabIndex = 3;
            this.SbizClientPortLabel.Text = "Port";
            // 
            // SbizClientPort
            // 
            this.SbizClientPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientPort.Location = new System.Drawing.Point(263, 77);
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
            // SbizClientConnectButton
            // 
            this.SbizClientConnectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SbizClientConnectButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SbizClientConnectButton.Location = new System.Drawing.Point(189, 131);
            this.SbizClientConnectButton.Name = "SbizClientConnectButton";
            this.SbizClientConnectButton.Size = new System.Drawing.Size(75, 23);
            this.SbizClientConnectButton.TabIndex = 4;
            this.SbizClientConnectButton.Text = "Connect";
            this.SbizClientConnectButton.UseVisualStyleBackColor = true;
            this.SbizClientConnectButton.Click += new System.EventHandler(this.SbizClientConnectButton_Click);
            // 
            // SbizClientConnectUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainPanel);
            this.Name = "SbizClientConnectUC";
            this.Size = new System.Drawing.Size(451, 201);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label SbizClientIPAddressLabel;
        private System.Windows.Forms.TextBox SbizClientIpAddress;
        private System.Windows.Forms.Label SbizClientPortLabel;
        private System.Windows.Forms.NumericUpDown SbizClientPort;
        private System.Windows.Forms.Button SbizClientConnectButton;
    }
}
