using DAL;
using Modelo;
using System;
using System.Data;

namespace BLL
{
    public class BLLItensCompra // https://youtu.be/q1RkQrDYMQE?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=156
    {
        private DALConexao conexao;//criar propriedade privada
        public BLLItensCompra(DALConexao cx)//criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        //Metodo para incluir 
        public void Incluir(ModeloItensCompra modelo)//modelo = coleta as informações da tela
        {
            //Validação:
            if (modelo.ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ItcCod <= 0)
            {
                throw new Exception("O codigo do item é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ItcQtde <= 0)
            {
                throw new Exception("A quantidade deve ser maior do que zero!");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ItcValor <= 0)
            {
                throw new Exception("O valor do item deve ser maior do que zero!");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ProCod <= 0)
            {
                throw new Exception("O codigo do produto é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }
            
            //cria um objeto, e informa a conexão
            DALItensCompra DALobj = new DALItensCompra(conexao);
            //manda gravar no banco as informações coletadas na tela
            DALobj.Incluir(modelo);//usa o metodo incluir
        }

        //==============================================================================================================================
        //Metodo para alterar uma categoria =================================================================== aula 05
        public void Alterar(ModeloItensCompra modelo) // https://youtu.be/q1RkQrDYMQE?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=445
        {
            //Validação:
            if (modelo.ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ItcCod <= 0)
            {
                throw new Exception("O codigo do item é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ItcQtde <= 0)
            {
                throw new Exception("A quantidade deve ser maior do que zero!");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ItcValor <= 0)
            {
                throw new Exception("O valor do item deve ser maior do que zero!");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ProCod <= 0)
            {
                throw new Exception("O codigo do produto é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //cria um objeto, e informa a conexão
            DALItensCompra DALobj = new DALItensCompra(conexao);
            //manda Alterar no banco conforme as informações coletadas na tela
            DALobj.Alterar(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir um item ===================================================================- aula 05
        public void Excluir(ModeloItensCompra modelo)//recebe o modelo como parametro
        {
            //Validação:
            if (modelo.ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ItcCod <= 0)
            {
                throw new Exception("O codigo do item é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ProCod <= 0)
            {
                throw new Exception("O codigo do produto é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            DALItensCompra DALobj = new DALItensCompra(conexao);
            DALobj.Excluir(modelo);//passando o modelo
        }

        //==============================================================================================================================
        //Metodo para Excluir um item ===================================================================- aula 05
        public void ExcluirTodosOsItens(int comcod)//recebe o modelo como parametro
        {
            //Validação:
            if (comcod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }
            
            DALItensCompra DALobj = new DALItensCompra(conexao);
            DALobj.ExcluirTodosOsItens(comcod);//passando o modelo
        }

        //==============================================================================================================================
        //Metodo para localixar os itens 
        public DataTable Localizar(int comcod)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALItensCompra DALobj = new DALItensCompra(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(comcod);
        }

        //==============================================================================================================================
        //Metodo para Localizar um item 
        //retorna uma datatable, tabela em memoria - conforme valores informado do que se quer procurar
        public ModeloItensCompra CarregaModeloItensCompra(int ItcCod, int com_cod, int ProCod)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALItensCompra DALobj = new DALItensCompra(conexao);
            return DALobj.CarregaModeloItensCompra( ItcCod, com_cod, ProCod);
        }
    }
}
