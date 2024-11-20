namespace WebAPIWithWindowsForm
{
    partial class frmKullanici
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUserName = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btnEkle = new Button();
            dtpDateOfBirth = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtAdress = new TextBox();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label8 = new Label();
            btnDüzenle = new Button();
            btnSil = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(138, 45);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(258, 23);
            txtUserName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "Kullanıcı Adı:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 322);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(835, 150);
            dataGridView1.TabIndex = 2;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(280, 236);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(98, 33);
            btnEkle.TabIndex = 3;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(569, 131);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(258, 23);
            dtpDateOfBirth.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 6;
            label2.Text = "Adı:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 7;
            label3.Text = "Soyadı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 173);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 8;
            label4.Text = "Şifre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(443, 48);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(443, 92);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 10;
            label6.Text = "Adres:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(138, 86);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(258, 23);
            txtFirstName.TabIndex = 11;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(138, 131);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(258, 23);
            txtLastName.TabIndex = 12;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(138, 173);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(258, 23);
            txtPassword.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(569, 48);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(258, 23);
            txtEmail.TabIndex = 14;
            // 
            // txtAdress
            // 
            txtAdress.Location = new Point(569, 92);
            txtAdress.Name = "txtAdress";
            txtAdress.Size = new Size(258, 23);
            txtAdress.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(443, 139);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 16;
            label7.Text = "Doğum Tarihi:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Erkek", "Kadın" });
            comboBox1.Location = new Point(569, 174);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 23);
            comboBox1.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(443, 182);
            label8.Name = "label8";
            label8.Size = new Size(52, 15);
            label8.TabIndex = 18;
            label8.Text = "Cinsiyet:";
            // 
            // btnDüzenle
            // 
            btnDüzenle.Location = new Point(401, 236);
            btnDüzenle.Name = "btnDüzenle";
            btnDüzenle.Size = new Size(107, 33);
            btnDüzenle.TabIndex = 19;
            btnDüzenle.Text = "Düzenle";
            btnDüzenle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(532, 236);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(102, 33);
            btnSil.TabIndex = 20;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            // 
            // frmKullanici
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 532);
            Controls.Add(btnSil);
            Controls.Add(btnDüzenle);
            Controls.Add(label8);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(txtAdress);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(btnEkle);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(txtUserName);
            Name = "frmKullanici";
            Text = "Kullanıcı";
            Load += frmKullanici_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private Label label1;
        private DataGridView dataGridView1;
        private Button btnEkle;
        private DateTimePicker dtpDateOfBirth;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtAdress;
        private Label label7;
        private ComboBox comboBox1;
        private Label label8;
        private Button btnDüzenle;
        private Button btnSil;
    }
}
