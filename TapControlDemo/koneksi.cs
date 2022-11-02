using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TapControlDemo
{
    class koneksi
    {
        public MySqlConnection GetConn()
        {
            MySqlConnection conn = new MySqlConnection();
            
            conn.ConnectionString = @"SERVER=172.31.6.167;PORT=3306;DATABASE=klsroute;USERID=root;PASSWORD=;";
            //conn.ConnectionString = "SERVER=172.31.6.167;DATABASE=klsroute;USERID=root;PASSWORD="";";
            return conn;

        }

    }
}
