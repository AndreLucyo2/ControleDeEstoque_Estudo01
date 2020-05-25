using Modelo; //Name space do modelo
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALFornecedor  //fazer validação de uma fornecedro pessoa fizica!!
    {
        private DALConexao conexao; // cria uma propriedade privada
        public DALFornecedor(DALConexao cx) //criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //Metodo para incluir uma categoria ==============================================================================
        public void Incluir(ModeloFornecedor modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao; // Definir a conexão

                //criar a query para o insert do nome da catagoria, utlizando parametro @nome, 
                cmd.CommandText = "INSERT INTO fornecedor(for_nome, for_cnpj, for_ie, for_rsocial, " +
                    "for_cep, for_endereco, for_bairro, for_fone, for_cel, for_email, for_endnumero, for_cidade, for_estado) " +
                    "VALUES (@For_nome, @For_cpfcnpj, @For_rgie, @For_rsocial, @For_cep, @For_endereco, " +
                    "@For_bairro, @For_fone, @For_cel, @For_email, @For_endnumero, @For_cidade, @For_estado); SELECT @@IDENTITY;"; //o selelct retorno COLUNA IDENTIDADE 

                //adiciona valores aos PARAMETROS DA QUERY usar o excel para agilisar a criação de parametros
                cmd.Parameters.AddWithValue("@For_nome", modelo.ForNome);
                cmd.Parameters.AddWithValue("@For_cpfcnpj", modelo.ForCnpj);
                cmd.Parameters.AddWithValue("@For_rgie", modelo.ForIe);
                cmd.Parameters.AddWithValue("@For_rsocial", modelo.ForRSocial);   
                cmd.Parameters.AddWithValue("@For_cep", modelo.ForCep);
                cmd.Parameters.AddWithValue("@For_endereco", modelo.ForEndereco);
                cmd.Parameters.AddWithValue("@For_bairro", modelo.ForBairro);
                cmd.Parameters.AddWithValue("@For_fone", modelo.ForFone);
                cmd.Parameters.AddWithValue("@For_cel", modelo.ForCel);
                cmd.Parameters.AddWithValue("@For_email", modelo.ForEmail);
                cmd.Parameters.AddWithValue("@For_endnumero", modelo.ForEndNumero);
                cmd.Parameters.AddWithValue("@For_cidade", modelo.ForCidade);
                cmd.Parameters.AddWithValue("@For_estado", modelo.ForEstado);

                //conecta ao banco
                conexao.Conectar();
                //CHAVE PRIMERIA - recebe o valor retornado pelo selecat identity
                modelo.ForCod = Convert.ToInt32(cmd.ExecuteScalar());//ExecuteScalar = quando quer retornor poucs informações da consulta

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

        //Metodo para alterar uma categoria ==============================================================================
        public void Alterar(ModeloFornecedor modelo) //aula 03
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o cat_Cod for igual ao codigo 
                cmd.CommandText = "UPDATE fornecedor SET for_nome = @For_nome, for_cnpj = @For_cnpj, for_ie = @For_ie, for_rsocial = @For_rsocial, " +
                                  "for_cep = @For_cep, for_endereco = @For_endereco, for_bairro = @For_bairro, for_fone = @For_fone, " +
                                  "for_cel = @For_cel, for_email = @For_email, for_endnumero = @For_endnumero, for_cidade = @For_cidade, for_estado = @For_estado " +
                                  "WHERE for_cod = @codigo;";

                //informa os dois parametros do comando
                cmd.Parameters.AddWithValue("@codigo", modelo.ForCod); //ver
                cmd.Parameters.AddWithValue("@For_nome", modelo.ForNome);
                cmd.Parameters.AddWithValue("@For_cnpj", modelo.ForCnpj);
                cmd.Parameters.AddWithValue("@For_ie", modelo.ForIe);
                cmd.Parameters.AddWithValue("@For_rsocial", modelo.ForRSocial);
                cmd.Parameters.AddWithValue("@For_cep", modelo.ForCep);
                cmd.Parameters.AddWithValue("@For_endereco", modelo.ForEndereco);
                cmd.Parameters.AddWithValue("@For_bairro", modelo.ForBairro);
                cmd.Parameters.AddWithValue("@For_fone", modelo.ForFone);
                cmd.Parameters.AddWithValue("@For_cel", modelo.ForCel);
                cmd.Parameters.AddWithValue("@For_email", modelo.ForEmail);
                cmd.Parameters.AddWithValue("@For_endnumero", modelo.ForEndNumero);
                cmd.Parameters.AddWithValue("@For_cidade", modelo.ForCidade);
                cmd.Parameters.AddWithValue("@For_estado", modelo.ForEstado);

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

        //Metodo para Excluir um item ====================================================================================
        public void Excluir(int codigo) //recebe como parametro o codigo do item que se quer excluir 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o excluir o item conforme codigo recebido,
                cmd.CommandText = "DELETE FROM fornecedor WHERE for_cod = @codigo;";

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

        //Metodo para Localizar um cadastro - GENERICO/REUTILIZAVEL ======================================================
        //fazer consulta BASEADA NO nome: -- d
        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fornecedor WHERE for_nome LIKE '%" +
                                                     valor + "%'", conexao.StringConexao);
            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //Metodo para Localizar Fornecedor pelo nome ======================================================
        public DataTable LocalizarPorNome(String valor) //https://youtu.be/VmTY593Mrqc?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=534
        {
            return Localizar(valor);//usa o metodo localizar como base
        }

        //Metodo para Localizar um Fornecedor pelo CNPJ ==================================================================
        //fazer consulta por CNPJ:
        public DataTable LocalizarCNPJ(String valor)
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fornecedor WHERE for_cnpj LIKE '%" +
                                                     valor + "%'", conexao.StringConexao);
            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //Metodo para carregar informações do BD Tabela Catagoria ======================================================== aula 04
        public ModeloFornecedor CarregaModeloFornecedor(int codigo) // recebeo o codigo do item que se quer carregar
        {
            ModeloFornecedor modelo = new ModeloFornecedor();// instacio o modelo
            //criar a query para o carregar o item conforme codigo recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM fornecedor WHERE for_cod = @codigo";//selecione todos os Fornecedor onde o codigo co Fornecedor seja igual ao informado pelo usuario

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
                modelo.ForCod = Convert.ToInt32(registro["for_cod"]);
                modelo.ForNome = Convert.ToString(registro["for_nome"]);
                modelo.ForCnpj = Convert.ToString(registro["for_cnpj"]);
                modelo.ForIe = Convert.ToString(registro["for_ie"]);
                modelo.ForRSocial = Convert.ToString(registro["for_rsocial"]);                
                modelo.ForCep = Convert.ToString(registro["for_cep"]);
                modelo.ForEndereco = Convert.ToString(registro["for_endereco"]);
                modelo.ForBairro = Convert.ToString(registro["for_bairro"]);
                modelo.ForFone = Convert.ToString(registro["for_fone"]);
                modelo.ForCel = Convert.ToString(registro["for_cel"]);
                modelo.ForEmail = Convert.ToString(registro["for_email"]);
                modelo.ForEndNumero = Convert.ToString(registro["for_endnumero"]);
                modelo.ForCidade = Convert.ToString(registro["for_cidade"]);
                modelo.ForEstado = Convert.ToString(registro["for_estado"]);

            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo do Fornecedor contem os campos da tabela de catagoria
        }

        //sobrecarga do metodo carregar Pode ser usado para validar cpfCnpj duplicado  ============================== Aula 51 - https://youtu.be/dwZVxyLSCQw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1674
        public ModeloFornecedor CarregaModeloFornecedor(string Cnpj) // recebeo uma string cpfCnpj do Fornecedor que se quer carregar
        {
            ModeloFornecedor modelo = new ModeloFornecedor();// instacio o modelo
            //criar a query para o carregar o item conforme cpfCnpj recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM fornecedor WHERE For_cnpj = @Cnpj";//selecione todos os Fornecedor onde o codigo co Fornecedor seja igual ao informado pelo usuario

            //Definir o valor do parametro - codigo do intem recebido 
            cmd.Parameters.AddWithValue("@Cnpj", Cnpj);

            //conecta ao banco
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader(); //ExecuteReader: quando quer retornor muita informações da consulta  
            //SqlDataReader: obejeto para ler e acessar as infornmações retornadas
            //verifica se existe alguma lina dentro o objeto, se existir linha, le as informações dela, e carrega cada campo em suas respectivas colunas
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ForCod = Convert.ToInt32(registro["for_cod"]);
                modelo.ForNome = Convert.ToString(registro["for_nome"]);
                modelo.ForCnpj = Convert.ToString(registro["for_cnpj"]);
                modelo.ForIe = Convert.ToString(registro["for_rgie"]);
                modelo.ForRSocial = Convert.ToString(registro["for_rsocial"]);
                modelo.ForCep = Convert.ToString(registro["for_cep"]);
                modelo.ForEndereco = Convert.ToString(registro["for_endereco"]);
                modelo.ForBairro = Convert.ToString(registro["for_bairro"]);
                modelo.ForFone = Convert.ToString(registro["for_fone"]);
                modelo.ForCel = Convert.ToString(registro["for_cel"]);
                modelo.ForEmail = Convert.ToString(registro["for_email"]);
                modelo.ForEndNumero = Convert.ToString(registro["for_endnumero"]);
                modelo.ForCidade = Convert.ToString(registro["for_cidade"]);
                modelo.ForEstado = Convert.ToString(registro["for_estado"]);

            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo do Fornecedor contem os campos da tabela de catagoria
        }


    }
}
