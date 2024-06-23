namespace DiplomAE
{
    partial class RegEnter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegEnter));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EntButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CBphoto = new System.Windows.Forms.PictureBox();
            this.RegFIO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RegButton = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.RegStatus = new System.Windows.Forms.ComboBox();
            this.RegUsername = new System.Windows.Forms.TextBox();
            this.RegPassword = new System.Windows.Forms.TextBox();
            this.RegPhoto = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBphoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(90, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 477);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Авторизация";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.EntButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(72, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 443);
            this.panel1.TabIndex = 5;
            // 
            // EntButton
            // 
            this.EntButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.EntButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EntButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EntButton.ForeColor = System.Drawing.SystemColors.Control;
            this.EntButton.Location = new System.Drawing.Point(60, 317);
            this.EntButton.Name = "EntButton";
            this.EntButton.Size = new System.Drawing.Size(224, 42);
            this.EntButton.TabIndex = 3;
            this.EntButton.Text = "Войти";
            this.EntButton.UseVisualStyleBackColor = false;
            this.EntButton.Click += new System.EventHandler(this.EntButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(92, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // txtUsername
            // 
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUsername.ForeColor = System.Drawing.Color.Gray;
            this.txtUsername.Location = new System.Drawing.Point(13, 157);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(306, 22);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Логин:";
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(13, 219);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(306, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Пароль:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Location = new System.Drawing.Point(13, 263);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Показать пароль";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Регистрация";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.Controls.Add(this.CBphoto);
            this.panel2.Controls.Add(this.RegFIO);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.RegButton);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.RegStatus);
            this.panel2.Controls.Add(this.RegUsername);
            this.panel2.Controls.Add(this.RegPassword);
            this.panel2.Controls.Add(this.RegPhoto);
            this.panel2.Location = new System.Drawing.Point(71, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 433);
            this.panel2.TabIndex = 11;
            // 
            // CBphoto
            // 
            this.CBphoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CBphoto.Location = new System.Drawing.Point(256, 259);
            this.CBphoto.Name = "CBphoto";
            this.CBphoto.Size = new System.Drawing.Size(79, 64);
            this.CBphoto.TabIndex = 11;
            this.CBphoto.TabStop = false;
            // 
            // RegFIO
            // 
            this.RegFIO.ForeColor = System.Drawing.Color.Gray;
            this.RegFIO.Location = new System.Drawing.Point(16, 99);
            this.RegFIO.Name = "RegFIO";
            this.RegFIO.Size = new System.Drawing.Size(306, 22);
            this.RegFIO.TabIndex = 2;
            this.RegFIO.Text = "ФИО:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(110, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Регистрация";
            // 
            // RegButton
            // 
            this.RegButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.RegButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RegButton.Location = new System.Drawing.Point(65, 354);
            this.RegButton.Name = "RegButton";
            this.RegButton.Size = new System.Drawing.Size(214, 43);
            this.RegButton.TabIndex = 10;
            this.RegButton.Text = "Зарегистрироваться";
            this.RegButton.UseVisualStyleBackColor = false;
            this.RegButton.Click += new System.EventHandler(this.RegButton_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox2.Location = new System.Drawing.Point(18, 221);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(139, 20);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Показать пароль";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // RegStatus
            // 
            this.RegStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.RegStatus.ForeColor = System.Drawing.Color.Gray;
            this.RegStatus.FormattingEnabled = true;
            this.RegStatus.Items.AddRange(new object[] {
            "Сотрудник",
            "Администратор"});
            this.RegStatus.Location = new System.Drawing.Point(16, 299);
            this.RegStatus.Name = "RegStatus";
            this.RegStatus.Size = new System.Drawing.Size(221, 24);
            this.RegStatus.TabIndex = 9;
            this.RegStatus.Text = "Должность:";
            // 
            // RegUsername
            // 
            this.RegUsername.Cursor = System.Windows.Forms.Cursors.Default;
            this.RegUsername.ForeColor = System.Drawing.Color.Gray;
            this.RegUsername.Location = new System.Drawing.Point(16, 141);
            this.RegUsername.Name = "RegUsername";
            this.RegUsername.Size = new System.Drawing.Size(306, 22);
            this.RegUsername.TabIndex = 3;
            this.RegUsername.Text = "Логин:";
            // 
            // RegPassword
            // 
            this.RegPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.RegPassword.ForeColor = System.Drawing.Color.Gray;
            this.RegPassword.Location = new System.Drawing.Point(16, 182);
            this.RegPassword.Name = "RegPassword";
            this.RegPassword.Size = new System.Drawing.Size(306, 22);
            this.RegPassword.TabIndex = 4;
            this.RegPassword.Text = "Пароль:";
            // 
            // RegPhoto
            // 
            this.RegPhoto.BackColor = System.Drawing.SystemColors.Window;
            this.RegPhoto.Cursor = System.Windows.Forms.Cursors.Default;
            this.RegPhoto.ForeColor = System.Drawing.Color.Gray;
            this.RegPhoto.FormattingEnabled = true;
            this.RegPhoto.Items.AddRange(new object[] {
            "photo1",
            "photo2",
            "photo3",
            "photo4",
            "photo5",
            "photo6",
            "photo7",
            "photo8",
            "photo9",
            "photo10"});
            this.RegPhoto.Location = new System.Drawing.Point(16, 259);
            this.RegPhoto.Name = "RegPhoto";
            this.RegPhoto.Size = new System.Drawing.Size(221, 24);
            this.RegPhoto.TabIndex = 8;
            this.RegPhoto.Text = "Фото:";
            this.RegPhoto.SelectedIndexChanged += new System.EventHandler(this.RegPhoto_SelectedIndexChanged);
            // 
            // RegEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(652, 575);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "RegEnter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация\\Регистрация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBphoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EntButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox CBphoto;
        private System.Windows.Forms.TextBox RegFIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RegButton;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox RegStatus;
        private System.Windows.Forms.TextBox RegUsername;
        private System.Windows.Forms.TextBox RegPassword;
        private System.Windows.Forms.ComboBox RegPhoto;
    }
}

