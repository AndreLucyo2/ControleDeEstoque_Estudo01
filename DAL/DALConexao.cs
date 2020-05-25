using System;
using System.Data.SqlClient;//referencia para o banco sql

namespace DAL
{
    public class DALConexao //Vai representar a conexão com o banco - Aula 03 
    {
        private String _stringConexao; // armazena a string de conexão
        private SqlConnection _conexao; // cria a comando para conexao
        private SqlTransaction _transaction;//criar movimentação no banco, garante integridade de dados(ex. Faltar energia no meio de uma gravação de dados  https://youtu.be/Ww3smEkjyCQ?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=942

        //===========================================================================================================================================
        public DALConexao (String dadosConexao) //Construtor recebe a string da conexão da classe DadosDaConexão
        {
            try
            {
                this._conexao = new SqlConnection();// Caomando  SQL que cria a conexao com o banco
                this.StringConexao = dadosConexao; //recebe a string da conexão da classe DadosDaConexão
                this._conexao.ConnectionString = dadosConexao; //definir a estring que vai utilizar 
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao criar conexão! \n" + erro.Message);
            }
        }

        //===========================================================================================================================================
        public String StringConexao //propriedade pegar string conexão (Encapsular)
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }

        //===========================================================================================================================================
        public SqlConnection ObjetoConexao //propriedade pegar o valor da conexão, setar e pagar  o valor ca conexão (Encapsular)
        {
            get { return this._conexao; }
            set { this._conexao = value; }

        }

        //===========================================================================================================================================
        public SqlTransaction ObjetoTransacao // Objeto responsavel pela movimentação de dados entre tabela no banco https://youtu.be/Ww3smEkjyCQ?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=976
        {
            get { return this._transaction; }
            set { this._transaction = value; }
        }

        //===========================================================================================================================================
        //CONECTAR NO BANCO
        public void Conectar()
        {
            this._conexao.Open();
        }

        //DESCONECTAR BANCO  ========================================================================================================================
        public void Desconectar()
        {
            this._conexao.Close();
        }

        //INICIAR TRANSAÇÃO DO BANCO - Ações que envolvem mais de uma tabela ========================================================================
        public void IniciarTransacao()
        {
            this._transaction = _conexao.BeginTransaction();
        }

        //TERMINAR TRANSAÇÃO DO BANCOE - fetivar a alterações no banco  =============================================================================
        public void TerminarTransacao()
        {
            this._transaction.Commit();
        }

        //CENCELAR TRANSAÇÃO - Desfaz todas as alterações caso der erro https://youtu.be/Ww3smEkjyCQ?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1146
        public void CancelarTransacao()
        {
            this._transaction.Rollback();
        }
    }
}
