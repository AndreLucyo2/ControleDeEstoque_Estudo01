using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class frmConsultaSubCategoria : Form
    {
        public int codigo = 0;//propriedade representa o codigo

        public frmConsultaSubCategoria()
        {
            InitializeComponent();
        }

        //================================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLSubCategoria bll = new BLLSubCategoria(cx);

            dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }

        //================================================================================================================
        private void frmConsultaSubCategoria_Load(object sender, EventArgs e) //aula 18
        {
            btLocalizar_Click(sender, e);

            //Formatar a datagridview , nomeia os cabeçalhos das colunas 
            dgvDados.Columns[0].HeaderText = "Código da SubCategoria";
            dgvDados.Columns[0].Width = 100;
            dgvDados.Columns[1].HeaderText = "SubCategoria";
            dgvDados.Columns[1].Width = 200;
            dgvDados.Columns[2].HeaderText = "Código da Categoria";
            dgvDados.Columns[2].Width = 100;

            dgvDados.Columns[3].HeaderText = "Categoria";
            dgvDados.Columns[3].Width = 200;

        }

        //================================================================================================================
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //guarda o valor da celula 0, da linha selecionada no datagridview, convertendo o valor para inteiro
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
