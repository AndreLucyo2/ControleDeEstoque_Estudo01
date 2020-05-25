using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class FrmConsultaProduto : Form
    {
        //serve para determinar se foi selecionado alguma linha no datagridview
        public int codigo = 0;

        public FrmConsultaProduto()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            //faz uma consula no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão
            //bll possui os metodos para incluir e alterar
            BLLProduto bll = new BLLProduto(cx);
            //indicar a fonte dos dados para o datagridview
            dgvDados.DataSource = bll.Localizar(txtValor.Text);//o metodo localizar, retorna uma datatable, que é carregada no datagridview
        }

        private void FrmConsultaProduto_Load(object sender, EventArgs e) //https://youtu.be/lj18oqTEPBY?t=776
        {
            btLocalizar_Click(sender, e);

            dgvDados.Columns[0].HeaderText = "Código";//renomeia a coluna do datagridview
            dgvDados.Columns[0].Width = 70; // configura a largura da coluna
            dgvDados.Columns[1].HeaderText = "Produto"; //renomeia a coluna do datagridview
            dgvDados.Columns[1].Width = 100; // configura a largura da coluna
            dgvDados.Columns[2].HeaderText = "Descrição"; //renomeia a coluna do datagridview
            dgvDados.Columns[2].Width = 100; // configura a largura da coluna
            dgvDados.Columns[3].HeaderText = "Foto"; //renomeia a coluna do datagridview
            dgvDados.Columns[3].Width = 50; // configura a largura da coluna
            dgvDados.Columns[4].HeaderText = "Valor Pago"; //renomeia a coluna do datagridview
            dgvDados.Columns[4].Width = 70; // configura a largura da coluna
            dgvDados.Columns[5].HeaderText = "Valor de Venda"; //renomeia a coluna do datagridview
            dgvDados.Columns[5].Width = 70; // configura a largura da coluna
            dgvDados.Columns[6].HeaderText = "Qtd"; //renomeia a coluna do datagridview
            dgvDados.Columns[6].Width = 70; // configura a largura da coluna

            //ucultas:
            //dgvDados.Columns[7].HeaderText = "Und. Medida"; //renomeia a coluna do datagridview
            //dgvDados.Columns[7].Width = 70; // configura a largura da coluna
            //dgvDados.Columns[8].HeaderText = "Categoria"; //renomeia a coluna do datagridview
            //dgvDados.Columns[8].Width = 70; // configura a largura da coluna
            //dgvDados.Columns[9].HeaderText = "SubCategoria"; //renomeia a coluna do datagridview
            //dgvDados.Columns[9].Width = 70; // configura a largura da coluna

            dgvDados.Columns[10].HeaderText = "Und. Medida"; //renomeia a coluna do datagridview
            dgvDados.Columns[10].Width = 70; // configura a largura da coluna
            dgvDados.Columns[11].HeaderText = "Categoria"; //renomeia a coluna do datagridview
            dgvDados.Columns[11].Width = 70; // configura a largura da coluna
            dgvDados.Columns[12].HeaderText = "SubCategoria"; //renomeia a coluna do datagridview
            dgvDados.Columns[12].Width = 70; // configura a largura da coluna

            //ocultar colunas:(nomes das colunas conforme tabela do BD)
            dgvDados.Columns["pro_foto"].Visible = false;
            dgvDados.Columns["pro_valorpago"].Visible = false;
            dgvDados.Columns["cat_cod"].Visible = false;
            dgvDados.Columns["scat_cod"].Visible = false;
            dgvDados.Columns["umed_cod"].Visible = false;


        }

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
