
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
            PCViewPort = new Label();
            label5 = new Label();
            label6 = new Label();
            PCViewIpAdress = new Label();
            GetConnectIP = new TextBox();
            label4 = new Label();
            label7 = new Label();
            resultBitmapBox = new PictureBox();
            KinectRun = new Button();
            DebugSender = new Button();
            LeftOffset = new TextBox();
            label9 = new Label();
            label10 = new Label();
            RightOffset = new TextBox();
            Offset = new GroupBox();
            label8 = new Label();
            label11 = new Label();
            TopOffset = new TextBox();
            BottomOffset = new TextBox();
            PCInfo = new GroupBox();
            SendInfo = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)depthBitmapBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)irBitmapBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultBitmapBox).BeginInit();
            Offset.SuspendLayout();
            PCInfo.SuspendLayout();
            SendInfo.SuspendLayout();
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
            UDPConectStart.Location = new Point(14, 35);
            UDPConectStart.Margin = new Padding(4);
            UDPConectStart.Name = "UDPConectStart";
            UDPConectStart.Size = new Size(105, 29);
            UDPConectStart.TabIndex = 4;
            UDPConectStart.Text = "UDPConectStart";
            UDPConectStart.UseVisualStyleBackColor = true;
            UDPConectStart.Click += UDPConectStart_Click;
            // 
            // ConnectViewIpAdress
            // 
            ConnectViewIpAdress.AutoSize = true;
            ConnectViewIpAdress.Location = new Point(51, 117);
            ConnectViewIpAdress.Margin = new Padding(4, 0, 4, 0);
            ConnectViewIpAdress.Name = "ConnectViewIpAdress";
            ConnectViewIpAdress.Size = new Size(121, 15);
            ConnectViewIpAdress.TabIndex = 5;
            ConnectViewIpAdress.Text = "ConnectViewIpAdress";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 70);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 6;
            label1.Text = "ConnectInfo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 117);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 7;
            label2.Text = "IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 138);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 8;
            label3.Text = "Port";
            // 
            // ConnectViewPort
            // 
            ConnectViewPort.AutoSize = true;
            ConnectViewPort.Location = new Point(51, 138);
            ConnectViewPort.Margin = new Padding(4, 0, 4, 0);
            ConnectViewPort.Name = "ConnectViewPort";
            ConnectViewPort.Size = new Size(98, 15);
            ConnectViewPort.TabIndex = 9;
            ConnectViewPort.Text = "ConnectViewPort";
            // 
            // PCViewPort
            // 
            PCViewPort.AutoSize = true;
            PCViewPort.Location = new Point(44, 40);
            PCViewPort.Margin = new Padding(4, 0, 4, 0);
            PCViewPort.Name = "PCViewPort";
            PCViewPort.Size = new Size(68, 15);
            PCViewPort.TabIndex = 15;
            PCViewPort.Text = "PCViewPort";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 40);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 14;
            label5.Text = "Port";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 19);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(17, 15);
            label6.TabIndex = 13;
            label6.Text = "IP";
            // 
            // PCViewIpAdress
            // 
            PCViewIpAdress.AutoSize = true;
            PCViewIpAdress.Location = new Point(44, 19);
            PCViewIpAdress.Margin = new Padding(4, 0, 4, 0);
            PCViewIpAdress.Name = "PCViewIpAdress";
            PCViewIpAdress.Size = new Size(91, 15);
            PCViewIpAdress.TabIndex = 11;
            PCViewIpAdress.Text = "PCViewIpAdress";
            // 
            // GetConnectIP
            // 
            GetConnectIP.Location = new Point(92, 89);
            GetConnectIP.Margin = new Padding(4);
            GetConnectIP.Name = "GetConnectIP";
            GetConnectIP.Size = new Size(193, 23);
            GetConnectIP.TabIndex = 16;
            GetConnectIP.Text = "localhost";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 93);
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
            // KinectRun
            // 
            KinectRun.Location = new Point(396, 459);
            KinectRun.Margin = new Padding(4);
            KinectRun.Name = "KinectRun";
            KinectRun.Size = new Size(88, 29);
            KinectRun.TabIndex = 20;
            KinectRun.Text = "KinectRun";
            KinectRun.UseVisualStyleBackColor = true;
            KinectRun.Click += KinectRun_Click;
            // 
            // DebugSender
            // 
            DebugSender.Location = new Point(492, 459);
            DebugSender.Margin = new Padding(4);
            DebugSender.Name = "DebugSender";
            DebugSender.Size = new Size(88, 29);
            DebugSender.TabIndex = 21;
            DebugSender.Text = "DebugSender";
            DebugSender.UseVisualStyleBackColor = true;
            DebugSender.Click += DebugSender_Click;
            // 
            // LeftOffset
            // 
            LeftOffset.ImeMode = ImeMode.Disable;
            LeftOffset.Location = new Point(7, 69);
            LeftOffset.Name = "LeftOffset";
            LeftOffset.ShortcutsEnabled = false;
            LeftOffset.Size = new Size(45, 23);
            LeftOffset.TabIndex = 23;
            LeftOffset.Text = "0";
            LeftOffset.KeyPress += txtNumOnly_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 51);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 24;
            label9.Text = "Left";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(105, 51);
            label10.Name = "label10";
            label10.Size = new Size(35, 15);
            label10.TabIndex = 26;
            label10.Text = "Right";
            // 
            // RightOffset
            // 
            RightOffset.ImeMode = ImeMode.Disable;
            RightOffset.Location = new Point(105, 69);
            RightOffset.Name = "RightOffset";
            RightOffset.ShortcutsEnabled = false;
            RightOffset.Size = new Size(45, 23);
            RightOffset.TabIndex = 25;
            RightOffset.Text = "0";
            RightOffset.KeyPress += txtNumOnly_KeyPress;
            // 
            // Offset
            // 
            Offset.Controls.Add(label8);
            Offset.Controls.Add(label11);
            Offset.Controls.Add(TopOffset);
            Offset.Controls.Add(BottomOffset);
            Offset.Controls.Add(label9);
            Offset.Controls.Add(label10);
            Offset.Controls.Add(LeftOffset);
            Offset.Controls.Add(RightOffset);
            Offset.Location = new Point(587, 459);
            Offset.Name = "Offset";
            Offset.Size = new Size(172, 162);
            Offset.TabIndex = 27;
            Offset.TabStop = false;
            Offset.Text = "Offset";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(56, 16);
            label8.Name = "label8";
            label8.Size = new Size(26, 15);
            label8.TabIndex = 28;
            label8.Text = "Top";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(56, 96);
            label11.Name = "label11";
            label11.Size = new Size(46, 15);
            label11.TabIndex = 30;
            label11.Text = "Bottom";
            // 
            // TopOffset
            // 
            TopOffset.ImeMode = ImeMode.Disable;
            TopOffset.Location = new Point(56, 34);
            TopOffset.Name = "TopOffset";
            TopOffset.ShortcutsEnabled = false;
            TopOffset.Size = new Size(45, 23);
            TopOffset.TabIndex = 27;
            TopOffset.Text = "0";
            TopOffset.KeyPress += txtNumOnly_KeyPress;
            // 
            // BottomOffset
            // 
            BottomOffset.ImeMode = ImeMode.Disable;
            BottomOffset.Location = new Point(56, 114);
            BottomOffset.Name = "BottomOffset";
            BottomOffset.ShortcutsEnabled = false;
            BottomOffset.Size = new Size(45, 23);
            BottomOffset.TabIndex = 29;
            BottomOffset.Text = "0";
            BottomOffset.KeyPress += txtNumOnly_KeyPress;
            // 
            // PCInfo
            // 
            PCInfo.Controls.Add(label6);
            PCInfo.Controls.Add(PCViewIpAdress);
            PCInfo.Controls.Add(label5);
            PCInfo.Controls.Add(PCViewPort);
            PCInfo.Location = new Point(397, 504);
            PCInfo.Name = "PCInfo";
            PCInfo.Size = new Size(171, 66);
            PCInfo.TabIndex = 28;
            PCInfo.TabStop = false;
            PCInfo.Text = "PCInfo";
            // 
            // SendInfo
            // 
            SendInfo.Controls.Add(GetConnectIP);
            SendInfo.Controls.Add(UDPConectStart);
            SendInfo.Controls.Add(ConnectViewIpAdress);
            SendInfo.Controls.Add(label1);
            SendInfo.Controls.Add(label2);
            SendInfo.Controls.Add(label3);
            SendInfo.Controls.Add(ConnectViewPort);
            SendInfo.Controls.Add(label4);
            SendInfo.Location = new Point(396, 637);
            SendInfo.Name = "SendInfo";
            SendInfo.Size = new Size(307, 169);
            SendInfo.TabIndex = 29;
            SendInfo.TabStop = false;
            SendInfo.Text = "SendInfo";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 890);
            Controls.Add(SendInfo);
            Controls.Add(PCInfo);
            Controls.Add(Offset);
            Controls.Add(DebugSender);
            Controls.Add(KinectRun);
            Controls.Add(label7);
            Controls.Add(resultBitmapBox);
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
            Offset.ResumeLayout(false);
            Offset.PerformLayout();
            PCInfo.ResumeLayout(false);
            PCInfo.PerformLayout();
            SendInfo.ResumeLayout(false);
            SendInfo.PerformLayout();
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
        private GroupBox PCInfo;
        private Label PCViewPort;
        private Label label5;
        private Label label6;
        private Label PCViewIpAdress;
        private TextBox GetConnectIP;
        private Label label4;
        private Label label7;
        private PictureBox resultBitmapBox;
        private Button KinectRun;
        private Button DebugSender;
        private TextBox LeftOffset;
        private Label label9;
        private Label label10;
        private TextBox RightOffset;
        private GroupBox Offset;
        private Label label8;
        private Label label11;
        private TextBox TopOffset;
        private TextBox BottomOffset;
        private GroupBox SendInfo;
    }
}

