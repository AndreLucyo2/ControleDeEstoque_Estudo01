using DAL;
using Modelo;
using System;
using System.Data;

namespace BLL
{
    public class BLLCompra
    {
        private DALConexao conexao;//criar propriedade privada
        public BLLCompra(DALConexao cx)//criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        //Metodo para incluir uma Compra =================================================================== aula 05
        public void Incluir(ModeloCompra modelo)//modelo = coleta as informações da tela
        {
            //validação da compra:
            if (modelo.ComNfiscal < 0)
            {
                throw new Exception("O Numero da Nota Fiscal deve ser informado! \n Caso nao possua informe 0 ."); // cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ComValorTotal <= 0)
            {
                throw new Exception("O valor da compra deve ser informado"); // cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ForCod <= 0)
            {
                throw new Exception("O fornecedor deve ser informado"); // cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ComNparcelas <= 0)
            {
                throw new Exception("O informe o número de parcelas"); // cria uma exceção, e retornar a mensagem obrigando
            }

            //validação para compra com datas retroativas: Controle das datas das compras -  https://youtu.be/ZSwhlPfD7V8?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=527
            //if (modelo.ComData != DateTime.Today)//tem que ajustar para validar somente o dia, esta validando a hora!!
            //{
            //    throw new Exception("a Data da compra não corresponde a data atual"); // cria uma exceção, e retornar a mensagem obrigando
            //}

            //cria um objeto, e informa a conexão
            DALCompra DALobj = new DALCompra(conexao);
            //manda gravar no banco as informações coletadas na tela
            DALobj.Incluir(modelo);//usa o metodo incluir

        }

        //==============================================================================================================================
        //Metodo para alterar uma Compra =================================================================== https://youtu.be/ZSwhlPfD7V8?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=639
        public void Alterar(ModeloCompra modelo)
        {
            //validação da compra:
            if (modelo.ComCod <= 0)
            {
                throw new Exception("O codigo da compra deve ser informado"); // cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ComValorTotal <= 0)
            {
                throw new Exception("O valor da compra deve ser informado"); // cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ForCod <= 0)
            {
                throw new Exception("O fornecedor deve ser informado"); // cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ComNparcelas <= 0)
            {
                throw new Exception("O informe o número de parcelas"); // cria uma exceção, e retornar a mensagem obrigando
            }

            //validação para compra com datas retroativas: Controle das datas das compras -  https://youtu.be/ZSwhlPfD7V8?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=527
            //if (modelo.ComData < DateTime.Now)
            //{
            //    throw new Exception("Data da compra não pode ser menor que a data atual"); // cria uma exceção, e retornar a mensagem obrigando
            //}

            //cria um objeto, e informa a conexão
            DALCompra DALobj = new DALCompra(conexao);
            //manda Alterar no banco conforme as informações coletadas na tela
            DALobj.Alterar(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir um item ===================================================================- 
        public void Excluir(int codigo)//recebe um codigo como parametro
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            DALobj.Excluir(codigo);
        }

        //==============================================================================================================================
        //Metodo para localixar um item ===================================================================- aula 05
        public DataTable Localizar(int codigo)//localizar por codigo forncedor
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(codigo);
        }
        //------------------------------------------------------------------------------------
        public DataTable Localizar()//localizar todas as compras https://youtu.be/r_vR5Ht_2nY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=685
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar();
        }
        //------------------------------------------------------------------------------------
        public DataTable Localizar(String nome)//localizaro pelo nome do fornecedor
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(nome);
        }
        //------------------------------------------------------------------------------------
        public DataTable Localizar(DateTime DTInicial , DateTime DTFinal)//localizar por periodo entre datas
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(DTInicial,DTFinal);
        }
        //------------------------------------------------------------------------------------
        public DataTable LocalizarProParcelasEmAberto(bool ParcAberto)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.LocalizarProParcelasEmAberto(ParcAberto);
        }

        //====================================================================================================================================
        //contagem de parcelas em aberto https://youtu.be/uGJE-7yKHPM?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=375
        public int QuantidadeParcelasEmAberto(int Codigo)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            return DALobj.QuantidadeParcelasEmAberto(Codigo);
        }

        //====================================================================================================================================
        //contagem de parcelas pagas
        public int QuantidadeParcePagas(int Codigo)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            return DALobj.QuantidadeParcelasPagas(Codigo);
        }

        //==============================================================================================================================
        //Metodo para Localizar um item ===================================================================- aula 05
        //retorna uma datatable, tabela em memoria - conforme valor informado do que se quer procurar
        public ModeloCompra CarregaModeloCompra(int codigo)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCompra DALobj = new DALCompra(conexao);
            return DALobj.CarregaModeloCompra(codigo);
        }

    }
}
