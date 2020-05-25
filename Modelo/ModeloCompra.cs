using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo // aula 69  https://youtu.be/Hlj1sU_vA2k?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=122
{
    public class ModeloCompra
    {
        //contrutor:
        public ModeloCompra() // https://youtu.be/Hlj1sU_vA2k?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=830
        {
            this.ComCod = 0;
            this.ComData = DateTime.Now;//data atual
            this.ComNfiscal = 0;
            this.ComValorTotal = 0;
            this.ComNparcelas = 0;
            this.ComStatus = "Válida";
            //INSERIR CAMPO COM NUMERO DE ITENS QUE COMPOE A VENDA
            this.ForCod = 0;
            this.TpaCod = 0;
        }

        //CONSTRUTOR COM PARAMETROS // https://youtu.be/Hlj1sU_vA2k?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=933
        public ModeloCompra(int com_cod, DateTime com_data, int com_nfiscal, double com_total, 
                            int com_nparcelas, string com_status, int for_cod, int tpa_cod)
        {
            this.ComCod = com_cod;
            this.ComData = com_data;
            this.ComNfiscal = com_nfiscal;
            this.ComValorTotal = com_total;
            this.ComNparcelas = com_nparcelas;
            this.ComStatus = com_status;
            this.ForCod = for_cod;
            this.TpaCod = tpa_cod;
        }

        //dados privados
        private int com_cod;
        private DateTime com_data;
        private int com_nfiscal;
        private Double com_total;
        private int com_nparcelas;
        private string com_status;
        private int for_cod;
        private int tpa_cod;

        //propriedades publicas
        public int ComCod { get => com_cod; set => com_cod = value; }
        public DateTime ComData { get => com_data; set => com_data = value; }
        public int ComNfiscal { get => com_nfiscal; set => com_nfiscal = value; }
        public double ComValorTotal { get => com_total; set => com_total = value; }
        public int ComNparcelas { get => com_nparcelas; set => com_nparcelas = value; }
        public string ComStatus { get => com_status; set => com_status = value; }
        public int ForCod { get => for_cod; set => for_cod = value; }
        public int TpaCod { get => tpa_cod; set => tpa_cod = value; }
    }
}
