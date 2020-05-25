using System;
using System.Data.SqlClient;
using Modelo;
using System.Data;


namespace DAL //Aula 25
{
    public class DALProduto
    {
        private DALConexao conexao;//propriedades da conexão, instancia a classe de conexão
        public DALProduto(DALConexao cx)
        {
            this.conexao = cx;
        }

        //===========================================================================================================================================================
        public void Incluir(ModeloProduto obj) //aula 26 ref: https://youtu.be/U0Xqh5LC9IU?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=415
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "insert into Produto (pro_nome, pro_descricao, pro_foto,  pro_valorpago, pro_valorvenda, pro_qtde,umed_cod , cat_cod, scat_cod) " +
            "values (@nome,@descricao,@foto,@valorpago,@valorvenda,@qtde,@undmedcod,@catcod,@scatcod); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", obj.ProNome);
            cmd.Parameters.AddWithValue("@descricao", obj.ProDescricao);

            //parametro Foto do produto:
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image);
            if (obj.ProFoto == null) //se o profoto usuário noa informou foto 
            {
                //cmd.Parameters.AddWithValue("@pro_foto", DBNull.Value);
                cmd.Parameters["@foto"].Value = DBNull.Value; //recebe um valor nullo
            }
            else
            {
                //cmd.Parameters.AddWithValue("@pro_foto", obj.pro_foto);
                cmd.Parameters["@foto"].Value = obj.ProFoto; //recebe o obleto como valor 
            }
            
            //Demais parametros:
            cmd.Parameters.AddWithValue("@valorpago", obj.ProValorPago);
            cmd.Parameters.AddWithValue("@valorvenda", obj.ProValorVenda);
            cmd.Parameters.AddWithValue("@qtde", obj.ProQtde);
            cmd.Parameters.AddWithValue("@undmedcod", obj.UmedCod);
            cmd.Parameters.AddWithValue("@catcod", obj.CatCod);
            cmd.Parameters.AddWithValue("@scatcod", obj.ScatCod);
            //conecta com BD: aula 26
            conexao.Conectar();

            obj.ProCod = Convert.ToInt32(cmd.ExecuteScalar());//armazena o codigo do produto , devolvido pelo ExecuteScalar()

            conexao.Desconectar();
        }

        //===========================================================================================================================================================
        public void Excluir(int codigo) //aula 27
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM Produto WHERE (pro_cod) = (@codigo)"; // deleta o produto conforme o codigo informado
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        //===========================================================================================================================================================
        public void Alterar(ModeloProduto obj) //aula 27
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            //UPDATE nos campos onde o codigo for igual ao informado no parametro obj
            cmd.CommandText = "UPDATE Produto SET pro_nome = (@nome), pro_descricao = (@descricao), " +
                "pro_foto = (@foto), pro_valorpago = (@valorpago), pro_valorvenda = (@valorvenda), " +
                "pro_qtde = (@qtde), umed_cod = (@undmedcod), cat_cod = (@catcod), " +
                "scat_cod = (@scatcod) WHERE pro_cod = (@codigo) ";

            //------------------------------------------------------------------------------------------------------------------------------------
            //PARAMETROS:
            //------------------------------------------------------------------------------------------------------------------------------------
            cmd.Parameters.AddWithValue("@nome", obj.ProNome);
            cmd.Parameters.AddWithValue("@descricao", obj.ProDescricao);

            //parametro Foto do produto: aula 27 4:30
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image);//informar o tipo do parametro
            if (obj.ProFoto == null)
            {
                //cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                cmd.Parameters["@foto"].Value = DBNull.Value;//se nao existir uma foro recebe valor nullo
            }
            else
            {
                //cmd.Parameters.AddWithValue("@foto", obj.pro_foto);
                cmd.Parameters["@foto"].Value = obj.ProFoto;
            }

            //Demais parametros:
            cmd.Parameters.AddWithValue("@valorpago", obj.ProValorPago);
            cmd.Parameters.AddWithValue("@valorvenda", obj.ProValorVenda);
            cmd.Parameters.AddWithValue("@qtde", obj.ProQtde);
            cmd.Parameters.AddWithValue("@undmedcod", obj.UmedCod);
            cmd.Parameters.AddWithValue("@catcod", obj.CatCod);
            cmd.Parameters.AddWithValue("@scatcod", obj.ScatCod);
            cmd.Parameters.AddWithValue("@codigo", obj.ProCod);

            //conecta com BD: aula 27
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        //===========================================================================================================================================================
        public DataTable Localizar(String valor)//aula 27 ref: https://youtu.be/6ACwNa2edw4?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=570
        {
            DataTable tabela = new DataTable(); //Cria o datatable ref: https://youtu.be/6ACwNa2edw4?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=647
            SqlDataAdapter da = new SqlDataAdapter("SELECT p.pro_cod, p.pro_nome, p.pro_descricao, p.pro_foto, p.pro_valorpago, " +
                        "p.pro_valorvenda, p.pro_qtde, p.umed_cod, p.cat_cod, p.scat_cod, u.umed_nome, c.cat_nome, sc.scat_nome " +
                        "FROM Produto AS p INNER JOIN undmedida AS u ON p.umed_cod = u.umed_cod INNER JOIN categoria AS c ON p.cat_cod = c.cat_cod "+
                        "INNER JOIN subcategoria sc ON p.scat_cod = sc.scat_cod  WHERE p.pro_nome LIKE " +
                        "'%" + valor + "%'", conexao.StringConexao);//informar a strinde conexão

            da.Fill(tabela);
            return tabela;
        }

        //===========================================================================================================================================================
        public ModeloProduto CarregaModeloProduto(int codigo) //carregar os dados do modelo aula 27 8:00  https://youtu.be/qb5JoiVSuAY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=656
        {
            ModeloProduto modelo = new ModeloProduto();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;//definir a coneção

            cmd.CommandText = "SELECT * FROM Produto WHERE (pro_cod) =" + codigo.ToString();

            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ProCod = Convert.ToInt32(registro["pro_cod"]);
                modelo.ProNome = Convert.ToString(registro["pro_nome"]);
                modelo.ProDescricao = Convert.ToString(registro["pro_descricao"]);

                try //tratativa de erro, validar o arquivo da foto
                {
                    //tentar fazer e leitura do arquivo da foto armazenado em byte
                    modelo.ProFoto = (byte[])registro["pro_foto"];//se o campo foto estiver vazio, nao vai apresentar erro, o try cuida disso

                }
                catch { }

                //demais parametros:
                modelo.ProValorPago = Convert.ToDouble(registro["pro_valorpago"]);
                modelo.ProValorVenda = Convert.ToDouble(registro["pro_valorvenda"]);
                modelo.ProQtde = Convert.ToInt32(registro["pro_qtde"]);
                modelo.UmedCod = Convert.ToInt32(registro["umed_cod"]);
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.ScatCod = Convert.ToInt32(registro["scat_cod"]);
            }
            conexao.Desconectar();
            return modelo;// retorna objeto modelo com todos os campos preenchidos aula 27 12:25
        }
    }
}
