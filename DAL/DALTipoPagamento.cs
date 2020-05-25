using Modelo; //Name space do modelo
using System;
using System.Data;
using System.Data.SqlClient; //referencia para o banco sql

namespace DAL
{
    public class DALTipoPagamento
    {
        private DALConexao conexao; // cria uma propriedade privada
        public DALTipoPagamento(DALConexao cx) //criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //Metodo para incluir uma tipopagamento =================================================================== aula 03
        public void Incluir(ModeloTipoPagamento modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao; // Definir a conexão

                //criar a query para o insert do nome da catagoria, utlizando parametro @nome, 
                cmd.CommandText = "insert into tipopagamento(tpa_nome) values (@nome); select @@IDENTITY;"; //o selelct retorno 
                //adiciona o valor da variavel ao parametro @nome
                cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);//parametro inser o nome da catagoria

                //conecta ao banco
                conexao.Conectar();
                //recebe o valor retornado pelo selecat identity
                modelo.TpaCod = Convert.ToInt32(cmd.ExecuteScalar());//ExecuteScalar = quando quer retornor poucs informações da consulta

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                //desconecta do banco
                conexao.Desconectar();
            }
        }

        //Metodo para alterar uma tipopagamento ===================================================================
        public void Alterar(ModeloTipoPagamento modelo) //aula 03
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o tpa_Cod for igual ao codigo 
                cmd.CommandText = "UPDATE tipopagamento SET tpa_nome = @nome WHERE tpa_cod = @codigo;";

                //informa os dois parametros do comando
                cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);
                cmd.Parameters.AddWithValue("@codigo", modelo.TpaCod);

                //conecta ao banco
                conexao.Conectar();
                cmd.ExecuteNonQuery(); //ExecuteNonQuery = quando não quer ou nao vai retornor informações da consulta

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                //desconecta do banco
                conexao.Desconectar();
            }
        }

        //Metodo para Excluir um item ===================================================================- aula 04
        public void Excluir(int codigo) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o excluir o item conforme codigo recebido,
                cmd.CommandText = "DELETE FROM tipopagamento WHERE tpa_cod = @codigo;";

                //Definir o valor do parametro - codigo do intem recebido 
                cmd.Parameters.AddWithValue("@codigo", codigo);

                //conecta ao banco
                conexao.Conectar();
                cmd.ExecuteNonQuery();//executa o comando que nao retorno valor
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                //desconecta do banco
                conexao.Desconectar();
            }
        }

        //Metodo para Localizar um item ===================================================================- aula 04
        //retorna uma datatable, tabela em memoria - conforme valor informado do que se quer procurar
        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tipopagamento WHERE tpa_nome LIKE '%" +
                                                     valor + "%'", conexao.StringConexao);
            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //Metodo para carregar informações do BD Tabela Catagoria ==========================================================- aula 04
        public ModeloTipoPagamento CarregaModeloTipoPagamento(int codigo) // recebeo o codigo do item que se quer carregar
        {
            ModeloTipoPagamento modelo = new ModeloTipoPagamento();// instacio o modelo
            //criar a query para o carregar o item conforme codigo recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM tipopagamento WHERE tpa_cod = @codigo";//selecione todos os itens da categori onde o codigo da categira seja igual ao informado pelo usuario

            //Definir o valor do parametro - codigo do intem recebido 
            cmd.Parameters.AddWithValue("@codigo", codigo);

            //conecta ao banco
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader(); //ExecuteReader: quando quer retornor muita informações da consulta  
            //SqlDataReader: obejeto para ler e acessar as infornmações retornadas
            //verifica se existe alguma lina dentro o objeto, se existir linha, le as informações dela, e carrega cada campo em suas respectivas colunas
            if (registro.HasRows)
            {
                registro.Read();
                modelo.TpaCod = Convert.ToInt32(registro["tpa_cod"]); //coloca o valor da coluna do objeto regitro na variavel do modelo
                modelo.TpaNome = Convert.ToString(registro["tpa_nome"]);
            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo tipopagamento contem os campos da tabela de catagoria
        }

    }
}
