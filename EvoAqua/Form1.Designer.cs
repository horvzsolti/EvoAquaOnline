namespace EvoAqua
{
    partial class Form1
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
            System.Windows.Forms.TabControl TabControl;
            this.output = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_raceName = new System.Windows.Forms.TextBox();
            this.tb_dbName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_uname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.b_conf = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_pw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_server = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.TabPage();
            this.tb_lastUpdate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.b_fileWatcher = new System.Windows.Forms.Button();
            this.b_imp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_watchedDir = new System.Windows.Forms.TextBox();
            this.timer_fileWatcher = new System.Windows.Forms.Timer(this.components);
            TabControl = new System.Windows.Forms.TabControl();
            TabControl.SuspendLayout();
            this.output.SuspendLayout();
            this.input.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(this.output);
            TabControl.Controls.Add(this.input);
            TabControl.Location = new System.Drawing.Point(41, 25);
            TabControl.Margin = new System.Windows.Forms.Padding(4);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new System.Drawing.Size(872, 593);
            TabControl.TabIndex = 0;
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.output.Controls.Add(this.label8);
            this.output.Controls.Add(this.tb_raceName);
            this.output.Controls.Add(this.tb_dbName);
            this.output.Controls.Add(this.label7);
            this.output.Controls.Add(this.tb_uname);
            this.output.Controls.Add(this.label6);
            this.output.Controls.Add(this.b_conf);
            this.output.Controls.Add(this.label3);
            this.output.Controls.Add(this.tb_pw);
            this.output.Controls.Add(this.label2);
            this.output.Controls.Add(this.tb_server);
            this.output.Location = new System.Drawing.Point(4, 25);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Padding = new System.Windows.Forms.Padding(4);
            this.output.Size = new System.Drawing.Size(864, 564);
            this.output.TabIndex = 0;
            this.output.Text = "Connect";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Race name:";
            // 
            // tb_raceName
            // 
            this.tb_raceName.Location = new System.Drawing.Point(311, 329);
            this.tb_raceName.Name = "tb_raceName";
            this.tb_raceName.Size = new System.Drawing.Size(351, 22);
            this.tb_raceName.TabIndex = 11;
            // 
            // tb_dbName
            // 
            this.tb_dbName.Location = new System.Drawing.Point(311, 272);
            this.tb_dbName.Name = "tb_dbName";
            this.tb_dbName.Size = new System.Drawing.Size(351, 22);
            this.tb_dbName.TabIndex = 10;
            this.tb_dbName.Text = "evoAquaOnline";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Database name:";
            // 
            // tb_uname
            // 
            this.tb_uname.Location = new System.Drawing.Point(311, 162);
            this.tb_uname.Name = "tb_uname";
            this.tb_uname.Size = new System.Drawing.Size(351, 22);
            this.tb_uname.TabIndex = 8;
            this.tb_uname.Text = "root";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Username:";
            // 
            // b_conf
            // 
            this.b_conf.BackColor = System.Drawing.Color.Gray;
            this.b_conf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_conf.Location = new System.Drawing.Point(390, 427);
            this.b_conf.Margin = new System.Windows.Forms.Padding(4);
            this.b_conf.Name = "b_conf";
            this.b_conf.Size = new System.Drawing.Size(111, 34);
            this.b_conf.TabIndex = 4;
            this.b_conf.Text = "OK";
            this.b_conf.UseVisualStyleBackColor = false;
            this.b_conf.Click += new System.EventHandler(this.b_conf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // tb_pw
            // 
            this.tb_pw.Location = new System.Drawing.Point(311, 211);
            this.tb_pw.Margin = new System.Windows.Forms.Padding(4);
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.PasswordChar = '*';
            this.tb_pw.Size = new System.Drawing.Size(351, 22);
            this.tb_pw.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server name:";
            // 
            // tb_server
            // 
            this.tb_server.Location = new System.Drawing.Point(311, 109);
            this.tb_server.Margin = new System.Windows.Forms.Padding(4);
            this.tb_server.Name = "tb_server";
            this.tb_server.Size = new System.Drawing.Size(351, 22);
            this.tb_server.TabIndex = 0;
            this.tb_server.Text = "localhost";
            // 
            // input
            // 
            this.input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.input.Controls.Add(this.tb_lastUpdate);
            this.input.Controls.Add(this.label4);
            this.input.Controls.Add(this.label5);
            this.input.Controls.Add(this.b_fileWatcher);
            this.input.Controls.Add(this.b_imp);
            this.input.Controls.Add(this.button1);
            this.input.Controls.Add(this.label1);
            this.input.Controls.Add(this.tb_watchedDir);
            this.input.Location = new System.Drawing.Point(4, 25);
            this.input.Margin = new System.Windows.Forms.Padding(4);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(4);
            this.input.Size = new System.Drawing.Size(864, 564);
            this.input.TabIndex = 1;
            this.input.Text = "Input";
            // 
            // tb_lastUpdate
            // 
            this.tb_lastUpdate.Location = new System.Drawing.Point(639, 527);
            this.tb_lastUpdate.Name = "tb_lastUpdate";
            this.tb_lastUpdate.ReadOnly = true;
            this.tb_lastUpdate.Size = new System.Drawing.Size(207, 22);
            this.tb_lastUpdate.TabIndex = 7;
            this.tb_lastUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(546, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last update:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "FileWatcher:";
            // 
            // b_fileWatcher
            // 
            this.b_fileWatcher.BackColor = System.Drawing.Color.Gray;
            this.b_fileWatcher.Enabled = false;
            this.b_fileWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_fileWatcher.Location = new System.Drawing.Point(433, 328);
            this.b_fileWatcher.Name = "b_fileWatcher";
            this.b_fileWatcher.Size = new System.Drawing.Size(93, 56);
            this.b_fileWatcher.TabIndex = 4;
            this.b_fileWatcher.Text = "button4";
            this.b_fileWatcher.UseVisualStyleBackColor = false;
            this.b_fileWatcher.Click += new System.EventHandler(this.b_fileWatcher_Click);
            // 
            // b_imp
            // 
            this.b_imp.BackColor = System.Drawing.Color.Gray;
            this.b_imp.Enabled = false;
            this.b_imp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_imp.Location = new System.Drawing.Point(672, 177);
            this.b_imp.Name = "b_imp";
            this.b_imp.Size = new System.Drawing.Size(155, 51);
            this.b_imp.TabIndex = 3;
            this.b_imp.Text = "Import";
            this.b_imp.UseVisualStyleBackColor = false;
            this.b_imp.Click += new System.EventHandler(this.b_imp_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(672, 95);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Import from:";
            // 
            // tb_watchedDir
            // 
            this.tb_watchedDir.Location = new System.Drawing.Point(171, 101);
            this.tb_watchedDir.Margin = new System.Windows.Forms.Padding(4);
            this.tb_watchedDir.Name = "tb_watchedDir";
            this.tb_watchedDir.Size = new System.Drawing.Size(476, 22);
            this.tb_watchedDir.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(953, 647);
            this.Controls.Add(TabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "EvoAquaOnline";
            this.Load += new System.EventHandler(this.Form1_Load);
            TabControl.ResumeLayout(false);
            this.output.ResumeLayout(false);
            this.output.PerformLayout();
            this.input.ResumeLayout(false);
            this.input.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabPage input;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tb_watchedDir;
        public System.Windows.Forms.TabPage output;
        public System.Windows.Forms.Button b_conf;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_pw;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tb_server;
        private System.Windows.Forms.Button b_imp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b_fileWatcher;
        private System.Windows.Forms.Timer timer_fileWatcher;
        private System.Windows.Forms.TextBox tb_dbName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_uname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_lastUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_raceName;
    }
}

