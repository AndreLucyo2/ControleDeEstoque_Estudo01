using System;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;

namespace GUI
{
    public partial class frmCadastroCategoria : GUI.frmModeloDeFormularioDeCadastro
    {
        //===============================================================================================================================
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        //limpara os campos================================================================================================
        public void LimpaTela() //aula 08
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        //===============================================================================================================================
        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            //indicar qual botão inicia ativo ou desativo:
            this.alteraBotoes(1);
        }

        //===============================================================================================================================
        private void btInserir_Click(object sender, EventArgs e)  //aula 08
        {
            //Variavel fo form modelo indica qual ação sera feita ao clicar neste botão:
            this.operacao = "inserir";//usado em condições porteriormente - aula 08 metodo gravar

            //indicar qual botão inicia ativo ou desativo:
            this.alteraBotoes(2);//aqui ja ativa os campos que estiverem no painel pnDados...

        }

        //===============================================================================================================================
        private void btCancelar_Click(object sender, EventArgs e) //aula 08
        {
            this.LimpaTela(); // limpar a tela 
            this.alteraBotoes(1);//volta os botoes para o estado original
        }


        //===============================================================================================================================
        private void btSalvar_Click(object sender, EventArgs e)//vai servir tanto para alterar quanto para gravar uma alteração
        {
            try //tratamento de erro
            {
                //leitura dos dados
                ModeloCategoria modelo = new ModeloCategoria();//cria uma objeto que representa os dados da tabela catagoria

                modelo.CatNome = txtNome.Text;// passar o valor do campo nome para a proriedade CatNome 
                
                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

                //bll possui os metodos para incluir e alterar
                BLLCategoria bll = new BLLCategoria(cx);//passa a string de conexao

                //verificar qual o tipo de operação que vai executar ao gravar
                if (this.operacao == "inserir")//valida se é um inserção, verificar o valro da variavel operação
                {
                    //cadastrar uma categoria
                    bll.Incluir(modelo);//passa o nome para o metodo incluir
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.CatCod.ToString());//retorna a mensagem como o codigo do item que foi gerado
                }
                else
                {
                    //alterar uma categoria
                    modelo.CatCod = Convert.ToInt32(txtCodigo.Text);//alterar a categoria correspondente ao codigo exixtente na tela
                    bll.Alterar(modelo);//alterar conforme codigo da tela
                    MessageBox.Show("Cadastro alterado");//mostrar mensagem de confirmação
                }

                //em ambos os casos:
                this.LimpaTela();// limpar a tela 
                this.alteraBotoes(1);//volta os botoes para o estado padrão
            }
            catch (Exception erro) // caos der algum erro...(não limpa a tela)
            {
                MessageBox.Show(erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario
            }
        }

        //===============================================================================================================================
        private void btAlterar_Click(object sender, EventArgs e) //aula 09
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        //===============================================================================================================================
        private void btExcluir_Click(object sender, EventArgs e) // aula 09
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);//confirmar antes de excluir
                //caso responder sim...
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão
                    
                    //bll possui o metodo para excluir
                    BLLCategoria bll = new BLLCategoria(cx); //passa a string de conexao

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

        //===============================================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e) //aula 09
        {
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria bll = new BLLCategoria(cx);
                ModeloCategoria modelo = bll.CarregaModeloCategoria(f.codigo);
                txtCodigo.Text = modelo.CatCod.ToString();
                txtNome.Text = modelo.CatNome;
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
