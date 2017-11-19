using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Globalization;

namespace WebApiTi
{
    public class BD
    {
        public bool verificaUsuario(String userClass)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "serverti-iasd.database.windows.net";
            builder.UserID = "user-master";
            builder.Password = "Min@s2018";
            builder.InitialCatalog = "face-ti-iasd";

            var conn = new SqlConnection(builder.ConnectionString);

            //Abrindo conexão com o BD
            conn.Open();
           
            //Criando comando SELECT
            var command = conn.CreateCommand();
            command.CommandText = String.Format("SELECT * FROM allowedUsers WHERE userClass='{0}'",userClass);

            var reader = command.ExecuteReader();


            if (reader.Read())
            {
                conn.Close();
                salvarLog(userClass, 1);
                return true;
            }
            else
            {
                conn.Close();
                salvarLog(userClass, 0);
                return false;
            }
        }

        private bool salvarLog(String userClass, int status)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "serverti-iasd.database.windows.net";
            builder.UserID = "user-master";
            builder.Password = "Min@s2018";
            builder.InitialCatalog = "face-ti-iasd";

            var conn = new SqlConnection(builder.ConnectionString);

            //Abrindo conexão com o banco de dados
            conn.Open();

            //Obtendo data atual
            CultureInfo cult = new CultureInfo("pt-BR");
            string data = DateTime.Now.ToString("dd/MM/yyyy_HH:mm", cult);

            var command = conn.CreateCommand();
            command.CommandText = String.Format("INSERT INTO log (data, userClass, status) VALUES('{0}','{1}',{2})",data,userClass,status);

            int i = command.ExecuteNonQuery();

            conn.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
