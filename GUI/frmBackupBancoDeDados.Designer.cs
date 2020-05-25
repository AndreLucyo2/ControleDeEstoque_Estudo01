namespace GUI
{
    partial class frmBackupBancoDeDados
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
            this.label4 = new System.Windows.Forms.Label();
            this.btBackup = new System.Windows.Forms.Button();
            this.btRestaurar = new System.Windows.Forms.Button();
            this.txtbLocalBackup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(11, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Local Backup:";
            // 
            // btBackup
            // 
            this.btBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBackup.Location = new System.Drawing.Point(11, 11);
            this.btBackup.Margin = new System.Windows.Forms.Padding(2);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(194, 129);
            this.btBackup.TabIndex = 25;
            this.btBackup.Text = "Backup do banco de dados";
            this.btBackup.UseVisualStyleBackColor = true;
            this.btBackup.Click += new System.EventHandler(this.btBackup_Click);
            // 
            // btRestaurar
            // 
            this.btRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRestaurar.Location = new System.Drawing.Point(226, 11);
            this.btRestaurar.Margin = new System.Windows.Forms.Padding(2);
            this.btRestaurar.Name = "btRestaurar";
            this.btRestaurar.Size = new System.Drawing.Size(189, 129);
            this.btRestaurar.TabIndex = 28;
            this.btRestaurar.Text = "Restaurar banco de dados";
            this.btRestaurar.UseVisualStyleBackColor = true;
            this.btRestaurar.Click += new System.EventHandler(this.btRestaurar_Click);
            // 
            // txtbLocalBackup
            // 
            this.txtbLocalBackup.Enabled = false;
            this.txtbLocalBackup.Location = new System.Drawing.Point(14, 185);
            this.txtbLocalBackup.Multiline = true;
            this.txtbLocalBackup.Name = "txtbLocalBackup";
            this.txtbLocalBackup.Size = new System.Drawing.Size(379, 47);
            this.txtbLocalBackup.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Usuário deve ter acesso total na pasta selecionada para salvar o Backup.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(11, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 58);
            this.label2.TabIndex = 32;
            this.label2.Text = "ver aula back up turbo  : https://www.youtube.com/watch?v=M3TiMzBZwu8&list=PLfvOp" +
    "w8k80Wqj1a66Qsjh8jj4hlkzKSjA&index=94";
            // 
            // frmBackupBancoDeDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 302);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbLocalBackup);
            this.Controls.Add(this.btRestaurar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btBackup);
            this.Name = "frmBackupBancoDeDados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Banco De Dados";
            this.Load += new System.EventHandler(this.frmBackupBancoDeDados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.Button btRestaurar;
        private System.Windows.Forms.TextBox txtbLocalBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}