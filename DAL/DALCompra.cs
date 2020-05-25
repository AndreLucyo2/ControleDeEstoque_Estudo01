using Modelo; //Name space do modelo
using System;
using System.Data;
using System.Data.SqlClient; //referencia para o banco sql

namespace DAL
{
    public class DALCompra
    {
        private DALConexao conexao; // cria uma propriedade privada
        public DALCompra(DALConexao cx) //criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //Metodo para incluir UMA COMPRA ===================================================================
        public void Incluir(ModeloCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao; // Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=753

                //criar a query para o inserir 
                cmd.CommandText = "INSERT INTO compra (com_data, com_nfiscal, com_total, com_nparcelas, com_status, for_cod, tpa_cod) "+
                                   "VALUES (@com_data, @com_nfiscal, @com_total, @com_nparcelas, @com_status, @for_cod, @tpa_cod); SELECT @@IDENTITY;"; //o selelct retorno 
                //------------------------------------------------------------------------------------------------------------------------------------
                //adiciona o valor da variavel ao parametro
                //------------------------------------------------------------------------------------------------------------------------------------
                //QUANDO O VALOR FOR TIPO DATA:
                cmd.Parameters.Add("@com_data", System.Data.SqlDbType.DateTime);//INFORMAR O TIPO DE DADO QUE O PARAMETRO VAI ARMAZENAR - CONFORME O BANCO
                cmd.Parameters["@com_data"].Value = modelo.ComData;//armazena a data no parametro // https://youtu.be/6pAcMAdranA?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=662
                //QUANDO DADOS DO TIPO PRIMITIVO:
                cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNfiscal);
                cmd.Parameters.AddWithValue("@com_total", modelo.ComValorTotal);
                cmd.Parameters.AddWithValue("@com_nparcelas", modelo.ComNparcelas);
                cmd.Parameters.AddWithValue("@com_status", modelo.ComStatus);
                cmd.Parameters.AddWithValue("@for_cod", modelo.ForCod);
                cmd.Parameters.AddWithValue("@tpa_cod", modelo.TpaCod);

                //conecta ao banco https://youtu.be/fA_T1ywEXqw?t=516
                //conexao.Conectar(); 
                //recebe o valor retornado pelo selecat identity
                modelo.ComCod = Convert.ToInt32(cmd.ExecuteScalar());//ExecuteScalar = quando quer retornor poucOs informações da consulta/ RETORNA O CODIGO 

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

        //Metodo para alterar uma categoria ===================================================================
        public void Alterar(ModeloCompra modelo) //aula 03
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=753

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o cat_Cod for igual ao codigo 
                cmd.CommandText = "UPDATE compra SET com_data = @com_data, com_nfiscal = @com_nfiscal, com_total = @com_total, com_nparcelas = @com_nparcelas, "+
                                   "com_status = @com_status, for_cod = @for_cod, tpa_cod = @tpa_cod WHERE com_cod = @codigo;";

                //------------------------------------------------------------------------------------------------------------------------------------
                //adiciona o valor da variavel ao parametro
                //------------------------------------------------------------------------------------------------------------------------------------
                //INFORMA O CODIGO:
                cmd.Parameters.AddWithValue("@codigo", modelo.ComCod);
                //QUANDO O VALOR FOR TIPO DATA:
                cmd.Parameters.Add("@com_data", System.Data.SqlDbType.DateTime);//INFORMAR O TIPO DE DADO QUE O PARAMETRO VAI ARMAZENAR - CONFORME O BANCO
                cmd.Parameters["@com_data"].Value = modelo.ComData;//armazena a data no parametro // https://youtu.be/6pAcMAdranA?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=662
                //QUANDO DADOS DO TIPO PRIMITIVO:
                cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNfiscal);
                cmd.Parameters.AddWithValue("@com_total", modelo.ComValorTotal);
                cmd.Parameters.AddWithValue("@com_nparcelas", modelo.ComNparcelas);
                cmd.Parameters.AddWithValue("@com_status", modelo.ComStatus);
                cmd.Parameters.AddWithValue("@for_cod", modelo.ForCod);
                cmd.Parameters.AddWithValue("@tpa_cod", modelo.TpaCod);

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

        //Metodo para Excluir um item ===================================================================
        public void Excluir(int codigo) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=753

                //criar a query para o excluir o item conforme codigo recebido,
                cmd.CommandText = "DELETE FROM compra WHERE com_cod = @codigo;";

                //Definir o valor do parametro - codigo do intem recebido 
                cmd.Parameters.AddWithValue("@codigo", codigo);

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

        //localizar todas as compras - SOBRECARGA 1  =========================================================================================================================
        public DataTable Localizar() // https://youtu.be/r_vR5Ht_2nY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=587
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.com_cod, c.com_data, c.com_nfiscal, c.com_total, c.com_nparcelas, c.com_status,  c.tpa_cod , c.for_cod, f.for_nome " +
                                                   "FROM compra AS c INNER JOIN fornecedor AS f ON c.for_cod = f.for_cod  ORDER BY c.com_cod ", conexao.StringConexao);

            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //localizar por CODIGO DO FORNECEDOR  SOBRECARGA 2 ====================================================================================================
        public DataTable Localizar(int codigo) // https://youtu.be/W3zOak9J1D0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=130
        {
            DataTable tabela = new DataTable();//cria a datatable...

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM compra WHERE for_cod LIKE '%" + codigo.ToString() + "%'", conexao.StringConexao);
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.com_cod, c.com_data, c.com_nfiscal, c.com_total, c.com_nparcelas, c.com_status,  c.tpa_cod , c.for_cod, f.for_nome " +
                                                   "FROM compra AS c INNER JOIN fornecedor AS f ON c.for_cod = f.for_cod " +
                                                   "WHERE f.for_cod LIKE '" + codigo.ToString() + "'", conexao.StringConexao);
            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //localizar por NOME DO FORNECEDOR SOBRECARGA 3 =======================================================================================================
        public DataTable Localizar(string nome) // https://youtu.be/W3zOak9J1D0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=130
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.com_cod, c.com_data, c.com_nfiscal, c.com_total, c.com_nparcelas, c.com_status,  c.tpa_cod , c.for_cod, f.for_nome "+
                                                   "FROM compra AS c INNER JOIN fornecedor AS f ON c.for_cod = f.for_cod "+
                                                   "WHERE f.for_nome LIKE '%" + nome + "%'", conexao.StringConexao);

            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //localizar por DATA INICIAL E FINAL SOBRECARGA 4 =====================================================================================================
        public DataTable Localizar(DateTime DTinicial, DateTime DTfinal) //https://youtu.be/wt6KgjodhC0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=493
        {
            DataTable tabela = new DataTable();//cria a datatable
            SqlCommand cmd = new SqlCommand();//quem vai executar o comando no banco
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT c.com_cod, c.com_data, c.com_nfiscal, c.com_total, c.com_nparcelas, c.com_status,  c.tpa_cod , c.for_cod, f.for_nome " +
                              "FROM compra AS c INNER JOIN fornecedor AS f ON c.for_cod = f.for_cod " +
                              "WHERE c.com_data BETWEEN @dtIni AND @dtFim";

            //PARAMETRO DATA INICIAL:
            cmd.Parameters.Add("@dtIni", System.Data.SqlDbType.DateTime);//INFORMAR O TIPO DE DADO QUE O PARAMETRO VAI ARMAZENAR - CONFORME O BANCO
            cmd.Parameters["@dtIni"].Value = DTinicial;//armazena a data no parametro //
            
            //PARAMETRO DATA FINAL:
            //AJUSTE PARA FILTRAR INTERVALO DE UM DIA:
            DTfinal = DTfinal.AddDays(1);//ADICIONA 1 DIA
            cmd.Parameters.Add("@dtFim", System.Data.SqlDbType.DateTime);//INFORMAR O TIPO DE DADO QUE O PARAMETRO VAI ARMAZENAR - CONFORME O BANCO
            cmd.Parameters["@dtFim"].Value = DTfinal;//armazena a data no parametro //

            //conecta ao banco
            conexao.Conectar();

            //passar o comando para SqlDataAdapter 
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //desconecta do banco
            conexao.Desconectar();

            //retorna a tabela
            return tabela;
        }

        //localizar todas as compras  com parcelas em aberto SOBRECARGA 5 =================================================================================================
        public DataTable LocalizarProParcelasEmAberto(bool ParcAberto) // https://youtu.be/r_vR5Ht_2nY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=587
        {
            string Busca;

            DataTable tabela = new DataTable();//cria a datatable

            //opção de ver parcelas pagas ou em aberto:
            if (ParcAberto)
            {
                //parcelas sem data de pagamento: em aberto
                Busca = "IS NULL";
            }
            else
            {
                //parcelas com data de pagamento - dado baixa
                Busca = "IS NOT NULL";
            }

            //cria o comando , selecione todas as compras que tenham alguma parcela sem data de pagamento [pco_datapagto IS NULL]
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT c.com_cod, c.com_data, c.com_nfiscal, c.com_total, c.com_nparcelas, c.com_status,  c.tpa_cod , c.for_cod, f.for_nome " +
                                                   "FROM compra AS c INNER JOIN fornecedor AS f ON c.for_cod = f.for_cod " +
                                                   "INNER JOIN parcelascompra AS p ON c.com_cod = p.com_cod  WHERE pco_datapagto " + Busca , conexao.StringConexao);

            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //CONTAGEM DE PARCELAS EM ABERTO: // https://youtu.be/-lusZJMWlX0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1127
        public int QuantidadeParcelasEmAberto(int Codigo)
        {
            //vai retornar o numero de parcelas sem data de pagamento
            int Qtde = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=753

                //criar a query para o excluir o item conforme codigo recebido,
                cmd.CommandText = "SELECT COUNT(com_cod) FROM parcelascompra WHERE com_cod = @codigo AND pco_datapagto IS NULL";

                //Definir o valor do parametro - codigo do intem recebido 
                cmd.Parameters.AddWithValue("@codigo", Codigo);

                //conecta ao banco
                //conexao.Conectar();
                Qtde = Convert.ToInt32(cmd.ExecuteScalar());
                
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
            //retorna o numero de parcelas:
            return Qtde;
        }

        //CONTAGEM DE PARCELAS EM ABERTO: // https://youtu.be/-lusZJMWlX0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1127
        public int QuantidadeParcelasPagas(int Codigo)
        {
            //vai retornar o numero de parcelas sem data de pagamento
            int Qtde = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=753

                //criar a query para o excluir o item conforme codigo recebido,
                cmd.CommandText = "SELECT COUNT(com_cod) FROM parcelascompra WHERE com_cod = @codigo AND pco_datapagto IS NOT NULL";

                //Definir o valor do parametro - codigo do intem recebido 
                cmd.Parameters.AddWithValue("@codigo", Codigo);

                //conecta ao banco
                //conexao.Conectar();
                Qtde = Convert.ToInt32(cmd.ExecuteScalar());

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
            //retorna o numero de parcelas:
            return Qtde;
        }

        //Metodo para carregar informações do BD Tabela compra ==========================================================- https://youtu.be/CNJNi9CGe8o?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=164
        public ModeloCompra CarregaModeloCompra(int codigo) // recebeo o codigo do item que se quer carregar
        {
            ModeloCompra modelo = new ModeloCompra();// instacio o modelo
            //criar a query para o carregar o item conforme codigo recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM compra WHERE com_cod = @codigo";//selecione todos os itens da categori onde o codigo da categira seja igual ao informado pelo usuario

            //Definir o valor do parametro - codigo do intem recebido 
            cmd.Parameters.AddWithValue("@codigo", codigo);

            //conecta ao banco
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader(); //ExecuteReader: quando quer retornor muita informações da consulta  
            //SqlDataReader: obejeto para ler e acessar as infornmações retornadas
            //verifica se existe alguma lina dentro o objeto, se existir linha, le as informações dela, e carrega cada campo em suas respectivas colunas
            if (registro.HasRows)
            {
                registro.Read();//le os dado do registro
                //coloca o valor da coluna do objeto regitro na variavel do modelo
                modelo.ComCod = Convert.ToInt32(registro["com_cod"]);
                modelo.ComData = Convert.ToDateTime(registro["com_data"]);//data atual
                modelo.ComNfiscal = Convert.ToInt32(registro["com_nfiscal"]);//da erro se nota nao for informada
                modelo.ComValorTotal = Convert.ToDouble(registro["com_total"]);
                modelo.ComNparcelas = Convert.ToInt32(registro["com_nparcelas"]);
                modelo.ComStatus = Convert.ToString(registro["com_status"]);
                modelo.ForCod = Convert.ToInt32(registro["for_cod"]);
                modelo.TpaCod = Convert.ToInt32(registro["tpa_cod"]);
            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo categoria contem os campos da tabela de catagoria
        }
    }
}
