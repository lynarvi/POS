using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace POS
{
    class DBConnection
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;


        public string DataConnection()
        {
            string conn = "server=localhost;port=3306;user id=root;password=;database=pos_management;convert zero datetime=true;";
            return conn;
          
        }

        public double DailySales()
        {
            bool found = false;
            double total = 0;
            int i = 0;
            string sdate = DateTime.Now.ToString("yyyy-MM-dd");
            connect = new MySqlConnection();
            connect.ConnectionString = DataConnection();

            connect.Open();
            command = new MySqlCommand("SELECT total_sales FROM sold_total WHERE sdate LIKE '" + sdate + "'",connect);
            DataReader = command.ExecuteReader();
            //DataReader.Read();

            //if(DataReader.HasRows)
            //{
                //found = true;
                while(DataReader.Read())
                {
                    i++;
                    total += Double.Parse(DataReader["total_sales"].ToString());
                }

            //}
           // else
            //{
                //found = false;
                //total.ToString("0.00");

            //}
            DataReader.Close();
            connect.Close();
            return total;
        }

        public int ProductLine()
        {
            int productline;
            connect = new MySqlConnection();
            connect.ConnectionString = DataConnection();

            connect.Open();
            command = new MySqlCommand("SELECT COUNT(*) FROM producttbl ", connect);
            productline = int.Parse(command.ExecuteScalar().ToString());
            connect.Close();
            return productline;
        }

        public int StockOnHand()
        {
            int stockonhand;
            connect = new MySqlConnection();
            connect.ConnectionString = DataConnection();

            connect.Open();
            command = new MySqlCommand("SELECT SUM(qty) AS qty FROM producttbl ", connect);
            stockonhand = int.Parse(command.ExecuteScalar().ToString());
            connect.Close();
            return stockonhand;
        }

        public int CriticalItems()
        {
            int criticalitems;
            connect = new MySqlConnection();
            connect.ConnectionString = DataConnection();

            connect.Open();
            command = new MySqlCommand("SELECT COUNT(*) FROM vwcriticalitems ", connect);
            criticalitems = int.Parse(command.ExecuteScalar().ToString());
            connect.Close();
            return criticalitems;
        }

        public double GetVal()
        {
            double vat = 0;
            connect = new MySqlConnection();
            connect.ConnectionString = DataConnection();

            connect.Open();
            command = new MySqlCommand("SELECT * FROM vat_tbl",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                vat = Double.Parse(DataReader["vat"].ToString());
            }

            DataReader.Close();
            connect.Close();
            return vat;
        }

        public string GetPassword(string user)
        {
            string password = "";
            connect = new MySqlConnection();
            connect.ConnectionString = DataConnection();

            connect.Open();
            command = new MySqlCommand("SELECT * FROM users_tbl WHERE username = @username", connect);
            command.Parameters.AddWithValue("@username", user);
            DataReader = command.ExecuteReader();
            DataReader.Read();
            if(DataReader.HasRows)
            {
                password = DataReader["password"].ToString();
            }
            DataReader.Close();
            connect.Close();
            return password;
        }

        public double GetDisc()
        {
            double disc = 0;
            connect = new MySqlConnection();
            connect.ConnectionString = DataConnection();

            connect.Open();
            command = new MySqlCommand("SELECT * FROM discount_tbl", connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                disc = Double.Parse(DataReader["discount"].ToString());
            }

            DataReader.Close();
            connect.Close();
            return disc;
        }

       

    }
}
