using System;
using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALSubCategoria //explicações ver a DALCategoria
    {
        private DALConexao conexao;//ptopriedade
        public DALSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        //============================================================================================= aula 13
        public void Incluir(ModeloSubCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into subcategoria(cat_cod, scat_nome) values (@catcod, @nome); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);//chave estrangeira da catagoria
                cmd.Parameters.AddWithValue("@nome", modelo.ScatNome);//nome da subcatagoria

                conexao.Conectar();

                modelo.ScatCod = Convert.ToInt32(cmd.ExecuteScalar());//retorna o cod da subcategoria da sequencia
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                conexao.Desconectar();
            }

        }

        //============================================================================================= aula 13
        public void Alterar(ModeloSubCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update subcategoria set scat_nome = @nome, cat_cod = @catcod WHERE scat_cod = @scatcod;";
                cmd.Parameters.AddWithValue("@nome", modelo.ScatNome);
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);
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

        //============================================================================================= aula 13
        public void Excluir(int codigo)
        {
            try // unica possibilidade de erro, é se o registro esta sendo utilizado em outra tabela (estudar relação diretamente no banco)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "DELETE FROM subcategoria WHERE scat_cod = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);//ver para trazer onde esta item pode estar sendo utilizado, caso der erro...
            }
            finally
            {
                conexao.Desconectar();
            }

        }

        //============================================================================================= aula 13
        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            /* 
            Carrega a subcatagoria, e com base na chave estrangeira Cat_cod, traz o nome da catagoria (usando inerjoin),
            ou seja faz a junção de duas tabelas pelo relacionamento entre elas (atentar para o nome das colunas no BD)

            1° seleciona os campos das tabelas de interesse,
                2° da uma apelido para cada tabela. Exemplo 
                subcategoria virou sc
                categoria virou c
                3° indicar quais colunas de relacionamento PK e FK
                on sc.cat_cod = c.cat_cod

            FORMAR 01: com INNER JOIN 
            select sc.scat_cod, sc.scat_nome, c.cat_cod, c.cat_nome
            from subcategoria sc INNER JOIN categoria c on sc.cat_cod = c.cat_cod

            FORMAR 02: COM WHERE
            Podemos usar também a cláusula WHERE e termos o mesmo resultado. O script ficará assim:
            select sc.scat_cod, sc.scat_nome, c.cat_cod, c.cat_nome //indicar quais colunas vai retornar
            from subcategoria as sc, categoria as c //criar apelidos para as tabelas
            WHERE sc.cat_cod = c.cat_cod  //clausula re relacionamento onde cmpo "X" for igual a campo "Y"
            */

            //Aplicando: Aula 18
            SqlDataAdapter da = new SqlDataAdapter("SELECT sc.scat_cod, sc.scat_nome, sc.cat_cod, c.cat_nome " +
                                                   "FROM subcategoria sc INNER JOIN categoria c ON sc.cat_cod = c.cat_cod WHERE scat_nome LIKE " +
                                                   "'%"+ valor + "%'", conexao.StringConexao); //LIKE que filtro por algo digitado no campo de pesquisa
            //preenche os dados da consulta:
            da.Fill(tabela);
            return tabela;
        }

        //============================================================================================= aula 33 - Combobox subcatagoria da tela de cadastro de produto
        public DataTable LocalizarPorCategoria(int categoria) // necessaario para selecionar  os combobox, dependendo da catagoria selecionada
        {
            //vai carregar as subcatagoria, conforme a catagoria selecionada, ou seja so retorna as subcatagoria da catagori selecionada 
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT sc.scat_cod, sc.scat_nome, sc.cat_cod, c.cat_nome " +
                " from subcategoria sc INNER JOIN categoria c on sc.cat_cod = c.cat_cod WHERE sc.cat_cod = " +
                categoria.ToString(), conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        //============================================================================================= aula 13
        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            ModeloSubCategoria modelo = new ModeloSubCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM subcategoria WHERE scat_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.ScatNome = Convert.ToString(registro["scat_nome"]);
                modelo.ScatCod = Convert.ToInt32(registro["scat_cod"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
