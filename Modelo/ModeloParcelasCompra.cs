using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasCompra //https://youtu.be/OMSmaA5RAh8?t=338
    {
        public ModeloParcelasCompra()
        {
           PcoCod =0;
           PcoValor = 0;
           //PcoDatapagto = null;//Vai controlar se pagou - iniciar ""
           PcoDatavecto = DateTime.Now;//data atual
           ComCod = 0;
        }

        public ModeloParcelasCompra(int pco_cod, double pco_valor, DateTime pco_datapagto, DateTime pco_datavecto, int com_cod)
        {
            this.PcoCod = pco_cod;
            this.PcoValor = pco_valor;
            this.PcoDatapagto = pco_datapagto;
            this.PcoDatavecto = pco_datavecto;
            this.ComCod = com_cod;
        }

        private int pco_cod;
        private Double pco_valor;
        private DateTime pco_datapagto;
        private DateTime pco_datavecto;
        private int com_cod;

        public int PcoCod { get => pco_cod; set => pco_cod = value; }
        public double PcoValor { get => pco_valor; set => pco_valor = value; }
        public DateTime PcoDatapagto { get => pco_datapagto; set => pco_datapagto = value; }
        public DateTime PcoDatavecto { get => pco_datavecto; set => pco_datavecto = value; }
        public int ComCod { get => com_cod; set => com_cod = value; }
    }
}
