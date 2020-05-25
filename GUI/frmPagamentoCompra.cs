using BLL;
using DAL;
using Modelo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmPagamentoCompra : Form
    {
        //serve para capturar o codigo selecionado alguma linha no datagridview
        public int pcoCod = 0;

        public frmPagamentoCompra()
        {
            InitializeComponent();
        }

        private void frmPagamentoCompra_Load(object sender, EventArgs e)
        {
            //AtualizaCabecalhoDGGridParcelas();
        }

        //METODO FORMATA GRID PARCELAS =================================================================================================================
        public void AtualizaCabecalhoDGGridParcelas() // https://youtu.be/vhfQkJ2pN80?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=822
        {
            try
            {
                //para ajustar a ordem das colunas basta ajustar o select:
                dgvParcelas.Columns[0].HeaderText = "Código";//renomeia a coluna do datagridview
                dgvParcelas.Columns[0].Width = 50; // configura a largura da coluna
                dgvParcelas.Columns[1].HeaderText = "Valor";
                dgvParcelas.Columns[1].Width = 80;
                dgvParcelas.Columns[2].HeaderText = "Pagamento";
                dgvParcelas.Columns[2].Width = 80;
                dgvParcelas.Columns[3].HeaderText = "Vencimento";
                dgvParcelas.Columns[3].Width = 80;
                dgvParcelas.Columns[4].HeaderText = "Compra";
                dgvParcelas.Columns[4].Width = 50;
                dgvParcelas.Columns[4].Visible = false;
            }
            catch
            {
            }

        }

        //localisar compra para carregar na tela:
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            //criar objeto da conexao:
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

            //exiber o formulario de consulta compra:
            frmConsultaCompra f = new frmConsultaCompra();
            f.ShowDialog();
            try
            {
                //verificar se tem um codigo carregado:{diferente de zero}
                if (f.codigo != 0)
                {
                    //cRIAR O bll:
                    BLLCompra bll = new BLLCompra(cx);
                    ModeloCompra modelo = bll.CarregaModeloCompra(f.codigo);//carrega o modelo da comprea pelo codigo

                    //--------------------------------------------------------------------------------------------------------
                    //  CARREGAR OS DADOS DA COMPRA
                    //--------------------------------------------------------------------------------------------------------
                    txtComCod.Text = modelo.ComCod.ToString();
                    txtNFiscal.Text = modelo.ComNfiscal.ToString();
                    dtDataCompra.Value = modelo.ComData;
                    txtForCod.Text = modelo.ForCod.ToString();
                    txtTotalCompra.Text = modelo.ComValorTotal.ToString();//VALOR TOTAL

                    //Carregar Nome do Fornecedor
                    BLLFornecedor bllf = new BLLFornecedor(cx);
                    ModeloFornecedor modelof = bllf.CarregaModeloFornecedor(Convert.ToInt32(txtForCod.Text));
                    //passar os valores do campo nome:
                    txtNomeFornecedor.Text = modelof.ForNome;         

                    //-----------------------------------------------------------------------------------------------------------------------------------
                    //CARREGAR PARCELAS DA COMPRA:
                    //-----------------------------------------------------------------------------------------------------------------------------------
                    BLLParcelasCompra bllParcelas = new BLLParcelasCompra(cx);
                    //localizar parcelas pelo codigo da compra:
                    dgvParcelas.DataSource = bllParcelas.Localizar(modelo.ComCod);

                    //FORMATAR CABECALHO DAS COLUNAS:
                    AtualizaCabecalhoDGGridParcelas();
                }
            }
            catch (Exception erro) // casa der algum erro na conexao
            {
                MessageBox.Show("Erro : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario
            }

        }

        //ao clicar na linha ja guarda o cogido da parcela: https://youtu.be/6RAAHztqGQc?t=1298
        private void dgvParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ocultar o botão de pagamento:
            btCancelaPagto.Visible = false;
            //desativa o botão pagar:
            btPagarParcela.Enabled = false;            

            //guarda o codigo da parcela, da linha selecionada no datagridview, convertendo o valor para inteiro
            this.pcoCod = Convert.ToInt32(dgvParcelas.Rows[e.RowIndex].Cells[0].Value);

            //verifica se clicou em alguma linha, e nesta linha a coluna datapagto esta vazia
            if (e.RowIndex >= 0 && dgvParcelas.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
            {
                //se sim...
                //ativa o botão:
                btPagarParcela.Enabled = true;              
            }
            else
            {
                //ocultar o botão de pagamento:
                btCancelaPagto.Visible = true;

                //desativa o botão pagar:
                btPagarParcela.Enabled = false;
            }
        }

        //BOTÃO PAGAR PARCELA: =====================================================================================================================
        private void btPagarParcela_Click(object sender, EventArgs e)
        {
            try
            {
                //criar objeto da conexao:
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLParcelasCompra bllp = new BLLParcelasCompra(cx);

                //codigo da compra:
                int comcod = Convert.ToInt32(txtComCod.Text);
                //---this.pcoCod = é capturado co clicar na linha

                //chama o metodo par afetur o pagamento:
                bllp.EfetuarPagamento(comcod, this.pcoCod, dtDataPagamento.Value.Date);

                //RECARREGAR PARCELAS DA COMPRA MOSTRA A DATA:
                dgvParcelas.DataSource = bllp.Localizar(comcod);

                //desativa o botão pagar:
                btPagarParcela.Enabled = false;

                //colocar a data atual na tela:
                dtDataPagamento.Value = DateTime.Now;

                //Mensagem de sucesso:
                MessageBox.Show("Pagamento efetuado com sucesso!");

            }
            catch (Exception erro) // casa der algum erro na conexao
            {
                MessageBox.Show("Erro : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario
            }
        }

        //BOTÃO CANCELAR O PAGAMENTO DE PARCELA: ===================================================================================================
        private void btCancelaPagto_Click(object sender, EventArgs e)
        {
            try
            {
                //criar objeto da conexao:
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLParcelasCompra bllp = new BLLParcelasCompra(cx);

                //codigo da compra:
                int comcod = Convert.ToInt32(txtComCod.Text);
                //---this.pcoCod = é capturado co clicar na linha

                //chama o metodo par afetur o pagamento:
                bllp.CancelarPagamento(comcod, this.pcoCod, dtDataPagamento.Value.Date);

                //RECARREGAR PARCELAS DA COMPRA MOSTRA A DATA:
                dgvParcelas.DataSource = bllp.Localizar(comcod);

                //desativa o botão pagar:
                btCancelaPagto.Visible = false;

                //colocar a data atual na tela:
                dtDataPagamento.Value = DateTime.Now;

                //Mensagem de sucesso:
                MessageBox.Show("Pagamento cancelado com sucesso!");

            }
            catch (Exception erro) // casa der algum erro na conexao
            {
                MessageBox.Show("Erro : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario
            }
        }
    }
}
