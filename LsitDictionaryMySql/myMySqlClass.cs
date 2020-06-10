using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsitDictionaryMySql
{
    public class myMySqlClass
    {
        private MySqlConnection connection;
        public List<Persons> listView;


        public myMySqlClass()
        {
            Initialize();
        }

        //initialize values
        private void Initialize()
        {
            string server = "localhost";
            string database = "persons";
            string uid = "root";
            string password = "asdQWE123";
            string port = "3306";
            string charset = "utf8";
            string connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARSET=" + charset + ";";

            connection = new MySqlConnection(connectionString);

        }

        //open connection
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //The program response depends on the error number
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Can not connect to server");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid password or username - please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //insert record
        public void Insert(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //execute command
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }
        }

        //update record
        public void Update(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command
                MySqlCommand cmd = new MySqlCommand();
                //assign the query using commandText
                cmd.CommandText = query;
                //assign the connection using Conection
                cmd.Connection = connection;

                //execute query
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }

        }

        //delete record
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Download data as a List
        public List<Persons> GetData(string query)
        {

            if (this.OpenConnection() == true)
            {
                //create command and constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //execute command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                listView = new List<Persons>();

                //reading data
                while (dataReader.Read())
                {
                    //because id is a int
                    int id = Int16.Parse(dataReader["person_id"].ToString());
                    listView.Add(new Persons(id, dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["location"].ToString()));
                }

                dataReader.Close();
                this.CloseConnection();
            }
            return listView;
        }
    }
}
