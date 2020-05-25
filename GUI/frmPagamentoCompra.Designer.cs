namespace GUI
{
    partial class frmPagamentoCompra
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
            this.btLocalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComCod = new System.Windows.Forms.TextBox();
            this.txtNomeFornecedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNFiscal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvParcelas = new System.Windows.Forms.DataGridView();
            this.btPagarParcela = new System.Windows.Forms.Button();
            this.btCancelaPagto = new System.Windows.Forms.Button();
            this.dtDataCompra = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalCompra = new System.Windows.Forms.TextBox();
            this.txtForCod = new System.Windows.Forms.TextBox();
            this.dtDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // btLocalizar
            // 
            this.btLocalizar.Location = new System.Drawing.Point(265, 96);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(128, 32);
            this.btLocalizar.TabIndex = 0;
            this.btLocalizar.Text = "Localizar compra";
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // txtComCod
            // 
            this.txtComCod.Enabled = false;
            this.txtComCod.Location = new System.Drawing.Point(10, 25);
            this.txtComCod.Name = "txtComCod";
            this.txtComCod.Size = new System.Drawing.Size(50, 20);
            this.txtComCod.TabIndex = 2;
            // 
            // txtNomeFornecedor
            // 
            this.txtNomeFornecedor.Enabled = false;
            this.txtNomeFornecedor.Location = new System.Drawing.Point(69, 70);
            this.txtNomeFornecedor.Name = "txtNomeFornecedor";
            this.txtNomeFornecedor.Size = new System.Drawing.Size(326, 20);
            this.txtNomeFornecedor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome Forncedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Vencimento:";
            // 
            // txtNFiscal
            // 
            this.txtNFiscal.Enabled = false;
            this.txtNFiscal.Location = new System.Drawing.Point(184, 25);
            this.txtNFiscal.Name = "txtNFiscal";
            this.txtNFiscal.Size = new System.Drawing.Size(100, 20);
            this.txtNFiscal.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "N° Nota Fiscal:";
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.AllowUserToDeleteRows = false;
            this.dgvParcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcelas.GridColor = System.Drawing.SystemColors.Control;
            this.dgvParcelas.Location = new System.Drawing.Point(10, 134);
            this.dgvParcelas.MultiSelect = false;
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.ReadOnly = true;
            this.dgvParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParcelas.Size = new System.Drawing.Size(384, 297);
            this.dgvParcelas.TabIndex = 9;
            this.dgvParcelas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParcelas_CellClick);
            // 
            // btPagarParcela
            // 
            this.btPagarParcela.Enabled = false;
            this.btPagarParcela.Location = new System.Drawing.Point(318, 437);
            this.btPagarParcela.Name = "btPagarParcela";
            this.btPagarParcela.Size = new System.Drawing.Size(75, 36);
            this.btPagarParcela.TabIndex = 10;
            this.btPagarParcela.Text = "Pagar";
            this.btPagarParcela.UseVisualStyleBackColor = true;
            this.btPagarParcela.Click += new System.EventHandler(this.btPagarParcela_Click);
            // 
            // btCancelaPagto
            // 
            this.btCancelaPagto.Location = new System.Drawing.Point(10, 437);
            this.btCancelaPagto.Name = "btCancelaPagto";
            this.btCancelaPagto.Size = new System.Drawing.Size(176, 23);
            this.btCancelaPagto.TabIndex = 11;
            this.btCancelaPagto.Text = "Cancelar Pagamento";
            this.btCancelaPagto.UseVisualStyleBackColor = true;
            this.btCancelaPagto.Visible = false;
            this.btCancelaPagto.Click += new System.EventHandler(this.btCancelaPagto_Click);
            // 
            // dtDataCompra
            // 
            this.dtDataCompra.Enabled = false;
            this.dtDataCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataCompra.Location = new System.Drawing.Point(74, 25);
            this.dtDataCompra.Name = "dtDataCompra";
            this.dtDataCompra.Size = new System.Drawing.Size(96, 20);
            this.dtDataCompra.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Parcelas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Valor da Compra:";
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.Enabled = false;
            this.txtTotalCompra.Location = new System.Drawing.Point(295, 25);
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCompra.TabIndex = 8;
            // 
            // txtForCod
            // 
            this.txtForCod.Enabled = false;
            this.txtForCod.Location = new System.Drawing.Point(11, 69);
            this.txtForCod.Name = "txtForCod";
            this.txtForCod.Size = new System.Drawing.Size(50, 20);
            this.txtForCod.TabIndex = 2;
            // 
            // dtDataPagamento
            // 
            this.dtDataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataPagamento.Location = new System.Drawing.Point(207, 453);
            this.dtDataPagamento.Name = "dtDataPagamento";
            this.dtDataPagamento.Size = new System.Drawing.Size(105, 20);
            this.dtDataPagamento.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Data do pagamento:";
            // 
            // frmPagamentoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 498);
            this.Controls.Add(this.dtDataPagamento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtDataCompra);
            this.Controls.Add(this.btCancelaPagto);
            this.Controls.Add(this.btPagarParcela);
            this.Controls.Add(this.dgvParcelas);
            this.Controls.Add(this.txtTotalCompra);
            this.Controls.Add(this.txtNFiscal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeFornecedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtForCod);
            this.Controls.Add(this.txtComCod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLocalizar);
            this.Name = "frmPagamentoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento de Compra";
            this.Load += new System.EventHandler(this.frmPagamentoCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComCod;
        private System.Windows.Forms.TextBox txtNomeFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNFiscal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvParcelas;
        private System.Windows.Forms.Button btPagarParcela;
        private System.Windows.Forms.Button btCancelaPagto;
        private System.Windows.Forms.DateTimePicker dtDataCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalCompra;
        private System.Windows.Forms.TextBox txtForCod;
        private System.Windows.Forms.DateTimePicker dtDataPagamento;
        private System.Windows.Forms.Label label7;
    }
}