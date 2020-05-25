using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//modelo de objeto Subcatagoria, a mesma possui propriedades e parametros

namespace Modelo 
{
    public class ModeloSubCategoria //aula 11
    {
        //=======================================================================================================================================
        public ModeloSubCategoria()//criar um contrutor sempre que chamado ao instanciar objeto, usar o mesmo nome da classe
        {
            this.CatCod = 0;//inicia as propriedade
            this.ScatCod = 0;//inicia as propriedade
            this.ScatNome = "";//inicia as propriedade
        }

        //=======================================================================================================================================
        public ModeloSubCategoria(int scatcod, int catcod, String snome) //criar um contrutor com parametros
        {
            this.CatCod = catcod;// iniciar as propriedades com os parametros informados, obrigando informar os campos
            this.ScatCod = scatcod;
            this.ScatNome = snome;
        }

        //=======================================================================================================================================
        private int scat_cod;//conforme coluna da tabela do BD
        public int ScatCod
        {
            get { return this.scat_cod; }
            set { this.scat_cod = value; }
        }

        //=======================================================================================================================================
        private int cat_cod;//conforme coluna da tabela do BD
        public int CatCod
        {
            get { return this.cat_cod; }
            set { this.cat_cod = value; }
        }

        //=======================================================================================================================================
        private String scat_nome;//conforme coluna da tabela do BD
        public String ScatNome
        {
            get { return this.scat_nome; }
            set { this.scat_nome = value; }
        }
    }
}
