namespace RNS
{
    partial class home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.button1 = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.faculty = new System.Windows.Forms.Button();
            this.se = new System.Windows.Forms.Button();
            this.te = new System.Windows.Forms.Button();
            this.be = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(271, 349);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(347, 231);
            this.username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(116, 23);
            this.username.TabIndex = 1;
            this.username.Visible = false;
            // 
            // password
            // 
            this.password.AcceptsTab = true;
            this.password.Location = new System.Drawing.Point(347, 293);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(116, 23);
            this.password.TabIndex = 4;
            this.password.Visible = false;
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(207, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(207, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            this.label3.Visible = false;
            // 
            // faculty
            // 
            this.faculty.BackColor = System.Drawing.Color.DarkBlue;
            this.faculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.faculty.ForeColor = System.Drawing.Color.White;
            this.faculty.Location = new System.Drawing.Point(81, 78);
            this.faculty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.faculty.Name = "faculty";
            this.faculty.Size = new System.Drawing.Size(87, 28);
            this.faculty.TabIndex = 7;
            this.faculty.Text = "Faculty";
            this.faculty.UseVisualStyleBackColor = false;
            this.faculty.Click += new System.EventHandler(this.faculty_Click);
            // 
            // se
            // 
            this.se.BackColor = System.Drawing.Color.DarkBlue;
            this.se.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.se.ForeColor = System.Drawing.Color.White;
            this.se.Location = new System.Drawing.Point(235, 78);
            this.se.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.se.Name = "se";
            this.se.Size = new System.Drawing.Size(87, 28);
            this.se.TabIndex = 8;
            this.se.Text = "SE";
            this.se.UseVisualStyleBackColor = false;
            this.se.Click += new System.EventHandler(this.se_Click);
            // 
            // te
            // 
            this.te.BackColor = System.Drawing.Color.DarkBlue;
            this.te.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.te.ForeColor = System.Drawing.Color.White;
            this.te.Location = new System.Drawing.Point(383, 78);
            this.te.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.te.Name = "te";
            this.te.Size = new System.Drawing.Size(87, 28);
            this.te.TabIndex = 9;
            this.te.Text = "TE";
            this.te.UseVisualStyleBackColor = false;
            this.te.Click += new System.EventHandler(this.te_Click);
            // 
            // be
            // 
            this.be.BackColor = System.Drawing.Color.DarkBlue;
            this.be.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.be.ForeColor = System.Drawing.Color.White;
            this.be.Location = new System.Drawing.Point(517, 78);
            this.be.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(87, 28);
            this.be.TabIndex = 10;
            this.be.Text = "BE";
            this.be.UseVisualStyleBackColor = false;
            this.be.Click += new System.EventHandler(this.be_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Login";
            this.label1.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Department Notice portal";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.be);
            this.Controls.Add(this.te);
            this.Controls.Add(this.se);
            this.Controls.Add(this.faculty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(683, 454);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(683, 454);
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notice Portal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.home_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button faculty;
        private System.Windows.Forms.Button se;
        private System.Windows.Forms.Button te;
        private System.Windows.Forms.Button be;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

