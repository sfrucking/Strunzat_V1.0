using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Prototype
{
    class Database
    {
        private MySqlConnection con;

        public Database(string connectionString)
        {
            this.con = new MySqlConnection(connectionString);
        }

        public List<Dictionary<string, string>> Read(string query)
        {
            List<Dictionary<string, string>> righe = new List<Dictionary<string, string>>();
            con.Open();
            MySqlDataReader rd = new MySqlCommand(query, con).ExecuteReader();

            for (; rd.Read();)
            {
                Dictionary<string, string> riga = new Dictionary<string, string>();

                for(int i = 0; i < rd.FieldCount; i++)
                {
                    riga.Add(rd.GetName(i), rd.GetValue(i).ToString());
                }

                righe.Add(riga);
            }

            con.Close();
            return righe;
        }

        public Dictionary<string, string> ReadOne(string query)
        {
            Dictionary<string, string> riga = new Dictionary<string, string>();
            try
            {
                riga = Read(query)[0];
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return riga;
        }

        public bool Update(string query)
        {
            try
            {
                con.Open();
                new MySqlCommand(query).ExecuteNonQuery();  
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"la seguente query ha prodotto un errore: \n {query}");
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
            
            
        }
    }
}
