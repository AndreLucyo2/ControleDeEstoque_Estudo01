using Modelo; //Name space do modelo
using System;
using System.Data;
using System.Data.SqlClient; //referencia para o banco sql

namespace DAL
{
    public class DALParcelasCompra
    {
        private DALConexao conexao; // cria uma propriedade privada
        public DALParcelasCompra(DALConexao cx) //criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //=============================================================================================================================================================
        //Metodo para incluir
        public void Incluir(ModeloParcelasCompra modelo) //https://youtu.be/Y_D6dfyMAYs?t=409
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao; // Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=904

                //criar a query para o insert do nome da categoria, utlizando parametro @nome, 
                cmd.CommandText = "INSERT INTO parcelascompra (pco_cod, com_cod, pco_datavecto, pco_valor ) " +
                                "VALUES (@pco_cod, @com_cod, @pco_datavecto, @pco_valor)"; //o selelct retorno 

                //adiciona o valor da variavel ao parametro 
                cmd.Parameters.AddWithValue("@pco_cod", modelo.PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pco_valor", modelo.PcoValor);
                //data de vencimento: ja trata tipo de valor SQL
                cmd.Parameters.Add("@pco_datavecto", System.Data.SqlDbType.DateTime);
                //Valida data de vencimento, se informado ou não: // https://youtu.be/Y_D6dfyMAYs?t=1506
                if (modelo.PcoDatavecto == null)//se nao informar a data,
                {
                    cmd.Parameters["@pco_datavecto"].Value = DBNull.Value;//parametro data recebe valor null
                }
                else
                {
                    cmd.Parameters["@pco_datavecto"].Value = modelo.PcoDatavecto;
                }

                //conecta ao banco
                //conexao.Conectar();
                //recebe o valor retornado pelo selecat identity
                //cmd.ExecuteScalar();//ExecuteScalar = quando quer retornor poucs informações da consulta
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

        //Metodo para alterar ===================================================================
        public void Alterar(ModeloParcelasCompra modelo) // https://youtu.be/Y_D6dfyMAYs?t=943
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o cat_Cod for igual ao codigo 
                cmd.CommandText = "UPDATE parcelascompra SET pco_valor = @pco_valor, pco_datavecto = @pco_datavecto, " +
                                   "pco_datapagto = @pco_datapagto WHERE pco_cod = @pco_cod AND com_cod = @com_cod;";

                //------------------------------------------------------------------------------------------------------------------------------------
                //adiciona o valor da variavel ao parametro
                //------------------------------------------------------------------------------------------------------------------------------------
                cmd.Parameters.AddWithValue("@pco_cod", modelo.PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pco_valor", modelo.PcoValor);                
                cmd.Parameters.Add("@pco_datavecto", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@pco_datavecto"].Value = modelo.PcoDatavecto;//armazena a data no parametro 
                
                cmd.Parameters.Add("@pco_datapagto", System.Data.SqlDbType.DateTime);
                //Valida data de pagamento, se informado ou não:
                if (modelo.PcoDatapagto == null)//se nao informar a data,
                {
                    cmd.Parameters["@pco_datapagto"].Value = DBNull.Value;//parametro data recebe valor null
                }
                else
                {
                    cmd.Parameters["@pco_datapagto"].Value = modelo.PcoDatapagto;
                }
               
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

        //Metodo para Excluir um item =====================================================================================================
        public void Excluir(ModeloParcelasCompra modelo) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o excluir o item conforme codigo recebido,
                cmd.CommandText = "DELETE FROM parcelascompra WHERE pco_cod = @pco_cod AND com_cod = @com_cod;";

                //adicona os parametros:
                cmd.Parameters.AddWithValue("@pco_cod", modelo.PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);

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

        //Metodo para Excluir todas as parcelas ===========================================================================================
        public void ExcluirTotasAsParcelas(int ComCod) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão
                cmd.Transaction = conexao.ObjetoTransacao;//https://youtu.be/fA_T1ywEXqw?t=753

                //criar a query para o excluir todas as conforme codigo recebido,
                cmd.CommandText = "DELETE FROM parcelascompra WHERE com_cod = @com_cod;";

                //adicona os parametros:
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

        //localizar por CODIGO DO FORNECEDOR  SOBRECARGA 1 ================================================================================
        public DataTable Localizar(int ComCod) // https://youtu.be/l9-D9LHZD3o?t=214
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM parcelascompra WHERE com_cod = '" +
                                                     ComCod + "'", conexao.StringConexao);

            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //Metodo para carregar informações do BD Tabela compra ============================================================================
        public ModeloParcelasCompra CarregaModeloParcelasCompra(int PcoCod, int ComCod) // recebeo o codigo do item que se quer carregar
        {
            ModeloParcelasCompra modelo = new ModeloParcelasCompra();// instacio o modelo
            //criar a query para o carregar o item conforme codigo recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM parcelascompra WHERE pco_cod = @PcoCod AND com_cod = @ComCod";//selecione todos os itens da categori onde o codigo da categira seja igual ao informado pelo usuario

            //Definir o valor do parametro - codigo do intem recebido 
            cmd.Parameters.AddWithValue("@PcoCod", PcoCod);
            cmd.Parameters.AddWithValue("@ComCod", ComCod);

            //conecta ao banco
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader(); //ExecuteReader: quando quer retornor muita informações da consulta  
            //SqlDataReader: obejeto para ler e acessar as infornmações retornadas
            //verifica se existe alguma lina dentro o objeto, se existir linha, le as informações dela, e carrega cada campo em suas respectivas colunas
            if (registro.HasRows) // https://youtu.be/l9-D9LHZD3o?t=446
            {
                registro.Read();//le os dado do registro
                //coloca o valor da coluna do objeto regitro na variavel do modelo
                modelo.ComCod = Convert.ToInt32(registro["com_cod"]);
                modelo.PcoCod = Convert.ToInt32(registro["pco_cod"]);
                modelo.PcoDatapagto = Convert.ToDateTime(registro["pco_datapagto"]);
                modelo.PcoDatavecto = Convert.ToDateTime(registro["pco_datavecto"]);
                modelo.PcoValor = Convert.ToDouble(registro["pco_valor"]);
            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo categoria contem os campos da tabela de catagoria
        }

        //Metodo para Efetuar pagamento da parcela de compra ==============================================================================
        public void EfetuarPagamento(int ComCod, int PcoCod, DateTime dtPagto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o update utlizando valor do parametros
                cmd.CommandText = "UPDATE parcelascompra SET pco_datapagto = @pco_datapagto "+
                                  "WHERE pco_cod = @pco_cod AND com_cod = @com_cod";

                //-------------------------------------------------------------------------------------------------------------------------
                //adiciona o valor da variavel ao parametro
                //-------------------------------------------------------------------------------------------------------------------------
                cmd.Parameters.AddWithValue("@pco_cod", PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", ComCod);
                //parametro data de pagamento:
                cmd.Parameters.Add("@pco_datapagto", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@pco_datapagto"].Value = dtPagto;

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

        //Metodo para Efetuar pagamento da parcela de compra ==============================================================================
        public void CancelarPagamento(int ComCod, int PcoCod, DateTime dtPagto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o update utlizando valor do parametros
                cmd.CommandText = "UPDATE parcelascompra SET pco_datapagto = NULL " +
                                  "WHERE pco_cod = @pco_cod AND com_cod = @com_cod";

                //-------------------------------------------------------------------------------------------------------------------------
                //adiciona o valor da variavel ao parametro
                //-------------------------------------------------------------------------------------------------------------------------
                cmd.Parameters.AddWithValue("@pco_cod", PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", ComCod);

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
    }
}
