using System;

namespace Modelo
{
    public class ModeloUnidadeDeMedida //aula 19
    {
        //umed_cod
        //umed_nome

        //=======================================================================================================================================
        public ModeloUnidadeDeMedida()//construtor 01, propriedades
        {
            this.UmedCod = 0;
            this.UmedNome = "";
        }

        //=======================================================================================================================================
        public ModeloUnidadeDeMedida(int cod, String nome)//construtor 02, com parametros
        {
            this.UmedCod = cod;
            this.UmedNome = nome;
        }

        //=======================================================================================================================================
        private int umed_cod;
        public int UmedCod
        {
            get
            {
                return this.umed_cod;
            }
            set
            {
                this.umed_cod = value;
            }
        }

        //=======================================================================================================================================
        private String umed_nome;
        public String UmedNome
        {
            get { return this.umed_nome; }
            set { this.umed_nome = value; }
        }
    }
}
