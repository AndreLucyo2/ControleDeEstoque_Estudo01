/* 
 * ref página http://www.codigoexpresso.com.br
 * Formatar CNPJ, CPF e Retirar a Formatação
 *  
 * public static string FormatCNPJ(string CNPJ)
 *        Formata uma string CNPJ 
 *        Informar uma string sem formatacao com o codigo do CNPJ 
 *        Exemplo '11222333000181' 
 *
 * public static string FormatCPF(string CPF)
 *        Formata uma string CPF 
 *        Informar uma string sem formatacao com o codigo do CPF 
 *        Exemplo '01122233344'
 *        
 * public static string SemFormatacao(string Codigo)
 *        Retira formatacao de uma string CNPJ ou CPF 
 *        Informar uma string formatada com o codigo do CNPJ ou CPF 
 *        Exemplo '99.999.999/9999-99' ou '111.222.333-44'        
 */

using System;

namespace Ferramentas
{
    public static class ValidacaoCnpjCpfOld
    {
        //==============================================================================================================================
        /// <summary>
        /// Formatar uma string CNPJ
        /// </summary>
        /// <param name="CNPJ">string CNPJ sem formatacao</param>
        /// <returns>string CNPJ formatada</returns>
        /// <example>Recebe '99999999999999' Devolve '99.999.999/9999-99'</example>
        public static string MET_FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        //==============================================================================================================================
        /// <summary>
        /// Formatar uma string CPF
        /// </summary>
        /// <param name="CPF">string CPF sem formatacao</param>
        /// <returns>string CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>
        public static string MET_FormatCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        //==============================================================================================================================
        /// <summary>
        /// Retira a Formatacao de uma string CNPJ/CPF
        /// </summary>
        /// <param name="Codigo">string Codigo Formatada</param>
        /// <returns>string sem formatacao</returns>
        /// <example>Recebe '99.999.999/9999-99' Devolve '99999999999999'</example>
        public static string MET_SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }
    }

    //************************************************************************************************************************************

    //Para validar o digito do CNPJ basta chamar a função :
    //    ValidaDigitoCNPJ.ValidaCNPJ(cnpj)
    //    Onde o valor pode ser um inteiro ou uma string com o número do CNPJ completo com o dígito A função retorna um boolean com True se o CNPJ é válido ou False se o CNPJ não é válido

    //Para calcular o dígito do CNPJ basta chamar a função :
    //    ValidaDigitoCNPJ.CalculaDigCNPJ(cnpj)
    //    Onde o valor pode ser um inteiro ou uma string com o número do CNPJ sem o dígito verificador A função retorna uma string com o dígito verificador do CNPJ, caso o valor informado tenha mais de 12 dígitos retorna nulo

    /* 
     * Valida e Calcula digito verificador de um CNPJ.
     * 
     * Visite nossa página http://www.codigoexpresso.com.br
     * 
     * by Antonio Azevedo
     *  
     * public static Boolean ValidaCNPJ(cnpj)
     *        Valida se o digito do CNPJ é valido
     *        Pode-se informar um valor inteiro ou uma string com o numero completo do CNPJ contendo o Digito 
     *        Exemplo '11.222.333/0001-81' 
     *
     * public static string CalculaDigCNPJ(cnpj)
     *        Calcula o digito do CNPJ informado
     *        Pode-se informar um valor inteiro ou uma string com o numero do CNPJ sem o Digito 
     *        Exemplo '11.222.333/0001' 
     * 
     */

    class ValidaDigitoCNPJ
    {
        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">Int64 com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public static Boolean MET_ValidaCNPJ(Int64 cnpj)
        {
            return MET_ValidaCNPJ(cnpj.ToString("D14"));
        }

        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">string com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public static Boolean MET_ValidaCNPJ(string cnpj)
        {
            // Declara variaveis para uso
            string new_cnpj = "";

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (isDigito(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CNPJ para 14 digitos considerando o digito verificador e completando com zeros a esquerda
            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D14");

            // Verifica se o CNPJ informado tem os 14 digitos 
            if (new_cnpj.Length > 14)
            {
                return false;
            }

            // Calcula o digito do CNPJ e compara com o digito informado
            if (MET_CalculaDigCNPJ(new_cnpj.Substring(0, 12)) == new_cnpj.Substring(12, 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">int64 com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        public static string MET_CalculaDigCNPJ(Int64 cnpj)
        {
            return MET_CalculaDigCNPJ(cnpj.ToString("D12"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">string com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        public static string MET_CalculaDigCNPJ(string cnpj)
        {
            // Declara variaveis para uso
            string new_cnpj = "";
            string digito = "";
            int[] calculo = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (isDigito(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CNPJ para 12 digitos completando com zeros a esquerda
            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D12");

            // Caso o tamanho do CNPJ informado for maior que 12 digitos retorna nulo
            if (new_cnpj.Length > 12)
            {
                return null;
            }

            // Calcula o primeiro digito do CNPJ
            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }

            Aux2 = (Aux1 % 11);

            // Carrega o primeiro digito na variavel digito
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }

            // Adiciona o primeiro digito ao final do CNPJ para calculo do segundo digito
            new_cnpj += digito;

            // Calcula o segundo digito do CNPJ
            calculo = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }

            Aux2 = (Aux1 % 11);

            // Carrega o segundo digito na variavel digito
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }

            return digito;
        }

        /// <summary>
        /// Verifica se um digito informado é um numero
        /// </summary>
        /// <param name="digito">string com um caracter para verificar se é um numero</param>
        /// <returns>Boolean True/False</returns>
        public static Boolean isDigito(string digito)
        {
            int n;
            return Int32.TryParse(digito, out n);
        }
    }


    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /* 
     * Valida e Calcula digito verificador de um CPF.
     * 
     * Visite nossa página http://www.codigoexpresso.com.br
     * 
     * by Antonio Azevedo
     *  
     * public static Boolean ValidaCPF(cpf)
     *        Valida se o digito do CPF é valido
     *        Pode-se informar um valor inteiro ou uma string com o numero completo do CPF contendo o Digito 
     *        Exemplo '123.456.789-10' 
     *
     * public static string CalculaDigCPF(cpf)
     *        Calcula o digito do CPF informado
     *        Pode-se informar um valor inteiro ou uma string com o numero do CPF sem o Digito 
     *        Exemplo '123.456.789' 
     * 
     */

    public static class ValidaDigitoCPF
    {
        /// <summary>
        /// Informar um CPF completo para validação do digito verificador
        /// </summary>
        /// <param name="cpf">Int64 com o numero CPF completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CPF Valido</returns>
        public static Boolean ValidaCPF(Int64 cpf)
        {
            return ValidaCPF(cpf.ToString("D11"));
        }

        /// <summary>
        /// Informar um CPF completo para validação do digito verificador
        /// </summary>
        /// <param name="cpf">string com o numero CPF completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CPF Valido</returns>
        public static Boolean ValidaCPF(string cpf)
        {
            // Declara variaveis para uso
            string new_cpf = "";

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigito(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CPF para 11 digitos considerando o digito verificador e completando com zeros a esquerda
            new_cpf = Convert.ToInt64(new_cpf).ToString("D11");

            // Verifica se o cpf informado tem os 11 digitos 
            if (new_cpf.Length > 11)
            {
                return false;
            }

            // Calcula o digito do CPF e compara com o digito informado
            if (CalculaDigCPF(new_cpf.Substring(0, 9)) == new_cpf.Substring(9, 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">int64 com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        public static string CalculaDigCPF(Int64 cpf)
        {
            return CalculaDigCPF(cpf.ToString("D9"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">string com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        public static string CalculaDigCPF(string cpf)
        {
            // Declara variaveis para uso
            string new_cpf = "";
            string digito = "";
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigito(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CPF para 9 digitos completando com zeros a esquerda
            new_cpf = Convert.ToInt64(new_cpf).ToString("D9");

            // Caso o tamanho do CPF informado for maior que 9 digitos retorna nulo
            if (new_cpf.Length > 9)
            {
                return null;
            }

            // Calcula o primeiro digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o primeiro digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            // Adiciona o primeiro digito ao final do CPF para calculo do segundo digito
            new_cpf += digito;

            // Calcula o segundo digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o segundo digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            return digito;
        }

        /// <summary>
        /// Verifica se um digito informado é um numero
        /// </summary>
        /// <param name="digito">string com um caracter para verificar se é um numero</param>
        /// <returns>Boolean True/False</returns>
        public static Boolean isDigito(string digito)
        {
            int n;
            return Int32.TryParse(digito, out n);
        }
    }
}