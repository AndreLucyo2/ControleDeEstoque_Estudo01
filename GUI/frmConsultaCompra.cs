using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*///-------------------------------------------------------------------------------------------------------------------
   
    CONSULTA COMPRA SQL PARA VER COMPLETA:
    select * from compra where com_cod = '8'
    select * from itenscompra where com_cod = '8'
    select * from parcelascompra where com_cod = '8'

*///-------------------------------------------------------------------------------------------------------------------

namespace GUI
{
    public partial class frmConsultaCompra : Form
    {
        //serve para determinar se foi selecionado alguma linha no datagridview
        public int codigo = 0; // https://youtu.be/xRnknzm4dgg?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=151

        public frmConsultaCompra()
        {
            InitializeComponent();
        }

        private void frmConsultaCompra_Load(object sender, EventArgs e)
        {
            //inicia mostrando todas as compras
            rbGeral_CheckedChanged(sender, e);
        }

        //LOCALIZAR TODAS AS COMPRAS OPÇÃO ==========================================================================================================
        private void rbGeral_CheckedChanged(object sender, EventArgs e)
        {
            //limpara as datagrid:
            dgvDadosCompra.DataSource = null;
            dgvItens.DataSource = null;
            dgvParcelas.DataSource = null;

            //Mostra aba dos campos conforme tipo da pesquisa selecionada:
            MostrarTabPage(tpgTipoConsulta, tabPage1, true, true);

            //-----------------------------------------------------------------------------------------------------------------------------------
            //CARREGA TODAS AS COMPRAS:
            //-----------------------------------------------------------------------------------------------------------------------------------
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCompra bll = new BLLCompra(cx);
            dgvDadosCompra.DataSource = bll.Localizar();

            //Formatar a DataGrid:
            this.AtualizaCabecalhoDGGridCompra();

        }

        //LOCALIZAR POR COD DO FORNECEDPR BOTÃO =====================================================================================================
        private void btLocFornecedor_Click(object sender, EventArgs e)
        {
            FrmConsultaFornecedor f = new FrmConsultaFornecedor();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)//se diferente de Zero , quer dizer que encontrou um fornecedor
            {
                //passa o codigo para o campo da tela: https://youtu.be/FvZ9aZIoQX4?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1371
                txtForCod.Text = f.codigo.ToString();

                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);
                ModeloFornecedor modelo = bll.CarregaModeloFornecedor(f.codigo);
                lbNomeFornecedor.Text = "Nome do Fornecedor: " + modelo.ForNome; //mostra o nome do fornecedor

                BLLCompra bllCompra = new BLLCompra(cx); // https://youtu.be/6wS0qjvQPMk?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=771
                dgvDadosCompra.DataSource = bllCompra.Localizar(f.codigo);
                //destroi o formulario
                f.Dispose();

                ////Formatar a DataGrid:
                this.AtualizaCabecalhoDGGridCompra();
            }
            else
            {
                txtForCod.Text = "";
                lbNomeFornecedor.Text = "Para consultas por fornecedor, Clique em localizar";
            }
        }

        //LOCALIZAR POR COD DO FORNECEDOR OPÇÃO =====================================================================================================
        private void rbFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            //limpara a datagrid:
            //limpara as datagrid:
            dgvDadosCompra.DataSource = null;
            dgvItens.DataSource = null;
            dgvParcelas.DataSource = null;

            //Mostra aba dos campos conforme tipo da pesquisa selecionada:
            MostrarTabPage(tpgTipoConsulta, tabPage2, true, true);
        }

        //LOCALIZAR POR DATA BOTÃO ==================================================================================================================
        private void btLocData_Click(object sender, EventArgs e)
        {
            //pega as datas do intervalo:
            DateTime dtIni = dateTimePicker1.Value.Date;
            DateTime dtFim = dateTimePicker2.Value.Date;

            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCompra bll = new BLLCompra(cx);
            dgvDadosCompra.DataSource = bll.Localizar(dtIni,dtFim);

            //Formatar a DataGrid:
            this.AtualizaCabecalhoDGGridCompra();
        }

        //LOCALIZAR POR DATA OPÇÃO ==================================================================================================================
        private void rbData_CheckedChanged(object sender, EventArgs e)
        {
            //limpara as datagrid:
            dgvDadosCompra.DataSource = null;
            dgvItens.DataSource = null;
            dgvParcelas.DataSource = null;

            //Mostra aba dos campos conforme tipo da pesquisa selecionada:
            MostrarTabPage(tpgTipoConsulta, tabPage3, true, true);
        }
        
        //LOCALIZAR POR PARCELAS EM ABERTO OU PAGAS =================================================================================================
        private void rbParcelas_CheckedChanged(object sender, EventArgs e)
        {
            //limpara as datagrid:
            dgvDadosCompra.DataSource = null;
            dgvItens.DataSource = null;
            dgvParcelas.DataSource = null;

            //Mostra aba dos campos conforme tipo da pesquisa selecionada:
            MostrarTabPage(tpgTipoConsulta, tabPage4, true, true);
        }

        //LOCALIZAR POR PARCELAS EM ABERTO OU PAGAS =================================================================================================
        private void btLocParcelas_Click(object sender, EventArgs e)
        {
            //caso marcado pega somente parcelas em aberto:            
            bool PacAberto = rbParcelasEmAberto.Checked;

            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCompra bll = new BLLCompra(cx);
            dgvDadosCompra.DataSource = bll.LocalizarProParcelasEmAberto(PacAberto);

            //Formatar a DataGrid:
            this.AtualizaCabecalhoDGGridCompra();
        }

        //===========================================================================================================================================
        private void dgvDadosCompra_CellClick(object sender, DataGridViewCellEventArgs e) //Aula 105
        {
            //verifica se uma linha foi clicada:
            if(e.RowIndex >=0)
            {
                //CONEXÃO:
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

                //-----------------------------------------------------------------------------------------------------------------------------------
                //CARREGA OS ITENS DA COMPRA:
                //-----------------------------------------------------------------------------------------------------------------------------------
                BLLItensCompra bllItens = new BLLItensCompra(cx);
                //localizar itens pelo codigo da compra:
                dgvItens.DataSource = bllItens.Localizar(Convert.ToInt32(dgvDadosCompra.Rows[e.RowIndex].Cells[0].Value));

                //-----------------------------------------------------------------------------------------------------------------------------------
                //PARCELAS DA COMPRA:
                //-----------------------------------------------------------------------------------------------------------------------------------
                BLLParcelasCompra bllParcelas = new BLLParcelasCompra(cx);
                //localizar parcelas pelo codigo da compra:
                dgvParcelas.DataSource = bllParcelas.Localizar(Convert.ToInt32(dgvDadosCompra.Rows[e.RowIndex].Cells[0].Value));

                //Formatar a grid:
                AtualizaCabecalhoDGGridItens();
                AtualizaCabecalhoDGGridParcelas();

            }
        }

        //METODO CONTROLA ATIVAÇÃO DE PAGETAB =======================================================================================================
        private void MostrarTabPage(TabControl tabControl, TabPage tabPage, bool Visivel = false, bool ativo = false)
        {
            //Controla visibiliadde: inicial falso
            tabControl.Visible = Visivel;
            //Controla se esta ativo: inicial bloqueado
            tabControl.Enabled = ativo;
            //descobre o numero de abas
            int tab = tabControl.TabPages.Count;

            //laço pelo numero de abas:
            for (int c = 0; tab >= c; c++)
            {
                try
                {
                    //conta tab no instante:
                    int tab1 = tabControl.TabPages.Count;
                    tabControl.TabPages.RemoveAt(tab1 - 1);

                }
                catch
                {
                    //ao acultar todas, motra comente a indicada:
                    tabControl.TabPages.Add(tabPage);
                    //MessageBox.Show("Mostrar: " + tabPage);
                }

            }
        }

        //METODO FORMATA GRID COMPRAS ===============================================================================================================
        public void AtualizaCabecalhoDGGridCompra() // https://youtu.be/mucFZpUq3FY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=834
        {

            try
            {   
                //para ajustar a ordem das colunas basta ajustar o select:
                dgvDadosCompra.Columns[0].HeaderText = "Código Compra";//renomeia a coluna do datagridview
                dgvDadosCompra.Columns[0].Width = 50; // configura a largura da coluna
                dgvDadosCompra.Columns[1].HeaderText = "Data da Compra";
                dgvDadosCompra.Columns[1].Width = 80;
                dgvDadosCompra.Columns[2].HeaderText = "N° da NF";
                dgvDadosCompra.Columns[2].Width = 70;
                dgvDadosCompra.Columns[3].HeaderText = "Total";
                dgvDadosCompra.Columns[3].Width = 70;
                dgvDadosCompra.Columns[4].HeaderText = "N° de parcelas";
                dgvDadosCompra.Columns[4].Width = 50;
                dgvDadosCompra.Columns[5].HeaderText = "Status da Compra";
                dgvDadosCompra.Columns[5].Width = 70;
                dgvDadosCompra.Columns[5].Visible = false;
                dgvDadosCompra.Columns[6].HeaderText = "Codigo do Fornecedor";
                dgvDadosCompra.Columns[6].Width = 70;
                dgvDadosCompra.Columns[6].Visible = false;
                dgvDadosCompra.Columns[7].HeaderText = "Codigo do tipo de patamento";
                dgvDadosCompra.Columns[7].Width = 70;
                dgvDadosCompra.Columns[7].Visible = false;
                dgvDadosCompra.Columns[8].HeaderText = "Fornecedor";
                dgvDadosCompra.Columns[8].Width = 170;

            }
            catch
            {
            }
        }

        //METODO FORMATA GRID ITENS =================================================================================================================
        public void AtualizaCabecalhoDGGridItens() // https://youtu.be/vhfQkJ2pN80?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=822
        {
            try
            { 
                //para ajustar a ordem das colunas basta ajustar o select:
                dgvItens.Columns[0].HeaderText = "Compra";//renomeia a coluna do datagridview
                dgvItens.Columns[0].Width = 50; // configura a largura da coluna
                dgvItens.Columns[0].Visible = false;
                dgvItens.Columns[1].HeaderText = "Item";
                dgvItens.Columns[1].Width = 50;
                dgvItens.Columns[2].HeaderText = "Código do Produto";
                dgvItens.Columns[2].Width = 50;
                dgvItens.Columns[3].HeaderText = "Nome do Produto";
                dgvItens.Columns[3].Width = 200;            
                dgvItens.Columns[4].HeaderText = "Qtde.";
                dgvItens.Columns[4].Width = 50;
                dgvItens.Columns[5].HeaderText = "Valor";
                dgvItens.Columns[5].Width = 80;
            }
            catch
            {
            }
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

        private void dgvDadosCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//https://youtu.be/xRnknzm4dgg?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=190
        {
            //verifica a linha se é maior ou igual a que zero, indicando que alguma linha foi selecionada
            if (e.RowIndex >= 0)
            {
                //guarda o codigo da celula 0, da linha selecionada no datagridview, convertendo o valor para inteiro
                this.codigo = Convert.ToInt32(dgvDadosCompra.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
