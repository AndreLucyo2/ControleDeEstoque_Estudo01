
using System;
using System.Data;
using DAL;
using Modelo;

namespace BLL //aula 28
{
    public class BLLProduto
    {
        private DALConexao conexao;
        public BLLProduto(DALConexao cx)//construtor da conexao , instacia a classe da conexão
        {
            this.conexao = cx;
        }

        //========================================================================================================================================
        public void Incluir(ModeloProduto obj) //cabeçalho semelhante ao do DAL
        {
            //validação de campos obrigatorios:
            if (obj.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            if (obj.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição do produto é obrigatória");
            }

            if (obj.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatório");
            }

            if (obj.ProQtde < 0)
            {
                throw new Exception("A quantidade do produto deve ser maior ou igual a zero");
            }

            if (obj.ScatCod <= 0)
            {
                throw new Exception("O código da subcategoria é obrigatório");
            }

            if (obj.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            if (obj.UmedCod <= 0)
            {
                throw new Exception("O código da unidade de medida é obrigatório");
            }

            //instancia o DAL do produto
            DALProduto DALobj = new DALProduto(conexao);
            //chamo o incluir:
            DALobj.Incluir(obj);
        }

        //========================================================================================================================================
        public void Excluir(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Excluir(codigo);
        }

        //========================================================================================================================================
        public void Alterar(ModeloProduto obj)
        {
            //validação de campos obrigatorios ao alterar:
            if (obj.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            if (obj.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição do produto é obrigatória");
            }

            if (obj.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatório");
            }

            if (obj.ProQtde < 0)
            {
                throw new Exception("A quantidade do produto deve ser maior ou igual a zero");
            }

            if (obj.ScatCod <= 0)
            {
                throw new Exception("O código da subcategoria é obrigatório");
            }

            if (obj.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            if (obj.UmedCod <= 0)
            {
                throw new Exception("O código da unidade de medida é obrigatório");
            }

            if (obj.ProCod <= 0)
            {
                throw new Exception("O código do produto é obrigatório");
            }

            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(obj);
        }

        //========================================================================================================================================
        public DataTable Localizar(String valor) // https://youtu.be/lj18oqTEPBY?t=296
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.Localizar(valor);
        }

        //========================================================================================================================================
        public ModeloProduto CarregaModeloProduto(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(codigo);
        }
    }
}