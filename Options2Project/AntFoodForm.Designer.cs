namespace SOFT152Steering
{
    partial class AntFoodForm
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
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.worldTimer = new System.Windows.Forms.Timer(this.components);
            this.colonySizeTextBox = new System.Windows.Forms.TextBox();
            this.antQuantityLabel = new System.Windows.Forms.Label();
            this.pauseResumeButton = new System.Windows.Forms.Button();
            this.antMemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.robberAntQuantityLabel = new System.Windows.Forms.Label();
            this.robberColonySizeTextBox = new System.Windows.Forms.TextBox();
            this.worldObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.robberNestRadioButton = new System.Windows.Forms.RadioButton();
            this.antNestRadioButton = new System.Windows.Forms.RadioButton();
            this.foodSourceRadioButton = new System.Windows.Forms.RadioButton();
            this.antBlackPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.antRedPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.antBluePictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.antIndigoPictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.antGreenPictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.antYellowPictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.antMagentaPictureBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.antColourKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.foodQuantityLabel = new System.Windows.Forms.Label();
            this.foodPiecesTextBox = new System.Windows.Forms.TextBox();
            this.setFoodPiecesButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.worldObjectGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.antBlackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antRedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antBluePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antIndigoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antGreenPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antYellowPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antMagentaPictureBox)).BeginInit();
            this.antColourKeyGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(27, 99);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(788, 433);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(96, 16);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(118, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // worldTimer
            // 
            this.worldTimer.Interval = 10;
            this.worldTimer.Tick += new System.EventHandler(this.worldTimer_Tick);
            // 
            // colonySizeTextBox
            // 
            this.colonySizeTextBox.Location = new System.Drawing.Point(132, 15);
            this.colonySizeTextBox.Name = "colonySizeTextBox";
            this.colonySizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.colonySizeTextBox.TabIndex = 3;
            this.colonySizeTextBox.Text = "50";
            // 
            // antQuantityLabel
            // 
            this.antQuantityLabel.AutoSize = true;
            this.antQuantityLabel.Location = new System.Drawing.Point(6, 18);
            this.antQuantityLabel.Name = "antQuantityLabel";
            this.antQuantityLabel.Size = new System.Drawing.Size(120, 13);
            this.antQuantityLabel.TabIndex = 4;
            this.antQuantityLabel.Text = "Normal Ant Colony Size:";
            // 
            // pauseResumeButton
            // 
            this.pauseResumeButton.Location = new System.Drawing.Point(96, 45);
            this.pauseResumeButton.Name = "pauseResumeButton";
            this.pauseResumeButton.Size = new System.Drawing.Size(118, 23);
            this.pauseResumeButton.TabIndex = 6;
            this.pauseResumeButton.Text = "Pause/Resume";
            this.pauseResumeButton.UseVisualStyleBackColor = true;
            this.pauseResumeButton.Click += new System.EventHandler(this.pauseResumeButton_Click);
            // 
            // antMemoryTimer
            // 
            this.antMemoryTimer.Interval = 10000;
            this.antMemoryTimer.Tick += new System.EventHandler(this.antMemoryTimer_Tick);
            // 
            // robberAntQuantityLabel
            // 
            this.robberAntQuantityLabel.AutoSize = true;
            this.robberAntQuantityLabel.Location = new System.Drawing.Point(6, 49);
            this.robberAntQuantityLabel.Name = "robberAntQuantityLabel";
            this.robberAntQuantityLabel.Size = new System.Drawing.Size(122, 13);
            this.robberAntQuantityLabel.TabIndex = 7;
            this.robberAntQuantityLabel.Text = "Robber Ant Colony Size:";
            // 
            // robberColonySizeTextBox
            // 
            this.robberColonySizeTextBox.Location = new System.Drawing.Point(132, 46);
            this.robberColonySizeTextBox.Name = "robberColonySizeTextBox";
            this.robberColonySizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.robberColonySizeTextBox.TabIndex = 8;
            this.robberColonySizeTextBox.Text = "20";
            // 
            // worldObjectGroupBox
            // 
            this.worldObjectGroupBox.Controls.Add(this.robberNestRadioButton);
            this.worldObjectGroupBox.Controls.Add(this.antNestRadioButton);
            this.worldObjectGroupBox.Controls.Add(this.foodSourceRadioButton);
            this.worldObjectGroupBox.Location = new System.Drawing.Point(482, 12);
            this.worldObjectGroupBox.Name = "worldObjectGroupBox";
            this.worldObjectGroupBox.Size = new System.Drawing.Size(333, 81);
            this.worldObjectGroupBox.TabIndex = 9;
            this.worldObjectGroupBox.TabStop = false;
            this.worldObjectGroupBox.Text = "World Objects";
            // 
            // robberNestRadioButton
            // 
            this.robberNestRadioButton.AutoSize = true;
            this.robberNestRadioButton.Location = new System.Drawing.Point(214, 33);
            this.robberNestRadioButton.Name = "robberNestRadioButton";
            this.robberNestRadioButton.Size = new System.Drawing.Size(104, 17);
            this.robberNestRadioButton.TabIndex = 2;
            this.robberNestRadioButton.Text = "Robber Ant Nest";
            this.robberNestRadioButton.UseVisualStyleBackColor = true;
            // 
            // antNestRadioButton
            // 
            this.antNestRadioButton.AutoSize = true;
            this.antNestRadioButton.Location = new System.Drawing.Point(127, 33);
            this.antNestRadioButton.Name = "antNestRadioButton";
            this.antNestRadioButton.Size = new System.Drawing.Size(66, 17);
            this.antNestRadioButton.TabIndex = 1;
            this.antNestRadioButton.Text = "Ant Nest";
            this.antNestRadioButton.UseVisualStyleBackColor = true;
            // 
            // foodSourceRadioButton
            // 
            this.foodSourceRadioButton.AutoSize = true;
            this.foodSourceRadioButton.Checked = true;
            this.foodSourceRadioButton.Location = new System.Drawing.Point(18, 33);
            this.foodSourceRadioButton.Name = "foodSourceRadioButton";
            this.foodSourceRadioButton.Size = new System.Drawing.Size(86, 17);
            this.foodSourceRadioButton.TabIndex = 0;
            this.foodSourceRadioButton.TabStop = true;
            this.foodSourceRadioButton.Text = "Food Source";
            this.foodSourceRadioButton.UseVisualStyleBackColor = true;
            // 
            // antBlackPictureBox
            // 
            this.antBlackPictureBox.BackColor = System.Drawing.Color.Black;
            this.antBlackPictureBox.Location = new System.Drawing.Point(14, 30);
            this.antBlackPictureBox.Name = "antBlackPictureBox";
            this.antBlackPictureBox.Size = new System.Drawing.Size(20, 20);
            this.antBlackPictureBox.TabIndex = 3;
            this.antBlackPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "- Normal ant (no knowledge of food or nest location)";
            // 
            // antRedPictureBox
            // 
            this.antRedPictureBox.BackColor = System.Drawing.Color.Red;
            this.antRedPictureBox.Location = new System.Drawing.Point(14, 216);
            this.antRedPictureBox.Name = "antRedPictureBox";
            this.antRedPictureBox.Size = new System.Drawing.Size(20, 20);
            this.antRedPictureBox.TabIndex = 11;
            this.antRedPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "- Robber ant";
            // 
            // antBluePictureBox
            // 
            this.antBluePictureBox.BackColor = System.Drawing.Color.Blue;
            this.antBluePictureBox.Location = new System.Drawing.Point(14, 71);
            this.antBluePictureBox.Name = "antBluePictureBox";
            this.antBluePictureBox.Size = new System.Drawing.Size(20, 20);
            this.antBluePictureBox.TabIndex = 13;
            this.antBluePictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "- Normal ant (knows only nest location)";
            // 
            // antIndigoPictureBox
            // 
            this.antIndigoPictureBox.BackColor = System.Drawing.Color.Indigo;
            this.antIndigoPictureBox.Location = new System.Drawing.Point(14, 109);
            this.antIndigoPictureBox.Name = "antIndigoPictureBox";
            this.antIndigoPictureBox.Size = new System.Drawing.Size(20, 20);
            this.antIndigoPictureBox.TabIndex = 15;
            this.antIndigoPictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "- Normal ant (knows only food location)";
            // 
            // antGreenPictureBox
            // 
            this.antGreenPictureBox.BackColor = System.Drawing.Color.Green;
            this.antGreenPictureBox.Location = new System.Drawing.Point(14, 146);
            this.antGreenPictureBox.Name = "antGreenPictureBox";
            this.antGreenPictureBox.Size = new System.Drawing.Size(20, 20);
            this.antGreenPictureBox.TabIndex = 17;
            this.antGreenPictureBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "- Normal ant (knows food and nest location)";
            // 
            // antYellowPictureBox
            // 
            this.antYellowPictureBox.BackColor = System.Drawing.Color.Yellow;
            this.antYellowPictureBox.Location = new System.Drawing.Point(14, 181);
            this.antYellowPictureBox.Name = "antYellowPictureBox";
            this.antYellowPictureBox.Size = new System.Drawing.Size(20, 20);
            this.antYellowPictureBox.TabIndex = 19;
            this.antYellowPictureBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "- Normal ant (carrying food piece)";
            // 
            // antMagentaPictureBox
            // 
            this.antMagentaPictureBox.BackColor = System.Drawing.Color.Magenta;
            this.antMagentaPictureBox.Location = new System.Drawing.Point(14, 252);
            this.antMagentaPictureBox.Name = "antMagentaPictureBox";
            this.antMagentaPictureBox.Size = new System.Drawing.Size(20, 20);
            this.antMagentaPictureBox.TabIndex = 21;
            this.antMagentaPictureBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "- Robber ant (carrying stolen food piece)";
            // 
            // antColourKeyGroupBox
            // 
            this.antColourKeyGroupBox.Controls.Add(this.label7);
            this.antColourKeyGroupBox.Controls.Add(this.antBlackPictureBox);
            this.antColourKeyGroupBox.Controls.Add(this.antMagentaPictureBox);
            this.antColourKeyGroupBox.Controls.Add(this.label1);
            this.antColourKeyGroupBox.Controls.Add(this.label2);
            this.antColourKeyGroupBox.Controls.Add(this.label6);
            this.antColourKeyGroupBox.Controls.Add(this.antRedPictureBox);
            this.antColourKeyGroupBox.Controls.Add(this.antBluePictureBox);
            this.antColourKeyGroupBox.Controls.Add(this.antYellowPictureBox);
            this.antColourKeyGroupBox.Controls.Add(this.label3);
            this.antColourKeyGroupBox.Controls.Add(this.antGreenPictureBox);
            this.antColourKeyGroupBox.Controls.Add(this.label5);
            this.antColourKeyGroupBox.Controls.Add(this.antIndigoPictureBox);
            this.antColourKeyGroupBox.Controls.Add(this.label4);
            this.antColourKeyGroupBox.Location = new System.Drawing.Point(826, 99);
            this.antColourKeyGroupBox.Name = "antColourKeyGroupBox";
            this.antColourKeyGroupBox.Size = new System.Drawing.Size(299, 292);
            this.antColourKeyGroupBox.TabIndex = 23;
            this.antColourKeyGroupBox.TabStop = false;
            this.antColourKeyGroupBox.Text = "Ant Colour Key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(826, 407);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 129);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "World Object Colour Key";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "- Robber Ant Nest";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox3.Location = new System.Drawing.Point(14, 91);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "- Normal Ant Nest";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "- Food Source";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Brown;
            this.pictureBox2.Location = new System.Drawing.Point(14, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox1.Location = new System.Drawing.Point(14, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // foodQuantityLabel
            // 
            this.foodQuantityLabel.AutoSize = true;
            this.foodQuantityLabel.Location = new System.Drawing.Point(265, 31);
            this.foodQuantityLabel.Name = "foodQuantityLabel";
            this.foodQuantityLabel.Size = new System.Drawing.Size(81, 13);
            this.foodQuantityLabel.TabIndex = 26;
            this.foodQuantityLabel.Text = "Pieces of Food:";
            // 
            // foodPiecesTextBox
            // 
            this.foodPiecesTextBox.Location = new System.Drawing.Point(352, 28);
            this.foodPiecesTextBox.Name = "foodPiecesTextBox";
            this.foodPiecesTextBox.Size = new System.Drawing.Size(100, 20);
            this.foodPiecesTextBox.TabIndex = 27;
            this.foodPiecesTextBox.Text = "200";
            // 
            // setFoodPiecesButton
            // 
            this.setFoodPiecesButton.Location = new System.Drawing.Point(352, 56);
            this.setFoodPiecesButton.Name = "setFoodPiecesButton";
            this.setFoodPiecesButton.Size = new System.Drawing.Size(100, 23);
            this.setFoodPiecesButton.TabIndex = 28;
            this.setFoodPiecesButton.Text = "Set Quantity";
            this.setFoodPiecesButton.UseVisualStyleBackColor = true;
            this.setFoodPiecesButton.Click += new System.EventHandler(this.setFoodPiecesButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colonySizeTextBox);
            this.groupBox2.Controls.Add(this.robberColonySizeTextBox);
            this.groupBox2.Controls.Add(this.antQuantityLabel);
            this.groupBox2.Controls.Add(this.robberAntQuantityLabel);
            this.groupBox2.Location = new System.Drawing.Point(27, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 81);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "World Conditions";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.startButton);
            this.groupBox3.Controls.Add(this.pauseResumeButton);
            this.groupBox3.Location = new System.Drawing.Point(828, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 81);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "World Controls";
            // 
            // AntFoodForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1136, 544);
            this.Controls.Add(this.setFoodPiecesButton);
            this.Controls.Add(this.foodPiecesTextBox);
            this.Controls.Add(this.foodQuantityLabel);
            this.Controls.Add(this.worldObjectGroupBox);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.antColourKeyGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "AntFoodForm";
            this.Text = "Ant Colony Simulation";
            this.worldObjectGroupBox.ResumeLayout(false);
            this.worldObjectGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.antBlackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antRedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antBluePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antIndigoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antGreenPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antYellowPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antMagentaPictureBox)).EndInit();
            this.antColourKeyGroupBox.ResumeLayout(false);
            this.antColourKeyGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer worldTimer;
        private System.Windows.Forms.TextBox colonySizeTextBox;
        private System.Windows.Forms.Label antQuantityLabel;
        private System.Windows.Forms.Button pauseResumeButton;
        private System.Windows.Forms.Timer antMemoryTimer;
        private System.Windows.Forms.Label robberAntQuantityLabel;
        private System.Windows.Forms.TextBox robberColonySizeTextBox;
        private System.Windows.Forms.GroupBox worldObjectGroupBox;
        private System.Windows.Forms.RadioButton robberNestRadioButton;
        private System.Windows.Forms.RadioButton antNestRadioButton;
        private System.Windows.Forms.RadioButton foodSourceRadioButton;
        private System.Windows.Forms.PictureBox antBlackPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox antRedPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox antBluePictureBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox antIndigoPictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox antGreenPictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox antYellowPictureBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox antMagentaPictureBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox antColourKeyGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label foodQuantityLabel;
        private System.Windows.Forms.TextBox foodPiecesTextBox;
        private System.Windows.Forms.Button setFoodPiecesButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

