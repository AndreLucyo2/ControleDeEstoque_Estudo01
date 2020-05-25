using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class ModeloVenda
    {
        //contrutor:
        public ModeloVenda() // https://youtu.be/Hlj1sU_vA2k?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=830
        {
            this.VenCod = 0;
            this.VenData = DateTime.Now;//data atual
            this.VenNfiscal = 0;
            this.VenValorTotal = 0;
            this.VenNparcelas = 0;
            this.VenStatus = "Válida";
            this.VenAVista = 0; // 0= a vista 1 a prazo            
            this.CliCod = 0;
            this.TpaCod = 0;
        }

        //CONSTRUTOR COM PARAMETROS // https://youtu.be/Hlj1sU_vA2k?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=933
        public ModeloVenda(int ven_cod, DateTime ven_data, int ven_nfiscal, double ven_total,
                            int ven_nparcelas, string ven_status,int ven_avista, int cli_cod, int tpa_cod)
        {
            this.VenCod = ven_cod;
            this.VenData = ven_data;
            this.VenNfiscal = ven_nfiscal;
            this.VenValorTotal = ven_total;
            this.VenNparcelas = ven_nparcelas;
            this.VenStatus = ven_status;
            this.VenAVista = ven_avista;
            this.CliCod = cli_cod;
            this.TpaCod = tpa_cod;
        }

        //dados privados
        private int ven_cod;
        private DateTime ven_data;
        private int ven_nfiscal;
        private Double ven_total;
        private int ven_nparcelas;
        private string ven_status;
        private int ven_avista;
        private int cli_cod;
        private int tpa_cod;

        //propriedades publicas
        public int VenCod { get => ven_cod; set => ven_cod = value; }
        public DateTime VenData { get => ven_data; set => ven_data = value; }
        public int VenNfiscal { get => ven_nfiscal; set => ven_nfiscal = value; }
        public double VenValorTotal { get => ven_total; set => ven_total = value; }
        public int VenNparcelas { get => ven_nparcelas; set => ven_nparcelas = value; }
        public string VenStatus { get => ven_status; set => ven_status = value; }
        public int VenAVista { get => ven_avista; set => ven_avista = value; }
        public int CliCod { get => cli_cod; set => cli_cod = value; }
        public int TpaCod { get => tpa_cod; set => tpa_cod = value; }
    }
}
