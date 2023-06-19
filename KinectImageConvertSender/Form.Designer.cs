
namespace KinectImageConvertSender
{
    partial class Form
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
            this.depthBitmapBox = new System.Windows.Forms.PictureBox();
            this.irBitmapBOX = new System.Windows.Forms.PictureBox();
            this.Depth_Label = new System.Windows.Forms.Label();
            this.IR_Label = new System.Windows.Forms.Label();
            this.UDPConectStart = new System.Windows.Forms.Button();
            this.ViewIpAdress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewPort = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.depthBitmapBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.irBitmapBOX)).BeginInit();
            this.SuspendLayout();
            // 
            // depthBitmapBox
            // 
            this.depthBitmapBox.Location = new System.Drawing.Point(15, 27);
            this.depthBitmapBox.Name = "depthBitmapBox";
            this.depthBitmapBox.Size = new System.Drawing.Size(300, 300);
            this.depthBitmapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.depthBitmapBox.TabIndex = 0;
            this.depthBitmapBox.TabStop = false;
            // 
            // irBitmapBOX
            // 
            this.irBitmapBOX.Location = new System.Drawing.Point(339, 27);
            this.irBitmapBOX.Name = "irBitmapBOX";
            this.irBitmapBOX.Size = new System.Drawing.Size(300, 300);
            this.irBitmapBOX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.irBitmapBOX.TabIndex = 1;
            this.irBitmapBOX.TabStop = false;
            // 
            // Depth_Label
            // 
            this.Depth_Label.AutoSize = true;
            this.Depth_Label.Location = new System.Drawing.Point(13, 12);
            this.Depth_Label.Name = "Depth_Label";
            this.Depth_Label.Size = new System.Drawing.Size(35, 12);
            this.Depth_Label.TabIndex = 2;
            this.Depth_Label.Text = "Depth";
            // 
            // IR_Label
            // 
            this.IR_Label.AutoSize = true;
            this.IR_Label.Location = new System.Drawing.Point(340, 12);
            this.IR_Label.Name = "IR_Label";
            this.IR_Label.Size = new System.Drawing.Size(16, 12);
            this.IR_Label.TabIndex = 3;
            this.IR_Label.Text = "IR";
            // 
            // UDPConectStart
            // 
            this.UDPConectStart.Location = new System.Drawing.Point(662, 27);
            this.UDPConectStart.Name = "UDPConectStart";
            this.UDPConectStart.Size = new System.Drawing.Size(75, 23);
            this.UDPConectStart.TabIndex = 4;
            this.UDPConectStart.Text = "UDPConectStart";
            this.UDPConectStart.UseVisualStyleBackColor = true;
            this.UDPConectStart.Click += new System.EventHandler(this.UDPConectStart_Click);
            // 
            // ViewIpAdress
            // 
            this.ViewIpAdress.AutoSize = true;
            this.ViewIpAdress.Location = new System.Drawing.Point(694, 88);
            this.ViewIpAdress.Name = "ViewIpAdress";
            this.ViewIpAdress.Size = new System.Drawing.Size(75, 12);
            this.ViewIpAdress.TabIndex = 5;
            this.ViewIpAdress.Text = "ViewIpAdress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ConectInfo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(662, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port";
            // 
            // ViewPort
            // 
            this.ViewPort.AutoSize = true;
            this.ViewPort.Location = new System.Drawing.Point(694, 100);
            this.ViewPort.Name = "ViewPort";
            this.ViewPort.Size = new System.Drawing.Size(51, 12);
            this.ViewPort.TabIndex = 9;
            this.ViewPort.Text = "ViewPort";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 369);
            this.Controls.Add(this.ViewPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ViewIpAdress);
            this.Controls.Add(this.UDPConectStart);
            this.Controls.Add(this.IR_Label);
            this.Controls.Add(this.Depth_Label);
            this.Controls.Add(this.irBitmapBOX);
            this.Controls.Add(this.depthBitmapBox);
            this.Name = "Form";
            this.Text = "KinectViewAndUDPSender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.depthBitmapBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.irBitmapBOX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox depthBitmapBox;
        private System.Windows.Forms.PictureBox irBitmapBOX;
        private System.Windows.Forms.Label Depth_Label;
        private System.Windows.Forms.Label IR_Label;
        private System.Windows.Forms.Button UDPConectStart;
        private System.Windows.Forms.Label ViewIpAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ViewPort;
    }
}

