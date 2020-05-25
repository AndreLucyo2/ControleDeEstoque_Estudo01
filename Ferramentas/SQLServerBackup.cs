using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramentas
{
    public class SQLServerBackup
    {

        //Aula 44 https://youtu.be/mCFVjokF9x8?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=206
        //Metodo estatico que retorna o nome de todos os bancos de dados exixtentes no servidor SQL Server
        public static ArrayList ObtemBancoDeDadosSQLSever(String ConnString)//passa uma string de conexao
        {
            ArrayList lista = new ArrayList();
            //criou a conexao
            SqlConnection cn = new SqlConnection(ConnString);
            //criou o comando
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = "SELECT [name] FROM sysdatabases";
            //criou o datareader
            SqlDataReader dr;
            try
            {
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(dr["name"]);
                }

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }
        
        //raliza o backup da bonco de dados informado
        public static void BackupDataBase(String ConnString, string nomeDB, string backupFile)
        {
            //string backup="";           

            //criou a conexao
            SqlConnection cn = new SqlConnection(ConnString);

            //criou o comando
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = "BACKUP DATABASE [" + nomeDB + "] TO DISK = '" + backupFile + "'";          

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
            //return backup;

        }

        public static void RestauraDatabase(String ConnString, string nomeDB, string backupFile)
        {
            SqlConnection cn = new SqlConnection(ConnString);
            //criou o comando

            //Encerra todas as conexões:
            SqlConnection.ClearAllPools(); // https://youtu.be/6r_5T9Vvdng?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=216

            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            //string sql = "RESTORE DATABASE [" + nomeDB + "] FROM DISK = '" + backupFile + "'  WITH REPLACE";
            //cm.CommandText = sql;

            //corrigido erro ao restaurar banco: aula 46
            string sql = "ALTER DATABASE [" + nomeDB + "] SET OFFLINE WITH ROLLBACK IMMEDIATE; " +
                "RESTORE DATABASE [" + nomeDB + "] FROM DISK = '" + backupFile + "'  WITH REPLACE;" +
                "ALTER DATABASE [" + nomeDB + "] SET ONLINE WITH ROLLBACK IMMEDIATE";
            cm.CommandText = sql;

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
            //return backup;
        }
    }
}
