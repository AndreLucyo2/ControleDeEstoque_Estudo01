using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class frmConsultaCategoria : Form
    {
        //serve para determinar se foi selecionado alguma linha de catagoria no datagridview
        public int codigo = 0;//aula 10

        //===============================================================================================================================
        public frmConsultaCategoria()
        {
            InitializeComponent();
        }

        //===============================================================================================================================
        private void frmConsultaCategoria_Load(object sender, EventArgs e) //aula 10
        { 
            btLocalizar_Click(sender, e); //manda executar a ação do click do botão localizar

            dgvDados.Columns[0].HeaderText = "Código";//renomeia a coluna do datagridview
            dgvDados.Columns[0].Width = 70; // configura a largura da coluna
            dgvDados.Columns[1].HeaderText = "Categoria"; 
            dgvDados.Columns[1].Width = 495;
        }

        //===============================================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e) //Aula 10
        {
            //faz uma consula no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão
            //bll possui os metodos para incluir e alterar
            BLLCategoria bll = new BLLCategoria(cx);
            //indicar a fonte dos dados para o datagridview
            dgvDados.DataSource = bll.Localizar(txtValor.Text);//o metodo localizar, retorna uma datatable, que é carregada no datagridview
        }

        //===============================================================================================================================
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //aula 10
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
