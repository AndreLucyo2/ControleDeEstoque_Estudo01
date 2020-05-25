using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloTipoPagamento
    {
        public ModeloTipoPagamento()//criar um contrutor, sempre pe chamado ao instanciar objeto, usar o mesmo nome da classe
        {
            this.TpaCod = 0;//inicia as propriedade
            this.TpaNome = "";//inicia as propriedade
        }

        public ModeloTipoPagamento(int Tpacod, String nome)//criar um contrutor com parametros
        {
            this.TpaCod = Tpacod;// iniciar as propriedades com os parametros informados, obrigando informar os campos
            this.TpaNome = nome;// iniciar as propriedades com os parametros informados, obrigando informar os campos
        }

        private int tpa_cod; //conforme coluna da tabela do BD
        public int TpaCod // representa o campo da tabela
        {
            get { return this.tpa_cod; }
            set { this.tpa_cod = value; }
        }

        private string tpa_nome;//conforme coluna da tabela do BD
        public string TpaNome // representa o campo da tabela
        {
            get { return this.tpa_nome; }
            set { this.tpa_nome = value; }
        }
    }
}
