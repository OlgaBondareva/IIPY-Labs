namespace USB_devices
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
            this.components = new System.ComponentModel.Container();
            this.OutputGrid = new System.Windows.Forms.DataGridView();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OutputGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputGrid
            // 
            this.OutputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutputGrid.Location = new System.Drawing.Point(12, 12);
            this.OutputGrid.Name = "OutputGrid";
            this.OutputGrid.Size = new System.Drawing.Size(443, 135);
            this.OutputGrid.TabIndex = 0;
            this.OutputGrid.SelectionChanged += new System.EventHandler(this.OutputGrid_SelectionChanged_1);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(380, 162);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Извлечь";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(228, 162);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(10, 13);
            this.Message.TabIndex = 3;
            this.Message.Text = " ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(467, 191);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.OutputGrid);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.OutputGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OutputGrid;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer timer1;

    }
}

