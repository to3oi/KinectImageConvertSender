
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
            this.irBitmapBox = new System.Windows.Forms.PictureBox();
            this.Depth_Label = new System.Windows.Forms.Label();
            this.IR_Label = new System.Windows.Forms.Label();
            this.UDPConectStart = new System.Windows.Forms.Button();
            this.ConnectViewIpAdress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConnectViewPort = new System.Windows.Forms.Label();
            this.PCInfo = new System.Windows.Forms.Label();
            this.PCViewPort = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PCViewIpAdress = new System.Windows.Forms.Label();
            this.GetConnectIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resultBitmapBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.depthBitmapBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.irBitmapBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBitmapBox)).BeginInit();
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
            // irBitmapBox
            // 
            this.irBitmapBox.Location = new System.Drawing.Point(339, 27);
            this.irBitmapBox.Name = "irBitmapBox";
            this.irBitmapBox.Size = new System.Drawing.Size(300, 300);
            this.irBitmapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.irBitmapBox.TabIndex = 1;
            this.irBitmapBox.TabStop = false;
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
            this.UDPConectStart.Location = new System.Drawing.Point(342, 573);
            this.UDPConectStart.Name = "UDPConectStart";
            this.UDPConectStart.Size = new System.Drawing.Size(75, 23);
            this.UDPConectStart.TabIndex = 4;
            this.UDPConectStart.Text = "UDPConectStart";
            this.UDPConectStart.UseVisualStyleBackColor = true;
            this.UDPConectStart.Click += new System.EventHandler(this.UDPConectStart_Click);
            // 
            // ConnectViewIpAdress
            // 
            this.ConnectViewIpAdress.AutoSize = true;
            this.ConnectViewIpAdress.Location = new System.Drawing.Point(374, 638);
            this.ConnectViewIpAdress.Name = "ConnectViewIpAdress";
            this.ConnectViewIpAdress.Size = new System.Drawing.Size(117, 12);
            this.ConnectViewIpAdress.TabIndex = 5;
            this.ConnectViewIpAdress.Text = "ConnectViewIpAdress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 601);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ConnectInfo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 638);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 655);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port";
            // 
            // ConnectViewPort
            // 
            this.ConnectViewPort.AutoSize = true;
            this.ConnectViewPort.Location = new System.Drawing.Point(374, 655);
            this.ConnectViewPort.Name = "ConnectViewPort";
            this.ConnectViewPort.Size = new System.Drawing.Size(93, 12);
            this.ConnectViewPort.TabIndex = 9;
            this.ConnectViewPort.Text = "ConnectViewPort";
            // 
            // PCInfo
            // 
            this.PCInfo.AutoSize = true;
            this.PCInfo.Location = new System.Drawing.Point(340, 367);
            this.PCInfo.Name = "PCInfo";
            this.PCInfo.Size = new System.Drawing.Size(43, 12);
            this.PCInfo.TabIndex = 10;
            this.PCInfo.Text = "PC Info";
            // 
            // PCViewPort
            // 
            this.PCViewPort.AutoSize = true;
            this.PCViewPort.Location = new System.Drawing.Point(374, 400);
            this.PCViewPort.Name = "PCViewPort";
            this.PCViewPort.Size = new System.Drawing.Size(66, 12);
            this.PCViewPort.TabIndex = 15;
            this.PCViewPort.Text = "PCViewPort";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "IP";
            // 
            // PCViewIpAdress
            // 
            this.PCViewIpAdress.AutoSize = true;
            this.PCViewIpAdress.Location = new System.Drawing.Point(374, 383);
            this.PCViewIpAdress.Name = "PCViewIpAdress";
            this.PCViewIpAdress.Size = new System.Drawing.Size(90, 12);
            this.PCViewIpAdress.TabIndex = 11;
            this.PCViewIpAdress.Text = "PCViewIpAdress";
            // 
            // GetConnectIP
            // 
            this.GetConnectIP.Location = new System.Drawing.Point(409, 616);
            this.GetConnectIP.Name = "GetConnectIP";
            this.GetConnectIP.Size = new System.Drawing.Size(166, 19);
            this.GetConnectIP.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 619);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "Connect IP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "Result";
            // 
            // resultBitmapBox
            // 
            this.resultBitmapBox.Location = new System.Drawing.Point(15, 367);
            this.resultBitmapBox.Name = "resultBitmapBox";
            this.resultBitmapBox.Size = new System.Drawing.Size(300, 300);
            this.resultBitmapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultBitmapBox.TabIndex = 18;
            this.resultBitmapBox.TabStop = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 712);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.resultBitmapBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GetConnectIP);
            this.Controls.Add(this.PCViewPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PCViewIpAdress);
            this.Controls.Add(this.PCInfo);
            this.Controls.Add(this.ConnectViewPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectViewIpAdress);
            this.Controls.Add(this.UDPConectStart);
            this.Controls.Add(this.IR_Label);
            this.Controls.Add(this.Depth_Label);
            this.Controls.Add(this.irBitmapBox);
            this.Controls.Add(this.depthBitmapBox);
            this.Name = "Form";
            this.Text = "KinectViewAndUDPSender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.depthBitmapBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.irBitmapBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBitmapBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox depthBitmapBox;
        private System.Windows.Forms.PictureBox irBitmapBox;
        private System.Windows.Forms.Label Depth_Label;
        private System.Windows.Forms.Label IR_Label;
        private System.Windows.Forms.Button UDPConectStart;
        private System.Windows.Forms.Label ConnectViewIpAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ConnectViewPort;
        private System.Windows.Forms.Label PCInfo;
        private System.Windows.Forms.Label PCViewPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label PCViewIpAdress;
        private System.Windows.Forms.TextBox GetConnectIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox resultBitmapBox;
    }
}

