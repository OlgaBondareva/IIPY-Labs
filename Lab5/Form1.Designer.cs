namespace Lab5
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
            this.DeviceInfo = new System.Windows.Forms.TextBox();
            this.EnableButton = new System.Windows.Forms.Button();
            this.DisableButton = new System.Windows.Forms.Button();
            this.DeviceList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // DeviceInfo
            // 
            this.DeviceInfo.Location = new System.Drawing.Point(11, 158);
            this.DeviceInfo.Multiline = true;
            this.DeviceInfo.Name = "DeviceInfo";
            this.DeviceInfo.Size = new System.Drawing.Size(403, 106);
            this.DeviceInfo.TabIndex = 1;
            // 
            // EnableButton
            // 
            this.EnableButton.Location = new System.Drawing.Point(12, 270);
            this.EnableButton.Name = "EnableButton";
            this.EnableButton.Size = new System.Drawing.Size(75, 23);
            this.EnableButton.TabIndex = 1;
            this.EnableButton.Text = "Enable";
            this.EnableButton.UseVisualStyleBackColor = true;
            this.EnableButton.Click += new System.EventHandler(this.EnableButton_Click);
            // 
            // DisableButton
            // 
            this.DisableButton.Location = new System.Drawing.Point(339, 270);
            this.DisableButton.Name = "DisableButton";
            this.DisableButton.Size = new System.Drawing.Size(75, 23);
            this.DisableButton.TabIndex = 2;
            this.DisableButton.Text = "Disable";
            this.DisableButton.UseVisualStyleBackColor = true;
            this.DisableButton.Click += new System.EventHandler(this.DisableButton_Click);
            // 
            // DeviceList
            // 
            this.DeviceList.FullRowSelect = true;
            this.DeviceList.Location = new System.Drawing.Point(12, 29);
            this.DeviceList.MultiSelect = false;
            this.DeviceList.Name = "DeviceList";
            this.DeviceList.Size = new System.Drawing.Size(403, 123);
            this.DeviceList.TabIndex = 4;
            this.DeviceList.UseCompatibleStateImageBehavior = false;
            this.DeviceList.View = System.Windows.Forms.View.List;
            this.DeviceList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeviceList_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 305);
            this.Controls.Add(this.DeviceList);
            this.Controls.Add(this.DisableButton);
            this.Controls.Add(this.EnableButton);
            this.Controls.Add(this.DeviceInfo);
            this.Name = "Form1";
            this.Text = "Device Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DeviceInfo;
        private System.Windows.Forms.Button EnableButton;
        private System.Windows.Forms.Button DisableButton;
        private System.Windows.Forms.ListView DeviceList;

    }
}

