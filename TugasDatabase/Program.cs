using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace RecGitarrr
{
    class Gitar
    {
        string type;
        string brand;
        string bodytype;
        int maxprice;

        public Gitar(string type, string brand, string bodytype, int maxprice)
        {
            this.type = type;
            this.brand = brand;
            this.bodytype = bodytype;
            this.maxprice = maxprice;
        }
        static string connectionString = "server=localhost; port=3306; uid=richa; pwd=pwd123098; database=dbguitar; charset=utf8mb4; sslMode=none";
        
        static MySQLConnection connection = new MySQLConnection(connectionString);

        static void Main(string[] args)
        {
            Console.WriteLine("Connect to MySql");

            using(connection)
            {
                try{
                    connection.Open();
                    System.Console.WriteLine("Koneksi: "+connection.State.Tostring() + Enviroment.NewLine);
                    
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = System.Data.CommandType.Text;
                    command.CommandText = "Select * from guitar";

                    MySqlDataReader reader = command.ExecuteReader();
                    var data = "[type]\t[brand]\t[bodytype]\t[price]\n";

                    if(reader.Hashrow)
                    {
                        while(reader.Read()){
                            data += reader.GetString(0) + reader.Getstring(1) + reader.GetString(2) + reader.GetInt(3); + Environment.NewLine;
                        }
                        Console.WriteLine(data); 
                    } else{
                        Console.WriteLine("Data Unknown")
                    }

                    reader.Close();
                    connection.Close();
                    System.Console.WriteLine("Koneksi: "+connection.State.Tostring() + Enviroment.NewLine);
                } catch(My.Sql.Data.MySqlClient.MySqlException ex){
                    System.Console.WriteLine("eror "+ ex.Message.Tostring());
                    Console.Readkey();
                } finally{
                    System.Console.WriteLine("Exit...");
                    Console.Readkey();               
                }
            
            }
        }
    }
}
