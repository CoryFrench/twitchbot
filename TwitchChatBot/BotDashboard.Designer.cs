using TwitchChatBot.Properties;

namespace TwitchChatBot
{
    partial class BotDashboard
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
            this.components = new System.ComponentModel.Container();
            this.ConnectionIndicatorTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.JoinChannelTextBox = new System.Windows.Forms.TextBox();
            this.JoinChannelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.RunLocalGameCheckbox = new System.Windows.Forms.CheckBox();
            this.StateSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.ForceStateButton = new System.Windows.Forms.Button();
            this.iDashboardModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iDashboardModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionIndicatorTextBox
            // 
            this.ConnectionIndicatorTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectionIndicatorTextBox.BackColor = System.Drawing.Color.Red;
            this.ConnectionIndicatorTextBox.Location = new System.Drawing.Point(4, 504);
            this.ConnectionIndicatorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectionIndicatorTextBox.Name = "ConnectionIndicatorTextBox";
            this.ConnectionIndicatorTextBox.Size = new System.Drawing.Size(24, 22);
            this.ConnectionIndicatorTextBox.TabIndex = 0;
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnectionStatusLabel.AutoSize = true;
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(36, 500);
            this.ConnectionStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(199, 30);
            this.ConnectionStatusLabel.TabIndex = 1;
            this.ConnectionStatusLabel.Text = "Twitch SRV Connection Status";
            this.ConnectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // JoinChannelTextBox
            // 
            this.JoinChannelTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinChannelTextBox.Location = new System.Drawing.Point(243, 41);
            this.JoinChannelTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.JoinChannelTextBox.Name = "JoinChannelTextBox";
            this.JoinChannelTextBox.Size = new System.Drawing.Size(189, 22);
            this.JoinChannelTextBox.TabIndex = 2;
            this.JoinChannelTextBox.Enter += new System.EventHandler(this.JoinChannelTextBox_Enter);
            this.JoinChannelTextBox.Leave += new System.EventHandler(this.JoinChannelTextBox_Leave);
            // 
            // JoinChannelButton
            // 
            this.JoinChannelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JoinChannelButton.AutoSize = true;
            this.JoinChannelButton.Location = new System.Drawing.Point(440, 38);
            this.JoinChannelButton.Margin = new System.Windows.Forms.Padding(4);
            this.JoinChannelButton.Name = "JoinChannelButton";
            this.JoinChannelButton.Size = new System.Drawing.Size(106, 28);
            this.JoinChannelButton.TabIndex = 3;
            this.JoinChannelButton.Text = "Join Channel";
            this.JoinChannelButton.UseVisualStyleBackColor = true;
            this.JoinChannelButton.Click += new System.EventHandler(this.JoinChannelButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.JoinChannelTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ConnectionIndicatorTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ConnectionStatusLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.RunLocalGameCheckbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StateSelectionComboBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ForceStateButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.JoinChannelButton, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1043, 530);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 5);
            this.groupBox1.Controls.Add(this.LogListBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1037, 424);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bot Log";
            // 
            // LogListBox
            // 
            this.LogListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogListBox.ItemHeight = 16;
            this.LogListBox.Location = new System.Drawing.Point(3, 18);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(1031, 403);
            this.LogListBox.TabIndex = 0;
            // 
            // RunLocalGameCheckbox
            // 
            this.RunLocalGameCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RunLocalGameCheckbox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.RunLocalGameCheckbox, 2);
            this.RunLocalGameCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.iDashboardModelBindingSource, "ShouldRunLocalGame", true));
            this.RunLocalGameCheckbox.Location = new System.Drawing.Point(3, 3);
            this.RunLocalGameCheckbox.Name = "RunLocalGameCheckbox";
            this.RunLocalGameCheckbox.Size = new System.Drawing.Size(136, 28);
            this.RunLocalGameCheckbox.TabIndex = 6;
            this.RunLocalGameCheckbox.Text = "Run Local Game";
            this.RunLocalGameCheckbox.UseVisualStyleBackColor = true;
            // 
            // StateSelectionComboBox
            // 
            this.StateSelectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StateSelectionComboBox.FormattingEnabled = true;
            this.StateSelectionComboBox.Location = new System.Drawing.Point(243, 5);
            this.StateSelectionComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.StateSelectionComboBox.Name = "StateSelectionComboBox";
            this.StateSelectionComboBox.Size = new System.Drawing.Size(189, 24);
            this.StateSelectionComboBox.TabIndex = 7;
            // 
            // ForceStateButton
            // 
            this.ForceStateButton.AutoSize = true;
            this.ForceStateButton.Location = new System.Drawing.Point(439, 3);
            this.ForceStateButton.Name = "ForceStateButton";
            this.ForceStateButton.Size = new System.Drawing.Size(107, 27);
            this.ForceStateButton.TabIndex = 8;
            this.ForceStateButton.Text = "Force State";
            this.ForceStateButton.UseVisualStyleBackColor = true;
            this.ForceStateButton.Click += new System.EventHandler(this.ForceState_Click);
            // 
            // iDashboardModelBindingSource
            // 
            this.iDashboardModelBindingSource.DataSource = typeof(TwitchChatBot.IDashboardModel);
            // 
            // BotDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BotDashboard";
            this.Text = "Twitch Adventure Bot";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iDashboardModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConnectionIndicatorTextBox;
        private System.Windows.Forms.Label ConnectionStatusLabel;
        private System.Windows.Forms.TextBox JoinChannelTextBox;
        private System.Windows.Forms.Button JoinChannelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.CheckBox RunLocalGameCheckbox;
        private System.Windows.Forms.ComboBox StateSelectionComboBox;
        private System.Windows.Forms.Button ForceStateButton;
        private System.Windows.Forms.BindingSource iDashboardModelBindingSource;
    }
}

