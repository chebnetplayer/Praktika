using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Queuservice.DataBase

{

    public static class DBProvider
    {
        public static string sql = "insert into sq values(";
        public static string srv = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=1e2d3r4i5t; Database=SQ;";
       public static void Insert(string task, string dsk, string rdns)
       
        {
           
            NpgsqlConnection con = new NpgsqlConnection(srv);
            NpgsqlCommand com = new NpgsqlCommand("select * from sq", con);


            con.Open();

            NpgsqlDataReader rdr = com.ExecuteReader();
            if (rdns.ToLower() != "false" && rdns.ToLower() != "true")
                throw new InvalidOperationException();

            while (rdr.Read())
            {
                if (task.ToLower()==rdr["task"].ToString().ToLower() && dsk.ToLower()==rdr["description"].ToString().ToLower() && rdns.ToLower()==rdr["readiness"].ToString().ToLower())
                    throw new InvalidOperationException();
                
            }

            con.Close();

            sql += "'" + task + "'," + "'" + dsk + "'," + rdns + ")";
            com = new NpgsqlCommand(sql, con);

            con.Open();

            int qqq = com.ExecuteNonQuery();
            Console.WriteLine("SUCCESS!");

            con.Close();


        }
        public static void Select()
        {
            NpgsqlConnection con = new NpgsqlConnection(srv);
            NpgsqlCommand com = new NpgsqlCommand("select * from sq", con);


            con.Open();

            NpgsqlDataReader rdr = com.ExecuteReader();

            while (rdr.Read())
                Console.WriteLine("\t{0}\t{1}\t{2}", rdr["task"].ToString(), rdr["description"].ToString(), rdr["readiness"].ToString());
        }
    }
}
