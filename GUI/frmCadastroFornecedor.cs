using System;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;
using Ferramentas;

namespace GUI
{
    public partial class frmCadastroFornecedor : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroFornecedor()
        {
            InitializeComponent();
        }

        private void frmCadastroFornecedor_Load(object sender, EventArgs e)
        {
            //indicar qual botão inicia ativo ou desativo:
            this.alteraBotoes(1);
        }

        //=============================================================================================================
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtRSocial.Clear();
            txtBairro.Clear();
            txtCelular.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtCpfCnpj.Clear();
            txtEmail.Clear();
            txtEstado.Clear();
            txtFone.Clear();
            txtIe.Clear();
            txtEndereco.Clear();
        }

        //=============================================================================================================
        private void btInserir_Click(object sender, EventArgs e)
        {
            //Variavel fo form modelo indica qual ação sera feita ao clicar neste botão:
            this.operacao = "inserir";//usado em condições porteriormente - aula 08 metodo gravar

            //indicar qual botão inicia ativo ou desativo:
            this.alteraBotoes(2);//aqui ja ativa os campos que estiverem no painel pnDados...
        }

        //=============================================================================================================
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela(); // limpar a tela 
            this.alteraBotoes(1);//volta os botoes para o estado original
        }

        //=============================================================================================================
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try //tratamento de erro
            {
                //leitura dos dados
                ModeloFornecedor modelo = new ModeloFornecedor();//cria uma objeto que representa os dados da tabela catagoria

                //passar os valores da tela para os campos:
                modelo.ForNome = txtNome.Text;
                modelo.ForCnpj = txtCpfCnpj.Text;
                modelo.ForIe = txtIe.Text;
                modelo.ForRSocial = txtRSocial.Text;
                modelo.ForCep = txtCep.Text;
                modelo.ForEndereco = txtEndereco.Text;
                modelo.ForBairro = txtBairro.Text;
                modelo.ForFone = txtFone.Text;
                modelo.ForCel = txtCelular.Text;
                modelo.ForEmail = txtEmail.Text;
                modelo.ForEndNumero = txtNumero.Text;
                modelo.ForCidade = txtCidade.Text;
                modelo.ForEstado = txtEstado.Text;


                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

                //bll possui os metodos para incluir e alterar
                BLLFornecedor bll = new BLLFornecedor(cx);//passa a string de conexao

                //verificar qual o tipo de operação que vai executar ao gravar
                if (this.operacao == "inserir")//valida se é um inserção, verificar o valro da variavel operação
                {
                    //cadastrar uma Fornecedor
                    bll.Incluir(modelo);//passa o nome para o metodo incluir
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.ForCod.ToString());//retorna a mensagem como o codigo do item que foi gerado
                }
                else //se for alterar:
                {
                    //alterar uma Fornecedor
                    modelo.ForCod = Convert.ToInt32(txtCodigo.Text);//alterar a Fornecedor correspondente ao codigo exixtente na tela
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

        //=============================================================================================================
        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        //=============================================================================================================
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
                    BLLFornecedor bll = new BLLFornecedor(cx); //passa a string de conexao

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

        //=============================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            FrmConsultaFornecedor f = new FrmConsultaFornecedor();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);
                ModeloFornecedor modelo = bll.CarregaModeloFornecedor(f.codigo);
                txtCodigo.Text = modelo.ForCod.ToString();

                //passar os valores dos campos para tela:
                txtNome.Text = modelo.ForNome;
                txtCpfCnpj.Text = modelo.ForCnpj;
                txtIe.Text = modelo.ForIe;
                txtRSocial.Text = modelo.ForRSocial;
                txtCep.Text = modelo.ForCep;
                txtEndereco.Text = modelo.ForEndereco;
                txtBairro.Text = modelo.ForBairro;
                txtFone.Text = modelo.ForFone;
                txtCelular.Text = modelo.ForCel;
                txtEmail.Text = modelo.ForEmail;
                txtNumero.Text = modelo.ForEndNumero;
                txtCidade.Text = modelo.ForCidade;
                txtEstado.Text = modelo.ForEstado;

                alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }

            //destroi o obejto
            f.Dispose();
        }

        private void txtCep_Leave(object sender, EventArgs e) //https://youtu.be/ZKqSRaDj6SM?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=403
        {
            if (BuscaEndereco.verificaCEP(txtCep.Text) == true)
            {
                //retorna dados da classe ferramentas:
                txtBairro.Text = BuscaEndereco.bairro;
                txtCidade.Text = BuscaEndereco.cidade;
                txtEstado.Text = BuscaEndereco.estado;
                txtEndereco.Text = BuscaEndereco.endereco;
            }
            else
            {
                MessageBox.Show("CEP nao encontrado!");

                //OPCIONAL - limpar campo do endereço tela caso não encontrar
                //txtCep.Clear();
                //txtBairro.Clear();               
                //txtCidade.Clear();              
                //txtEstado.Clear();
                //txtRua.Clear();
            }

        }

        private void txtCpfCnpj_Leave(object sender, EventArgs e)
        {
            //oculta aviso:
            lbValorIncorreto.Visible = false;

            //Valida cnpj
            if (Validacao.IsCnpj(txtCpfCnpj.Text) == false)
            {
                lbValorIncorreto.Visible = false;
            }
            
        }



    }
}
