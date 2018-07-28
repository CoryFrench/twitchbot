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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotDashboard));
            this.ConnectionIndicatorTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.JoinChannelTextBox = new System.Windows.Forms.TextBox();
            this.JoinChannelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LogListView = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.SetColumnSpan(this.JoinChannelTextBox, 2);
            this.JoinChannelTextBox.Location = new System.Drawing.Point(4, 7);
            this.JoinChannelTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.JoinChannelTextBox.Name = "JoinChannelTextBox";
            this.JoinChannelTextBox.Size = new System.Drawing.Size(239, 22);
            this.JoinChannelTextBox.TabIndex = 2;
            this.JoinChannelTextBox.Enter += new System.EventHandler(this.JoinChannelTextBox_Enter);
            this.JoinChannelTextBox.Leave += new System.EventHandler(this.JoinChannelTextBox_Leave);
            // 
            // JoinChannelButton
            // 
            this.JoinChannelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JoinChannelButton.Location = new System.Drawing.Point(251, 4);
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
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.JoinChannelTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ConnectionIndicatorTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ConnectionStatusLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.JoinChannelButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
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
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.LogListView);
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1037, 458);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bot Log";
            // 
            // LogListView
            // 
            this.LogListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogListView.Location = new System.Drawing.Point(7, 22);
            this.LogListView.Name = "LogListView";
            this.LogListView.Size = new System.Drawing.Size(1024, 429);
            this.LogListView.TabIndex = 0;
            //this.LogListView.UseCompatibleStateImageBehavior = false;
            // 
            // BotDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BotDashboard";
            this.Text = "Twitch Adventure Bot";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox LogListView;
    }
}

