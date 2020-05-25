using Modelo; //Name space do modelo
using System;
using System.Data;
using System.Data.SqlClient; //referencia para o banco sql

namespace DAL
{
    public class DALParcelasVenda
    {
        private DALConexao conexao; // cria uma propriedade privada
        public DALParcelasVenda(DALConexao cx) //criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //=============================================================================================================================================================
        //Metodo para incluir
        public void Incluir(ModeloParcelasVenda modelo) //https://youtu.be/Y_D6dfyMAYs?t=409
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao; // Definir a conexão

                //criar a query para o insert do nome da categoria, utlizando parametro @nome, 
                cmd.CommandText = "INSERT INTO parcelasVenda (pve_cod, ven_cod, pve_datavecto, pve_valor ) " +
                                "VALUES (@pve_cod, @ven_cod, @pve_datavecto, @pve_valor)"; //o selelct retorno 

                //adiciona o valor da variavel ao parametro 
                cmd.Parameters.AddWithValue("@pve_cod", modelo.PveCod);
                cmd.Parameters.AddWithValue("@ven_cod", modelo.VenCod);
                cmd.Parameters.AddWithValue("@pve_valor", modelo.PveValor);
                //data de vencimento: ja trata tipo de valor SQL
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.DateTime);
                //Valida data de vencimento, se informado ou não: // https://youtu.be/Y_D6dfyMAYs?t=1506
                if (modelo.PveDatavecto == null)//se nao informar a data,
                {
                    cmd.Parameters["@pve_datavecto"].Value = DBNull.Value;//parametro data recebe valor null
                }
                else
                {
                    cmd.Parameters["@pve_datavecto"].Value = modelo.PveDatavecto;
                }

                //conecta ao banco
                conexao.Conectar();
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
                conexao.Desconectar();
            }
        }

        //Metodo para alterar ===================================================================
        public void Alterar(ModeloParcelasVenda modelo) // https://youtu.be/Y_D6dfyMAYs?t=943
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o cat_Cod for igual ao codigo 
                cmd.CommandText = "UPDATE parcelasVenda SET pve_valor = @pve_valor, pve_datavecto = @pve_datavecto, " +
                                   "pve_datapagto = @pve_datapagto WHERE pve_cod = @pve_cod AND ven_cod = @ven_cod;";

                //------------------------------------------------------------------------------------------------------------------------------------
                //adiciona o valor da variavel ao parametro
                //------------------------------------------------------------------------------------------------------------------------------------
                cmd.Parameters.AddWithValue("@pve_cod", modelo.PveCod);
                cmd.Parameters.AddWithValue("@ven_cod", modelo.VenCod);
                cmd.Parameters.AddWithValue("@pve_valor", modelo.PveValor);
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@pve_datavecto"].Value = modelo.PveDatavecto;//armazena a data no parametro 

                cmd.Parameters.Add("@pve_datapagto", System.Data.SqlDbType.DateTime);
                //Valida data de pagamento, se informado ou não:
                if (modelo.PveDatapagto == null)//se nao informar a data,
                {
                    cmd.Parameters["@pve_datapagto"].Value = DBNull.Value;//parametro data recebe valor null
                }
                else
                {
                    cmd.Parameters["@pve_datapagto"].Value = modelo.PveDatapagto;
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

        //Metodo para Excluir um item ==================================================================================================
        public void Excluir(ModeloParcelasVenda modelo) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o excluir o item conforme codigo recebido,
                cmd.CommandText = "DELETE FROM parcelasVenda WHERE pve_cod = @pve_cod AND ven_cod = @ven_cod;";

                //adicona os parametros:
                cmd.Parameters.AddWithValue("@pve_cod", modelo.PveCod);
                cmd.Parameters.AddWithValue("@ven_cod", modelo.VenCod);

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

        //Metodo para Excluir todas as parcelas ========================================================================================
        public void ExcluirTotasAsParcelas(int ComCod) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o excluir todas as conforme codigo recebido,
                cmd.CommandText = "DELETE FROM parcelasVenda WHERE ven_cod = @ven_cod;";

                //adicona os parametros:
                cmd.Parameters.AddWithValue("@ven_cod", ComCod);

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

        //localizar por CODIGO DO FORNECEDOR  SOBRECARGA 1 ==============================================================================
        public DataTable Localizar(int VenCod) // https://youtu.be/l9-D9LHZD3o?t=214
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM parcelasVenda WHERE ven_cod LIKE '%" +
                                                     VenCod + "%'", conexao.StringConexao);

            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //Metodo para carregar informações do BD Tabela Venda =========================================================================
        public ModeloParcelasVenda CarregaModeloParcelasVenda(int PcoCod, int VenCod) // recebeo o codigo do item que se quer carregar
        {
            ModeloParcelasVenda modelo = new ModeloParcelasVenda();// instacio o modelo
            //criar a query para o carregar o item conforme codigo recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM parcelasVenda WHERE pve_cod = @PcoCod AND ven_cod = @ComCod";//selecione todos os itens da categori onde o codigo da categira seja igual ao informado pelo usuario

            //Definir o valor do parametro - codigo do intem recebido 
            cmd.Parameters.AddWithValue("@PcoCod", PcoCod);
            cmd.Parameters.AddWithValue("@ComCod", VenCod);

            //conecta ao banco
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader(); //ExecuteReader: quando quer retornor muita informações da consulta  
            //SqlDataReader: obejeto para ler e acessar as infornmações retornadas
            //verifica se existe alguma lina dentro o objeto, se existir linha, le as informações dela, e carrega cada campo em suas respectivas colunas
            if (registro.HasRows) // https://youtu.be/l9-D9LHZD3o?t=446
            {
                registro.Read();//le os dado do registro
                //coloca o valor da coluna do objeto regitro na variavel do modelo
                modelo.VenCod = Convert.ToInt32(registro["ven_cod"]);
                modelo.PveCod = Convert.ToInt32(registro["pve_cod"]);
                modelo.PveDatapagto = Convert.ToDateTime(registro["pve_datapagto"]);
                modelo.PveDatavecto = Convert.ToDateTime(registro["pve_datavecto"]);
                modelo.PveValor = Convert.ToDouble(registro["pve_valor"]);
            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo categoria contem os campos da tabela de catagoria
        }
    }
}
