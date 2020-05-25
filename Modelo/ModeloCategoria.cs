using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//modelo de objeto catagoria, a mesma possui propriedades e parametros

namespace Modelo // representa nossa tabela no banco
{
    //============================================================================================= aula 02
    //esta classe representa a tabela catagoria do banco de dados, referncia cada campo
    public class ModeloCategoria
    {
        public ModeloCategoria()//criar um contrutor, sempre pe chamado ao instanciar objeto, usar o mesmo nome da classe
        {
            this.CatCod = 0;//inicia as propriedade
            this.CatNome = "";//inicia as propriedade
        }

        public ModeloCategoria(int catcod, String nome)//criar um contrutor com parametros
        {
            this.CatCod = catcod;// iniciar as propriedades com os parametros informados, obrigando informar os campos
            this.CatNome = nome;// iniciar as propriedades com os parametros informados, obrigando informar os campos
        }

        private int cat_cod; //conforme coluna da tabela do BD
        public int CatCod // representa o campo da tabela
        {
            get { return this.cat_cod; }
            set { this.cat_cod = value; }
        }

        private string cat_nome;//conforme coluna da tabela do BD
        public string CatNome // representa o campo da tabela
        {
            get { return this.cat_nome; }
            set { this.cat_nome = value; }
        }

        //Pode-se utilizar também a propriedade propfull digitando-a  e dar tab (duas veses) para que que escrever o código na classe modelo.
    }
}
