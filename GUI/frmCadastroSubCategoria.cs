using System;
using System.Windows.Forms;
using BLL;
using DAL;
using Modelo;

namespace GUI
{
    public partial class frmCadastroSubCategoria : GUI.frmModeloDeFormularioDeCadastro
    {
        //==========================================================================================================================================
        public frmCadastroSubCategoria()
        {
            InitializeComponent();
        }

        //==========================================================================================================================================
        public void LimpaTela()
        {
            txtNome.Clear();
            txtScatCod.Clear();
        }

        //==========================================================================================================================================
        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);

            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);

            //carregar o combobox: DataSource indica a origem dos dados
            cbCatCod.DataSource = bll.Localizar("");//retornar um datatable com todas as catagorias
            cbCatCod.DisplayMember = "cat_nome"; //qual campo sera monstrado, (Fica Visivel)
            cbCatCod.ValueMember = "cat_cod"; // indicar qual campo vai ser guardado como referencia

            //auto completar combobox: https://youtu.be/duG7x9KR4jA?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=340
            cbCatCod.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCatCod.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //==========================================================================================================================================
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            this.operacao = "inserir";
        }

        //==========================================================================================================================================
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            this.LimpaTela();
        }

        //==========================================================================================================================================
        private void btSalvar_Click(object sender, EventArgs e) //aula 16
        {
            try
            {
                //leitura dos dados
                ModeloSubCategoria modelo = new ModeloSubCategoria();
                modelo.ScatNome = txtNome.Text;//nome da subcatagoria
                modelo.CatCod = Convert.ToInt32(cbCatCod.SelectedValue);//pegao o valor oculto do combobox correspondente a catagoria selecionada e converte para inteiro

                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubCategoria bll = new BLLSubCategoria(cx);

                if (this.operacao == "inserir")
                {
                    //cadastrar uma categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.ScatCod.ToString());

                }
                else
                {
                    //alterar uma categoria
                    modelo.ScatCod = Convert.ToInt32(txtScatCod.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                }
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        //==========================================================================================================================================
        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLSubCategoria bll = new BLLSubCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtScatCod.Text));
                    this.LimpaTela();
                    this.alteraBotoes(1);

                    MessageBox.Show("Cadastro excluido com sucesso!");
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        //==========================================================================================================================================
        private void btAlterar_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "alterar";
        }

        //==========================================================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e) //auça 16
        {
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            f.ShowDialog();//ao dar duploclik na linha, fecha o form consultasubcart, e retornar o 

            if (f.codigo != 0) //usa a propriedade codigo para retornar o codigo da subcat selecionado
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubCategoria bll = new BLLSubCategoria(cx);

                ModeloSubCategoria modelo = bll.CarregaModeloSubCategoria(f.codigo);//carrega subcatagoria conforme propriedade cod
                txtScatCod.Text = modelo.ScatCod.ToString();//carregar o cod da subcat
                txtNome.Text = modelo.ScatNome;//carregar o nome da subcat
                cbCatCod.SelectedValue = modelo.CatCod;
                alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
        }

        private void btAdd_Click(object sender, EventArgs e) //aula 49 - criar um novo cadastro
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();

            //Atualizar combobox:
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);

            //carregar o combobox: DataSource indica a origem dos dados
            cbCatCod.DataSource = bll.Localizar("");//retornar um datatable com todas as catagorias
            cbCatCod.DisplayMember = "cat_nome"; //qual campo sera monstrado, (Fica Visivel)
            cbCatCod.ValueMember = "cat_cod"; // indicar qual campo vai ser guardado como referencia


        }
    }
}
