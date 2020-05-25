namespace GUI
{
    partial class frmMovimentacaoCompra
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtForCod = new System.Windows.Forms.TextBox();
            this.txtComCod = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDataCompra = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.proCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proVUnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proVTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNFiscal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btLocFor = new System.Windows.Forms.Button();
            this.lbNomeFornecedor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDataIniPgt = new System.Windows.Forms.DateTimePicker();
            this.txtTotalCompra = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btLocProd = new System.Windows.Forms.Button();
            this.txtProdCod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbProduto = new System.Windows.Forms.Label();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValorUnit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbNParcela = new System.Windows.Forms.ComboBox();
            this.cbTPagto = new System.Windows.Forms.ComboBox();
            this.btAddProd = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.pnFinalizaCompra = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbValorTotal = new System.Windows.Forms.Label();
            this.btCancelarFechamento = new System.Windows.Forms.Button();
            this.btSalvarCompra = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvParcelas = new System.Windows.Forms.DataGridView();
            this.pco_Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcoDataVecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.pnFinalizaCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.label12);
            this.pnDados.Controls.Add(this.btAddProd);
            this.pnDados.Controls.Add(this.cbTPagto);
            this.pnDados.Controls.Add(this.cbNParcela);
            this.pnDados.Controls.Add(this.txtValorUnit);
            this.pnDados.Controls.Add(this.label11);
            this.pnDados.Controls.Add(this.txtQtd);
            this.pnDados.Controls.Add(this.label10);
            this.pnDados.Controls.Add(this.lbProduto);
            this.pnDados.Controls.Add(this.btLocProd);
            this.pnDados.Controls.Add(this.txtProdCod);
            this.pnDados.Controls.Add(this.label9);
            this.pnDados.Controls.Add(this.label4);
            this.pnDados.Controls.Add(this.txtTotalCompra);
            this.pnDados.Controls.Add(this.label8);
            this.pnDados.Controls.Add(this.label7);
            this.pnDados.Controls.Add(this.dtDataIniPgt);
            this.pnDados.Controls.Add(this.label6);
            this.pnDados.Controls.Add(this.label5);
            this.pnDados.Controls.Add(this.lbNomeFornecedor);
            this.pnDados.Controls.Add(this.btLocFor);
            this.pnDados.Controls.Add(this.txtNFiscal);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Controls.Add(this.dgvItens);
            this.pnDados.Controls.Add(this.label2);
            this.pnDados.Controls.Add(this.dtDataCompra);
            this.pnDados.Controls.Add(this.txtForCod);
            this.pnDados.Controls.Add(this.txtComCod);
            this.pnDados.Controls.Add(this.lbNome);
            this.pnDados.Controls.Add(this.label1);
            this.pnDados.Size = new System.Drawing.Size(560, 423);
            // 
            // pnBotoes
            // 
            this.pnBotoes.Location = new System.Drawing.Point(12, 441);
            // 
            // btCancelar
            // 
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btInserir
            // 
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // txtForCod
            // 
            this.txtForCod.Location = new System.Drawing.Point(13, 67);
            this.txtForCod.Margin = new System.Windows.Forms.Padding(2);
            this.txtForCod.Name = "txtForCod";
            this.txtForCod.Size = new System.Drawing.Size(113, 20);
            this.txtForCod.TabIndex = 33;
            this.txtForCod.Leave += new System.EventHandler(this.txtForCod_Leave);
            // 
            // txtComCod
            // 
            this.txtComCod.Enabled = false;
            this.txtComCod.Location = new System.Drawing.Point(15, 23);
            this.txtComCod.Margin = new System.Windows.Forms.Padding(2);
            this.txtComCod.Name = "txtComCod";
            this.txtComCod.Size = new System.Drawing.Size(58, 20);
            this.txtComCod.TabIndex = 32;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(14, 50);
            this.lbNome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(112, 13);
            this.lbNome.TabIndex = 31;
            this.lbNome.Text = "Codigo do Fornecedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Código";
            // 
            // dtDataCompra
            // 
            this.dtDataCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataCompra.Location = new System.Drawing.Point(345, 23);
            this.dtDataCompra.Name = "dtDataCompra";
            this.dtDataCompra.Size = new System.Drawing.Size(105, 20);
            this.dtDataCompra.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Data da compra";
            // 
            // dgvItens
            // 
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proCod,
            this.pro_Nome,
            this.proQtd,
            this.proVUnd,
            this.proVTotal});
            this.dgvItens.Location = new System.Drawing.Point(15, 207);
            this.dgvItens.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.RowTemplate.Height = 24;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(532, 149);
            this.dgvItens.TabIndex = 36;
            this.dgvItens.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItens_CellDoubleClick);
            // 
            // proCod
            // 
            this.proCod.HeaderText = "Código";
            this.proCod.Name = "proCod";
            this.proCod.ReadOnly = true;
            this.proCod.Width = 50;
            // 
            // pro_Nome
            // 
            this.pro_Nome.HeaderText = "Nome";
            this.pro_Nome.Name = "pro_Nome";
            this.pro_Nome.ReadOnly = true;
            this.pro_Nome.Width = 200;
            // 
            // proQtd
            // 
            this.proQtd.HeaderText = "Qtd.";
            this.proQtd.Name = "proQtd";
            this.proQtd.ReadOnly = true;
            this.proQtd.Width = 70;
            // 
            // proVUnd
            // 
            this.proVUnd.HeaderText = "Valor unitario";
            this.proVUnd.Name = "proVUnd";
            this.proVUnd.ReadOnly = true;
            this.proVUnd.Width = 70;
            // 
            // proVTotal
            // 
            this.proVTotal.HeaderText = "Valor total";
            this.proVTotal.Name = "proVTotal";
            this.proVTotal.ReadOnly = true;
            this.proVTotal.Width = 70;
            // 
            // txtNFiscal
            // 
            this.txtNFiscal.Location = new System.Drawing.Point(86, 23);
            this.txtNFiscal.Margin = new System.Windows.Forms.Padding(2);
            this.txtNFiscal.Name = "txtNFiscal";
            this.txtNFiscal.Size = new System.Drawing.Size(232, 20);
            this.txtNFiscal.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "N° da Nota Fiscal ";
            // 
            // btLocFor
            // 
            this.btLocFor.Location = new System.Drawing.Point(130, 64);
            this.btLocFor.Margin = new System.Windows.Forms.Padding(2);
            this.btLocFor.Name = "btLocFor";
            this.btLocFor.Size = new System.Drawing.Size(66, 24);
            this.btLocFor.TabIndex = 39;
            this.btLocFor.Text = "Localizar";
            this.btLocFor.UseVisualStyleBackColor = true;
            this.btLocFor.Click += new System.EventHandler(this.btLocFor_Click);
            // 
            // lbNomeFornecedor
            // 
            this.lbNomeFornecedor.ForeColor = System.Drawing.Color.Blue;
            this.lbNomeFornecedor.Location = new System.Drawing.Point(204, 66);
            this.lbNomeFornecedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNomeFornecedor.Name = "lbNomeFornecedor";
            this.lbNomeFornecedor.Size = new System.Drawing.Size(338, 17);
            this.lbNomeFornecedor.TabIndex = 40;
            this.lbNomeFornecedor.Text = "Informe o código do fornecedor ou clique em localizar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 370);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "N° Percelas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 370);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Tipo de pagamento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 372);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Data Iniciao do pagto";
            // 
            // dtDataIniPgt
            // 
            this.dtDataIniPgt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataIniPgt.Location = new System.Drawing.Point(235, 390);
            this.dtDataIniPgt.Name = "dtDataIniPgt";
            this.dtDataIniPgt.Size = new System.Drawing.Size(105, 20);
            this.dtDataIniPgt.TabIndex = 45;
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.Location = new System.Drawing.Point(442, 390);
            this.txtTotalCompra.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.Size = new System.Drawing.Size(85, 20);
            this.txtTotalCompra.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Cyan;
            this.label8.Location = new System.Drawing.Point(444, 372);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(529, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "_________________________________________________________________________________" +
    "______";
            // 
            // btLocProd
            // 
            this.btLocProd.Location = new System.Drawing.Point(131, 143);
            this.btLocProd.Margin = new System.Windows.Forms.Padding(2);
            this.btLocProd.Name = "btLocProd";
            this.btLocProd.Size = new System.Drawing.Size(66, 20);
            this.btLocProd.TabIndex = 52;
            this.btLocProd.Text = "Localizar";
            this.btLocProd.UseVisualStyleBackColor = true;
            this.btLocProd.Click += new System.EventHandler(this.btLocProd_Click);
            // 
            // txtProdCod
            // 
            this.txtProdCod.Location = new System.Drawing.Point(14, 143);
            this.txtProdCod.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdCod.Name = "txtProdCod";
            this.txtProdCod.Size = new System.Drawing.Size(113, 20);
            this.txtProdCod.TabIndex = 51;
            this.txtProdCod.Leave += new System.EventHandler(this.txtProdCod_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 126);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Codigo do Produto";
            // 
            // lbProduto
            // 
            this.lbProduto.ForeColor = System.Drawing.Color.Blue;
            this.lbProduto.Location = new System.Drawing.Point(14, 165);
            this.lbProduto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbProduto.Name = "lbProduto";
            this.lbProduto.Size = new System.Drawing.Size(338, 17);
            this.lbProduto.TabIndex = 53;
            this.lbProduto.Text = "Informe o código do produto ou clique em localizar";
            // 
            // txtQtd
            // 
            this.txtQtd.Location = new System.Drawing.Point(314, 143);
            this.txtQtd.Margin = new System.Windows.Forms.Padding(2);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(63, 20);
            this.txtQtd.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Cyan;
            this.label10.Location = new System.Drawing.Point(315, 126);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Quantidade";
            // 
            // txtValorUnit
            // 
            this.txtValorUnit.Location = new System.Drawing.Point(383, 143);
            this.txtValorUnit.Margin = new System.Windows.Forms.Padding(2);
            this.txtValorUnit.Name = "txtValorUnit";
            this.txtValorUnit.Size = new System.Drawing.Size(69, 20);
            this.txtValorUnit.TabIndex = 57;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Cyan;
            this.label11.Location = new System.Drawing.Point(384, 126);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Valor unitario";
            // 
            // cbNParcela
            // 
            this.cbNParcela.FormattingEnabled = true;
            this.cbNParcela.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbNParcela.Location = new System.Drawing.Point(13, 389);
            this.cbNParcela.Name = "cbNParcela";
            this.cbNParcela.Size = new System.Drawing.Size(80, 21);
            this.cbNParcela.TabIndex = 58;
            // 
            // cbTPagto
            // 
            this.cbTPagto.FormattingEnabled = true;
            this.cbTPagto.Location = new System.Drawing.Point(99, 389);
            this.cbTPagto.Name = "cbTPagto";
            this.cbTPagto.Size = new System.Drawing.Size(121, 21);
            this.cbTPagto.TabIndex = 59;
            // 
            // btAddProd
            // 
            this.btAddProd.Location = new System.Drawing.Point(460, 126);
            this.btAddProd.Margin = new System.Windows.Forms.Padding(2);
            this.btAddProd.Name = "btAddProd";
            this.btAddProd.Size = new System.Drawing.Size(67, 36);
            this.btAddProd.TabIndex = 60;
            this.btAddProd.Text = "Add";
            this.btAddProd.UseVisualStyleBackColor = true;
            this.btAddProd.Click += new System.EventHandler(this.btAddProd_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 190);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "Itens da Compra (Aula 80)";
            // 
            // pnFinalizaCompra
            // 
            this.pnFinalizaCompra.Controls.Add(this.lbTotal);
            this.pnFinalizaCompra.Controls.Add(this.lbValorTotal);
            this.pnFinalizaCompra.Controls.Add(this.btCancelarFechamento);
            this.pnFinalizaCompra.Controls.Add(this.btSalvarCompra);
            this.pnFinalizaCompra.Controls.Add(this.label15);
            this.pnFinalizaCompra.Controls.Add(this.label14);
            this.pnFinalizaCompra.Controls.Add(this.label13);
            this.pnFinalizaCompra.Controls.Add(this.dgvParcelas);
            this.pnFinalizaCompra.Location = new System.Drawing.Point(580, 12);
            this.pnFinalizaCompra.Name = "pnFinalizaCompra";
            this.pnFinalizaCompra.Size = new System.Drawing.Size(560, 519);
            this.pnFinalizaCompra.TabIndex = 2;
            this.pnFinalizaCompra.Visible = false;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.ForeColor = System.Drawing.Color.Red;
            this.lbTotal.Location = new System.Drawing.Point(392, 392);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(107, 13);
            this.lbTotal.TabIndex = 56;
            this.lbTotal.Text = "Valor total da compra";
            // 
            // lbValorTotal
            // 
            this.lbValorTotal.AutoSize = true;
            this.lbValorTotal.ForeColor = System.Drawing.Color.Red;
            this.lbValorTotal.Location = new System.Drawing.Point(515, 392);
            this.lbValorTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbValorTotal.Name = "lbValorTotal";
            this.lbValorTotal.Size = new System.Drawing.Size(28, 13);
            this.lbValorTotal.TabIndex = 55;
            this.lbValorTotal.Text = "0,00";
            // 
            // btCancelarFechamento
            // 
            this.btCancelarFechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelarFechamento.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btCancelarFechamento.Image = global::GUI.Properties.Resources.Cancelar;
            this.btCancelarFechamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelarFechamento.Location = new System.Drawing.Point(473, 427);
            this.btCancelarFechamento.Name = "btCancelarFechamento";
            this.btCancelarFechamento.Size = new System.Drawing.Size(70, 85);
            this.btCancelarFechamento.TabIndex = 54;
            this.btCancelarFechamento.Text = "Cancelar";
            this.btCancelarFechamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelarFechamento.UseVisualStyleBackColor = true;
            this.btCancelarFechamento.Click += new System.EventHandler(this.btCancelarFechamento_Click);
            // 
            // btSalvarCompra
            // 
            this.btSalvarCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvarCompra.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btSalvarCompra.Image = global::GUI.Properties.Resources.Salvar1_fw;
            this.btSalvarCompra.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvarCompra.Location = new System.Drawing.Point(378, 427);
            this.btSalvarCompra.Name = "btSalvarCompra";
            this.btSalvarCompra.Size = new System.Drawing.Size(70, 85);
            this.btSalvarCompra.TabIndex = 53;
            this.btSalvarCompra.Text = "Salvar";
            this.btSalvarCompra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvarCompra.UseVisualStyleBackColor = true;
            this.btSalvarCompra.Click += new System.EventHandler(this.btSalvarCompra_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 33);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Parcelas da compra:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(171, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Fechamento da compra / Parcelas";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 14);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(547, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.AllowUserToDeleteRows = false;
            this.dgvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pco_Cod,
            this.pcoValor,
            this.pcoDataVecto});
            this.dgvParcelas.Location = new System.Drawing.Point(12, 49);
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.ReadOnly = true;
            this.dgvParcelas.Size = new System.Drawing.Size(531, 333);
            this.dgvParcelas.TabIndex = 0;
            // 
            // pco_Cod
            // 
            this.pco_Cod.HeaderText = "Parcela";
            this.pco_Cod.Name = "pco_Cod";
            this.pco_Cod.ReadOnly = true;
            // 
            // pcoValor
            // 
            this.pcoValor.HeaderText = "Valor da parcela";
            this.pcoValor.Name = "pcoValor";
            this.pcoValor.ReadOnly = true;
            // 
            // pcoDataVecto
            // 
            this.pcoDataVecto.HeaderText = "Data do vencimento";
            this.pcoDataVecto.Name = "pcoDataVecto";
            this.pcoDataVecto.ReadOnly = true;
            // 
            // frmMovimentacaoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1230, 536);
            this.Controls.Add(this.pnFinalizaCompra);
            this.Name = "frmMovimentacaoCompra";
            this.Text = "Movimentação de Compra";
            this.Load += new System.EventHandler(this.frmMovimentacaoCompra_Load);
            this.Controls.SetChildIndex(this.pnFinalizaCompra, 0);
            this.Controls.SetChildIndex(this.pnDados, 0);
            this.Controls.SetChildIndex(this.pnBotoes, 0);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.pnFinalizaCompra.ResumeLayout(false);
            this.pnFinalizaCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDataCompra;
        private System.Windows.Forms.TextBox txtForCod;
        private System.Windows.Forms.TextBox txtComCod;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNFiscal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.Label lbNomeFornecedor;
        private System.Windows.Forms.Button btLocFor;
        private System.Windows.Forms.TextBox txtTotalCompra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDataIniPgt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbProduto;
        private System.Windows.Forms.Button btLocProd;
        private System.Windows.Forms.TextBox txtProdCod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorUnit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTPagto;
        private System.Windows.Forms.ComboBox cbNParcela;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btAddProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn proCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn proQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn proVUnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn proVTotal;
        private System.Windows.Forms.Panel pnFinalizaCompra;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvParcelas;
        protected System.Windows.Forms.Button btCancelarFechamento;
        protected System.Windows.Forms.Button btSalvarCompra;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn pco_Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcoDataVecto;
    }
}
