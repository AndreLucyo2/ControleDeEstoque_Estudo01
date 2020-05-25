using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL //camada de acesso aos dados
{    
    public class DadosDaConexao // armazena as informação de conexão com o banco (Aula 02) 
    {
        //Campos da conexão:
        public static String servidor = "";
        public static String banco = "";
        public static String usuario = "";
        public static String senha = "";


        public static String StringDeConexao //propriedade estatica,ou seja assim que definida nao muda  
        {
            get //vai retornar a string conexão com o banco de dados:
            {
                //retorna para o usuario a estring de conexão: (Aula 02) ref: https://youtu.be/gZmswJ9PXwE?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=524
                //return "Data Source=BLACK-PC\\SQLEXPRESS;Initial Catalog=ControleDeEstoque;User ID=sa;Password=78996312@sdf#";//Retornar a string de conexão

                //montar a string e conexão usando os campos do arquivo config
                return @"Data Source="+servidor+";Initial Catalog="+banco+";User ID="+usuario+";Password="+senha;//Retornar a string de conexão
            }
        }

    }
}
