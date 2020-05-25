namespace GUI
{
    partial class frmConsultaCompra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbGeral = new System.Windows.Forms.RadioButton();
            this.rbParcelas = new System.Windows.Forms.RadioButton();
            this.rbData = new System.Windows.Forms.RadioButton();
            this.rbFornecedor = new System.Windows.Forms.RadioButton();
            this.dgvDadosCompra = new System.Windows.Forms.DataGridView();
            this.tpgTipoConsulta = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbNomeFornecedor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btLocFornecedor = new System.Windows.Forms.Button();
            this.txtForCod = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btLocData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btLocParcelas = new System.Windows.Forms.Button();
            this.rbParcelasEmAberto = new System.Windows.Forms.RadioButton();
            this.rbParcelasPagas = new System.Windows.Forms.RadioButton();
            this.tbcItensCompra = new System.Windows.Forms.TabControl();
            this.tpCompra = new System.Windows.Forms.TabPage();
            this.tpItens = new System.Windows.Forms.TabPage();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.peParcelas = new System.Windows.Forms.TabPage();
            this.dgvParcelas = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDadosCompra)).BeginInit();
            this.tpgTipoConsulta.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tbcItensCompra.SuspendLayout();
            this.tpCompra.SuspendLayout();
            this.tpItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.peParcelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.rbGeral);
            this.groupBox1.Controls.Add(this.rbParcelas);
            this.groupBox1.Controls.Add(this.rbData);
            this.groupBox1.Controls.Add(this.rbFornecedor);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 56);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar por";
            // 
            // rbGeral
            // 
            this.rbGeral.AutoSize = true;
            this.rbGeral.Checked = true;
            this.rbGeral.Location = new System.Drawing.Point(15, 22);
            this.rbGeral.Name = "rbGeral";
            this.rbGeral.Size = new System.Drawing.Size(112, 17);
            this.rbGeral.TabIndex = 0;
            this.rbGeral.TabStop = true;
            this.rbGeral.Text = "Todas as compras";
            this.rbGeral.UseVisualStyleBackColor = true;
            this.rbGeral.CheckedChanged += new System.EventHandler(this.rbGeral_CheckedChanged);
            // 
            // rbParcelas
            // 
            this.rbParcelas.AutoSize = true;
            this.rbParcelas.Location = new System.Drawing.Point(362, 22);
            this.rbParcelas.Name = "rbParcelas";
            this.rbParcelas.Size = new System.Drawing.Size(117, 17);
            this.rbParcelas.TabIndex = 0;
            this.rbParcelas.Text = "Parcelas Em aberto";
            this.rbParcelas.UseVisualStyleBackColor = true;
            this.rbParcelas.CheckedChanged += new System.EventHandler(this.rbParcelas_CheckedChanged);
            // 
            // rbData
            // 
            this.rbData.AutoSize = true;
            this.rbData.Location = new System.Drawing.Point(242, 22);
            this.rbData.Name = "rbData";
            this.rbData.Size = new System.Drawing.Size(102, 17);
            this.rbData.TabIndex = 0;
            this.rbData.Text = "Data da Compra";
            this.rbData.UseVisualStyleBackColor = true;
            this.rbData.CheckedChanged += new System.EventHandler(this.rbData_CheckedChanged);
            // 
            // rbFornecedor
            // 
            this.rbFornecedor.AutoSize = true;
            this.rbFornecedor.Location = new System.Drawing.Point(145, 22);
            this.rbFornecedor.Name = "rbFornecedor";
            this.rbFornecedor.Size = new System.Drawing.Size(79, 17);
            this.rbFornecedor.TabIndex = 0;
            this.rbFornecedor.Text = "Fornecedor";
            this.rbFornecedor.UseVisualStyleBackColor = true;
            this.rbFornecedor.CheckedChanged += new System.EventHandler(this.rbFornecedor_CheckedChanged);
            // 
            // dgvDadosCompra
            // 
            this.dgvDadosCompra.AllowUserToAddRows = false;
            this.dgvDadosCompra.AllowUserToDeleteRows = false;
            this.dgvDadosCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDadosCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDadosCompra.Location = new System.Drawing.Point(6, 5);
            this.dgvDadosCompra.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDadosCompra.Name = "dgvDadosCompra";
            this.dgvDadosCompra.ReadOnly = true;
            this.dgvDadosCompra.RowTemplate.Height = 24;
            this.dgvDadosCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDadosCompra.Size = new System.Drawing.Size(490, 384);
            this.dgvDadosCompra.TabIndex = 35;
            this.dgvDadosCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDadosCompra_CellClick);
            this.dgvDadosCompra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDadosCompra_CellDoubleClick);
            // 
            // tpgTipoConsulta
            // 
            this.tpgTipoConsulta.Controls.Add(this.tabPage1);
            this.tpgTipoConsulta.Controls.Add(this.tabPage2);
            this.tpgTipoConsulta.Controls.Add(this.tabPage3);
            this.tpgTipoConsulta.Controls.Add(this.tabPage4);
            this.tpgTipoConsulta.Enabled = false;
            this.tpgTipoConsulta.Location = new System.Drawing.Point(12, 68);
            this.tpgTipoConsulta.Name = "tpgTipoConsulta";
            this.tpgTipoConsulta.SelectedIndex = 0;
            this.tpgTipoConsulta.Size = new System.Drawing.Size(507, 101);
            this.tpgTipoConsulta.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(499, 75);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Todas as compras";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lbNomeFornecedor);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btLocFornecedor);
            this.tabPage2.Controls.Add(this.txtForCod);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(499, 75);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta por fornecedor";
            // 
            // lbNomeFornecedor
            // 
            this.lbNomeFornecedor.ForeColor = System.Drawing.Color.Blue;
            this.lbNomeFornecedor.Location = new System.Drawing.Point(7, 52);
            this.lbNomeFornecedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNomeFornecedor.Name = "lbNomeFornecedor";
            this.lbNomeFornecedor.Size = new System.Drawing.Size(487, 18);
            this.lbNomeFornecedor.TabIndex = 45;
            this.lbNomeFornecedor.Text = "Clique em localizar";
            this.lbNomeFornecedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Código";
            // 
            // btLocFornecedor
            // 
            this.btLocFornecedor.BackColor = System.Drawing.SystemColors.Control;
            this.btLocFornecedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLocFornecedor.Location = new System.Drawing.Point(67, 26);
            this.btLocFornecedor.Margin = new System.Windows.Forms.Padding(2);
            this.btLocFornecedor.Name = "btLocFornecedor";
            this.btLocFornecedor.Size = new System.Drawing.Size(132, 24);
            this.btLocFornecedor.TabIndex = 44;
            this.btLocFornecedor.Text = "Localizar Fornecedor";
            this.btLocFornecedor.UseVisualStyleBackColor = false;
            this.btLocFornecedor.Click += new System.EventHandler(this.btLocFornecedor_Click);
            // 
            // txtForCod
            // 
            this.txtForCod.Enabled = false;
            this.txtForCod.Location = new System.Drawing.Point(7, 28);
            this.txtForCod.Margin = new System.Windows.Forms.Padding(2);
            this.txtForCod.Name = "txtForCod";
            this.txtForCod.Size = new System.Drawing.Size(56, 20);
            this.txtForCod.TabIndex = 43;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btLocData);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dateTimePicker2);
            this.tabPage3.Controls.Add(this.dateTimePicker1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(499, 75);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Consultar por data";
            // 
            // btLocData
            // 
            this.btLocData.BackColor = System.Drawing.SystemColors.Control;
            this.btLocData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLocData.Location = new System.Drawing.Point(214, 24);
            this.btLocData.Margin = new System.Windows.Forms.Padding(2);
            this.btLocData.Name = "btLocData";
            this.btLocData.Size = new System.Drawing.Size(132, 24);
            this.btLocData.TabIndex = 45;
            this.btLocData.Text = "Localizar";
            this.btLocData.UseVisualStyleBackColor = false;
            this.btLocData.Click += new System.EventHandler(this.btLocData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Data Final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Data Inicial:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(113, 28);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(11, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2018, 2, 4, 0, 0, 0, 0);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.btLocParcelas);
            this.tabPage4.Controls.Add(this.rbParcelasEmAberto);
            this.tabPage4.Controls.Add(this.rbParcelasPagas);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(499, 75);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Consultar por parcelas em aberto";
            // 
            // btLocParcelas
            // 
            this.btLocParcelas.BackColor = System.Drawing.SystemColors.Control;
            this.btLocParcelas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLocParcelas.Location = new System.Drawing.Point(270, 23);
            this.btLocParcelas.Margin = new System.Windows.Forms.Padding(2);
            this.btLocParcelas.Name = "btLocParcelas";
            this.btLocParcelas.Size = new System.Drawing.Size(132, 24);
            this.btLocParcelas.TabIndex = 46;
            this.btLocParcelas.Text = "Localizar";
            this.btLocParcelas.UseVisualStyleBackColor = false;
            this.btLocParcelas.Click += new System.EventHandler(this.btLocParcelas_Click);
            // 
            // rbParcelasEmAberto
            // 
            this.rbParcelasEmAberto.AutoSize = true;
            this.rbParcelasEmAberto.Checked = true;
            this.rbParcelasEmAberto.Location = new System.Drawing.Point(20, 27);
            this.rbParcelasEmAberto.Name = "rbParcelasEmAberto";
            this.rbParcelasEmAberto.Size = new System.Drawing.Size(117, 17);
            this.rbParcelasEmAberto.TabIndex = 2;
            this.rbParcelasEmAberto.TabStop = true;
            this.rbParcelasEmAberto.Text = "Parcelas Em aberto";
            this.rbParcelasEmAberto.UseVisualStyleBackColor = true;
            // 
            // rbParcelasPagas
            // 
            this.rbParcelasPagas.AutoSize = true;
            this.rbParcelasPagas.Location = new System.Drawing.Point(157, 27);
            this.rbParcelasPagas.Name = "rbParcelasPagas";
            this.rbParcelasPagas.Size = new System.Drawing.Size(99, 17);
            this.rbParcelasPagas.TabIndex = 1;
            this.rbParcelasPagas.Text = "Parcelas Pagas";
            this.rbParcelasPagas.UseVisualStyleBackColor = true;
            // 
            // tbcItensCompra
            // 
            this.tbcItensCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcItensCompra.Controls.Add(this.tpCompra);
            this.tbcItensCompra.Controls.Add(this.tpItens);
            this.tbcItensCompra.Controls.Add(this.peParcelas);
            this.tbcItensCompra.Location = new System.Drawing.Point(12, 175);
            this.tbcItensCompra.Name = "tbcItensCompra";
            this.tbcItensCompra.SelectedIndex = 0;
            this.tbcItensCompra.Size = new System.Drawing.Size(511, 420);
            this.tbcItensCompra.TabIndex = 39;
            // 
            // tpCompra
            // 
            this.tpCompra.BackColor = System.Drawing.SystemColors.Control;
            this.tpCompra.Controls.Add(this.dgvDadosCompra);
            this.tpCompra.Location = new System.Drawing.Point(4, 22);
            this.tpCompra.Name = "tpCompra";
            this.tpCompra.Padding = new System.Windows.Forms.Padding(3);
            this.tpCompra.Size = new System.Drawing.Size(503, 394);
            this.tpCompra.TabIndex = 0;
            this.tpCompra.Text = "Compra Selecionada";
            // 
            // tpItens
            // 
            this.tpItens.BackColor = System.Drawing.SystemColors.Control;
            this.tpItens.Controls.Add(this.dgvItens);
            this.tpItens.Location = new System.Drawing.Point(4, 22);
            this.tpItens.Name = "tpItens";
            this.tpItens.Padding = new System.Windows.Forms.Padding(3);
            this.tpItens.Size = new System.Drawing.Size(503, 394);
            this.tpItens.TabIndex = 1;
            this.tpItens.Text = "Itens da compra Selecionada";
            // 
            // dgvItens
            // 
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Location = new System.Drawing.Point(5, 7);
            this.dgvItens.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.RowTemplate.Height = 24;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(494, 384);
            this.dgvItens.TabIndex = 36;
            // 
            // peParcelas
            // 
            this.peParcelas.BackColor = System.Drawing.SystemColors.Control;
            this.peParcelas.Controls.Add(this.dgvParcelas);
            this.peParcelas.Location = new System.Drawing.Point(4, 22);
            this.peParcelas.Name = "peParcelas";
            this.peParcelas.Padding = new System.Windows.Forms.Padding(3);
            this.peParcelas.Size = new System.Drawing.Size(503, 394);
            this.peParcelas.TabIndex = 2;
            this.peParcelas.Text = "Parcelas da compra Selecionada";
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.AllowUserToDeleteRows = false;
            this.dgvParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcelas.Location = new System.Drawing.Point(5, 7);
            this.dgvParcelas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.ReadOnly = true;
            this.dgvParcelas.RowTemplate.Height = 24;
            this.dgvParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParcelas.Size = new System.Drawing.Size(494, 384);
            this.dgvParcelas.TabIndex = 36;
            // 
            // frmConsultaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(528, 599);
            this.Controls.Add(this.tbcItensCompra);
            this.Controls.Add(this.tpgTipoConsulta);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsultaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localiza Compra";
            this.Load += new System.EventHandler(this.frmConsultaCompra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDadosCompra)).EndInit();
            this.tpgTipoConsulta.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tbcItensCompra.ResumeLayout(false);
            this.tpCompra.ResumeLayout(false);
            this.tpItens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.peParcelas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGeral;
        private System.Windows.Forms.RadioButton rbParcelas;
        private System.Windows.Forms.RadioButton rbData;
        private System.Windows.Forms.RadioButton rbFornecedor;
        private System.Windows.Forms.DataGridView dgvDadosCompra;
        private System.Windows.Forms.TabControl tpgTipoConsulta;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbNomeFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btLocFornecedor;
        private System.Windows.Forms.TextBox txtForCod;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btLocData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rbParcelasEmAberto;
        private System.Windows.Forms.RadioButton rbParcelasPagas;
        private System.Windows.Forms.Button btLocParcelas;
        private System.Windows.Forms.TabControl tbcItensCompra;
        private System.Windows.Forms.TabPage tpCompra;
        private System.Windows.Forms.TabPage tpItens;
        private System.Windows.Forms.TabPage peParcelas;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.DataGridView dgvParcelas;
    }
}