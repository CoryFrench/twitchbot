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
            this.ConnectionIndicatorTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.JoinChannelTextBox = new System.Windows.Forms.TextBox();
            this.JoinChannelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectionIndicatorTextBox
            // 
            this.ConnectionIndicatorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionIndicatorTextBox.BackColor = System.Drawing.Color.Red;
            this.ConnectionIndicatorTextBox.Location = new System.Drawing.Point(4, 4);
            this.ConnectionIndicatorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectionIndicatorTextBox.Name = "ConnectionIndicatorTextBox";
            this.ConnectionIndicatorTextBox.Size = new System.Drawing.Size(24, 22);
            this.ConnectionIndicatorTextBox.TabIndex = 0;
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConnectionStatusLabel.AutoSize = true;
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(36, 6);
            this.ConnectionStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(199, 17);
            this.ConnectionStatusLabel.TabIndex = 1;
            this.ConnectionStatusLabel.Text = "Twitch SRV Connection Status";
            // 
            // JoinChannelTextBox
            // 
            this.JoinChannelTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinChannelTextBox.Location = new System.Drawing.Point(4, 44);
            this.JoinChannelTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.JoinChannelTextBox.Name = "JoinChannelTextBox";
            this.JoinChannelTextBox.Size = new System.Drawing.Size(271, 22);
            this.JoinChannelTextBox.TabIndex = 2;
            this.JoinChannelTextBox.Enter += new System.EventHandler(this.JoinChannelTextBox_Enter);
            this.JoinChannelTextBox.Leave += new System.EventHandler(this.JoinChannelTextBox_Leave);
            // 
            // JoinChannelButton
            // 
            this.JoinChannelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JoinChannelButton.Location = new System.Drawing.Point(283, 41);
            this.JoinChannelButton.Margin = new System.Windows.Forms.Padding(4);
            this.JoinChannelButton.Name = "JoinChannelButton";
            this.JoinChannelButton.Size = new System.Drawing.Size(100, 28);
            this.JoinChannelButton.TabIndex = 3;
            this.JoinChannelButton.Text = "Join Channel";
            this.JoinChannelButton.UseVisualStyleBackColor = true;
            this.JoinChannelButton.Click += new System.EventHandler(this.JoinChannelButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.8714F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.1286F));
            this.tableLayoutPanel1.Controls.Add(this.JoinChannelButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.JoinChannelTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 76);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ConnectionIndicatorTextBox);
            this.flowLayoutPanel1.Controls.Add(this.ConnectionStatusLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 29);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // BotDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BotDashboard";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ConnectionIndicatorTextBox;
        private System.Windows.Forms.Label ConnectionStatusLabel;
        private System.Windows.Forms.TextBox JoinChannelTextBox;
        private System.Windows.Forms.Button JoinChannelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

