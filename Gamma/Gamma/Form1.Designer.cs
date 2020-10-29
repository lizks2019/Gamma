namespace Gamma
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.шифрВернамаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шифрованиеПоМодулю33ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шифрВернамаToolStripMenuItem,
            this.шифрованиеПоМодулю33ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(293, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Шифр Вернама";
            // 
            // шифрВернамаToolStripMenuItem
            // 
            this.шифрВернамаToolStripMenuItem.Name = "шифрВернамаToolStripMenuItem";
            this.шифрВернамаToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.шифрВернамаToolStripMenuItem.Text = "Шифр Вернама";
            this.шифрВернамаToolStripMenuItem.Click += new System.EventHandler(this.шифрВернамаToolStripMenuItem_Click);
            // 
            // шифрованиеПоМодулю33ToolStripMenuItem
            // 
            this.шифрованиеПоМодулю33ToolStripMenuItem.Name = "шифрованиеПоМодулю33ToolStripMenuItem";
            this.шифрованиеПоМодулю33ToolStripMenuItem.Size = new System.Drawing.Size(172, 20);
            this.шифрованиеПоМодулю33ToolStripMenuItem.Text = "Шифрование по модулю 33";
            this.шифрованиеПоМодулю33ToolStripMenuItem.Click += new System.EventHandler(this.шифрованиеПоМодулю33ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 77);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Шифры гаммирования";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem шифрВернамаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шифрованиеПоМодулю33ToolStripMenuItem;
    }
}

