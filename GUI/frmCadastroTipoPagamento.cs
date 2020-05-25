using System;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;

namespace GUI
{
    public partial class frmCadastroTipoPagamento : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroTipoPagamento()
        {
            InitializeComponent();
        }

        //limpara os campos================================================================================================
        public void LimpaTela() 
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void frmCadastroTipoPagamento_Load(object sender, EventArgs e)
        {
            //indicar qual botão inicia ativo ou desativo:
            this.alteraBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            //Variavel fo form modelo indica qual ação sera feita ao clicar neste botão:
            this.operacao = "inserir";//usado em condições porteriormente - aula 08 metodo gravar

            //indicar qual botão inicia ativo ou desativo:
            this.alteraBotoes(2);//aqui ja ativa os campos que estiverem no painel pnDados...
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela(); // limpar a tela 
            this.alteraBotoes(1);//volta os botoes para o estado original
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try //tratamento de erro
            {
                //leitura dos dados
                ModeloTipoPagamento modelo = new ModeloTipoPagamento();//cria uma objeto que representa os dados da tabela

                modelo.TpaNome = txtNome.Text;// passar o valor do campo nome para a proriedade TpaNome 

                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

                //bll possui os metodos para incluir e alterar
                BLLTipoPagamento bll = new BLLTipoPagamento(cx);//passa a string de conexao

                //verificar qual o tipo de operação que vai executar ao gravar
                if (this.operacao == "inserir")//valida se é um inserção, verificar o valro da variavel operação
                {
                    //cadastrar
                    bll.Incluir(modelo);//passa o nome para o metodo incluir
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.TpaCod.ToString());//retorna a mensagem como o codigo do item que foi gerado
                }
                else
                {
                    //alterar 
                    modelo.TpaCod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);//alterar conforme codigo da tela
                    MessageBox.Show("Cadastro alterado");//mostrar mensagem de confirmação
                }

                //em ambos os casos:
                this.LimpaTela();// limpar a tela 
                this.alteraBotoes(1);//volta os botoes para o estado padrão
            }
            catch (Exception erro) // caso der algum erro...(não limpa a tela)
            {
                MessageBox.Show(erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);//confirmar antes de excluir
                //caso responder sim...
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

                    //bll possui o metodo para excluir
                    BLLTipoPagamento bll = new BLLTipoPagamento(cx); //passa a string de conexao

                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));//retorna erro se este codigo ja estiver sendo utilizado como chave em outra tabela
                    this.LimpaTela();
                    this.alteraBotoes(1);

                    MessageBox.Show("Cadastro excluido com sucesso!");
                }
            }
            catch // sem o Exception, qualquer tipo de erro
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaTipoPagamento f = new frmConsultaTipoPagamento();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLTipoPagamento bll = new BLLTipoPagamento(cx);
                ModeloTipoPagamento modelo = bll.CarregaModeloTipoPagamento(f.codigo);
                txtCodigo.Text = modelo.TpaCod.ToString();
                txtNome.Text = modelo.TpaNome;
                alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();

        }
    }
}
