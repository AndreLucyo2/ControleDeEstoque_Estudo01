using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloItensCompra // https://youtu.be/6xF-EijT5k4?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=833
    {

        public ModeloItensCompra()//criar um contrutor, sempre pe chamado ao instanciar objeto, usar o mesmo nome da classe
        {
            this.ItcCod = 0;
            this.ItcQtde = 0;
            this.ItcValor = 0;
            this.ComCod = 0;
            this.ProCod = 0;
        }

        public ModeloItensCompra(int itc_cod, double itc_qtde, double itc_valor, int com_cod, int pro_cod)
        {
            this.ItcCod = itc_cod;
            this.ItcQtde = itc_qtde;
            this.ItcValor = itc_valor;
            this.ComCod = com_cod;
            this.ProCod = pro_cod;
        }

        private int itc_cod;
        private double itc_qtde;
        private double itc_valor;
        private int com_cod;
        private int pro_cod;

        public int ItcCod { get => itc_cod; set => itc_cod = value; }
        public double ItcQtde { get => itc_qtde; set => itc_qtde = value; }
        public double ItcValor { get => itc_valor; set => itc_valor = value; }
        public int ComCod { get => com_cod; set => com_cod = value; }
        public int ProCod { get => pro_cod; set => pro_cod = value; }
    }
}
