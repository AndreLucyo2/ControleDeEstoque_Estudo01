using DAL;
using Modelo;
using System;
using System.Data;
using Ferramentas;
using System.Text.RegularExpressions;

namespace BLL
{
    public class BLLFornecedor
    {
        private DALConexao conexao;//criar propriedade privada
        public BLLFornecedor(DALConexao cx)//criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        //Metodo para incluir uma categoria =================================================================== aula 05
        public void Incluir(ModeloFornecedor modelo)//modelo = coleta as informações da tela
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //VALIDAÇÕES DE CAMPOS OBIGATORIOS - //Validação se o nome esta preenchido, campo nome nao pode ser vazio, a propriedade nome nao pode ser vazia
            //--------------------------------------------------------------------------------------------------------------------------
            //CAMPO NOME:    
            if (modelo.ForNome.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O nome do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO RG/IE - VAI VERIFICAR SE É PSSOA FISICA OU JURIDICA
            if (modelo.ForIe.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O RG/IE do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO FONE
            if (modelo.ForFone.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O telefone do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO CPF/CNPJ  -- VELIDAR SE ´VALIDO --- SERA FEITO DEPOIS
            if (modelo.ForCnpj.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O CNPJ do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //Valida cnpj
            if (Validacao.IsCnpj(modelo.ForCnpj) == false)
            {
                throw new Exception("CNPJ Inválido!");
            }


            //valida Email: Espressao regular: https://youtu.be/VEoGhrk-4kw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=322
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(modelo.ForEmail))
            {
                throw new Exception("Digite um email válido.");
            }

            //formatar o texto para maiusculo:
            modelo.ForNome = modelo.ForNome.ToUpper();

            //cria um objeto, e informa a conexão
            DALFornecedor DALobj = new DALFornecedor(conexao);
            //manda gravar no banco as informações coletadas na tela
            DALobj.Incluir(modelo);//usa o metodo incluir

        }

        //==============================================================================================================================
        //Metodo para alterar uma categoria =================================================================== aula 05
        public void Alterar(ModeloFornecedor modelo)
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //VALIDAÇÕES DE CAMPOS OBIGATORIOS - //Validação se o nome esta preenchido, campo nome nao pode ser vazio, a propriedade nome nao pode ser vazia
            //--------------------------------------------------------------------------------------------------------------------------
            //CAMPO NOME:    
            if (modelo.ForNome.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O nome do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO RG/IE - VAI VERIFICAR SE É PSSOA FISICA OU JURIDICA
            if (modelo.ForIe.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O IE do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO FONE
            if (modelo.ForFone.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O telefone do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }


            //CAMPO CPF/CNPJ  -- VELIDAR SE ´VALIDO --- SERA FEITO DEPOIS
            if (modelo.ForCnpj.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O CNPJ do fornecedor é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //Valida cnpj
            if (Validacao.IsCnpj(modelo.ForCnpj) == false)
            {
                throw new Exception("CNPJ Inválido!");
            }

            //valida Email: Espressao regular: https://youtu.be/VEoGhrk-4kw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=322
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(modelo.ForEmail))
            {
                throw new Exception("Digite um email válido.");
            }

            //formatar o texto para maiusculo:
            modelo.ForNome = modelo.ForNome.ToUpper();

            //cria um objeto, e informa a conexão
            DALFornecedor DALobj = new DALFornecedor(conexao);
            //manda Alterar no banco conforme as informações coletadas na tela
            DALobj.Alterar(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir um item ===================================================================- aula 05
        public void Excluir(int codigo)//recebe um codigo como parametro
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Excluir(codigo);
        }

        //==============================================================================================================================
        //Metodo para localixar um item ================================================================================================- aula 05
        public DataTable Localizar(String valor) //generico reutilizavel 
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALFornecedor DALobj = new DALFornecedor(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(valor);
        }

        //==============================================================================================================================
        //metodo para a opção de consulta por nome
        public DataTable LocalizarPorNome(String valor) //https://youtu.be/VmTY593Mrqc?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=541
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALFornecedor DALobj = new DALFornecedor(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.LocalizarPorNome(valor);
        }

        //==============================================================================================================================
        //metodo para a opção de consulta por nome
        public DataTable LocalizarCNPJ(String valor) //https://youtu.be/VmTY593Mrqc?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=541
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALFornecedor DALobj = new DALFornecedor(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.LocalizarCNPJ(valor);
        }

        //==============================================================================================================================
        //carregar os dados na tela pelo codigo -- metodo com 2 sobrecargas
        public ModeloFornecedor CarregaModeloFornecedor(int codigo)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.CarregaModeloFornecedor(codigo);
        }

        //==============================================================================================================================
        //carregar os dados na tela pelo CPF/CNPJ -- metodo com 2 sobrecargas
        public ModeloFornecedor CarregaModelofornecedor(string cpfcnpj)
        {
            //sem validação , pois se o cpfcnpj informado nao existir, nao vai fazer nada
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.CarregaModeloFornecedor(cpfcnpj);
        }

    }
}
