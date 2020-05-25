using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCliente //Aula 50
    {
        //construtores:
        public ModeloCliente ()
        {
            this.CliCod = 0;
            this.CliNome = "";
            this.CliCpfCnpj = "";
            this.CliRgIe = "";
            this.CliRSocial = "";
            this.CliTipo = "Física"; //https://youtu.be/YM0R_uW9ajk?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=596
            this.CliCep = "";
            this.CliEndereco = "";
            this.CliBairro = "";
            this.CliFone = "";
            this.CliCel = "";
            this.CliEmail = "";
            this.CliEndNumero = "";
            this.CliCidade = "";
            this.CliEstado = "";
        }

        //CONSTRUTOR COM PARAMETROS
        public ModeloCliente(int cod, string nome, string cpfcnpj, string rgie, string rsocial,
                             string tipo, string cep, string endereco, string bairro, string fone,
                             string cel, string email, string endnumero, string cidade, string estado)
        {
            this.CliCod =cod;
            this.CliNome = nome;
            this.CliCpfCnpj = cpfcnpj;
            this.CliRgIe = rgie;
            this.CliRSocial = rsocial;
            this.CliTipo = tipo;
            this.CliCep = cep;
            this.CliEndereco = endereco;
            this.CliBairro = bairro;
            this.CliFone = fone;
            this.CliCel = cel;
            this.CliEmail = email;
            this.CliEndNumero = endnumero;
            this.CliCidade = cidade;
            this.CliEstado = estado;
        }

        //encapsulamento - criar as propriedades privadas
        private int cli_cod;
        private string cli_nome;
        private string cli_cpfcnpj;
        private string cli_rgie;
        private string cli_rsocial;
        private string cli_tipo;
        private string cli_cep;
        private string cli_endereco;
        private string cli_bairro;
        private string cli_fone;
        private string cli_cel;
        private string cli_email;
        private string cli_endnumero;
        private string cli_cidade;
        private string cli_estado;

        //propriedades publicas criado automaticamente, pelas ações rapidas, encapsular e usar a propriedade
        public int CliCod { get => cli_cod; set => cli_cod = value; }
        public string CliNome { get => cli_nome; set => cli_nome = value; }
        public string CliCpfCnpj { get => cli_cpfcnpj; set => cli_cpfcnpj = value; }
        public string CliRgIe { get => cli_rgie; set => cli_rgie = value; }
        public string CliRSocial { get => cli_rsocial; set => cli_rsocial = value; }
        public string CliTipo { get => cli_tipo; set => cli_tipo = value; }
        public string CliCep { get => cli_cep; set => cli_cep = value; }
        public string CliEndereco { get => cli_endereco; set => cli_endereco = value; }
        public string CliBairro { get => cli_bairro; set => cli_bairro = value; }
        public string CliFone { get => cli_fone; set => cli_fone = value; }
        public string CliCel { get => cli_cel; set => cli_cel = value; }
        public string CliEmail { get => cli_email; set => cli_email = value; }
        public string CliEndNumero { get => cli_endnumero; set => cli_endnumero = value; }
        public string CliCidade { get => cli_cidade; set => cli_cidade = value; }
        public string CliEstado { get => cli_estado; set => cli_estado = value; } 
    }
}
