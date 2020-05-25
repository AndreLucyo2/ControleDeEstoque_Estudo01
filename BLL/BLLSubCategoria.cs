using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLSubCategoria //aula 14
    {
        private DALConexao conexao;
        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        //==========================================================================================================================================
        public void Incluir(ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório");
            }

            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            //formatar o texto para maiusculo:
            modelo.ScatNome = modelo.ScatNome.ToUpper();

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(modelo);
        }

        //==========================================================================================================================================
        public void Alterar(ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O código da subcategoria é obrigatório");
            }

            //formatar o texto para maiusculo:
            modelo.ScatNome = modelo.ScatNome.ToUpper();

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(modelo);
        }

        //==========================================================================================================================================
        public void Excluir(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        //==========================================================================================================================================
        public DataTable Localizar(String valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        //==========================================================================================================================================
        public DataTable LocalizarPorCategoria(int categoria) //aula 33 - Combobox subcatagoria da tela de cadastro de produto
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao); // https://youtu.be/TUke-tVYFcw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=456
            return DALobj.LocalizarPorCategoria(categoria); //metodo para carregar a combobox, conforme a catagoria selecionada
        }

        //==========================================================================================================================================
        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(codigo);
        }
    }
}
