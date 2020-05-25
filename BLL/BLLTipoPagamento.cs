using DAL;
using Modelo;
using System;
using System.Data;

namespace BLL
{
    public class BLLTipoPagamento
    {
        private DALConexao conexao;//criar propriedade privada
        public BLLTipoPagamento(DALConexao cx)//criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        //Metodo para incluir uma categoria =================================================================== aula 05
        public void Incluir(ModeloTipoPagamento modelo)//modelo = coleta as informações da tela
        {
            //Validação se o nome esta preenchido, campo nome nao pode ser vazio, a propriedade nome nao pode ser vazia
            if (modelo.TpaNome.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O nome do tipo de pagamento é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //formatar o texto para maiusculo:
            modelo.TpaNome = modelo.TpaNome.ToUpper();

            //cria um objeto, e informa a conexão
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            //manda gravar no banco as informações coletadas na tela
            DALobj.Incluir(modelo);//usa o metodo incluir

        }

        //==============================================================================================================================
        //Metodo para alterar uma categoria =================================================================== aula 05
        public void Alterar(ModeloTipoPagamento modelo)
        {
            //Validação: verificar se o codigo informado é menor ou igual a zero, 
            if (modelo.TpaCod <= 0)//verifica se o usuário informou o codigo
            {
                throw new Exception("O código do tipo de pagamento é obrigatório");
            }
            //Validação: verifica se foi informado um nome para a catagoria
            if (modelo.TpaNome.Trim().Length == 0)
            {
                throw new Exception("O nome do tipo de pagamento é obrigatório");
            }

            //formatar o texto para maiusculo:
            modelo.TpaNome = modelo.TpaNome.ToUpper();

            //cria um objeto, e informa a conexão
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            //manda Alterar no banco conforme as informações coletadas na tela
            DALobj.Alterar(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir um item ===================================================================- aula 05
        public void Excluir(int codigo)//recebe um codigo como parametro
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            DALobj.Excluir(codigo);
        }

        //==============================================================================================================================
        //Metodo para localixar um item ===================================================================- aula 05
        public DataTable Localizar(String valor)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(valor);
        }

        //==============================================================================================================================
        //Metodo para Localizar um item ===================================================================- aula 05
        //retorna uma datatable, tabela em memoria - conforme valor informado do que se quer procurar
        public ModeloTipoPagamento CarregaModeloTipoPagamento(int codigo)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            return DALobj.CarregaModeloTipoPagamento(codigo);
        }

    }
}
