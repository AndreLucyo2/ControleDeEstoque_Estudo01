using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using DAL;

namespace GUI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //verificar conexão com banco:
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.config");
                DadosDaConexao.servidor = arquivo.ReadLine();
                DadosDaConexao.banco = arquivo.ReadLine();
                DadosDaConexao.usuario = arquivo.ReadLine();
                DadosDaConexao.senha = arquivo.ReadLine();

                arquivo.Close();

                //testar conexao:
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DadosDaConexao.StringDeConexao;
                conexao.Open();
                conexao.Close();

            }
            catch (SqlException erroBanco)//caos der erro de conexção
            {
                //caso der erro ao testar conexao mostrar mensagem de erro: o "\n" indica nova linha na messagebox
                MessageBox.Show("Erro ao conectar no banco de dados \n"+
                                 "Acesso as Configurações do Banco de Dados \n"+
                                 "informe os parametros da conexão.");
            }
            catch (Exception erroS)//caso der erro com dados informados:
            {
                //caso der erro ao testar conexao mostrar mensagem de erro: 
                MessageBox.Show(erroS.Message);
            }

        }


        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();//so permite interagir com outros forms se fechar este
            //f.Show();//permite interagir com outras telas mesmo com este aberto
            f.Dispose();//destroi o objeto, limpar memoria

        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
            f.Dispose();//destroi o objeto, limpar memoria
        }

        private void subCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroSubCategoria f = new frmCadastroSubCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void subCategoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrounidadeDeMedida f = new frmCadastrounidadeDeMedida();
            f.ShowDialog();
            f.Dispose();
        }

        private void unidadeDeMedidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaUnidadeDeMedida f = new frmConsultaUnidadeDeMedida();
            f.ShowDialog();
            f.Dispose();
        }


        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProduto f = new frmCadastroProduto();
            f.ShowDialog();
            f.Dispose();
        }

        private void tsbtCadastrarProduto_Click(object sender, EventArgs e)
        {
            produtoToolStripMenuItem_Click(sender, e);
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaProduto f = new FrmConsultaProduto();
            f.ShowDialog();
            f.Dispose();
        }

        private void configaçãoDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracaoBancoDados f = new frmConfiguracaoBancoDados();
            f.ShowDialog();
            f.Dispose();
        }

        private void backupDosDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupBancoDeDados f = new frmBackupBancoDeDados();
            f.ShowDialog();
            f.Dispose();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrir processo da calculadora: Aula 41.1
            System.Diagnostics.Process.Start("calc");
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrir  calculadora: Aula 41.1
            System.Diagnostics.Process.Start("explorer");
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrir bloco de notas: Aula 41.1
            System.Diagnostics.Process.Start("notepad");
        }

        private void excelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //abre excel: Aula 41.1
            System.Diagnostics.Process.Start("excel");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abre word Aula 41.1
            System.Diagnostics.Process.Start("winword");
        }

        private void tipoDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroTipoPagamento f = new frmCadastroTipoPagamento();
            f.ShowDialog();
            f.Dispose();
        }

        private void tipoDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaTipoPagamento f = new frmConsultaTipoPagamento();
            f.ShowDialog();
            f.Dispose();
        }
        
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Falta implementar: "+
                        " \n mascaras -CEP CPF CNPJ Tel CEL "+
                        "\n Falta emplemtar validação diretamente nos campos."+
                        "\n usar maskedTextBox |ref: https://youtu.be/BTJP2RASd_c?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA |"); 

            frmCadastroCliente f = new frmCadastroCliente();
            f.ShowDialog();
            f.Dispose();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmConsultaCliente f = new frmConsultaCliente();
            f.ShowDialog();
            f.Dispose();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Falta implementar: \n mascaras -CEP CPF CNPJ Tel CEL " + 
                "\n falta tela de consulta ala 66" +
                "\n Falta emplemtar validação diretamente nos campos.");

            frmCadastroFornecedor f = new frmCadastroFornecedor();
            f.ShowDialog();
            f.Dispose();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaFornecedor f = new FrmConsultaFornecedor();
            f.ShowDialog();
            f.Dispose();

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre f = new frmSobre();
            f.ShowDialog();
            f.Dispose();
        }


        private void compraToolStripMenuItem_Click(object sender, EventArgs e) //https://youtu.be/VOjVYzRZk50?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=159
        {
            frmMovimentacaoCompra f = new frmMovimentacaoCompra();
            f.ShowDialog();
            f.Dispose();
        }

        private void backupTurboToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaCompra f = new frmConsultaCompra();
            f.ShowDialog();
            f.Dispose();
        }

        private void pagamentoCompraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPagamentoCompra f = new frmPagamentoCompra();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
