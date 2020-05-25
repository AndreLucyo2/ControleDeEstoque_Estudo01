using DAL;
using Modelo;
using System;
using System.Data;

namespace BLL
{
    public class BLLParcelasVenda
    {
        private DALConexao conexao;//criar propriedade privada
        public BLLParcelasVenda(DALConexao cx)//criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        //Metodo para incluir 
        public void Incluir(ModeloParcelasVenda modelo) //https://youtu.be/hDnbSqf1-pg?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=247
        {
            //Validação campo nao pode ser vazio
            if (modelo.PveCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.VenCod <= 0)
            {
                throw new Exception("O codigo da Venda é obrigatório");
            }

            //valdação campo valor:
            if (modelo.PveValor <= 0)
            {
                throw new Exception("O valor da parcela é obrigatório");
            }

            //criar validação para data de vencimento
            //pegar a data atual:
            DateTime Data = DateTime.Now;
            if (modelo.PveDatavecto.Year < Data.Year)
            {
                throw new Exception("Ano de vencimento inferior ao ano atual");
            }
            if (modelo.PveDatavecto == null)
            {
                throw new Exception("A data de vencimento da parcela é obrigatório");
            }

            // criar validação para nao deixar por vencimento anterior a data da Venda...!!!
            // ou seja nao se pode receber antes de Vender!!

            //cria um objeto, e informa a conexão
            DALParcelasVenda DALobj = new DALParcelasVenda(conexao);
            //manda gravar no banco as informações coletadas na tela
            DALobj.Incluir(modelo);//usa o metodo incluir
        }

        //==============================================================================================================================
        //Metodo para alterar 
        public void Alterar(ModeloParcelasVenda modelo)
        {
            //Validação campo nao pode ser vazio
            if (modelo.PveCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.VenCod <= 0)
            {
                throw new Exception("O codigo da Venda é obrigatório");
            }

            //valdação campo valor:
            if (modelo.PveValor <= 0)
            {
                throw new Exception("O valor da parcela é obrigatório");
            }

            //criar validação para data de vencimento
            //pegar a data atual:
            DateTime Data = DateTime.Now;
            if (modelo.PveDatavecto.Year < Data.Year)
            {
                throw new Exception("Ano de vencimento inferior ao ano atual");
            }
            if (modelo.PveDatavecto == null)
            {
                throw new Exception("A data de vencimento da parcela é obrigatório");
            }

            // criar validação para nao deixar por vencimento anterior a data da Venda...!!!
            // ou seja nao se pode pagar antes de Vendar!!

            //cria um objeto, e informa a conexão
            DALParcelasVenda DALobj = new DALParcelasVenda(conexao);
            //manda Alterar no banco conforme as informações coletadas na tela
            DALobj.Alterar(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir uma parcela
        public void Excluir(ModeloParcelasVenda modelo)//recebe o modelo como parametro
        {
            //Validação campo nao pode ser vazio
            if (modelo.PveCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (modelo.VenCod <= 0)
            {
                throw new Exception("O codigo da Venda é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasVenda DALobj = new DALParcelasVenda(conexao);
            DALobj.Excluir(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir todas as parcelas 
        public void ExcluirTodasAsParcelas(int VenCod)//recebe um codigo como parametro
        {
            //Validação campo nao pode ser vazio
            if (VenCod <= 0)
            {
                throw new Exception("O codigo da Venda é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasVenda DALobj = new DALParcelasVenda(conexao);
            DALobj.ExcluirTotasAsParcelas(VenCod);
        }

        //==============================================================================================================================
        //Metodo para localixar um item
        public DataTable Localizar(int VenCod)
        {
            //valida campo obrigatorio:
            if (VenCod <= 0)
            {
                throw new Exception("O codigo da Venda é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasVenda DALobj = new DALParcelasVenda(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(VenCod);
        }

        //==============================================================================================================================
        //Metodo para Localizar um item
        //retorna uma datatable, tabela em memoria - conforme valor informado do que se quer procurar //https://youtu.be/4FrqeIDgPaQ?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1286
        public ModeloParcelasVenda CarregaModeloParcelasVenda(int PveCod, int VenCod)
        {
            //Validação campo nao pode ser vazio
            if (PveCod <= 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O codigo da parcela é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            if (VenCod <= 0)
            {
                throw new Exception("O codigo da Venda é obrigatório");
            }

            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALParcelasVenda DALobj = new DALParcelasVenda(conexao);
            return DALobj.CarregaModeloParcelasVenda(PveCod, VenCod);
        }
    }
}
