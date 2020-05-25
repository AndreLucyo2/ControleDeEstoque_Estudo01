using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramentas  //https://youtu.be/mCFVjokF9x8?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=200  + https://youtu.be/ZKqSRaDj6SM?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=163
{
    public class BuscaEndereco
    {
        //campos estaticos, nao precisa instanciar a calsse:
        static public String cep = "";
        static public String cidade = "";
        static public String estado = "";
        static public String endereco = "";
        static public String bairro = "";

        public static Boolean verificaCEP(String CEP) //retorna falso caso nao encontre, utiliza o web service da republica virtual
        {
            bool flag = false;
            try
            {
                DataSet ds = new DataSet();
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);//busca informações neste site
                ds.ReadXml(xml);
                endereco = ds.Tables[0].Rows[0]["logradouro"].ToString();
                bairro = ds.Tables[0].Rows[0]["bairro"].ToString();
                cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
                estado = ds.Tables[0].Rows[0]["uf"].ToString();
                cep = CEP;
                flag = true; //se conseguir armazenar, retorna true
            }
            catch (Exception ex)
            {
                endereco = "";
                bairro = "";
                cidade = "";
                estado = "";
                cep = "";
            }
            return flag;
        }
    }
}
