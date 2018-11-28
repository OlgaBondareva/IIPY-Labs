namespace Battery
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.powerTypeLabel = new System.Windows.Forms.Label();
            this.powerType = new System.Windows.Forms.Label();
            this.powerLeftLabel = new System.Windows.Forms.Label();
            this.powerLeft = new System.Windows.Forms.ProgressBar();
            this.screenOffLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.timeLeft = new System.Windows.Forms.Label();
            this.powerValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // powerTypeLabel
            // 
            this.powerTypeLabel.AutoSize = true;
            this.powerTypeLabel.Location = new System.Drawing.Point(13, 28);
            this.powerTypeLabel.Name = "powerTypeLabel";
            this.powerTypeLabel.Size = new System.Drawing.Size(76, 13);
            this.powerTypeLabel.TabIndex = 0;
            this.powerTypeLabel.Text = "Тип питания: ";
            // 
            // powerType
            // 
            this.powerType.AutoSize = true;
            this.powerType.Location = new System.Drawing.Point(193, 28);
            this.powerType.Name = "powerType";
            this.powerType.Size = new System.Drawing.Size(0, 13);
            this.powerType.TabIndex = 1;
            // 
            // powerLeftLabel
            // 
            this.powerLeftLabel.AutoSize = true;
            this.powerLeftLabel.Location = new System.Drawing.Point(13, 66);
            this.powerLeftLabel.Name = "powerLeftLabel";
            this.powerLeftLabel.Size = new System.Drawing.Size(88, 13);
            this.powerLeftLabel.TabIndex = 2;
            this.powerLeftLabel.Text = "Заряд батареи: ";
            // 
            // powerLeft
            // 
            this.powerLeft.Location = new System.Drawing.Point(196, 66);
            this.powerLeft.Name = "powerLeft";
            this.powerLeft.Size = new System.Drawing.Size(100, 23);
            this.powerLeft.Step = 1;
            this.powerLeft.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.powerLeft.TabIndex = 3;
            // 
            // screenOffLabel
            // 
            this.screenOffLabel.AutoSize = true;
            this.screenOffLabel.Location = new System.Drawing.Point(13, 145);
            this.screenOffLabel.Name = "screenOffLabel";
            this.screenOffLabel.Size = new System.Drawing.Size(177, 13);
            this.screenOffLabel.TabIndex = 4;
            this.screenOffLabel.Text = "Время выключения экрана (мин):";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(196, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(307, 140);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 6;
            this.button.Text = "Применить";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Location = new System.Drawing.Point(13, 104);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(145, 13);
            this.timeLeftLabel.TabIndex = 7;
            this.timeLeftLabel.Text = "Оставшееся врем работы: ";
            // 
            // timeLeft
            // 
            this.timeLeft.AutoSize = true;
            this.timeLeft.Location = new System.Drawing.Point(193, 104);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(0, 13);
            this.timeLeft.TabIndex = 8;
            // 
            // powerValue
            // 
            this.powerValue.AutoSize = true;
            this.powerValue.BackColor = System.Drawing.SystemColors.Menu;
            this.powerValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.powerValue.Location = new System.Drawing.Point(231, 50);
            this.powerValue.Name = "powerValue";
            this.powerValue.Size = new System.Drawing.Size(35, 13);
            this.powerValue.TabIndex = 9;
            this.powerValue.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 191);
            this.Controls.Add(this.powerValue);
            this.Controls.Add(this.timeLeft);
            this.Controls.Add(this.timeLeftLabel);
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.screenOffLabel);
            this.Controls.Add(this.powerLeft);
            this.Controls.Add(this.powerLeftLabel);
            this.Controls.Add(this.powerType);
            this.Controls.Add(this.powerTypeLabel);
            this.Name = "Form1";
            this.Text = "Battery Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label powerTypeLabel;
        private System.Windows.Forms.Label powerType;
        private System.Windows.Forms.Label powerLeftLabel;
        private System.Windows.Forms.ProgressBar powerLeft;
        private System.Windows.Forms.Label screenOffLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label timeLeftLabel;
        private System.Windows.Forms.Label timeLeft;
        private System.Windows.Forms.Label powerValue;
    }
}

