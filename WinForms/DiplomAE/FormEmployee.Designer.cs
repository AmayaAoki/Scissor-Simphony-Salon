namespace DiplomAE
{
    partial class FormEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployee));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.photoImg = new System.Windows.Forms.PictureBox();
            this.RefreshB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.FIO = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.EditBtn = new System.Windows.Forms.Button();
            this.DelFilterB = new System.Windows.Forms.Button();
            this.DelB = new System.Windows.Forms.Button();
            this.CancelB = new System.Windows.Forms.Button();
            this.SaveB = new System.Windows.Forms.Button();
            this.AppointmentsDVG = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statuss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chatFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SendB = new System.Windows.Forms.Button();
            this.writetext = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoImg)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsDVG)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.photoImg);
            this.groupBox1.Controls.Add(this.RefreshB);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ExitButton);
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.FIO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(235, 761);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(47, 516);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 135);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // photoImg
            // 
            this.photoImg.BackColor = System.Drawing.Color.Transparent;
            this.photoImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.photoImg.Location = new System.Drawing.Point(37, 63);
            this.photoImg.Name = "photoImg";
            this.photoImg.Size = new System.Drawing.Size(170, 160);
            this.photoImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoImg.TabIndex = 6;
            this.photoImg.TabStop = false;
            // 
            // RefreshB
            // 
            this.RefreshB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshB.Location = new System.Drawing.Point(37, 410);
            this.RefreshB.Name = "RefreshB";
            this.RefreshB.Size = new System.Drawing.Size(170, 54);
            this.RefreshB.TabIndex = 5;
            this.RefreshB.Text = "Обновить данные";
            this.RefreshB.UseVisualStyleBackColor = true;
            this.RefreshB.Click += new System.EventHandler(this.RefreshB_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(37, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Профиль";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ProfileB_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Location = new System.Drawing.Point(37, 667);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(170, 34);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Status.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Status.Location = new System.Drawing.Point(68, 28);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(116, 24);
            this.Status.TabIndex = 1;
            this.Status.Text = "Сотрудник";
            // 
            // FIO
            // 
            this.FIO.AutoSize = true;
            this.FIO.BackColor = System.Drawing.Color.Transparent;
            this.FIO.ForeColor = System.Drawing.SystemColors.Control;
            this.FIO.Location = new System.Drawing.Point(43, 251);
            this.FIO.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.FIO.MaximumSize = new System.Drawing.Size(150, 80);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(54, 24);
            this.FIO.TabIndex = 0;
            this.FIO.Text = "ФИО";
            this.FIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(245, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(941, 761);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.EditBtn);
            this.tabPage1.Controls.Add(this.DelFilterB);
            this.tabPage1.Controls.Add(this.DelB);
            this.tabPage1.Controls.Add(this.CancelB);
            this.tabPage1.Controls.Add(this.SaveB);
            this.tabPage1.Controls.Add(this.AppointmentsDVG);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(933, 724);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Записи";
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.EditBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EditBtn.Location = new System.Drawing.Point(369, 27);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(242, 46);
            this.EditBtn.TabIndex = 10;
            this.EditBtn.Text = "Добавление и фильтр";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // DelFilterB
            // 
            this.DelFilterB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelFilterB.Location = new System.Drawing.Point(182, 28);
            this.DelFilterB.Name = "DelFilterB";
            this.DelFilterB.Size = new System.Drawing.Size(169, 46);
            this.DelFilterB.TabIndex = 9;
            this.DelFilterB.Text = "Убрать фильтр";
            this.DelFilterB.UseVisualStyleBackColor = true;
            this.DelFilterB.Visible = false;
            this.DelFilterB.Click += new System.EventHandler(this.DelFilterB_Click);
            // 
            // DelB
            // 
            this.DelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DelB.BackColor = System.Drawing.Color.SteelBlue;
            this.DelB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelB.ForeColor = System.Drawing.SystemColors.Control;
            this.DelB.Location = new System.Drawing.Point(618, 30);
            this.DelB.Margin = new System.Windows.Forms.Padding(4);
            this.DelB.Name = "DelB";
            this.DelB.Size = new System.Drawing.Size(136, 43);
            this.DelB.TabIndex = 4;
            this.DelB.Text = "Удалить";
            this.DelB.UseVisualStyleBackColor = false;
            this.DelB.Click += new System.EventHandler(this.DelB_Click);
            // 
            // CancelB
            // 
            this.CancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelB.BackColor = System.Drawing.Color.SteelBlue;
            this.CancelB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelB.ForeColor = System.Drawing.SystemColors.Control;
            this.CancelB.Location = new System.Drawing.Point(773, 30);
            this.CancelB.Margin = new System.Windows.Forms.Padding(4);
            this.CancelB.Name = "CancelB";
            this.CancelB.Size = new System.Drawing.Size(138, 43);
            this.CancelB.TabIndex = 2;
            this.CancelB.Text = "Отменить";
            this.CancelB.UseVisualStyleBackColor = false;
            this.CancelB.Click += new System.EventHandler(this.CancelB_Click);
            // 
            // SaveB
            // 
            this.SaveB.BackColor = System.Drawing.Color.SteelBlue;
            this.SaveB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveB.ForeColor = System.Drawing.SystemColors.Control;
            this.SaveB.Location = new System.Drawing.Point(24, 30);
            this.SaveB.Margin = new System.Windows.Forms.Padding(4);
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(132, 43);
            this.SaveB.TabIndex = 1;
            this.SaveB.Text = "Сохранить";
            this.SaveB.UseVisualStyleBackColor = false;
            this.SaveB.Click += new System.EventHandler(this.SaveB_Click);
            // 
            // AppointmentsDVG
            // 
            this.AppointmentsDVG.AllowUserToAddRows = false;
            this.AppointmentsDVG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppointmentsDVG.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AppointmentsDVG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AppointmentsDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentsDVG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.EmployeeId,
            this.UserId,
            this.ServiceId,
            this.Datee,
            this.Timee,
            this.Statuss});
            this.AppointmentsDVG.Location = new System.Drawing.Point(24, 98);
            this.AppointmentsDVG.Margin = new System.Windows.Forms.Padding(4);
            this.AppointmentsDVG.MultiSelect = false;
            this.AppointmentsDVG.Name = "AppointmentsDVG";
            this.AppointmentsDVG.Size = new System.Drawing.Size(898, 581);
            this.AppointmentsDVG.TabIndex = 0;
            this.AppointmentsDVG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // EmployeeId
            // 
            this.EmployeeId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmployeeId.DataPropertyName = "EmployeeId";
            this.EmployeeId.HeaderText = "Сотрудник";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.Visible = false;
            // 
            // UserId
            // 
            this.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "Пользователь";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            // 
            // ServiceId
            // 
            this.ServiceId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServiceId.DataPropertyName = "ServiceId";
            this.ServiceId.HeaderText = "Услуга";
            this.ServiceId.Name = "ServiceId";
            // 
            // Datee
            // 
            this.Datee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Datee.DataPropertyName = "Date";
            this.Datee.HeaderText = "Дата";
            this.Datee.Name = "Datee";
            // 
            // Timee
            // 
            this.Timee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Timee.DataPropertyName = "EventTime";
            this.Timee.HeaderText = "Время";
            this.Timee.Name = "Timee";
            // 
            // Statuss
            // 
            this.Statuss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Statuss.DataPropertyName = "Status";
            this.Statuss.HeaderText = "Статус";
            this.Statuss.Name = "Statuss";
            this.Statuss.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.chatFlowLayoutPanel);
            this.tabPage3.Controls.Add(this.SendB);
            this.tabPage3.Controls.Add(this.writetext);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(933, 724);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Чат";
            // 
            // chatFlowLayoutPanel
            // 
            this.chatFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatFlowLayoutPanel.AutoScroll = true;
            this.chatFlowLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chatFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.chatFlowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatFlowLayoutPanel.Location = new System.Drawing.Point(12, 15);
            this.chatFlowLayoutPanel.Name = "chatFlowLayoutPanel";
            this.chatFlowLayoutPanel.Size = new System.Drawing.Size(911, 532);
            this.chatFlowLayoutPanel.TabIndex = 0;
            this.chatFlowLayoutPanel.WrapContents = false;
            // 
            // SendB
            // 
            this.SendB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendB.BackColor = System.Drawing.Color.SteelBlue;
            this.SendB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendB.ForeColor = System.Drawing.SystemColors.Control;
            this.SendB.Location = new System.Drawing.Point(729, 608);
            this.SendB.Name = "SendB";
            this.SendB.Size = new System.Drawing.Size(176, 60);
            this.SendB.TabIndex = 5;
            this.SendB.Text = "Отправить";
            this.SendB.UseVisualStyleBackColor = false;
            // 
            // writetext
            // 
            this.writetext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.writetext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.writetext.Location = new System.Drawing.Point(12, 567);
            this.writetext.Name = "writetext";
            this.writetext.Size = new System.Drawing.Size(690, 136);
            this.writetext.TabIndex = 4;
            this.writetext.Text = "";
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "FormEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель сотрудника";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoImg)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsDVG)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox photoImg;
        private System.Windows.Forms.Button RefreshB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label FIO;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button DelB;
        private System.Windows.Forms.Button CancelB;
        private System.Windows.Forms.Button SaveB;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button SendB;
        private System.Windows.Forms.RichTextBox writetext;
        private System.Windows.Forms.FlowLayoutPanel chatFlowLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button DelFilterB;
        private System.Windows.Forms.DataGridView AppointmentsDVG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statuss;
    }
}