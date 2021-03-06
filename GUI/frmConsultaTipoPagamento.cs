﻿using System;
using System.Windows.Forms;
using BLL;
using DAL;


namespace GUI
{
    public partial class frmConsultaTipoPagamento : Form
    {
        //serve para determinar se foi selecionado alguma linha de catagoria no datagridview
        public int codigo = 0;//aula 10

        public frmConsultaTipoPagamento()
        {
            InitializeComponent();
        }

        //===============================================================================================================================
        private void frmConsultaTipoPagamento_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e); //manda executar a ação do click do botão localizar

            dgvDados.Columns[0].HeaderText = "Código";//renomeia a coluna do datagridview
            dgvDados.Columns[0].Width = 70; // configura a largura da coluna
            dgvDados.Columns[1].HeaderText = "Tipo de Pagamento"; //renomeia a coluna do datagridview
            dgvDados.Columns[1].Width = 495; // configura a largura da coluna
        }

        //===============================================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            //faz uma consula no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão
            //bll possui os metodos para incluir e alterar
            BLLTipoPagamento bll = new BLLTipoPagamento(cx);
            //indicar a fonte dos dados para o datagridview
            dgvDados.DataSource = bll.Localizar(txtValor.Text);//o metodo localizar, retorna uma datatable, que é carregada no datagridview
        }

        //===============================================================================================================================
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //verifica a linha se é maior ou igual a que zero, indicando que alguma linha foi selecionada
            if (e.RowIndex >= 0)
            {
                //guarda o valor da celula 0, da linha selecionada no datagridview, convertendo o valor para inteiro
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
