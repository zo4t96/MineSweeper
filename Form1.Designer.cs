namespace MineSweeper
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.難度選擇ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.ToHard = new System.Windows.Forms.ToolStripMenuItem();
            this.Arrange = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "base.png");
            this.imageList1.Images.SetKeyName(1, "1.png");
            this.imageList1.Images.SetKeyName(2, "2.png");
            this.imageList1.Images.SetKeyName(3, "3.png");
            this.imageList1.Images.SetKeyName(4, "4.png");
            this.imageList1.Images.SetKeyName(5, "5.png");
            this.imageList1.Images.SetKeyName(6, "6.png");
            this.imageList1.Images.SetKeyName(7, "7.png");
            this.imageList1.Images.SetKeyName(8, "8.png");
            this.imageList1.Images.SetKeyName(9, "boom.png");
            this.imageList1.Images.SetKeyName(10, "face.png");
            this.imageList1.Images.SetKeyName(11, "flag.png");
            this.imageList1.Images.SetKeyName(12, "mine.png");
            this.imageList1.Images.SetKeyName(13, "wrong.png");
            this.imageList1.Images.SetKeyName(14, "xx.png");
            this.imageList1.Images.SetKeyName(15, "Sun.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.難度選擇ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 難度選擇ToolStripMenuItem
            // 
            this.難度選擇ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToEasy,
            this.ToNormal,
            this.ToHard,
            this.Arrange});
            this.難度選擇ToolStripMenuItem.Name = "難度選擇ToolStripMenuItem";
            this.難度選擇ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.難度選擇ToolStripMenuItem.Text = "難度選擇";
            // 
            // ToEasy
            // 
            this.ToEasy.Name = "ToEasy";
            this.ToEasy.Size = new System.Drawing.Size(122, 22);
            this.ToEasy.Text = "簡單";
            // 
            // ToNormal
            // 
            this.ToNormal.Name = "ToNormal";
            this.ToNormal.Size = new System.Drawing.Size(122, 22);
            this.ToNormal.Text = "中級";
            // 
            // ToHard
            // 
            this.ToHard.Name = "ToHard";
            this.ToHard.Size = new System.Drawing.Size(122, 22);
            this.ToHard.Text = "困難";
            // 
            // Arrange
            // 
            this.Arrange.Name = "Arrange";
            this.Arrange.Size = new System.Drawing.Size(122, 22);
            this.Arrange.Text = "自訂難度";
            this.Arrange.Click += new System.EventHandler(this.Arrange_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "作弊鈕ㄛ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(830, 610);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 難度選擇ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToEasy;
        private System.Windows.Forms.ToolStripMenuItem ToNormal;
        private System.Windows.Forms.ToolStripMenuItem ToHard;
        private System.Windows.Forms.ToolStripMenuItem Arrange;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

