using Modelo; //Name space do modelo
using System;
using System.Data;
using System.Data.SqlClient; //referencia para o banco sql

namespace DAL
{
    public class DALCliente
    {
        private DALConexao conexao; // cria uma propriedade privada
        public DALCliente(DALConexao cx) //criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //Metodo para incluir uma categoria ==============================================================================
        public void Incluir(ModeloCliente modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao; // Definir a conexão

                //criar a query para o insert do nome da catagoria, utlizando parametro @nome, 
                cmd.CommandText = "INSERT INTO cliente(cli_nome, cli_cpfcnpj, cli_rgie, cli_rsocial, cli_tipo, " +
                    "cli_cep, cli_endereco, cli_bairro, cli_fone, cli_cel, cli_email, cli_endnumero, cli_cidade, cli_estado) " +
                    "VALUES (@cli_nome, @cli_cpfcnpj, @cli_rgie, @cli_rsocial, @cli_tipo, @cli_cep, @cli_endereco, "+
                    "@cli_bairro, @cli_fone, @cli_cel, @cli_email, @cli_endnumero, @cli_cidade, @cli_estado); SELECT @@IDENTITY;"; //o selelct retorno COLUNA IDENTIDADE 
                
                //adiciona valores aos PARAMETROS DA QUERY usar o excel para agilisar a criação de parametros
                cmd.Parameters.AddWithValue("@cli_nome", modelo.CliNome);
                cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.CliCpfCnpj);
                cmd.Parameters.AddWithValue("@cli_rgie", modelo.CliRgIe);
                cmd.Parameters.AddWithValue("@cli_rsocial", modelo.CliRSocial);
                cmd.Parameters.AddWithValue("@cli_tipo", modelo.CliTipo);
                cmd.Parameters.AddWithValue("@cli_cep", modelo.CliCep);
                cmd.Parameters.AddWithValue("@cli_endereco", modelo.CliEndereco);
                cmd.Parameters.AddWithValue("@cli_bairro", modelo.CliBairro);
                cmd.Parameters.AddWithValue("@cli_fone", modelo.CliFone);
                cmd.Parameters.AddWithValue("@cli_cel", modelo.CliCel);
                cmd.Parameters.AddWithValue("@cli_email", modelo.CliEmail);
                cmd.Parameters.AddWithValue("@cli_endnumero", modelo.CliEndNumero);
                cmd.Parameters.AddWithValue("@cli_cidade", modelo.CliCidade);
                cmd.Parameters.AddWithValue("@cli_estado", modelo.CliEstado);

                //conecta ao banco
                conexao.Conectar();
                //recebe o valor retornado pelo selecat identity
                modelo.CliCod = Convert.ToInt32(cmd.ExecuteScalar());//ExecuteScalar = quando quer retornor poucs informações da consulta

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
        public void Alterar(ModeloCliente modelo) //aula 03
        {
            try
            {
                SqlCommand cmd = new SqlCommand();// criar um comando SQL
                cmd.Connection = conexao.ObjetoConexao;// Definir a conexão

                //criar a query para o update no nome da catagoria, utlizando valor do parametro @nome, onde o cat_Cod for igual ao codigo 
                cmd.CommandText = "UPDATE cliente SET cli_nome = @cli_nome, cli_cpfcnpj = @cli_cpfcnpj, cli_rgie = @cli_rgie, cli_rsocial = @cli_rsocial, "+
                                  "cli_tipo = @cli_tipo, cli_cep = @cli_cep, cli_endereco = @cli_endereco, cli_bairro = @cli_bairro, cli_fone = @cli_fone, "+
                                  "cli_cel = @cli_cel, cli_email = @cli_email, cli_endnumero = @cli_endnumero, cli_cidade = @cli_cidade, cli_estado = @cli_estado "+
                                  "WHERE cli_cod = @codigo;";

                //informa os dois parametros do comando
                cmd.Parameters.AddWithValue("@codigo", modelo.CliCod); //ver
                cmd.Parameters.AddWithValue("@cli_nome", modelo.CliNome);
                cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.CliCpfCnpj);
                cmd.Parameters.AddWithValue("@cli_rgie", modelo.CliRgIe);
                cmd.Parameters.AddWithValue("@cli_rsocial", modelo.CliRSocial);
                cmd.Parameters.AddWithValue("@cli_tipo", modelo.CliTipo);
                cmd.Parameters.AddWithValue("@cli_cep", modelo.CliCep);
                cmd.Parameters.AddWithValue("@cli_endereco", modelo.CliEndereco);
                cmd.Parameters.AddWithValue("@cli_bairro", modelo.CliBairro);
                cmd.Parameters.AddWithValue("@cli_fone", modelo.CliFone);
                cmd.Parameters.AddWithValue("@cli_cel", modelo.CliCel);
                cmd.Parameters.AddWithValue("@cli_email", modelo.CliEmail);
                cmd.Parameters.AddWithValue("@cli_endnumero", modelo.CliEndNumero);
                cmd.Parameters.AddWithValue("@cli_cidade", modelo.CliCidade);
                cmd.Parameters.AddWithValue("@cli_estado", modelo.CliEstado);

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
                cmd.CommandText = "DELETE FROM cliente WHERE cli_cod = @codigo;";

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
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cliente WHERE cli_nome LIKE '%" +
                                                     valor + "%'", conexao.StringConexao);
            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //Metodo para Localizar cliente pelo nome ======================================================
        public DataTable LocalizarPorNome(String valor) //https://youtu.be/VmTY593Mrqc?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=534
        {
            return Localizar(valor);//usa o metodo localizar como base
        }

        //Metodo para Localizar um cliente pelo CPF/CNPJ ==================================================================
        //fazer consulta por CPF/CNPJ:
        public DataTable LocalizarCPFCNPJ(String valor)
        {
            DataTable tabela = new DataTable();//cria a datatable

            //cria o comando , selecione em todos os campos e retorne um valor que for parecido com o informado
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cliente WHERE cli_cpfcnpj LIKE '%" +
                                                     valor + "%'", conexao.StringConexao);
            //preenche a tabela com os dados localizados:
            da.Fill(tabela);

            //retorna a tabela
            return tabela;
        }

        //Metodo para carregar informações do BD Tabela Catagoria ======================================================== aula 04
        public ModeloCliente CarregaModeloCliente(int codigo) // recebeo o codigo do item que se quer carregar
        {
            ModeloCliente modelo = new ModeloCliente();// instacio o modelo
            //criar a query para o carregar o item conforme codigo recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM cliente WHERE cli_cod = @codigo";//selecione todos os cliente onde o codigo co cliente seja igual ao informado pelo usuario

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
                modelo.CliCod = Convert.ToInt32(registro["cli_cod"]);
                modelo.CliNome = Convert.ToString(registro["cli_nome"]);
                modelo.CliCpfCnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.CliRgIe = Convert.ToString(registro["cli_rgie"]);
                modelo.CliRSocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.CliTipo = Convert.ToString(registro["cli_tipo"]);
                modelo.CliCep = Convert.ToString(registro["cli_cep"]);
                modelo.CliEndereco = Convert.ToString(registro["cli_endereco"]);
                modelo.CliBairro = Convert.ToString(registro["cli_bairro"]);
                modelo.CliFone = Convert.ToString(registro["cli_fone"]);
                modelo.CliCel = Convert.ToString(registro["cli_cel"]);
                modelo.CliEmail = Convert.ToString(registro["cli_email"]);
                modelo.CliEndNumero = Convert.ToString(registro["cli_endnumero"]);
                modelo.CliCidade = Convert.ToString(registro["cli_cidade"]);
                modelo.CliEstado = Convert.ToString(registro["cli_estado"]);

            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo do cliente contem os campos da tabela de catagoria
        }

        //sobrecarga do metodo carregar Pode ser usado para validar cpfCnpj duplicado  ============================== Aula 51 - https://youtu.be/dwZVxyLSCQw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1674
        public ModeloCliente CarregaModeloCliente(string cpfCnpj) // recebeo uma string cpfCnpj do cliente que se quer carregar
        {
            ModeloCliente modelo = new ModeloCliente();// instacio o modelo
            //criar a query para o carregar o item conforme cpfCnpj recebido,
            SqlCommand cmd = new SqlCommand();

            // Definir a conexão
            cmd.Connection = conexao.ObjetoConexao;

            // Definir o comando Query SQL:
            cmd.CommandText = "SELECT * FROM cliente WHERE cli_cpfcnpj = @cpfCnpj";//selecione todos os cliente onde o codigo co cliente seja igual ao informado pelo usuario

            //Definir o valor do parametro - codigo do intem recebido 
            cmd.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

            //conecta ao banco
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader(); //ExecuteReader: quando quer retornor muita informações da consulta  
            //SqlDataReader: obejeto para ler e acessar as infornmações retornadas
            //verifica se existe alguma lina dentro o objeto, se existir linha, le as informações dela, e carrega cada campo em suas respectivas colunas
            if (registro.HasRows)
            {
                registro.Read();
                modelo.CliCod = Convert.ToInt32(registro["cli_cod"]);
                modelo.CliNome = Convert.ToString(registro["cli_nome"]);
                modelo.CliCpfCnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.CliRgIe = Convert.ToString(registro["cli_rgie"]);
                modelo.CliRSocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.CliTipo = Convert.ToString(registro["cli_tipo"]);
                modelo.CliCep = Convert.ToString(registro["cli_cep"]);
                modelo.CliEndereco = Convert.ToString(registro["cli_endereco"]);
                modelo.CliBairro = Convert.ToString(registro["cli_bairro"]);
                modelo.CliFone = Convert.ToString(registro["cli_fone"]);
                modelo.CliCel = Convert.ToString(registro["cli_cel"]);
                modelo.CliEmail = Convert.ToString(registro["cli_email"]);
                modelo.CliEndNumero = Convert.ToString(registro["cli_endnumero"]);
                modelo.CliCidade = Convert.ToString(registro["cli_cidade"]);
                modelo.CliEstado = Convert.ToString(registro["cli_estado"]);

            }

            //desconecta do banco
            conexao.Desconectar();

            //retorna o objeto modelo com todas as informações 
            return modelo; // o modelo do cliente contem os campos da tabela de catagoria
        }

    }
}
