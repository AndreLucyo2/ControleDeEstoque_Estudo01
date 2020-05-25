using Modelo; //Name space do modelo
using System;
using System.Data;
using System.Data.SqlClient; //referencia para o banco sql

namespace DAL
{
    public class DALItensCompra
    {
        private DALConexao conexao; // cria uma propriedade privada
        public DALItensCompra(DALConexao cx) //criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //=============================================================================================================================================================
        //Metodo para incluir uma categoria 
        public void Incluir(ModeloItensCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao; // Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=874

                //criar a query para o insert do nome da categoria, utlizando parametro @nome, 
                cmd.CommandText = "INSERT INTO itenscompra (itc_cod, itc_qtde, itc_valor, com_cod, pro_cod) " +
                                "VALUES (@itc_cod, @itc_qtde, @itc_valor, @com_cod, @pro_cod)"; //o selelct retorno                

                //adiciona o valor da variavel ao parametro 
                cmd.Parameters.AddWithValue("@itc_cod", modelo.ItcCod);
                cmd.Parameters.AddWithValue("@itc_qtde", modelo.ItcQtde);
                cmd.Parameters.AddWithValue("@itc_valor", modelo.ItcValor);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);

                //conecta ao banco https://youtu.be/fA_T1ywEXqw?t=869
                //conexao.Conectar();

                //recebe o valor retornado pelo selecat identity
                //cmd.ExecuteScalar();//ExecuteScalar = quando quer retornor poucas informações da consulta
                //ou: https://youtu.be/uRVZ8LXnQ2M?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=498
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                //desconecta do banco
                //conexao.Desconectar();
            }
        }

        //=============================================================================================================================================================
        //Metodo para alterar uma categoria 
        public void Alterar(ModeloItensCompra modelo) //aula 03
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=874

                //pega todos od campos porem so vai alterar a qtd e o valor
                cmd.CommandText = "UPDATE itenscompra SET itc_qtde = @itc_qtde, itc_valor = @itc_valor " +
                                  "WHERE itc_cod = @itc_cod AND com_cod = @com_cod AND pro_cod = @pro_cod";//where ainhado, mais de uma condição

                //informa os dois parametros do comando
                //adiciona o valor da variavel ao parametro 
                cmd.Parameters.AddWithValue("@itc_cod", modelo.ItcCod);
                cmd.Parameters.AddWithValue("@itc_qtde", modelo.ItcQtde);
                cmd.Parameters.AddWithValue("@itc_valor", modelo.ItcValor);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);

                //conecta ao banco
                //conexao.Conectar();
                cmd.ExecuteNonQuery(); //ExecuteNonQuery = quando não quer ou nao vai retornor informações da consulta

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                //desconecta do banco
                //conexao.Desconectar();
            }
        }

        //=============================================================================================================================================================
        //Metodo para Excluir um item , usa o modelo pois precisar do cod da compra, item da compra e do codigo do produto
        public void Excluir(ModeloItensCompra modelo) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=874

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o cat_Cod for igual ao codigo 
                cmd.CommandText = "DELETE FROM itenscompra WHERE itc_cod = @itc_cod AND com_cod = @com_cod AND pro_cod = @pro_cod";//where ainhado

                //informa os dois parametros do comando //https://youtu.be/uRVZ8LXnQ2M?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=945
                //adiciona o valor da variavel ao parametro 
                cmd.Parameters.AddWithValue("@itc_cod", modelo.ItcCod);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);

                //conecta ao banco
                //conexao.Conectar();
                cmd.ExecuteNonQuery();//executa o comando que nao retorno valor
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                //desconecta do banco
                //conexao.Desconectar();
            }
        }

        //=============================================================================================================================================================
        //Metodo para Excluir um item , usa o modelo pois precisar do cod da compra, item da compra e do codigo do produto
        public void ExcluirTodosOsItens(int ComCod) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=753

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o cat_Cod for igual ao codigo 
                cmd.CommandText = "DELETE FROM itenscompra WHERE com_cod = @com_cod";

                //informa os dois parametros do comando 
                //adiciona o valor da variavel ao parametro                
                cmd.Parameters.AddWithValue("@com_cod", ComCod);                

                //conecta ao banco
                //conexao.Conectar();
                cmd.ExecuteNonQuery();//executa o comando que nao retorno valor
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally // tanto se der erro ou nao , ele sera executado
            {
                //desconecta do banco
                //conexao.Desconectar();
            }
        }

        //=============================================================================================================================================================
        //Metodo para Localizar um item busca pelo codigo da compra
        //retorna uma datatable, 
        public DataTable Localizar(int comcod)
        {
            DataTable tabela = new DataTable();//cria a datatable

            ////query sem nome do produto:
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM itenscompra WHERE com_cod LIKE " +
            //                                      "'" + comcod.ToString() + "'", conexao.StringConexao);

            //query com nome do produto: // https://youtu.be/vhfQkJ2pN80?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=974
            SqlDataAdapter da = new SqlDataAdapter("SELECT  i.com_cod, i.itc_cod, i.pro_cod, p.pro_nome, i.itc_qtde, i.itc_valor " +
                                                   "FROM itenscompra AS i INNER JOIN produto AS p ON p.pro_cod = i.pro_cod " +
                                                   "WHERE i.com_cod LIKE " + "'" + comcod.ToString() + "'", conexao.StringConexao);

            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //=============================================================================================================================================================
        //Metodo para carregar informações da compra, pega os tres campos chaves, para caarrgar ...
        public ModeloItensCompra CarregaModeloItensCompra(int ItcCod, int com_cod, int ProCod) // recebeo o codigo do item que se quer carregar
        {
            ModeloItensCompra modelo = new ModeloItensCompra();// instacio o modelo //https://youtu.be/uRVZ8LXnQ2M?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1259
            //criar a query para o carregar o item conforme codigo recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;
            cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=874

            //query sem nome do produto:
            cmd.CommandText = "SELECT itenscompra WEHERE itc_qtde = @itc_qtde, itc_valor = @itc_valor " +
                              "WHERE itc_cod = @itc_cod AND com_cod = @com_cod AND pro_cod = @pro_cod";//where ainhado

            //informa os dois parametros do comando
            //adiciona o valor da variavel ao parametro 
            cmd.Parameters.AddWithValue("@itc_cod", ItcCod);
            cmd.Parameters.AddWithValue("@com_cod", com_cod);
            cmd.Parameters.AddWithValue("@pro_cod", ProCod);
                                                           
            //conecta ao banco
            //conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader(); //ExecuteReader: quando quer retornor muita informações da consulta  
            //SqlDataReader: obejeto para ler e acessar as infornmações retornadas
            //verifica se existe alguma lina dentro o objeto, se existir linha, le as informações dela, e carrega cada campo em suas respectivas colunas
            if (registro.HasRows)
            {
                registro.Read(); // https://youtu.be/uRVZ8LXnQ2M?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1407
                modelo.ItcCod = ItcCod;
                modelo.ProCod = ProCod;
                modelo.ComCod = com_cod;
                modelo.ItcQtde = Convert.ToDouble(registro["itc_qtde"]);
                modelo.ItcValor = Convert.ToDouble(registro["itc_valor"]);
            } 
            
            //de modelo.ProCod);sconecta do banco
            //conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo categoria contem os campos da tabela de catagoria
        }
    }
}
