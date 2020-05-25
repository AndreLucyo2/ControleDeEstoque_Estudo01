using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo //https://youtu.be/6U3GY7ELeZI?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=246
{
    public class ModeloFornecedor //Aula 50
    {
        //construtores:
        public ModeloFornecedor()
        {
            this.ForCod = 0;
            this.ForNome = "";
            this.ForCnpj = "";
            this.ForIe = "";
            this.ForRSocial = "";            
            this.ForCep = "";
            this.ForEndereco = "";
            this.ForBairro = "";
            this.ForFone = "";
            this.ForCel = "";
            this.ForEmail = "";
            this.ForEndNumero = "";
            this.ForCidade = "";
            this.ForEstado = "";
        }

        //CONSTRUTOR COM PARAMETROS
        public ModeloFornecedor(int cod, string nome, string cnpj, string Ie, string rsocial,
                             string cep, string endereco, string bairro, string fone,
                             string cel, string email, string endnumero, string cidade, string estado)
        {
            this.ForCod = cod;
            this.ForNome = nome;
            this.ForCnpj = cnpj;
            this.ForIe = Ie;
            this.ForRSocial = rsocial;            
            this.ForCep = cep;
            this.ForEndereco = endereco;
            this.ForBairro = bairro;
            this.ForFone = fone;
            this.ForCel = cel;
            this.ForEmail = email;
            this.ForEndNumero = endnumero;
            this.ForCidade = cidade;
            this.ForEstado = estado;
        }

        //teste de encapsulamento - criar as propriedades
        private int for_cod;
        private string for_nome;
        private string for_cnpj;
        private string for_Ie;
        private string for_rsocial;        
        private string for_cep;
        private string for_endereco;
        private string for_bairro;
        private string for_fone;
        private string for_cel;
        private string for_email;
        private string for_endnumero;
        private string for_cidade;
        private string for_estado;

        //teste - propriedades publicas criado automaticamente, pelas ações rapidas, encapsular
        public int ForCod { get => for_cod; set => for_cod = value; }
        public string ForNome { get => for_nome; set => for_nome = value; }
        public string ForCnpj { get => for_cnpj; set => for_cnpj = value; }
        public string ForIe { get => for_Ie; set => for_Ie = value; }
        public string ForRSocial { get => for_rsocial; set => for_rsocial = value; }
        public string ForCep { get => for_cep; set => for_cep = value; }
        public string ForEndereco { get => for_endereco; set => for_endereco = value; }
        public string ForBairro { get => for_bairro; set => for_bairro = value; }
        public string ForFone { get => for_fone; set => for_fone = value; }
        public string ForCel { get => for_cel; set => for_cel = value; }
        public string ForEmail { get => for_email; set => for_email = value; }
        public string ForEndNumero { get => for_endnumero; set => for_endnumero = value; }
        public string ForCidade { get => for_cidade; set => for_cidade = value; }
        public string ForEstado { get => for_estado; set => for_estado = value; }
    }
}
