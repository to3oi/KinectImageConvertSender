
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
            resultBitmapBox = new PictureBox();
            KinectRun = new Button();
            DebugSender = new Button();
            label9 = new Label();
            label10 = new Label();
            Mask = new GroupBox();
            BottomMask = new NumericUpDown();
            RightMask = new NumericUpDown();
            TopMask = new NumericUpDown();
            LeftMask = new NumericUpDown();
            label8 = new Label();
            label11 = new Label();
            PCInfo = new GroupBox();
            SendInfo = new GroupBox();
            g_IR = new GroupBox();
            g_Depth = new GroupBox();
            g_Result = new GroupBox();
            g_SendType = new GroupBox();
            g_PositionOffset = new GroupBox();
            PositionOffsetY = new NumericUpDown();
            PositionOffsetX = new NumericUpDown();
            label12 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)depthBitmapBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)irBitmapBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultBitmapBox).BeginInit();
            Mask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BottomMask).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RightMask).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TopMask).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LeftMask).BeginInit();
            PCInfo.SuspendLayout();
            SendInfo.SuspendLayout();
            g_IR.SuspendLayout();
            g_Depth.SuspendLayout();
            g_Result.SuspendLayout();
            g_SendType.SuspendLayout();
            g_PositionOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PositionOffsetY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PositionOffsetX).BeginInit();
            SuspendLayout();
            // 
            // depthBitmapBox
            // 
            depthBitmapBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            depthBitmapBox.Location = new Point(7, 23);
            depthBitmapBox.Margin = new Padding(4);
            depthBitmapBox.Name = "depthBitmapBox";
            depthBitmapBox.Size = new Size(350, 375);
            depthBitmapBox.SizeMode = PictureBoxSizeMode.Zoom;
            depthBitmapBox.TabIndex = 0;
            depthBitmapBox.TabStop = false;
            // 
            // irBitmapBox
            // 
            irBitmapBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            irBitmapBox.Location = new Point(8, 23);
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
            Depth_Label.Size = new Size(0, 15);
            Depth_Label.TabIndex = 2;
            // 
            // UDPConectStart
            // 
            UDPConectStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UDPConectStart.Location = new Point(7, 23);
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
            ConnectViewIpAdress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ConnectViewIpAdress.AutoSize = true;
            ConnectViewIpAdress.Location = new Point(44, 105);
            ConnectViewIpAdress.Margin = new Padding(4, 0, 4, 0);
            ConnectViewIpAdress.Name = "ConnectViewIpAdress";
            ConnectViewIpAdress.Size = new Size(121, 15);
            ConnectViewIpAdress.TabIndex = 5;
            ConnectViewIpAdress.Text = "ConnectViewIpAdress";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(7, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 6;
            label1.Text = "ConnectInfo";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(7, 105);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 7;
            label2.Text = "IP";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(7, 126);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 8;
            label3.Text = "Port";
            // 
            // ConnectViewPort
            // 
            ConnectViewPort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ConnectViewPort.AutoSize = true;
            ConnectViewPort.Location = new Point(44, 126);
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
            GetConnectIP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GetConnectIP.Location = new Point(85, 77);
            GetConnectIP.Margin = new Padding(4);
            GetConnectIP.Name = "GetConnectIP";
            GetConnectIP.Size = new Size(193, 23);
            GetConnectIP.TabIndex = 16;
            GetConnectIP.Text = "localhost";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(7, 81);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 17;
            label4.Text = "Connect IP";
            // 
            // resultBitmapBox
            // 
            resultBitmapBox.Location = new Point(11, 23);
            resultBitmapBox.Margin = new Padding(4);
            resultBitmapBox.Name = "resultBitmapBox";
            resultBitmapBox.Size = new Size(350, 375);
            resultBitmapBox.SizeMode = PictureBoxSizeMode.Zoom;
            resultBitmapBox.TabIndex = 18;
            resultBitmapBox.TabStop = false;
            // 
            // KinectRun
            // 
            KinectRun.Location = new Point(7, 23);
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
            DebugSender.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DebugSender.Location = new Point(105, 23);
            DebugSender.Margin = new Padding(4);
            DebugSender.Name = "DebugSender";
            DebugSender.Size = new Size(88, 29);
            DebugSender.TabIndex = 21;
            DebugSender.Text = "DebugSender";
            DebugSender.UseVisualStyleBackColor = true;
            DebugSender.Click += DebugSender_Click;
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
            // Mask
            // 
            Mask.Controls.Add(BottomMask);
            Mask.Controls.Add(RightMask);
            Mask.Controls.Add(TopMask);
            Mask.Controls.Add(LeftMask);
            Mask.Controls.Add(label8);
            Mask.Controls.Add(label11);
            Mask.Controls.Add(label9);
            Mask.Controls.Add(label10);
            Mask.Location = new Point(606, 459);
            Mask.Name = "Mask";
            Mask.Size = new Size(158, 162);
            Mask.TabIndex = 27;
            Mask.TabStop = false;
            Mask.Text = "Mask";
            // 
            // BottomMask
            // 
            BottomMask.Location = new Point(56, 114);
            BottomMask.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            BottomMask.Name = "BottomMask";
            BottomMask.Size = new Size(45, 23);
            BottomMask.TabIndex = 39;
            // 
            // RightMask
            // 
            RightMask.Location = new Point(107, 69);
            RightMask.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            RightMask.Name = "RightMask";
            RightMask.Size = new Size(45, 23);
            RightMask.TabIndex = 38;
            // 
            // TopMask
            // 
            TopMask.Location = new Point(54, 34);
            TopMask.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            TopMask.Name = "TopMask";
            TopMask.Size = new Size(45, 23);
            TopMask.TabIndex = 37;
            // 
            // LeftMask
            // 
            LeftMask.Location = new Point(7, 69);
            LeftMask.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            LeftMask.Name = "LeftMask";
            LeftMask.Size = new Size(45, 23);
            LeftMask.TabIndex = 36;
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
            // PCInfo
            // 
            PCInfo.Controls.Add(label6);
            PCInfo.Controls.Add(PCViewIpAdress);
            PCInfo.Controls.Add(label5);
            PCInfo.Controls.Add(PCViewPort);
            PCInfo.Location = new Point(404, 646);
            PCInfo.Name = "PCInfo";
            PCInfo.Size = new Size(200, 66);
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
            SendInfo.Location = new Point(404, 718);
            SendInfo.Name = "SendInfo";
            SendInfo.Size = new Size(307, 147);
            SendInfo.TabIndex = 29;
            SendInfo.TabStop = false;
            SendInfo.Text = "SendInfo";
            // 
            // g_IR
            // 
            g_IR.Controls.Add(irBitmapBox);
            g_IR.Location = new Point(396, 15);
            g_IR.Name = "g_IR";
            g_IR.Size = new Size(368, 406);
            g_IR.TabIndex = 30;
            g_IR.TabStop = false;
            g_IR.Text = "IR";
            // 
            // g_Depth
            // 
            g_Depth.Controls.Add(depthBitmapBox);
            g_Depth.Location = new Point(12, 15);
            g_Depth.Name = "g_Depth";
            g_Depth.Size = new Size(368, 406);
            g_Depth.TabIndex = 31;
            g_Depth.TabStop = false;
            g_Depth.Text = "Depth";
            // 
            // g_Result
            // 
            g_Result.Controls.Add(resultBitmapBox);
            g_Result.Location = new Point(12, 459);
            g_Result.Name = "g_Result";
            g_Result.Size = new Size(368, 406);
            g_Result.TabIndex = 32;
            g_Result.TabStop = false;
            g_Result.Text = "Result";
            // 
            // g_SendType
            // 
            g_SendType.Controls.Add(KinectRun);
            g_SendType.Controls.Add(DebugSender);
            g_SendType.Location = new Point(396, 459);
            g_SendType.Name = "g_SendType";
            g_SendType.Size = new Size(200, 65);
            g_SendType.TabIndex = 33;
            g_SendType.TabStop = false;
            g_SendType.Text = "SendType";
            // 
            // g_PositionOffset
            // 
            g_PositionOffset.Controls.Add(PositionOffsetY);
            g_PositionOffset.Controls.Add(PositionOffsetX);
            g_PositionOffset.Controls.Add(label12);
            g_PositionOffset.Controls.Add(label7);
            g_PositionOffset.Location = new Point(396, 540);
            g_PositionOffset.Name = "g_PositionOffset";
            g_PositionOffset.Size = new Size(200, 81);
            g_PositionOffset.TabIndex = 34;
            g_PositionOffset.TabStop = false;
            g_PositionOffset.Text = "PositionOffset";
            // 
            // PositionOffsetY
            // 
            PositionOffsetY.Location = new Point(128, 31);
            PositionOffsetY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PositionOffsetY.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            PositionOffsetY.Name = "PositionOffsetY";
            PositionOffsetY.Size = new Size(45, 23);
            PositionOffsetY.TabIndex = 35;
            // 
            // PositionOffsetX
            // 
            PositionOffsetX.Location = new Point(34, 31);
            PositionOffsetX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PositionOffsetX.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            PositionOffsetX.Name = "PositionOffsetX";
            PositionOffsetX.Size = new Size(45, 23);
            PositionOffsetX.TabIndex = 34;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(108, 33);
            label12.Name = "label12";
            label12.Size = new Size(14, 15);
            label12.TabIndex = 33;
            label12.Text = "Y";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 33);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 31;
            label7.Text = "X";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 881);
            Controls.Add(g_PositionOffset);
            Controls.Add(g_SendType);
            Controls.Add(g_Result);
            Controls.Add(g_Depth);
            Controls.Add(g_IR);
            Controls.Add(SendInfo);
            Controls.Add(PCInfo);
            Controls.Add(Mask);
            Controls.Add(Depth_Label);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "KinectViewAndUDPSender";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)depthBitmapBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)irBitmapBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultBitmapBox).EndInit();
            Mask.ResumeLayout(false);
            Mask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BottomMask).EndInit();
            ((System.ComponentModel.ISupportInitialize)RightMask).EndInit();
            ((System.ComponentModel.ISupportInitialize)TopMask).EndInit();
            ((System.ComponentModel.ISupportInitialize)LeftMask).EndInit();
            PCInfo.ResumeLayout(false);
            PCInfo.PerformLayout();
            SendInfo.ResumeLayout(false);
            SendInfo.PerformLayout();
            g_IR.ResumeLayout(false);
            g_Depth.ResumeLayout(false);
            g_Result.ResumeLayout(false);
            g_SendType.ResumeLayout(false);
            g_PositionOffset.ResumeLayout(false);
            g_PositionOffset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PositionOffsetY).EndInit();
            ((System.ComponentModel.ISupportInitialize)PositionOffsetX).EndInit();
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
        private Label label9;
        private Label label10;
        private GroupBox Mask;
        private Label label8;
        private Label label11;
        private GroupBox SendInfo;
        private GroupBox g_IR;
        private GroupBox g_Depth;
        private GroupBox g_Result;
        private GroupBox g_SendType;
        private GroupBox g_PositionOffset;
        private Label label12;
        private NumericUpDown PositionOffsetY;
        private NumericUpDown PositionOffsetX;
        private NumericUpDown BottomMask;
        private NumericUpDown RightMask;
        private NumericUpDown TopMask;
        private NumericUpDown LeftMask;
    }
}

