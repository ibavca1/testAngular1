using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

namespace AngularJS_Test.Models
{
    public class mySqlRemote
    {
        string connectionString =
            "Server=MYSQL5002.HostBuddy.com;" +
            "Database=db_9ba681_somee;" +
            "Uid=9ba681_somee;" +
            "Pwd=vtufntkrf1";
        MySqlConnection connection = null;
        public modelConnection mConn = new modelConnection();

        public void mySqlConnect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                mConn.version = connection.ServerVersion;
                mConn.state = true;
                mConn.message = connection.ConnectionString;
            }
            catch(Exception ex)
            {
                mConn.version = "unknow";
                mConn.state = false;
                mConn.message = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public List<string> Tables 
        {
            get 
            {
                List<string> result = new List<string>();
                if (connection!=null)
                {
                    MySqlDataReader rdr = null;
                    MySqlCommand cmd = new MySqlCommand("SHOW TABLES", connection);
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        result.Add(rdr.GetString(0));
                    }
                }
                return result;
            }
        }

    }

    public class modelConnection
    {
        public string version { get; set; }
        public bool state { get; set; }
        public string message { get; set; }
    }
}