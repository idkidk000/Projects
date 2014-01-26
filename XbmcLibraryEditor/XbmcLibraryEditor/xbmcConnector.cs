using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace XbmcLibraryEditor
{
    class XbmcConnector
        /*Initially use MySQL provider. In future, use XBMC JSON RPC API*/
    {
        /*Initially hardcode the connection details. In future, pull from XBMC advancedsettings.xml and support multiple databases*/
        private const string MYSQL_ADDRESSS = "127.0.0.1";
        private const int MYSQL_PORT = 3306;
        private const string MYSQL_DATABASE = "myvideos75";
        private const string MYSQL_USERNAME = "xbmc";
        private const string MYSQL_PASSWORD = "xbmc";

        public enum DatabaseType { Videos, Music}
        MySqlConnection objConnection = new MySqlConnection();

        public void Connect()
        {
            MySqlConnectionStringBuilder objConnectionBuilder = new MySqlConnectionStringBuilder
            {
                Server = MYSQL_ADDRESSS,
                Port = MYSQL_PORT,
                Database = MYSQL_DATABASE,
                UserID = MYSQL_USERNAME,
                Password = MYSQL_PASSWORD
            };
            objConnection.ConnectionString = objConnectionBuilder.ConnectionString;
            objConnection.Open();
            MySqlCommand objCommand = new MySqlCommand
            {
                CommandText = "select * from files;",
                Connection = objConnection
            };
            MySqlDataAdapter objDataAdaptor = new MySqlDataAdapter();
            objDataAdaptor.SelectCommand = objCommand;
            MySqlCommandBuilder objCommandBuilder = new MySqlCommandBuilder
            {
                DataAdapter = objDataAdaptor
            };
        }
    }
}
