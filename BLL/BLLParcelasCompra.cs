using DAL;
using Modelo;
using System;
using System.Data;

namespace BLL
{
    public class BLLParcelasCompra
    {
        private DALConexao conexao;//criar propriedade privada
        public BLLParcelasCompra(DALConexao cx)//criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        //Metodo para incluir 
        public void Incluir(ModeloParcelasCompra modelo) //https://youtu.be/4FrqeIDgPaQ?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA
        {
            //Validação campo nao pode ser vazio
            if (modelo.PcoCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");
            }

            //valdação campo valor:
            if (modelo.PcoValor <= 0)
            {
                throw new Exception("O valor da parcela é obrigatório");
            }

            //criar validação para data de vencimento
            //pegar a data atual:
            DateTime Data = DateTime.Now;            
            if (modelo.PcoDatavecto.Year < Data.Year )
            {
                throw new Exception("Ano de vencimento inferior ao ano atual");
            }
            if (modelo.PcoDatavecto == null)
            {
                throw new Exception("A data de vencimento da parcela é obrigatório");
            }

            // criar validação para nao deixar por vencimento anterior a data da compra...!!!
            // ou seja nao se pode pagar antes de comprar!!
            
            //cria um objeto, e informa a conexão
            DALParcelasCompra DALobj = new DALParcelasCompra(conexao);
            //manda gravar no banco as informações coletadas na tela
            DALobj.Incluir(modelo);//usa o metodo incluir
        }

        //==============================================================================================================================
        //Metodo para alterar 
        public void Alterar(ModeloParcelasCompra modelo)
        {
            //Validação campo nao pode ser vazio
            if (modelo.PcoCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");
            }

            //valdação campo valor:
            if (modelo.PcoValor <= 0)
            {
                throw new Exception("O valor da parcela é obrigatório");
            }

            //criar validação para data de vencimento
            //pegar a data atual:
            DateTime Data = DateTime.Now;
            if (modelo.PcoDatavecto.Year < Data.Year)
            {
                throw new Exception("Ano de vencimento inferior ao ano atual");
            }
            if (modelo.PcoDatavecto == null)
            {
                throw new Exception("A data de vencimento da parcela é obrigatório");
            }

            // criar validação para nao deixar por vencimento anterior a data da compra...!!!
            // ou seja nao se pode pagar antes de comprar!!

            //cria um objeto, e informa a conexão
            DALParcelasCompra DALobj = new DALParcelasCompra(conexao);
            //manda Alterar no banco conforme as informações coletadas na tela
            DALobj.Alterar(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir uma parcela
        public void Excluir(ModeloParcelasCompra modelo)//recebe o modelo como parametro
        {
            //Validação campo nao pode ser vazio
            if (modelo.PcoCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasCompra DALobj = new DALParcelasCompra(conexao);
            DALobj.Excluir(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir todas as parcelas 
        public void ExcluirTodasAsParcelas(int ComCod)//recebe um codigo como parametro
        {
            //Validação campo nao pode ser vazio
            if (ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasCompra DALobj = new DALParcelasCompra(conexao);
            DALobj.ExcluirTotasAsParcelas(ComCod);
        }

        //==============================================================================================================================
        //Metodo para localixar um item
        public DataTable Localizar(int ComCod)
        {
            //valida campo obrigatorio:
            if (ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasCompra DALobj = new DALParcelasCompra(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(ComCod);
        }

        //==============================================================================================================================
        //Metodo para Localizar um item
        //retorna uma datatable, tabela em memoria - conforme valor informado do que se quer procurar //https://youtu.be/4FrqeIDgPaQ?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1286
        public ModeloParcelasCompra CarregaModeloParcelasCompra(int PcoCod, int ComCod)
        {
            //Validação campo nao pode ser vazio
            if (PcoCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (ComCod <= 0)
            {
                throw new Exception("O codigo da compra é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasCompra DALobj = new DALParcelasCompra(conexao);
            return DALobj.CarregaModeloParcelasCompra(PcoCod, ComCod);
        }

        //Metodo para Efetuar pagamento da parcela de compra ==============================================================================
        public void EfetuarPagamento(int ComCod, int PcoCod, DateTime dtPagto) // https://youtu.be/6RAAHztqGQc?t=634
        {
            if (dtPagto == null)
            {
                throw new Exception("Informe a data pagamento da parcela é obrigatório");
            }

            if (PcoCod <= 0)
            {
                throw new Exception("Codigo da parcela é obrigatório");
            }

            if (ComCod <= 0)
            {
                throw new Exception("Codigo da compra é obrigatório");
            }

            //criar validação para data de vencimento 
            //pegar a data atual:
            DateTime Data = DateTime.Now;
            //validação de data:ideia é nao pode pagar antes do venciemnto da primeira parcela
            if (dtPagto.Year < Data.Year)
            {
                throw new Exception("Ano de vencimento inferior ao ano atual");
            }

            //inserir a data de pagamento:
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            DALObj.EfetuarPagamento(ComCod, PcoCod, dtPagto);

            
        }

        //Metodo para Cancelar o pagamento da parcela de compra ==============================================================================
        public void CancelarPagamento(int ComCod, int PcoCod, DateTime dtPagto) // https://youtu.be/6RAAHztqGQc?t=634
        {
            if (PcoCod <= 0)
            {
                throw new Exception("Codigo da parcela é obrigatório");
            }

            if (ComCod <= 0)
            {
                throw new Exception("Codigo da compra é obrigatório");
            }

            //apaga a data de pagamento:
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            DALObj.CancelarPagamento(ComCod, PcoCod, dtPagto);
        }
    }
}
