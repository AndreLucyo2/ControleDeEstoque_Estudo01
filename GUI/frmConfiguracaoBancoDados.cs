using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConfiguracaoBancoDados : Form
    {
        public frmConfiguracaoBancoDados()
        {
            InitializeComponent();
        }
        
        //.............. CRIAR VALIDAÇÃO PARA NAO DEIxAR DIGITAR ACENTOS OU CARACTERES ESPSCIAIS
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try //Aula 42 https://youtu.be/_p6Bable09U?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=230
            {
                //criar ou abrir uma arquivo no mesmo local do executavel
                // para guardar as configurações do banco:(Ver para criptogravar a gravação)
                StreamWriter arquivo = new StreamWriter("ConfiguracaoBanco.config"); //TODA VEZ ELE LIMPA O TEXTO ANTIGO
                arquivo.WriteLine(txtServidor.Text); //escreve a linha como o servidor
                arquivo.WriteLine(txtBanco.Text);
                arquivo.WriteLine(txtUsuario.Text);
                arquivo.WriteLine(txtSenha.Text);
                arquivo.Close();
                this.Close();
                MessageBox.Show("Arquivo atualizado com sucesso!!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void frmConfiguracaoBancoDados_Load(object sender, EventArgs e)
        {
            try //Aula 42 https://youtu.be/_p6Bable09U?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=230
            {
                //ler o arquivo no mesmo local do executavel
                // para ler as configurações do banco:(Ver para criptogravar a gravação)
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.config");

                //le as linhas em ordem, e passa para os campos:
                txtServidor.Text = arquivo.ReadLine();
                txtBanco.Text = arquivo.ReadLine();
                txtUsuario.Text = arquivo.ReadLine();
                txtSenha.Text = arquivo.ReadLine();
                //fechar o arqquivo
                arquivo.Close();               
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btTestar_Click(object sender, EventArgs e) //https://youtu.be/cCNL-KMNe84?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=342
        {
            //verificar conexão com banco:
            try
            {
                //as informação ja estarão na tela:
                DadosDaConexao.servidor = txtServidor.Text;
                DadosDaConexao.banco = txtBanco.Text;
                DadosDaConexao.usuario = txtUsuario.Text;
                DadosDaConexao.senha = txtSenha.Text;

                //testar conexao:
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DadosDaConexao.StringDeConexao;
                conexao.Open();
                conexao.Close();
                MessageBox.Show("Conexao efetuada com sucesso");
            }
            catch (SqlException erroBanco)//caos der erro de conexção
            {
                //caso der erro ao testar conexao mostrar mensagem de erro: o "\n" indica nova linha na messagebox
                MessageBox.Show("Erro ao conectar no banco de dados \n" +
                                 "Verifique os dados informados \n Erro: " + erroBanco.Message);
            }
            catch (Exception erroS)//caso der erro com dados informados:
            {
                //caso der erro ao testar conexao mostrar mensagem de erro: 
                MessageBox.Show(erroS.Message);
            }

        }
    }
}
