namespace DiplomAE
{
    partial class ChatUserControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.Date = new System.Windows.Forms.Label();
            this.FIO = new System.Windows.Forms.Label();
            this.Statuss = new System.Windows.Forms.Label();
            this.Text = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Avatar.Location = new System.Drawing.Point(3, 27);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(61, 55);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // Date
            // 
            this.Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Date.Location = new System.Drawing.Point(72, 91);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(497, 12);
            this.Date.TabIndex = 2;
            this.Date.Text = "Отправлено";
            this.Date.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FIO
            // 
            this.FIO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FIO.AutoSize = true;
            this.FIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIO.Location = new System.Drawing.Point(3, 2);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(110, 18);
            this.FIO.TabIndex = 3;
            this.FIO.Text = "Отправитель";
            // 
            // Statuss
            // 
            this.Statuss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Statuss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Statuss.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Statuss.Location = new System.Drawing.Point(326, 1);
            this.Statuss.Name = "Statuss";
            this.Statuss.Size = new System.Drawing.Size(159, 19);
            this.Statuss.TabIndex = 4;
            this.Statuss.Text = "Статус";
            this.Statuss.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Text
            // 
            this.Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Text.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Text.CausesValidation = false;
            this.Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.Text.DetectUrls = false;
            this.Text.Location = new System.Drawing.Point(72, 28);
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            this.Text.Size = new System.Drawing.Size(497, 59);
            this.Text.TabIndex = 5;
            this.Text.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16458F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.83542F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Text, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Date, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Avatar, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.58228F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.41772F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(572, 103);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Statuss);
            this.panel1.Controls.Add(this.FIO);
            this.panel1.Location = new System.Drawing.Point(72, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 18);
            this.panel1.TabIndex = 6;
            // 
            // ChatUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChatUserControl";
            this.Size = new System.Drawing.Size(578, 109);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label FIO;
        private System.Windows.Forms.Label Statuss;
        public new System.Windows.Forms.RichTextBox Text;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
