namespace TwitchChatBot
{
    partial class Form1
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
            this.tbIndicator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbJoinChannel = new System.Windows.Forms.TextBox();
            this.bJoinChannel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIndicator
            // 
            this.tbIndicator.BackColor = System.Drawing.Color.Red;
            this.tbIndicator.Location = new System.Drawing.Point(12, 12);
            this.tbIndicator.Name = "tbIndicator";
            this.tbIndicator.Size = new System.Drawing.Size(19, 20);
            this.tbIndicator.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twitch SRV Connection Status";
            // 
            // tbJoinChannel
            // 
            this.tbJoinChannel.Location = new System.Drawing.Point(12, 38);
            this.tbJoinChannel.Name = "tbJoinChannel";
            this.tbJoinChannel.Size = new System.Drawing.Size(100, 20);
            this.tbJoinChannel.TabIndex = 2;
            this.tbJoinChannel.Text = "Channel to join";
            // 
            // bJoinChannel
            // 
            this.bJoinChannel.Location = new System.Drawing.Point(116, 38);
            this.bJoinChannel.Name = "bJoinChannel";
            this.bJoinChannel.Size = new System.Drawing.Size(75, 23);
            this.bJoinChannel.TabIndex = 3;
            this.bJoinChannel.Text = "Join Channel";
            this.bJoinChannel.UseVisualStyleBackColor = true;
            this.bJoinChannel.Click += new System.EventHandler(this.bJoinChannel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bJoinChannel);
            this.Controls.Add(this.tbJoinChannel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIndicator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIndicator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbJoinChannel;
        private System.Windows.Forms.Button bJoinChannel;
    }
}

