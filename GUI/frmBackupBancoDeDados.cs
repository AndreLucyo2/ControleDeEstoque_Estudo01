using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Ferramentas;
using System.Data.SqlClient;


namespace GUI
{
    public partial class frmBackupBancoDeDados : Form
    {
        public frmBackupBancoDeDados()
        {
            InitializeComponent();
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("O banco de dados nao pode estar em uso!");

            try
            {
                //abre janela para usuario escolher onde salvar o bakup
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Backup Files |* .back";//filtro somente os arquivos de backup
                d.ShowDialog();//mostra a janela

                if (d.FileName != "")
                {
                    String nomeBanco = DadosDaConexao.banco;//busca o nome do banco de dados que se vai criar o backup
                    String localBackup = d.FileName;

                    //mostra o caminho + nome inde vai ser criado o backup
                    txtbLocalBackup.Text = d.FileName;

                    //se conecta no banco de dados "master", pois nao pode criar backup do mesmo banco aberto
                    String conexao = @"Data Source=" + DadosDaConexao.servidor + ";Initial Catalog=master;User ID=" +
                                     DadosDaConexao.usuario + ";Password=" + DadosDaConexao.senha; //Retornar a string de conexão do BD master

                    //executa o comanco para criar backup conforme endereço indicado:
                    SQLServerBackup.BackupDataBase(conexao, nomeBanco, d.FileName);

                    MessageBox.Show("Bakup criado com sucesso!");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void btRestaurar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O banco de dados nao pode estar em uso!");

            try //aula 44 - 45 - 46
            {
                //abre janela para usuario escolher onde salvar o bakup
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "Backup Files |* .back";//filtro somente os arquivos de backup
                d.ShowDialog();//mostra a janela

                if (d.FileName != "")
                {
                    String nomeBanco = DadosDaConexao.banco;//busca local banco de dados que se vai criar o backup
                    String localBackup = d.FileName;

                    //mostra o caminho + nome inde vai ser criado o backup
                    txtbLocalBackup.Text = d.FileName;

                    //se conecta no banco de dados "master", pois nao pode criar backup do mesmo banco aberto
                    String conexao = @"Data Source=" + DadosDaConexao.servidor + ";Initial Catalog=master;User ID=" +
                                     DadosDaConexao.usuario + ";Password=" + DadosDaConexao.senha; //Retornar a string de conexão do BD master

                    //executa o comando para criar backup conforme endereço indicado:
                    SQLServerBackup.RestauraDatabase(conexao, nomeBanco, d.FileName);

                    MessageBox.Show("Backup restaurado com sucesso!");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void frmBackupBancoDeDados_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Ver aula : https://www.youtube.com/watch?v=M3TiMzBZwu8&list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&index=94");
        }
    }
}
