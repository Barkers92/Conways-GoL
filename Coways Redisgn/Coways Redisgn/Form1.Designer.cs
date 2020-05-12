namespace Coways_Redisgn
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
            this.components = new System.ComponentModel.Container();
            this.PlayBTN = new System.Windows.Forms.Button();
            this.ClearBTN = new System.Windows.Forms.Button();
            this.ClassicGameModeBTN = new System.Windows.Forms.Button();
            this.NewRulesBTN = new System.Windows.Forms.Button();
            this.SetOverpopBtn = new System.Windows.Forms.Button();
            this.SetUnderpopBTN = new System.Windows.Forms.Button();
            this.SetRebirthBTN = new System.Windows.Forms.Button();
            this.PulsarBTN = new System.Windows.Forms.Button();
            this.LionHeartBTN = new System.Windows.Forms.Button();
            this.ShurikenBTN = new System.Windows.Forms.Button();
            this.OverPopTB = new System.Windows.Forms.TextBox();
            this.UnderpopTB = new System.Windows.Forms.TextBox();
            this.RebirthPopTB = new System.Windows.Forms.TextBox();
            this.GenerationLB = new System.Windows.Forms.Label();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.nextGenBTN = new System.Windows.Forms.Button();
            this.GliderBTN = new System.Windows.Forms.Button();
            this.RandomBTN = new System.Windows.Forms.Button();
            this.clearHeatBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayBTN
            // 
            this.PlayBTN.Location = new System.Drawing.Point(1306, 168);
            this.PlayBTN.Name = "PlayBTN";
            this.PlayBTN.Size = new System.Drawing.Size(160, 63);
            this.PlayBTN.TabIndex = 0;
            this.PlayBTN.Text = "Play";
            this.PlayBTN.UseVisualStyleBackColor = true;
            this.PlayBTN.Click += new System.EventHandler(this.PlayBTN_Click);
            // 
            // ClearBTN
            // 
            this.ClearBTN.Location = new System.Drawing.Point(1306, 237);
            this.ClearBTN.Name = "ClearBTN";
            this.ClearBTN.Size = new System.Drawing.Size(160, 63);
            this.ClearBTN.TabIndex = 1;
            this.ClearBTN.Text = "Clear";
            this.ClearBTN.UseVisualStyleBackColor = true;
            this.ClearBTN.Click += new System.EventHandler(this.ClearBTN_Click);
            // 
            // ClassicGameModeBTN
            // 
            this.ClassicGameModeBTN.Location = new System.Drawing.Point(1306, 306);
            this.ClassicGameModeBTN.Name = "ClassicGameModeBTN";
            this.ClassicGameModeBTN.Size = new System.Drawing.Size(160, 63);
            this.ClassicGameModeBTN.TabIndex = 2;
            this.ClassicGameModeBTN.Text = "Classic Conways";
            this.ClassicGameModeBTN.UseVisualStyleBackColor = true;
            this.ClassicGameModeBTN.Click += new System.EventHandler(this.ClassicGameModeBTN_Click);
            // 
            // NewRulesBTN
            // 
            this.NewRulesBTN.Location = new System.Drawing.Point(1306, 375);
            this.NewRulesBTN.Name = "NewRulesBTN";
            this.NewRulesBTN.Size = new System.Drawing.Size(160, 63);
            this.NewRulesBTN.TabIndex = 3;
            this.NewRulesBTN.Text = "New Rules";
            this.NewRulesBTN.UseVisualStyleBackColor = true;
            this.NewRulesBTN.Click += new System.EventHandler(this.NewRulesBTN_Click);
            // 
            // SetOverpopBtn
            // 
            this.SetOverpopBtn.Location = new System.Drawing.Point(1425, 564);
            this.SetOverpopBtn.Name = "SetOverpopBtn";
            this.SetOverpopBtn.Size = new System.Drawing.Size(89, 40);
            this.SetOverpopBtn.TabIndex = 4;
            this.SetOverpopBtn.Text = "Set";
            this.SetOverpopBtn.UseVisualStyleBackColor = true;
            this.SetOverpopBtn.Click += new System.EventHandler(this.SetOverpopBtn_Click);
            // 
            // SetUnderpopBTN
            // 
            this.SetUnderpopBTN.Location = new System.Drawing.Point(1425, 738);
            this.SetUnderpopBTN.Name = "SetUnderpopBTN";
            this.SetUnderpopBTN.Size = new System.Drawing.Size(89, 35);
            this.SetUnderpopBTN.TabIndex = 5;
            this.SetUnderpopBTN.Text = "Set";
            this.SetUnderpopBTN.UseVisualStyleBackColor = true;
            this.SetUnderpopBTN.Click += new System.EventHandler(this.SetUnderpopBTN_Click);
            // 
            // SetRebirthBTN
            // 
            this.SetRebirthBTN.Location = new System.Drawing.Point(1425, 902);
            this.SetRebirthBTN.Name = "SetRebirthBTN";
            this.SetRebirthBTN.Size = new System.Drawing.Size(89, 33);
            this.SetRebirthBTN.TabIndex = 6;
            this.SetRebirthBTN.Text = "Set";
            this.SetRebirthBTN.UseVisualStyleBackColor = true;
            this.SetRebirthBTN.Click += new System.EventHandler(this.SetRebirthBTN_Click);
            // 
            // PulsarBTN
            // 
            this.PulsarBTN.Location = new System.Drawing.Point(319, 1263);
            this.PulsarBTN.Name = "PulsarBTN";
            this.PulsarBTN.Size = new System.Drawing.Size(160, 63);
            this.PulsarBTN.TabIndex = 7;
            this.PulsarBTN.Text = "Pulsar";
            this.PulsarBTN.UseVisualStyleBackColor = true;
            this.PulsarBTN.Click += new System.EventHandler(this.PulsarBTN_Click);
            // 
            // LionHeartBTN
            // 
            this.LionHeartBTN.Location = new System.Drawing.Point(527, 1263);
            this.LionHeartBTN.Name = "LionHeartBTN";
            this.LionHeartBTN.Size = new System.Drawing.Size(160, 63);
            this.LionHeartBTN.TabIndex = 8;
            this.LionHeartBTN.Text = "Lion Heart";
            this.LionHeartBTN.UseVisualStyleBackColor = true;
            this.LionHeartBTN.Click += new System.EventHandler(this.LionHeartBTN_Click);
            // 
            // ShurikenBTN
            // 
            this.ShurikenBTN.Location = new System.Drawing.Point(733, 1263);
            this.ShurikenBTN.Name = "ShurikenBTN";
            this.ShurikenBTN.Size = new System.Drawing.Size(160, 63);
            this.ShurikenBTN.TabIndex = 9;
            this.ShurikenBTN.Text = "Shuriken";
            this.ShurikenBTN.UseVisualStyleBackColor = true;
            this.ShurikenBTN.Click += new System.EventHandler(this.ShurikenBTN_Click);
            // 
            // OverPopTB
            // 
            this.OverPopTB.Location = new System.Drawing.Point(1319, 571);
            this.OverPopTB.Name = "OverPopTB";
            this.OverPopTB.Size = new System.Drawing.Size(100, 26);
            this.OverPopTB.TabIndex = 10;
            // 
            // UnderpopTB
            // 
            this.UnderpopTB.Location = new System.Drawing.Point(1319, 738);
            this.UnderpopTB.Name = "UnderpopTB";
            this.UnderpopTB.Size = new System.Drawing.Size(100, 26);
            this.UnderpopTB.TabIndex = 11;
            // 
            // RebirthPopTB
            // 
            this.RebirthPopTB.Location = new System.Drawing.Point(1319, 909);
            this.RebirthPopTB.Name = "RebirthPopTB";
            this.RebirthPopTB.Size = new System.Drawing.Size(100, 26);
            this.RebirthPopTB.TabIndex = 12;
            // 
            // GenerationLB
            // 
            this.GenerationLB.AutoSize = true;
            this.GenerationLB.Location = new System.Drawing.Point(1306, 51);
            this.GenerationLB.Name = "GenerationLB";
            this.GenerationLB.Size = new System.Drawing.Size(97, 20);
            this.GenerationLB.TabIndex = 13;
            this.GenerationLB.Text = "Generation: ";
            // 
            // DrawTimer
            // 
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1244, 444);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 114);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "set how many cells must be \r\nsurronding a cell for it to die \r\nof overpopulation";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1244, 631);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(270, 101);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "Set an under-population limit\r\nat which cells will die if there are\r\nless surroun" +
    "ding the cell";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1244, 808);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(270, 88);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "Set the rebirth limit for the cells,\r\nthis will change how many cells must \r\nbe s" +
    "urrounding a cell in order to reproduce ";
            // 
            // nextGenBTN
            // 
            this.nextGenBTN.Location = new System.Drawing.Point(1306, 87);
            this.nextGenBTN.Name = "nextGenBTN";
            this.nextGenBTN.Size = new System.Drawing.Size(160, 43);
            this.nextGenBTN.TabIndex = 17;
            this.nextGenBTN.Text = "nextGenBTN";
            this.nextGenBTN.UseVisualStyleBackColor = true;
            this.nextGenBTN.Click += new System.EventHandler(this.nextGenBTN_Click);
            // 
            // GliderBTN
            // 
            this.GliderBTN.Location = new System.Drawing.Point(150, 1263);
            this.GliderBTN.Name = "GliderBTN";
            this.GliderBTN.Size = new System.Drawing.Size(149, 63);
            this.GliderBTN.TabIndex = 18;
            this.GliderBTN.Text = "Glider";
            this.GliderBTN.UseVisualStyleBackColor = true;
            this.GliderBTN.Click += new System.EventHandler(this.GliderBTN_Click);
            // 
            // RandomBTN
            // 
            this.RandomBTN.Location = new System.Drawing.Point(921, 1263);
            this.RandomBTN.Name = "RandomBTN";
            this.RandomBTN.Size = new System.Drawing.Size(139, 63);
            this.RandomBTN.TabIndex = 19;
            this.RandomBTN.Text = "Random";
            this.RandomBTN.UseVisualStyleBackColor = true;
            this.RandomBTN.Click += new System.EventHandler(this.RandomBTN_Click);
            // 
            // clearHeatBTN
            // 
            this.clearHeatBTN.Location = new System.Drawing.Point(1306, 960);
            this.clearHeatBTN.Name = "clearHeatBTN";
            this.clearHeatBTN.Size = new System.Drawing.Size(144, 59);
            this.clearHeatBTN.TabIndex = 20;
            this.clearHeatBTN.Text = "Clear HeatMap";
            this.clearHeatBTN.UseVisualStyleBackColor = true;
            this.clearHeatBTN.Click += new System.EventHandler(this.clearHeatBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 1735);
            this.Controls.Add(this.clearHeatBTN);
            this.Controls.Add(this.RandomBTN);
            this.Controls.Add(this.GliderBTN);
            this.Controls.Add(this.nextGenBTN);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GenerationLB);
            this.Controls.Add(this.RebirthPopTB);
            this.Controls.Add(this.UnderpopTB);
            this.Controls.Add(this.OverPopTB);
            this.Controls.Add(this.ShurikenBTN);
            this.Controls.Add(this.LionHeartBTN);
            this.Controls.Add(this.PulsarBTN);
            this.Controls.Add(this.SetRebirthBTN);
            this.Controls.Add(this.SetUnderpopBTN);
            this.Controls.Add(this.SetOverpopBtn);
            this.Controls.Add(this.NewRulesBTN);
            this.Controls.Add(this.ClassicGameModeBTN);
            this.Controls.Add(this.ClearBTN);
            this.Controls.Add(this.PlayBTN);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayBTN;
        private System.Windows.Forms.Button ClearBTN;
        private System.Windows.Forms.Button ClassicGameModeBTN;
        private System.Windows.Forms.Button NewRulesBTN;
        private System.Windows.Forms.Button SetOverpopBtn;
        private System.Windows.Forms.Button SetUnderpopBTN;
        private System.Windows.Forms.Button SetRebirthBTN;
        private System.Windows.Forms.Button PulsarBTN;
        private System.Windows.Forms.Button LionHeartBTN;
        private System.Windows.Forms.Button ShurikenBTN;
        private System.Windows.Forms.TextBox OverPopTB;
        private System.Windows.Forms.TextBox UnderpopTB;
        private System.Windows.Forms.TextBox RebirthPopTB;
        private System.Windows.Forms.Label GenerationLB;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button nextGenBTN;
        private System.Windows.Forms.Button GliderBTN;
        private System.Windows.Forms.Button RandomBTN;
        private System.Windows.Forms.Button clearHeatBTN;
    }
}

