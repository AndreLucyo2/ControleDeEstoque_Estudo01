using System;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;
using Ferramentas;

namespace GUI  //falta usar os metodos para formatar o CPF e CNPJ - VEr aplicação ja criada
{
    public partial class frmCadastroCliente : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        //=============================================================================================================
        private void frmCadastroCliente_Load(object sender, EventArgs e)
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
            txtRgIe.Clear();
            txtEndereco.Clear();
            rbFisica.Checked = true;//ativa pessoa fisica por padrão
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
                ModeloCliente modelo = new ModeloCliente();//cria uma objeto que representa os dados da tabela catagoria

                //passar os valores da tela para os campos:
                modelo.CliNome = txtNome.Text;
                modelo.CliCpfCnpj = txtCpfCnpj.Text;
                modelo.CliRgIe = txtRgIe.Text;                
                modelo.CliRSocial = txtRSocial.Text;                
                modelo.CliCep = txtCep.Text;
                modelo.CliEndereco = txtEndereco.Text;
                modelo.CliBairro = txtBairro.Text;
                modelo.CliFone = txtFone.Text;
                modelo.CliCel = txtCelular.Text;
                modelo.CliEmail = txtEmail.Text;
                modelo.CliEndNumero = txtNumero.Text;
                modelo.CliCidade = txtCidade.Text;
                modelo.CliEstado = txtEstado.Text;

                //verificar o tipo do cliente:
                if (rbFisica.Checked==true)
                {
                    modelo.CliTipo = "Física"; //pessoa fisica
                    modelo.CliRSocial = "-"; // pessoa fisica nao usa rasão social
                }
                else
                {
                    modelo.CliTipo = "Jurídica"; //pessoa juridica
                }                

                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

                //bll possui os metodos para incluir e alterar
                BLLCliente bll = new BLLCliente(cx);//passa a string de conexao

                //verificar qual o tipo de operação que vai executar ao gravar
                if (this.operacao == "inserir")//valida se é um inserção, verificar o valro da variavel operação
                {
                    //cadastrar uma Cliente
                    bll.Incluir(modelo);//passa o nome para o metodo incluir
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.CliCod.ToString());//retorna a mensagem como o codigo do item que foi gerado
                }
                else //se for alterar:
                {
                    //alterar uma Cliente
                    modelo.CliCod = Convert.ToInt32(txtCodigo.Text);//alterar a Cliente correspondente ao codigo exixtente na tela
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
                    BLLCliente bll = new BLLCliente(cx); //passa a string de conexao

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
            frmConsultaCliente f = new frmConsultaCliente();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCliente bll = new BLLCliente(cx);
                ModeloCliente modelo = bll.CarregaModeloCliente(f.codigo);
                txtCodigo.Text = modelo.CliCod.ToString();

                //passar os valores dos campos para tela:
                txtNome.Text = modelo.CliNome;
                txtCpfCnpj.Text= modelo.CliCpfCnpj;
                txtRgIe.Text= modelo.CliRgIe;
                txtRSocial.Text = modelo.CliRSocial;
                txtCep.Text = modelo.CliCep;
                txtEndereco.Text = modelo.CliEndereco;
                txtBairro.Text = modelo.CliBairro;
                txtFone.Text = modelo.CliFone;
                txtCelular.Text = modelo.CliCel;
                txtEmail.Text = modelo.CliEmail;
                txtNumero.Text = modelo.CliEndNumero;
                txtCidade.Text = modelo.CliCidade;
                txtEstado.Text = modelo.CliEstado;

                //verificar o tipo do cliente:
                if (modelo.CliTipo == "Física")
                {
                    rbFisica.Checked = true; //pessoa fisica
                }
                else
                {
                    rbJuridica.Checked = true; //pessoa "Jurídica";
                }

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

        //ao alterar a opção de pessoa fisica ou juridica
        private void rbFisica_CheckedChanged(object sender, EventArgs e)
        {
            //vai ocultar ou mostrar campo rasão social
            if (rbFisica.Checked ==true)
            {
                lbRSocial.Visible = false;
                txtRSocial.Visible = false;
                lbCpfCnpj.Text = "CPF";
                lbRgIe.Text = "RG"; // VER PARA POR INCRIÇÃO MUNICIPAL...

            }
            else
            {
                lbRSocial.Visible = true;
                txtRSocial.Visible = true;
                lbCpfCnpj.Text = "CNPJ";
                lbRgIe.Text = "IE"; // VER PARA POR INCRIÇÃO MUNICIPAL...
            }
        }

        private void txtCep_Leave(object sender, EventArgs e) //https://youtu.be/ZKqSRaDj6SM?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=403
        {
            if (BuscaEndereco.verificaCEP(txtCep.Text)==true)
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
            //valida se é CPF:
            if (rbFisica.Checked==true)
            {
                //Valida cpf
                if (Validacao.IsCpf(txtCpfCnpj.Text) == false)
                {
                    lbValorIncorreto.Visible = true;
                }

            }
            else
            {
                //Valida cnpj
                if (Validacao.IsCnpj(txtCpfCnpj.Text)==false)
                {
                    lbValorIncorreto.Visible = false;
                }
            }
        }

    }
}
