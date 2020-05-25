using DAL;
using Modelo;
using System;
using System.Data;
using Ferramentas;
using System.Text.RegularExpressions;

namespace BLL
{
    public class BLLCliente
    {
        private DALConexao conexao;//criar propriedade privada
        public BLLCliente(DALConexao cx)//criar um construtor, ele recebe uma conexão
        {
            this.conexao = cx;
        }

        //==============================================================================================================================
        //Metodo para incluir uma categoria =================================================================== aula 05
        public void Incluir(ModeloCliente modelo)//modelo = coleta as informações da tela
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //VALIDAÇÕES DE CAMPOS OBIGATORIOS - //Validação se o nome esta preenchido, campo nome nao pode ser vazio, a propriedade nome nao pode ser vazia
            //--------------------------------------------------------------------------------------------------------------------------
            //CAMPO NOME:    
            if (modelo.CliNome.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O nome do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO RG/IE - VAI VERIFICAR SE É PSSOA FISICA OU JURIDICA
            if (modelo.CliRgIe.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O RG/IE do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO FONE
            if (modelo.CliFone.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O telefone do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO CPF/CNPJ  -- VELIDAR SE ´VALIDO --- SERA FEITO DEPOIS
            if (modelo.CliCpfCnpj.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O CPF/CNPJ do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //valida CPF/CNPJ au salvar e alterar
            //valida se é CPF: aula 60 https://youtu.be/3EAdYK2Zcww?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1107
            if (modelo.CliTipo == "Física")
            {
                //Valida cpf
                if (Validacao.IsCpf(modelo.CliCpfCnpj) == false)
                {
                    throw new Exception("CPF Inválido!");
                }
            }
            else
            {
                //Valida cnpj
                if (Validacao.IsCnpj(modelo.CliCpfCnpj) == false)
                {
                    throw new Exception("CNPJ Inválido!");
                }
            }

            
            //valida Email: Espressao regular: https://youtu.be/VEoGhrk-4kw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=322
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(modelo.CliEmail))
            {
                throw new Exception("Digite um email válido.");
            }

            //formatar o texto para maiusculo:
            modelo.CliNome = modelo.CliNome.ToUpper();

            //cria um objeto, e informa a conexão
            DALCliente DALobj = new DALCliente(conexao);
            //manda gravar no banco as informações coletadas na tela
            DALobj.Incluir(modelo);//usa o metodo incluir

        }

        //==============================================================================================================================
        //Metodo para alterar uma categoria =================================================================== aula 05
        public void Alterar(ModeloCliente modelo)
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //VALIDAÇÕES DE CAMPOS OBIGATORIOS - //Validação se o nome esta preenchido, campo nome nao pode ser vazio, a propriedade nome nao pode ser vazia
            //--------------------------------------------------------------------------------------------------------------------------
            //CAMPO NOME:    
            if (modelo.CliNome.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O nome do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO RG/IE - VAI VERIFICAR SE É PSSOA FISICA OU JURIDICA
            if (modelo.CliRgIe.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O RG/IE do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //CAMPO FONE
            if (modelo.CliFone.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O telefone do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }


            //CAMPO CPF/CNPJ  -- VELIDAR SE ´VALIDO --- SERA FEITO DEPOIS
            if (modelo.CliCpfCnpj.Trim().Length == 0)//se o tamanho do texto for igual a zero ...
            {
                throw new Exception("O CPF/CNPJ do cliente é obrigatório");// cria uma exceção, e retornar a mensagem obrigando
            }

            //valida CPF/CNPJ au salvar e alterar
            //valida se é CPF: aula 60 https://youtu.be/3EAdYK2Zcww?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1107
            if (modelo.CliTipo == "Física")
            {
                //Valida cpf
                if (Validacao.IsCpf(modelo.CliCpfCnpj) == false)
                {
                    throw new Exception("CPF Inválido!");
                }
            }
            else
            {
                //Valida cnpj
                if (Validacao.IsCnpj(modelo.CliCpfCnpj) == false)
                {
                    throw new Exception("CNPJ Inválido!");
                }
            }

            //valida Email: Espressao regular: https://youtu.be/VEoGhrk-4kw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=322
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(modelo.CliEmail))
            {
                throw new Exception("Digite um email válido.");
            }

            //formatar o texto para maiusculo:
            modelo.CliNome = modelo.CliNome.ToUpper();

            //cria um objeto, e informa a conexão
            DALCliente DALobj = new DALCliente(conexao);
            //manda Alterar no banco conforme as informações coletadas na tela
            DALobj.Alterar(modelo);
        }

        //==============================================================================================================================
        //Metodo para Excluir um item ===================================================================- aula 05
        public void Excluir(int codigo)//recebe um codigo como parametro
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Excluir(codigo);
        }

        //==============================================================================================================================
        //Metodo para localixar um item ================================================================================================- aula 05
        public DataTable Localizar(String valor) //generico reutilizavel 
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCliente DALobj = new DALCliente(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.Localizar(valor);
        }

        //==============================================================================================================================
        //metodo para a opção de consulta por nome
        public DataTable LocalizarPorNome(String valor) //https://youtu.be/VmTY593Mrqc?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=541
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCliente DALobj = new DALCliente(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.LocalizarPorNome(valor);
        }

        //==============================================================================================================================
        //metodo para a opção de consulta por nome
        public DataTable LocalizarCPFCNPJ(String valor) //https://youtu.be/VmTY593Mrqc?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=541
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCliente DALobj = new DALCliente(conexao);
            //retorna uma datatable, realizando o localizar
            return DALobj.LocalizarCPFCNPJ(valor);
        }

        //==============================================================================================================================
        //carregar os dados na tela pelo codigo -- metodo com 2 sobrecargas
        public ModeloCliente CarregaModeloCliente(int codigo)
        {
            //sem validação , pois se o codigo informado nao existir, nao vai fazer nada
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.CarregaModeloCliente(codigo);
        }

        //==============================================================================================================================
        //carregar os dados na tela pelo CPF/CNPJ -- metodo com 2 sobrecargas
        public ModeloCliente CarregaModeloCliente(string cpfcnpj)
        {
            //sem validação , pois se o cpfcnpj informado nao existir, nao vai fazer nada
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.CarregaModeloCliente(cpfcnpj);
        }

    }
}
