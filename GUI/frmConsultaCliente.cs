using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class frmConsultaCliente : Form
    {
        //serve para determinar se foi selecionado alguma linha de catagoria no datagridview
        public int codigo = 0;//aula 10

        public frmConsultaCliente()
        {
            InitializeComponent();
        }

        private void frmConsultaCliente_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e); //manda executar a ação do click do botão localizar

            dgvDados.Columns[0].HeaderText = "Código";//renomeia a coluna do datagridview
            dgvDados.Columns[0].Width = 70; // configura a largura da coluna
            dgvDados.Columns[1].HeaderText = "Nome";
            dgvDados.Columns[1].Width = 150;
            dgvDados.Columns[2].HeaderText = "CPF/CNPJ";
            dgvDados.Columns[2].Width = 70;
            dgvDados.Columns[3].HeaderText = "RG/IE";
            dgvDados.Columns[3].Width = 70;
            dgvDados.Columns[4].HeaderText = "Razão Social";
            dgvDados.Columns[4].Width = 70;
            dgvDados.Columns[5].HeaderText = "Tipo";
            dgvDados.Columns[5].Width = 70;
            dgvDados.Columns[6].HeaderText = "CEP";
            dgvDados.Columns[6].Width = 70;
            dgvDados.Columns[7].HeaderText = "Endeço";
            dgvDados.Columns[7].Width = 70;
            dgvDados.Columns[8].HeaderText = "Bairro";
            dgvDados.Columns[8].Width = 70;
            dgvDados.Columns[9].HeaderText = "Fone";
            dgvDados.Columns[9].Width = 70;
            dgvDados.Columns[10].HeaderText = "Celular";
            dgvDados.Columns[10].Width = 70;
            dgvDados.Columns[11].HeaderText = "E-mail";
            dgvDados.Columns[11].Width = 70;
            dgvDados.Columns[12].HeaderText = "Numero";
            dgvDados.Columns[12].Width = 70;
            dgvDados.Columns[13].HeaderText = "Cidade";
            dgvDados.Columns[13].Width = 70;
            dgvDados.Columns[14].HeaderText = "Estado";
            dgvDados.Columns[14].Width = 70;

            //ver para ordenar as colunas no select do DAL
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            //faz uma consula no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão
            //bll possui os metodos para incluir e alterar
            BLLCliente bll = new BLLCliente(cx);

            //validar o tipo de consulta:
            if (rbNome.Checked==true) 
            {
                //consulta por nome:
                //indicar a fonte dos dados para o datagridview
                dgvDados.DataSource = bll.LocalizarPorNome(txtValor.Text);//o metodo localizar, retorna uma datatable, que é carregada no datagridview
            }
            else // https://youtu.be/VmTY593Mrqc?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=599
            {
                //consulta por cpf cnpj
                dgvDados.DataSource = bll.LocalizarCPFCNPJ(txtValor.Text);
            }
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
