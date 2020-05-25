using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasVenda //https://youtu.be/OMSmaA5RAh8?t=695
    {
        public ModeloParcelasVenda()
        {
            PveCod = 0;
            PveValor = 0;
            PveDatapagto = DateTime.Now;//Vai controlar se pagou - iniciar ""
            PveDatavecto = DateTime.Now;//data atual
            VenCod = 0;
        }

        public ModeloParcelasVenda(int pve_cod, double pve_valor, DateTime pve_datapagto, DateTime pve_datavecto, int ven_cod)
        {
            this.PveCod = pve_cod;
            this.PveValor = pve_valor;
            this.PveDatapagto = pve_datapagto;
            this.PveDatavecto = pve_datavecto;
            this.VenCod = ven_cod;
        }

        private int pve_cod;
        private Double pve_valor;
        private DateTime pve_datapagto;
        private DateTime pve_datavecto;
        private int ven_cod;

        public int PveCod { get => pve_cod; set => pve_cod = value; }
        public double PveValor { get => pve_valor; set => pve_valor = value; }
        public DateTime PveDatapagto { get => pve_datapagto; set => pve_datapagto = value; }
        public DateTime PveDatavecto { get => pve_datavecto; set => pve_datavecto = value; }
        public int VenCod { get => ven_cod; set => ven_cod = value; }
    }
}
