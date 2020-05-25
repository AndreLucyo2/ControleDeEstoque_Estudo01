using System;
using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALUnidadeDeMedida
    {
        private DALConexao conexao;
        public DALUnidadeDeMedida(DALConexao cx)
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        public void Incluir(ModeloUnidadeDeMedida modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into undmedida(umed_nome) values (@nome); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", modelo.UmedNome);
                conexao.Conectar();
                modelo.UmedCod = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }

        }

        //==============================================================================================================================
        public void Alterar(ModeloUnidadeDeMedida modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update undmedida set umed_nome = @nome WHERE umed_cod = @cod;";
                cmd.Parameters.AddWithValue("@nome", modelo.UmedNome);
                cmd.Parameters.AddWithValue("@cod", modelo.UmedCod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }

        }

        //==============================================================================================================================
        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "DELETE FROM undmedida WHERE umed_cod = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }

        }

        //==============================================================================================================================
        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM undmedida WHERE umed_nome LIKE '%" +
                valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        //==============================================================================================================================
        //verifica se ja existe algo parecido cadastrado, evitar cadastro duplicado: aula 22.1, retorna o id do primeiro registro encontrado
        public int VerificaUnidadeDeMedida(String valor) //se retornar 0 - nao existe || numero > 0 existe algum registro ja cadastrado, retornar o ID do registro em "r"
        {
            int r = 0; //0 - não existe, logo de cara nao existe, depois verifca
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;//definir a conexão
            cmd.CommandText = "SELECT * FROM undmedida WHERE umed_nome = @nome";//procura no banco o que esta sendo cadastrado
            cmd.Parameters.AddWithValue("@nome", valor);//passa o que foi digitado no campo para o parametro

            conexao.Conectar();//conectar no banco

            SqlDataReader registro = cmd.ExecuteReader();//executa o comando e guarda no objeto registro
            if (registro.HasRows)//verifica se o objeto registro tem alguma linha, significa que encontrou algum valor
            {
                registro.Read();//ler a linha encontradda
                r = Convert.ToInt32(registro["umed_cod"]);//armazena na variavel r
            }
            //desconecta do banco
            conexao.Desconectar();
            return r;//retorna o que encontrou 
        }

        public ModeloUnidadeDeMedida CarregaModeloUnidadeDeMedida(int codigo)
        {
            ModeloUnidadeDeMedida modelo = new ModeloUnidadeDeMedida();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM undmedida WHERE umed_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.UmedCod = Convert.ToInt32(registro["umed_cod"]);
                modelo.UmedNome = Convert.ToString(registro["umed_nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }

}
