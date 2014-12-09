namespace Sbiz.Client
{
    partial class SbizSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SbizSettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SbizClientShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.SbizClientAltCheckBox = new System.Windows.Forms.CheckBox();
            this.SbizClientCtrlCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.SbizClientNextComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SbizClientFullscreenComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SbizClientHotKeyComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.SbizClientInputUDPportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientInputUDPportNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(267, 262);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SbizClientShiftCheckBox);
            this.tabPage1.Controls.Add(this.SbizClientAltCheckBox);
            this.tabPage1.Controls.Add(this.SbizClientCtrlCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(259, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Modifiers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SbizClientShiftCheckBox
            // 
            this.SbizClientShiftCheckBox.AutoSize = true;
            this.SbizClientShiftCheckBox.Location = new System.Drawing.Point(22, 70);
            this.SbizClientShiftCheckBox.Name = "SbizClientShiftCheckBox";
            this.SbizClientShiftCheckBox.Size = new System.Drawing.Size(57, 17);
            this.SbizClientShiftCheckBox.TabIndex = 4;
            this.SbizClientShiftCheckBox.Text = "SHIFT";
            this.SbizClientShiftCheckBox.UseVisualStyleBackColor = true;
            this.SbizClientShiftCheckBox.CheckedChanged += new System.EventHandler(this.SbizClientShiftCheckBox_CheckedChanged);
            // 
            // SbizClientAltCheckBox
            // 
            this.SbizClientAltCheckBox.AutoSize = true;
            this.SbizClientAltCheckBox.Location = new System.Drawing.Point(22, 103);
            this.SbizClientAltCheckBox.Name = "SbizClientAltCheckBox";
            this.SbizClientAltCheckBox.Size = new System.Drawing.Size(46, 17);
            this.SbizClientAltCheckBox.TabIndex = 5;
            this.SbizClientAltCheckBox.Text = "ALT";
            this.SbizClientAltCheckBox.UseVisualStyleBackColor = true;
            this.SbizClientAltCheckBox.CheckedChanged += new System.EventHandler(this.SbizClientAltCheckBox_CheckedChanged);
            // 
            // SbizClientCtrlCheckBox
            // 
            this.SbizClientCtrlCheckBox.AutoSize = true;
            this.SbizClientCtrlCheckBox.Location = new System.Drawing.Point(22, 37);
            this.SbizClientCtrlCheckBox.Name = "SbizClientCtrlCheckBox";
            this.SbizClientCtrlCheckBox.Size = new System.Drawing.Size(54, 17);
            this.SbizClientCtrlCheckBox.TabIndex = 3;
            this.SbizClientCtrlCheckBox.Text = "CTRL";
            this.SbizClientCtrlCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SbizClientCtrlCheckBox.UseVisualStyleBackColor = true;
            this.SbizClientCtrlCheckBox.CheckedChanged += new System.EventHandler(this.SbizClientCtrlCheckBox_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.SbizClientNextComboBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.SbizClientFullscreenComboBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.SbizClientHotKeyComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(259, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Key Binds";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Next";
            // 
            // SbizClientNextComboBox
            // 
            this.SbizClientNextComboBox.FormattingEnabled = true;
            this.SbizClientNextComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.SbizClientNextComboBox.Location = new System.Drawing.Point(202, 78);
            this.SbizClientNextComboBox.Name = "SbizClientNextComboBox";
            this.SbizClientNextComboBox.Size = new System.Drawing.Size(46, 21);
            this.SbizClientNextComboBox.TabIndex = 11;
            this.SbizClientNextComboBox.SelectedIndexChanged += new System.EventHandler(this.SbizClientNextComboBox_SelectedIndexChanged);
            this.SbizClientNextComboBox.Enter += new System.EventHandler(this.SbizClientNextComboBox_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fullscreen";
            // 
            // SbizClientFullscreenComboBox
            // 
            this.SbizClientFullscreenComboBox.FormattingEnabled = true;
            this.SbizClientFullscreenComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.SbizClientFullscreenComboBox.Location = new System.Drawing.Point(202, 50);
            this.SbizClientFullscreenComboBox.Name = "SbizClientFullscreenComboBox";
            this.SbizClientFullscreenComboBox.Size = new System.Drawing.Size(46, 21);
            this.SbizClientFullscreenComboBox.TabIndex = 9;
            this.SbizClientFullscreenComboBox.SelectedIndexChanged += new System.EventHandler(this.SbizClientFullscreenComboBox_SelectedIndexChanged);
            this.SbizClientFullscreenComboBox.Enter += new System.EventHandler(this.SbizClientFullscreenComboBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sbiz HotKey";
            // 
            // SbizClientHotKeyComboBox
            // 
            this.SbizClientHotKeyComboBox.FormattingEnabled = true;
            this.SbizClientHotKeyComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.SbizClientHotKeyComboBox.Location = new System.Drawing.Point(202, 22);
            this.SbizClientHotKeyComboBox.Name = "SbizClientHotKeyComboBox";
            this.SbizClientHotKeyComboBox.Size = new System.Drawing.Size(46, 21);
            this.SbizClientHotKeyComboBox.TabIndex = 7;
            this.SbizClientHotKeyComboBox.SelectedIndexChanged += new System.EventHandler(this.SbizClientHotKeyComboBox_SelectedIndexChanged);
            this.SbizClientHotKeyComboBox.Enter += new System.EventHandler(this.SbizClientHotKeyComboBox_Enter);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.SbizClientInputUDPportNumericUpDown);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(259, 236);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Port";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Input UDP port";
            // 
            // SbizClientInputUDPportNumericUpDown
            // 
            this.SbizClientInputUDPportNumericUpDown.Location = new System.Drawing.Point(15, 39);
            this.SbizClientInputUDPportNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SbizClientInputUDPportNumericUpDown.Name = "SbizClientInputUDPportNumericUpDown";
            this.SbizClientInputUDPportNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.SbizClientInputUDPportNumericUpDown.TabIndex = 0;
            this.SbizClientInputUDPportNumericUpDown.ValueChanged += new System.EventHandler(this.SbizClientInputUDPportNumericUpDown_ValueChanged);
            // 
            // SbizSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 262);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SbizSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SbizClientInputUDPportNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox SbizClientShiftCheckBox;
        private System.Windows.Forms.CheckBox SbizClientAltCheckBox;
        private System.Windows.Forms.CheckBox SbizClientCtrlCheckBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SbizClientFullscreenComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SbizClientHotKeyComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SbizClientNextComboBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SbizClientInputUDPportNumericUpDown;

    }
}