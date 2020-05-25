using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Para formatar um CEP basta chamar a função :

//    FormataCep(cep)
//    Onde o valor deve ser uma string com o número do CEP sem formatação
//    A função retorna uma string com o com o CEP formatado( 99999-999)


namespace Ferramentas
{
    class ValidacaoCEPOld
    {
        public static string FormataCep(string cep)
        {
            try
            {
                return Convert.ToUInt64(cep).ToString(@"00000\-000");
            }
            catch
            {
                return "";
            }
        }
    }
}
