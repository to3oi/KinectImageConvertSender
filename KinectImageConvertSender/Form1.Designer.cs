
namespace KinectImageConvertSender
{
    partial class Form1
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
            depthBitmapBox = new PictureBox();
            irBitmapBox = new PictureBox();
            Depth_Label = new Label();
            IR_Label = new Label();
            UDPConectStart = new Button();
            ConnectViewIpAdress = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ConnectViewPort = new Label();
            PCInfo = new Label();
            PCViewPort = new Label();
            label5 = new Label();
            label6 = new Label();
            PCViewIpAdress = new Label();
            GetConnectIP = new TextBox();
            label4 = new Label();
            label7 = new Label();
            resultBitmapBox = new PictureBox();
            TestButton = new Button();
            ((System.ComponentModel.ISupportInitialize)depthBitmapBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)irBitmapBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultBitmapBox).BeginInit();
            SuspendLayout();
            // 
            // depthBitmapBox
            // 
            depthBitmapBox.Location = new Point(18, 34);
            depthBitmapBox.Margin = new Padding(4);
            depthBitmapBox.Name = "depthBitmapBox";
            depthBitmapBox.Size = new Size(350, 375);
            depthBitmapBox.SizeMode = PictureBoxSizeMode.Zoom;
            depthBitmapBox.TabIndex = 0;
            depthBitmapBox.TabStop = false;
            // 
            // irBitmapBox
            // 
            irBitmapBox.Location = new Point(396, 34);
            irBitmapBox.Margin = new Padding(4);
            irBitmapBox.Name = "irBitmapBox";
            irBitmapBox.Size = new Size(350, 375);
            irBitmapBox.SizeMode = PictureBoxSizeMode.Zoom;
            irBitmapBox.TabIndex = 1;
            irBitmapBox.TabStop = false;
            // 
            // Depth_Label
            // 
            Depth_Label.AutoSize = true;
            Depth_Label.Location = new Point(15, 15);
            Depth_Label.Margin = new Padding(4, 0, 4, 0);
            Depth_Label.Name = "Depth_Label";
            Depth_Label.Size = new Size(39, 15);
            Depth_Label.TabIndex = 2;
            Depth_Label.Text = "Depth";
            // 
            // IR_Label
            // 
            IR_Label.AutoSize = true;
            IR_Label.Location = new Point(397, 15);
            IR_Label.Margin = new Padding(4, 0, 4, 0);
            IR_Label.Name = "IR_Label";
            IR_Label.Size = new Size(17, 15);
            IR_Label.TabIndex = 3;
            IR_Label.Text = "IR";
            // 
            // UDPConectStart
            // 
            UDPConectStart.Location = new Point(399, 716);
            UDPConectStart.Margin = new Padding(4);
            UDPConectStart.Name = "UDPConectStart";
            UDPConectStart.Size = new Size(88, 29);
            UDPConectStart.TabIndex = 4;
            UDPConectStart.Text = "UDPConectStart";
            UDPConectStart.UseVisualStyleBackColor = true;
            UDPConectStart.Click += UDPConectStart_Click;
            // 
            // ConnectViewIpAdress
            // 
            ConnectViewIpAdress.AutoSize = true;
            ConnectViewIpAdress.Location = new Point(436, 798);
            ConnectViewIpAdress.Margin = new Padding(4, 0, 4, 0);
            ConnectViewIpAdress.Name = "ConnectViewIpAdress";
            ConnectViewIpAdress.Size = new Size(121, 15);
            ConnectViewIpAdress.TabIndex = 5;
            ConnectViewIpAdress.Text = "ConnectViewIpAdress";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(399, 751);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 6;
            label1.Text = "ConnectInfo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(399, 798);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 7;
            label2.Text = "IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(399, 819);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 8;
            label3.Text = "Port";
            // 
            // ConnectViewPort
            // 
            ConnectViewPort.AutoSize = true;
            ConnectViewPort.Location = new Point(436, 819);
            ConnectViewPort.Margin = new Padding(4, 0, 4, 0);
            ConnectViewPort.Name = "ConnectViewPort";
            ConnectViewPort.Size = new Size(98, 15);
            ConnectViewPort.TabIndex = 9;
            ConnectViewPort.Text = "ConnectViewPort";
            // 
            // PCInfo
            // 
            PCInfo.AutoSize = true;
            PCInfo.Location = new Point(397, 459);
            PCInfo.Margin = new Padding(4, 0, 4, 0);
            PCInfo.Name = "PCInfo";
            PCInfo.Size = new Size(45, 15);
            PCInfo.TabIndex = 10;
            PCInfo.Text = "PC Info";
            // 
            // PCViewPort
            // 
            PCViewPort.AutoSize = true;
            PCViewPort.Location = new Point(436, 500);
            PCViewPort.Margin = new Padding(4, 0, 4, 0);
            PCViewPort.Name = "PCViewPort";
            PCViewPort.Size = new Size(68, 15);
            PCViewPort.TabIndex = 15;
            PCViewPort.Text = "PCViewPort";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(399, 500);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 14;
            label5.Text = "Port";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(399, 479);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(17, 15);
            label6.TabIndex = 13;
            label6.Text = "IP";
            // 
            // PCViewIpAdress
            // 
            PCViewIpAdress.AutoSize = true;
            PCViewIpAdress.Location = new Point(436, 479);
            PCViewIpAdress.Margin = new Padding(4, 0, 4, 0);
            PCViewIpAdress.Name = "PCViewIpAdress";
            PCViewIpAdress.Size = new Size(91, 15);
            PCViewIpAdress.TabIndex = 11;
            PCViewIpAdress.Text = "PCViewIpAdress";
            // 
            // GetConnectIP
            // 
            GetConnectIP.Location = new Point(477, 770);
            GetConnectIP.Margin = new Padding(4);
            GetConnectIP.Name = "GetConnectIP";
            GetConnectIP.Size = new Size(193, 23);
            GetConnectIP.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(399, 774);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 17;
            label4.Text = "Connect IP";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 440);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 19;
            label7.Text = "Result";
            // 
            // resultBitmapBox
            // 
            resultBitmapBox.Location = new Point(18, 459);
            resultBitmapBox.Margin = new Padding(4);
            resultBitmapBox.Name = "resultBitmapBox";
            resultBitmapBox.Size = new Size(350, 375);
            resultBitmapBox.SizeMode = PictureBoxSizeMode.Zoom;
            resultBitmapBox.TabIndex = 18;
            resultBitmapBox.TabStop = false;
            // 
            // TestButton
            // 
            TestButton.Location = new Point(786, 34);
            TestButton.Margin = new Padding(4);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(88, 29);
            TestButton.TabIndex = 20;
            TestButton.Text = "TestButton";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 890);
            Controls.Add(TestButton);
            Controls.Add(label7);
            Controls.Add(resultBitmapBox);
            Controls.Add(label4);
            Controls.Add(GetConnectIP);
            Controls.Add(PCViewPort);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(PCViewIpAdress);
            Controls.Add(PCInfo);
            Controls.Add(ConnectViewPort);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ConnectViewIpAdress);
            Controls.Add(UDPConectStart);
            Controls.Add(IR_Label);
            Controls.Add(Depth_Label);
            Controls.Add(irBitmapBox);
            Controls.Add(depthBitmapBox);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "KinectViewAndUDPSender";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)depthBitmapBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)irBitmapBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultBitmapBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox depthBitmapBox;
        private PictureBox irBitmapBox;
        private Label Depth_Label;
        private Label IR_Label;
        private Button UDPConectStart;
        private Label ConnectViewIpAdress;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label ConnectViewPort;
        private Label PCInfo;
        private Label PCViewPort;
        private Label label5;
        private Label label6;
        private Label PCViewIpAdress;
        private TextBox GetConnectIP;
        private Label label4;
        private Label label7;
        private PictureBox resultBitmapBox;
        private Button TestButton;
    }
}

