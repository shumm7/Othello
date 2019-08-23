namespace Othello
{
    partial class Othello
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Othello));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TipLabel = new System.Windows.Forms.Label();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.LabelAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentColorDisplayPanel = new System.Windows.Forms.Panel();
            this.CanPlaceLabel = new System.Windows.Forms.Label();
            this.MousePos = new System.Windows.Forms.Label();
            this.Position = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 640);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawBoard);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClicked);
            this.panel1.MouseLeave += new System.EventHandler(this.MouseLeft);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TipLabel);
            this.panel2.Controls.Add(this.TurnLabel);
            this.panel2.Controls.Add(this.LabelAmount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CurrentColorDisplayPanel);
            this.panel2.Controls.Add(this.CanPlaceLabel);
            this.panel2.Controls.Add(this.MousePos);
            this.panel2.Controls.Add(this.Position);
            this.panel2.Controls.Add(this.reset);
            this.panel2.Location = new System.Drawing.Point(12, 658);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(640, 85);
            this.panel2.TabIndex = 1;
            // 
            // TipLabel
            // 
            this.TipLabel.AutoSize = true;
            this.TipLabel.Location = new System.Drawing.Point(275, 45);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(0, 15);
            this.TipLabel.TabIndex = 11;
            // 
            // TurnLabel
            // 
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.Font = new System.Drawing.Font("Meiryo UI", 11F);
            this.TurnLabel.Location = new System.Drawing.Point(9, 45);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(18, 19);
            this.TurnLabel.TabIndex = 10;
            this.TurnLabel.Text = "0";
            // 
            // LabelAmount
            // 
            this.LabelAmount.AutoSize = true;
            this.LabelAmount.Font = new System.Drawing.Font("Meiryo UI", 20F);
            this.LabelAmount.Location = new System.Drawing.Point(107, 45);
            this.LabelAmount.Name = "LabelAmount";
            this.LabelAmount.Size = new System.Drawing.Size(136, 35);
            this.LabelAmount.TabIndex = 9;
            this.LabelAmount.Text = "黒:2 白:2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "手番";
            // 
            // CurrentColorDisplayPanel
            // 
            this.CurrentColorDisplayPanel.Location = new System.Drawing.Point(47, 30);
            this.CurrentColorDisplayPanel.Name = "CurrentColorDisplayPanel";
            this.CurrentColorDisplayPanel.Size = new System.Drawing.Size(50, 50);
            this.CurrentColorDisplayPanel.TabIndex = 6;
            this.CurrentColorDisplayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawCurrentColor);
            // 
            // CanPlaceLabel
            // 
            this.CanPlaceLabel.AutoSize = true;
            this.CanPlaceLabel.Font = new System.Drawing.Font("Meiryo UI", 14.25F);
            this.CanPlaceLabel.Location = new System.Drawing.Point(232, 3);
            this.CanPlaceLabel.Name = "CanPlaceLabel";
            this.CanPlaceLabel.Size = new System.Drawing.Size(99, 24);
            this.CanPlaceLabel.TabIndex = 5;
            this.CanPlaceLabel.Text = "範囲外です";
            // 
            // MousePos
            // 
            this.MousePos.AutoSize = true;
            this.MousePos.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MousePos.Location = new System.Drawing.Point(109, 3);
            this.MousePos.Name = "MousePos";
            this.MousePos.Size = new System.Drawing.Size(73, 24);
            this.MousePos.TabIndex = 4;
            this.MousePos.Text = "(-1,-1)";
            // 
            // Position
            // 
            this.Position.AutoSize = true;
            this.Position.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Position.Location = new System.Drawing.Point(9, 3);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(94, 24);
            this.Position.TabIndex = 3;
            this.Position.Text = "X:-1 Y:-1";
            // 
            // reset
            // 
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.reset.Location = new System.Drawing.Point(476, 3);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(161, 38);
            this.reset.TabIndex = 0;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 661);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 2;
            // 
            // Othello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 755);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 794);
            this.MinimumSize = new System.Drawing.Size(680, 794);
            this.Name = "Othello";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Othello";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Position;
        private System.Windows.Forms.Label MousePos;
        private System.Windows.Forms.Label CanPlaceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CurrentColorDisplayPanel;
        private System.Windows.Forms.Label LabelAmount;
        private System.Windows.Forms.Label TurnLabel;
        private System.Windows.Forms.Label TipLabel;
    }
}

